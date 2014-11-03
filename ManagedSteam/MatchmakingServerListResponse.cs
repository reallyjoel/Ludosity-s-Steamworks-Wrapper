using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;
using ManagedSteam.Implementations;
using ManagedSteam.Utility;

namespace ManagedSteam
{
    /// <summary>
    /// Managed version of the \a ISteamMatchmakingServerListResponse interface.
    /// </summary>
    public abstract class MatchmakingServerListResponse : IDisposable
    {
        private List<CachedResponses> serverResponded;
        private List<CachedResponses> serverFailedToRespond;
        private List<CachedResponses> refreshComplete;

        /// <summary>
        /// Creates a managed and native object that cooperate to enable matchmaking callbacks from 
        /// MatchmakingServers.
        /// </summary>
        protected MatchmakingServerListResponse()
        {
            if (Steam.Instance == null)
            {
                throw new InvalidOperationException(StringMap.GetString(ErrorCodes.SteamInstanceIsNull));
            }
            if (Steam.Instance.MatchmakingServers == null)
            {
                throw new InvalidOperationException(StringMap.GetString(ErrorCodes.MatchmakingServersIsNull));
            }

            // Allocates the native object
            ObjectId = NativeMethods.MatchmakingServerListResponse_CreateObject();
            serverResponded = new List<CachedResponses>();
            serverFailedToRespond = new List<CachedResponses>();
            refreshComplete = new List<CachedResponses>();
            MatchmakingServers.ServerListResponse.Add(ObjectId, this);
            Disposed = false;
        }

        ~MatchmakingServerListResponse()
        {
            Dispose(false);
        }

        /// <summary>
        /// The id of this object. This is actually the address of the native object
        /// </summary>
        internal uint ObjectId { get; private set; }

        /// <summary>
        /// When true, the object have been disposed and will no longer receive callbacks.
        /// </summary>
        public bool Disposed { get; private set; }

        private static MatchmakingServers MatchmakingServers
        {
            get { return (MatchmakingServers)Steam.Instance.MatchmakingServers; }
        }

        internal static void Initialize()
        {
            NativeMethods.MatchmakingServerListResponse_RegisterCallbacks(ServerRespondedCallback,
                ServerFailedToRespondCallback, RefreshCompleteCallback);
        }

        /// <summary>
        /// Callback that is called directly from native code
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="request"></param>
        /// <param name="server"></param>
        private static void ServerRespondedCallback(uint instanceId, uint request, int server)
        {
            try
            {
                var target = MatchmakingServers.ServerListResponse[instanceId];
                target.serverResponded.Add(new CachedResponses(request, server));
            }
            catch (Exception e)
            {
                // If we get a null reference exception it means that either the Steam.Instance,
                // Steam.Instance.MatchmakingServers,
                // Steam.Instance.MatchmakingServers.PingResponse,
                // target or target.serverResponded is null. 
                // 
                // Either way, this should not happen during correct usage. But since we can't 
                // throw an exception as this method is called from native code, we try to save it.

                try
                {
                    MatchmakingServers.SaveException(e);
                }
                catch (Exception)
                {
                    // If anything goes wrong while saving the exception, just ignore it.
                }
            }
        }

        private static void ServerFailedToRespondCallback(uint instanceId, uint request, int server)
        {
            try
            {
                var target = MatchmakingServers.ServerListResponse[instanceId];
                target.serverFailedToRespond.Add(new CachedResponses(request, server));
            }
            catch (Exception e)
            {
                // See ServerRespondedCallback for an explanation
                try
                {
                    MatchmakingServers.SaveException(e);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void RefreshCompleteCallback(uint instanceId, uint request, int response)
        {
            try
            {
                var target = MatchmakingServers.ServerListResponse[instanceId];
                target.refreshComplete.Add(new CachedResponses(request, response));
            }
            catch (Exception e)
            {
                // See ServerRespondedCallback for an explanation
                try
                {
                    MatchmakingServers.SaveException(e);
                }
                catch (Exception)
                {
                }
            }
        }

        internal void InvokeEvents()
        {
            foreach (var item in serverResponded)
            {
                ServerResponded(new ServerListRequestHandle(item.Request), item.Data);
            }
            foreach (var item in serverFailedToRespond)
            {
                ServerFailedToRespond(new ServerListRequestHandle(item.Request), item.Data);
            }
            foreach (var item in refreshComplete)
            {
                RefreshComplete(new ServerListRequestHandle(item.Request), (MatchMakingServerResponse)item.Data);
            }

            serverResponded.Clear();
            serverFailedToRespond.Clear();
            refreshComplete.Clear();
        }

        /// <summary>
        /// Called from outside when the managed part of the library is shutting down
        /// </summary>
        internal void LibraryShuttingDown()
        {
            NativeMethods.MatchmakingServerListResponse_DestroyObject(ObjectId);
            ObjectId = 0;

            // Have not technically been disposed, but we have done everything that we need to 
            // do during a Dispose, so might as well skip it if it is called later
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    // Cleanup managed references. 
                    // Shall only be done when the object is disposed as this object will unregister
                    // itself from the MatchmakingServers object. And since Dispose is never called
                    // by library code, as the library handles the unregistering in a different way,
                    // All is well.

                    serverResponded = null;
                    serverFailedToRespond = null;
                    refreshComplete = null;

                    // Make sure that we can actually access the needed objects
                    if (Steam.Instance != null && Steam.Instance.MatchmakingServers != null)
                    {
                        MatchmakingServers.ServerListResponse.Remove(ObjectId);
                    }
                }

                // Cleanup native stuff

                LibraryShuttingDown();
            }
            Disposed = true;
        }


        /// <summary>
        /// Server has responded ok with updated data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="server"></param>
        protected abstract void ServerResponded(ServerListRequestHandle request, int server);

        /// <summary>
        /// Server has failed to respond
        /// </summary>
        /// <param name="request"></param>
        /// <param name="server"></param>
        protected abstract void ServerFailedToRespond(ServerListRequestHandle request, int server);

        /// <summary>
        /// A list refresh you had initiated is now 100% completed
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        protected abstract void RefreshComplete(ServerListRequestHandle request, MatchMakingServerResponse response);


        private struct CachedResponses
        {
            public uint Request;
            public int Data;

            public CachedResponses(uint request, int data)
            {
                this.Request = request;
                this.Data = data;
            }
        }
    }
}
