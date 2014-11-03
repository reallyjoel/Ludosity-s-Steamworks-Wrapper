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
    public abstract class MatchmakingPingResponse : IDisposable
    {
        private List<GameServerItem> serverResponded;
        private int serverFailedToRespond;

        /// <summary>
        /// Creates a managed and native object that cooperate to enable matchmaking callbacks from 
        /// MatchmakingServers.
        /// </summary>
        protected MatchmakingPingResponse()
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
            ObjectId = NativeMethods.MatchmakingPingResponse_CreateObject();
            serverResponded = new List<GameServerItem>();
            serverFailedToRespond = 0;
            MatchmakingServers.PingResponse.Add(ObjectId, this);
            Disposed = false;
        }

        ~MatchmakingPingResponse()
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
            NativeMethods.MatchmakingPingResponse_RegisterCallbacks(ServerRespondedCallback,
                ServerFailedToRespondCallback);
        }

        /// <summary>
        /// Callback that is called directly from native code
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="server"></param>
        /// <param name="serverSize"></param>
        private static void ServerRespondedCallback(uint instanceId, IntPtr server, int serverSize)
        {
            try
            {
                var target = MatchmakingServers.PingResponse[instanceId];
                target.serverResponded.Add(GameServerItem.Create(server, serverSize));
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

        private static void ServerFailedToRespondCallback(uint instanceId)
        {
            try
            {
                var target = MatchmakingServers.PingResponse[instanceId];
                target.serverFailedToRespond++;
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
                ServerResponded(item);
            }
            for (int i = 0; i < serverFailedToRespond; ++i)
            {
                ServerFailedToRespond();
            }

            serverResponded.Clear();
            serverFailedToRespond = 0;
        }

        /// <summary>
        /// Called from outside when the managed part of the library is shutting down
        /// </summary>
        internal void LibraryShuttingDown()
        {
            NativeMethods.MatchmakingPingResponse_DestroyObject(ObjectId);
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
                    // by library code, and the library handles the unregistering in a different way,
                    // All is well.

                    serverResponded = null;

                    // Make sure that we can actually access the needed objects
                    if (Steam.Instance != null && Steam.Instance.MatchmakingServers != null)
                    {
                        MatchmakingServers.PingResponse.Remove(ObjectId);
                    }
                }

                // Cleanup native stuff

                LibraryShuttingDown();
            }
            Disposed = true;
        }


        /// <summary>
        /// Server has responded successfully and has updated data
        /// </summary>
        protected abstract void ServerResponded(GameServerItem server);

        /// <summary>
        /// Server failed to respond to the ping request
        /// </summary>
        protected abstract void ServerFailedToRespond();
    }
}