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
    public abstract class MatchmakingRulesResponse : IDisposable
    {
        private List<CachedResponses> rulesResponded;
        private int rulesFailedToRespond;
        private int rulesRefreshComplete;

        /// <summary>
        /// Creates a managed and native object that cooperate to enable matchmaking callbacks from 
        /// MatchmakingServers.
        /// </summary>
        protected MatchmakingRulesResponse()
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
            ObjectId = NativeMethods.MatchmakingRulesResponse_CreateObject();
            rulesResponded = new List<CachedResponses>();
            rulesFailedToRespond = 0;
            rulesRefreshComplete = 0;
            MatchmakingServers.RulesResponse.Add(ObjectId, this);
            Disposed = false;
        }

        ~MatchmakingRulesResponse()
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
            NativeMethods.MatchmakingRulesResponse_RegisterCallbacks(RulesRespondedCallback,
                 RulesFailedToRespondCallback, RulesRefreshCompleteCallback);
        }

        /// <summary>
        /// Callback that is called directly from native code
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void RulesRespondedCallback(uint instanceId, IntPtr key, IntPtr value)
        {
            try
            {
                var target = MatchmakingServers.RulesResponse[instanceId];
                target.rulesResponded.Add(new CachedResponses(NativeHelpers.ToStringUtf8(key), NativeHelpers.ToStringUtf8(value)));
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

        private static void RulesFailedToRespondCallback(uint instanceId)
        {
            try
            {
                var target = MatchmakingServers.RulesResponse[instanceId];
                target.rulesFailedToRespond++;
            }
            catch (Exception e)
            {
                // See RulesRespondedCallback for an explanation
                try
                {
                    MatchmakingServers.SaveException(e);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void RulesRefreshCompleteCallback(uint instanceId)
        {
            try
            {
                var target = MatchmakingServers.RulesResponse[instanceId];
                target.rulesRefreshComplete++;
            }
            catch (Exception e)
            {
                // See RulesRespondedCallback for an explanation
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
            foreach (var item in rulesResponded)
            {
                RulesResponded(item.Key, item.Value);
            }
            for (int i = 0; i < rulesFailedToRespond; i++)
            {
                RulesFailedToRespond();
            }
            for (int i = 0; i < rulesRefreshComplete; i++)
            {
                RulesRefreshComplete();
            }

            rulesResponded.Clear();
            rulesFailedToRespond = 0;
            rulesRefreshComplete = 0;
        }

        /// <summary>
        /// Called from outside when the managed part of the library is shutting down
        /// </summary>
        internal void LibraryShuttingDown()
        {
            NativeMethods.MatchmakingRulesResponse_DestroyObject(ObjectId);
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

                    rulesResponded = null;


                    // Make sure that we can actually access the needed objects
                    if (Steam.Instance != null && Steam.Instance.MatchmakingServers != null)
                    {
                        MatchmakingServers.RulesResponse.Remove(ObjectId);
                    }
                }

                // Cleanup native stuff

                LibraryShuttingDown();
            }
            Disposed = true;
        }


        /// <summary>
        /// Got data on a rule on the server -- you'll get one of these per rule defined on
        /// the server you are querying
        /// </summary>
        protected abstract void RulesResponded(string rule, string value);

        /// <summary>
        /// The server failed to respond to the request for rule details
        /// </summary>
        protected abstract void RulesFailedToRespond();

        /// <summary>
        /// The server has finished responding to the rule details request 
        /// (ie, you won't get anymore RulesResponded callbacks)
        /// </summary>
        protected abstract void RulesRefreshComplete();


        private struct CachedResponses
        {
            public string Key;
            public string Value;

            public CachedResponses(string key, string value)
            {
                this.Key = key;
                this.Value = value;
            }
        }
    }
}
