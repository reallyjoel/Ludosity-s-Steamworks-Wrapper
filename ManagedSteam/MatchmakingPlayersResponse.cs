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
    public abstract class MatchmakingPlayersResponse : IDisposable
    {
        private List<CachedResponses> addPlayerToList;
        private int playersFailedToRespond;
        private int playersRefreshComplete;

        /// <summary>
        /// Creates a managed and native object that cooperate to enable matchmaking callbacks from 
        /// MatchmakingServers.
        /// </summary>
        protected MatchmakingPlayersResponse()
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
            ObjectId = NativeMethods.MatchmakingPlayersResponse_CreateObject();
            addPlayerToList = new List<CachedResponses>();
            playersFailedToRespond = 0;
            playersRefreshComplete = 0;
            MatchmakingServers.PlayersResponse.Add(ObjectId, this);
            Disposed = false;
        }

        ~MatchmakingPlayersResponse()
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
            NativeMethods.MatchmakingPlayersResponse_RegisterCallbacks(AddPlayerToListCallback,
                 PlayersFailedToRespondCallback, PlayersRefreshCompleteCallback);

        }

        /// <summary>
        /// Callback that is called directly from native code
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="timePlayed"></param>
        private static void AddPlayerToListCallback(uint instanceId, IntPtr name, int score, float timePlayed)
        {
            try
            {
                var target = MatchmakingServers.PlayersResponse[instanceId];
                target.addPlayerToList.Add(new CachedResponses(NativeHelpers.ToStringUtf8(name), score, timePlayed));
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

        private static void PlayersFailedToRespondCallback(uint instanceId)
        {
            try
            {
                var target = MatchmakingServers.PlayersResponse[instanceId];
                target.playersFailedToRespond++;
            }
            catch (Exception e)
            {
                // See AddPlayerToListCallback for an explanation
                try
                {
                    MatchmakingServers.SaveException(e);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void PlayersRefreshCompleteCallback(uint instanceId)
        {
            try
            {
                var target = MatchmakingServers.PlayersResponse[instanceId];
                target.playersRefreshComplete++;
            }
            catch (Exception e)
            {
                // See AddPlayerToListCallback for an explanation
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
            foreach (var item in addPlayerToList)
            {
                AddPlayerToList(item.Name, item.Score, item.TimePlayed);
            }
            for (int i = 0; i < playersFailedToRespond; i++)
            {
                PlayersFailedToRespond();
            }
            for (int i = 0; i < playersRefreshComplete; i++)
            {
                PlayersRefreshComplete();
            }

            addPlayerToList.Clear();
            playersFailedToRespond = 0;
            playersRefreshComplete = 0;
        }

        /// <summary>
        /// Called from outside when the managed part of the library is shutting down
        /// </summary>
        internal void LibraryShuttingDown()
        {
            NativeMethods.MatchmakingPlayersResponse_DestroyObject(ObjectId);
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

                    addPlayerToList = null;

                    // Make sure that we can actually access the needed objects
                    if (Steam.Instance != null && Steam.Instance.MatchmakingServers != null)
                    {
                        MatchmakingServers.PlayersResponse.Remove(ObjectId);
                    }
                }

                // Cleanup native stuff

                LibraryShuttingDown();
            }
            Disposed = true;
        }


        /// <summary>
        /// Got data on a new player on the server -- you'll get this callback once per player
        /// on the server which you have requested player data on.
        /// </summary>
        protected abstract void AddPlayerToList(string name, int score, float timePlayed);

        /// <summary>
        /// The server failed to respond to the request for player details
        /// </summary>
        protected abstract void PlayersFailedToRespond();

        /// <summary>
        /// The server has finished responding to the player details request 
        /// (ie, you won't get anymore AddPlayerToList callbacks)
        /// </summary>
        protected abstract void PlayersRefreshComplete();


        private struct CachedResponses
        {
            public string Name;
            public int Score;
            public float TimePlayed;

            public CachedResponses(string name, int score, float timePlayed)
            {
                this.Name = name;
                this.Score = score;
                this.TimePlayed = timePlayed;
            }
        }
    }
}
