using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;

using ManagedSteam.Utility;
using ManagedSteam.Exceptions;
using ManagedSteam.Implementations;

/// <summary>
/// The main namespace containing all classes for the wrapper.
/// </summary>
namespace ManagedSteam
{
    /// <summary>
    /// The main class.
    /// This is the primary interface point between .NET code and the native C++ code.
    /// Use Initialize() to start the API.
    /// </summary>
    public sealed class Steam
    {
        private JobManager serviceJobs;

        private Cloud cloud;
        private Stats stats;
        private User user;
        private Friends friends;
        private MatchMaking matchmaking;
        private MatchmakingServers matchmakingServers;
        private Networking networking;
        private Utils utils;
        private Apps apps;
        private HTTP http;
        private Screenshots screenshots;
        private UGC ugc;
        private SteamController steamcontroller;
        private Hmd hmd;

        private List<Exception> bufferedExceptions;

        private ManagedCallback nativeCallbackHandle;
        private ManagedResultCallback nativeResultCallbackHandle;

        private ManagedCallback NativeCallbacksDelegate;
        private ManagedResultCallback NativeResultCallbacksDelegate;

        private Steam(CultureInfo activeCulture)
        {
            Culture = activeCulture;

            bufferedExceptions = new List<Exception>();

            //keep a handle in this class to delegates so that GC knows not to collect them
            nativeCallbackHandle = NativeCallbacks;
            nativeResultCallbackHandle   = NativeResultCallbacks;
            
            NativeMethods.Services_RegisterManagedCallbacks(nativeCallbackHandle, nativeResultCallbackHandle);
        }

        // Mapping for the native callbacks
        internal Dictionary<CallbackID, NativeCallback> Callbacks { get; private set; }
        internal Dictionary<ResultID, NativeResultCallback> ResultCallbacks { get; private set; }
        internal CultureInfo Culture { get; private set; }

        /// <summary>
        /// The active instance that can communicate with the Steamworks API.
        /// </summary>
        public static Steam Instance { get; private set; }


        /// <summary>
        /// Returns true if communication with the steam API is possible
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                // TODO Check connection and other stuff via the API
                return Instance != null;
            }
        }

        /// <summary>
        /// The application id of the game. Only valid if IsAvailable is true
        /// </summary>
        public SteamTypes.AppID AppID { get; private set; }

        public ICloud Cloud
        {
            get
            {
                Error.NotAvailableInLite();
                return cloud;
            }
        }
        public IStats Stats
        {
            get
            {
                return stats;
            }
        }
        public IUser User
        {
            get
            {
                return user;
            }
        }
        public IFriends Friends
        {
            get
            {
                Error.NotAvailableInLite();
                return friends;
            }
        }

        public IMatchmaking Matchmaking
        {
            get
            {
                Error.NotAvailableInLite();
                return matchmaking;
            }
        }

        public IMatchmakingServers MatchmakingServers
        {
            get
            {
                return matchmakingServers;
            }
        }

        public INetworking Networking
        {
            get
            {
                Error.NotAvailableInLite();
                return networking;
            }

        }

        public IUtils Utils
        {
            get
            {
                Error.NotAvailableInLite();
                return utils;
            }
        }

        public IApps Apps
        {
            get
            {
                Error.NotAvailableInLite();
                return apps;
            }
        }

        public IHTTP HTTP
        {
            get
            {
                Error.NotAvailableInLite();
                return http;
            }
        }

        public IScreenshots Screenshots
        {
            get
            {
                Error.NotAvailableInLite();
                return screenshots;
            }
        }

        public IUGC UGC
        {
            get
            {
                Error.NotAvailableInLite();
                return ugc;
            }
        }

        public ISteamController SteamController
        {
            get
            {
                Error.NotAvailableInLite();
                return steamcontroller;
            }
        }

        public IHmd Hmd
        {
            get
            {
                Error.NotAvailableInLite();
                return hmd;
            }
        }

        /// <summary>
        /// This event is raised if any exceptions are thrown directly or indirectly while in native code
        /// </summary>
        public event ExceptionDelegate ExceptionThrown;

        /// <summary>
        /// Initializes the native dll and the managed wrapper. Use the returned class to
        /// communicate with the steam API. Can only be used once.
        /// </summary>
        /// <exception cref="ManagedSteam.Exceptions.AlreadyLoadedException"></exception>
        /// <exception cref="ManagedSteam.Exceptions.SteamInitializeFailedException"></exception>
        /// <exception cref="ManagedSteam.Exceptions.SteamInterfaceInitializeFailedException"></exception>
        /// <exception cref="InvalidOperationException">One instance of the Steam class already exists.</exception>
        /// <returns>The instance of the Steam class to be used for all communication with the Steamworks API.</returns>
        public static Steam Initialize()
        {
            return Initialize(CultureInfo.InvariantCulture);
        }

        // TODO Enable when/if there is a need for the ability to change culture
        private static Steam Initialize(CultureInfo activeCulture)
        {

            if (activeCulture == null)
            {
                throw new ArgumentNullException("activeCulture", "activeCulture is null.");
            }
            if (Instance != null)
            {
                throw new InvalidOperationException(StringMap.GetString(StringID.OnlyOneInstance, typeof(Steam).Name));
            }
            Instance = new Steam(activeCulture);

            Instance.Startup();
            
            return Instance;
        }

        private void Startup()
        {
            if (NativeHelpers.Services_GetSteamLoadStatus() == LoadStatus.NotLoaded)
            {
                // Only startup the native parts if they are not loaded yet
                if (!NativeMethods.Services_Startup(Constants.VersionInfo.InterfaceID))
                {
                    // Setup failed!
                    Instance = null;
                    ErrorCodes error = NativeHelpers.Services_GetErrorCode();
                    if (error == ErrorCodes.InvalidInterfaceVersion)
                    {
                        Error.ThrowError(ErrorCodes.InvalidInterfaceVersion,
                            NativeMethods.Services_GetInterfaceVersion(), Constants.VersionInfo.InterfaceID);
                    }
                    else
                    {
                        Error.ThrowError(error);
                    }
                }
            }
            
            AppID = new SteamTypes.AppID(NativeMethods.Services_GetAppID());

            serviceJobs = new JobManager();
            serviceJobs.AddJob(new DelegateJob(() => RegisterManagedCallback(), () => RemoveManagedCallback()));
            serviceJobs.AddJob(new DelegateJob(() => cloud = new Cloud(), () => cloud.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => stats = new Stats(), () => stats.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => user = new User(), () => user.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => friends = new Friends(), () => friends.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => matchmaking = new MatchMaking(), () => matchmaking.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => matchmakingServers = new MatchmakingServers(), () => matchmakingServers.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => networking = new Networking(), () => networking.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => utils = new Utils(), () => utils.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => apps = new Apps(), () => apps.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => http = new HTTP(), () => http.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => screenshots = new Screenshots(), () => screenshots.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => ugc = new UGC(), () => ugc.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => steamcontroller = new SteamController(), () => steamcontroller.ReleaseManagedResources()));

            hmd = new Hmd();

            serviceJobs.RunCreateJobs();
        }

        /// <summary>
        /// Call this right before your game shuts down. This performs cleanup of managed and native resources.
        /// </summary>
        /// <remarks>No parts of the API will be usable after this.</remarks>
        public void Shutdown()
        {
            CheckIfUsable();

            NativeMethods.Services_Shutdown();

            ReleaseManagedResources();
        }

        public bool IsSteamRunning()
        {
            CheckIfUsable();

            return NativeMethods.Services_IsSteamRunning();
        }

        public static bool RestartAppIfNecessary(uint ownAppID)
        {
            return NativeMethods.Services_RestartAppIfNecessary(ownAppID);
        }

        public bool RunCallbackSizeCheck()
        {
            return NativeMethods.Services_RunCallbackSizeCheck();
        }

        /// <summary>
        /// This method dispatches all events. It needs to be run at regular intervals (like every frame).
        /// </summary>
        public void Update()
        {
            CheckIfUsable();

            NativeMethods.Services_HandleCallbacks();
            ReportExceptions();
            matchmakingServers.ReportExceptions();

            cloud.InvokeEvents();
            stats.InvokeEvents();
            user.InvokeEvents();
            friends.InvokeEvents();
            matchmaking.InvokeEvents();
            matchmakingServers.InvokeEvents();
            networking.InvokeEvents();
            utils.InvokeEvents();
            apps.InvokeEvents();
            http.InvokeEvents();
            screenshots.InvokeEvents();
            ugc.InvokeEvents();
            steamcontroller.InvokeEvents();
        }

        private void ReportExceptions()
        {
            if (ExceptionThrown != null)
            {
                foreach (var e in bufferedExceptions)
                {
                    ExceptionThrown(e);
                }
            }

            bufferedExceptions.Clear();
        }

        /// <summary>
        /// Shall be called by other classes that have callbacks from native code, and therefore have 
        /// to buffer exceptions.
        /// Will invoke the exception event with the specified exception as parameter.
        /// </summary>
        internal void ReportException(Exception e)
        {
            if (ExceptionThrown != null && e != null)
            {
                ExceptionThrown(e);
            }
        }

        /// <summary>
        /// This will release all the managed resources. The native dll is still loaded and usable.
        /// Just call Initialize to be able to communicate with steam again.
        /// This method is only intended to be used if the API is used in Unity's editor during
        /// development.
        /// </summary>
        public void ReleaseManagedResources()
        {
            CheckIfUsable();

            serviceJobs.RunDestroyJobs();

            Instance = null;
        }

        private void RegisterManagedCallback()
        {
            // TODO Provide a comparer object to avoid boxing
            Callbacks = new Dictionary<CallbackID, NativeCallback>();
            ResultCallbacks = new Dictionary<ResultID, NativeResultCallback>();
            
            bufferedExceptions = new List<Exception>();

            NativeCallbacksDelegate = NativeCallbacks;
            NativeResultCallbacksDelegate = NativeResultCallbacks;
            
            NativeMethods.Services_RegisterManagedCallbacks(NativeCallbacksDelegate, NativeResultCallbacksDelegate);
        }

        private void RemoveManagedCallback()
        {
            NativeMethods.Services_RemoveManagedCallbacks();

            ResultCallbacks = null;
            Callbacks = null;

            nativeCallbackHandle = null;
            nativeResultCallbackHandle = null;
        }

        private static void NativeCallbacks(int id, IntPtr dataPointer, int dataSize)
        {
            try
            {
                if (Instance.Callbacks.ContainsKey((CallbackID)id))
                {
                    Instance.Callbacks[(CallbackID)id](dataPointer, dataSize);
                }
                else
                {
                    throw new ManagedException(ErrorCodes.NoCallbackEvent, id);
                }
            }
            catch (Exception e)
            {
                // Prevent the exception from propagating upwards as this method is called from native code.
                try
                {
                    Instance.bufferedExceptions.Add(e);
                }
                catch (Exception)
                {
                    // If anything goes wrong while saving the exception, just ignore it.
                }
            }
        }

        private static void NativeResultCallbacks(int id, IntPtr dataPointer, int dataSize, bool flag)
        {
            try
            {
                if (Instance.ResultCallbacks.ContainsKey((ResultID)id))
                {
                    Instance.ResultCallbacks[(ResultID)id](dataPointer, dataSize, flag);
                }
                else
                {
                    throw new ManagedException(ErrorCodes.NoResultEvent, id);
                }
            }
            catch (Exception e)
            {
                // Prevent the exception from propagating upwards as this method is called from native code.
                try
                {
                    Instance.bufferedExceptions.Add(e);
                }
                catch (Exception)
                {
                    // If anything goes wrong while saving the exception, just ignore it.
                }
            }
        }

        /// <summary>
        /// This method does some general checks to see if the current instance can communicate with the native dll.
        /// </summary>
        internal void CheckIfUsable()
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException(StringMap.GetString(ErrorCodes.UsageAfterAPIShutdown));
            }
        }


        public delegate void ExceptionDelegate(Exception e);
    }
}
