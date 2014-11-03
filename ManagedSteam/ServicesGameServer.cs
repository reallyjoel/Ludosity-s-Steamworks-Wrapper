using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

using ManagedSteam.Utility;
using ManagedSteam.Exceptions;
using ManagedSteam.Implementations;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    /// <summary>
    /// The main class for game servers
    /// This is the primary interface point between .NET code and the native C++ code.
    /// Use Initialize() to start the API.
    /// </summary>
    public sealed class ServicesGameServer
    {
        private JobManager serviceJobs;
        private GameServer gameServer;
        private GameServerStats gameServerStats;

        private List<Exception> bufferedExceptions;

        private ServicesGameServer(CultureInfo activeCulture)
        {
            Culture = activeCulture;
        }

        // Mapping for the native callbacks
        internal Dictionary<CallbackID, NativeCallback> Callbacks { get; private set; }
        internal Dictionary<ResultID, NativeResultCallback> ResultCallbacks { get; private set; }
        internal CultureInfo Culture { get; private set; }

        /// <summary>
        /// The active instance that can communicate with the Steamworks API.
        /// </summary>
        public static ServicesGameServer Instance { get; private set; }


        /// <summary>
        /// Returns true if communication with the steam API is possible
        /// </summary>
        public bool IsAvailable
        {
            get
            {
                return Instance != null;
            }
        }

        public IGameServer GameServer
        {
            get
            {
                return gameServer;
            }
        }

        public IGameServerStats GameServerStats
        {
            get
            {
                return gameServerStats;
            }
        }


        /// <summary>
        /// This event is raised if any exceptions are thrown directly or indirectly from native code.
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
        public static ServicesGameServer Initialize(uint ip, ushort steamPort, ushort gamePort, ushort queryPort, ServerMode serverMode, string versionString)
        {
            return Initialize(CultureInfo.InvariantCulture, ip, steamPort, gamePort, queryPort, serverMode, versionString);
        }

        // TODO Enable when/if there is a need for the ability to change culture
        private static ServicesGameServer Initialize(CultureInfo activeCulture, uint ip, ushort steamPort, ushort gamePort, ushort queryPort, ServerMode serverMode, string versionString)
        {
            if (activeCulture == null)
            {
                throw new ArgumentNullException("activeCulture", "activeCulture is null.");
            }

            if (Instance != null)
            {
                throw new InvalidOperationException(StringMap.GetString(StringID.OnlyOneInstance, typeof(ServicesGameServer).Name));
            }

            Instance = new ServicesGameServer(activeCulture);
            Instance.Startup(ip, steamPort, gamePort, queryPort, serverMode, versionString);

            return Instance;
        }

        private void Startup(uint ip, ushort steamPort, ushort gamePort, ushort queryPort, ServerMode serverMode, string versionString)
        {
            if (NativeHelpers.ServicesGameServer_GetSteamLoadStatus() == LoadStatus.NotLoaded)
            {
                // Only startup the native parts if they are not loaded yet
                if (!NativeMethods.ServicesGameServer_Startup(Constants.VersionInfo.InterfaceID, ip, steamPort, gamePort, queryPort, (int)serverMode, versionString))
                {
                    // Setup failed!
                    Instance = null;
                    ErrorCodes error = NativeHelpers.ServicesGameServer_GetErrorCode();
                    if (error == ErrorCodes.InvalidInterfaceVersion)
                    {
                        Error.ThrowError(ErrorCodes.InvalidInterfaceVersion,
                            NativeMethods.ServicesGameServer_GetInterfaceVersion(), Constants.VersionInfo.InterfaceID);
                    }
                    else
                    {
                        Error.ThrowError(error);
                    }
                }
            }

            serviceJobs = new JobManager();
            serviceJobs.AddJob(new DelegateJob(() => RegisterManagedCallback(), () => RemoveManagedCallback()));
            serviceJobs.AddJob(new DelegateJob(() => gameServer = new GameServer(), () => gameServer.ReleaseManagedResources()));
            serviceJobs.AddJob(new DelegateJob(() => gameServerStats = new GameServerStats(), () => gameServerStats.ReleaseManagedResources()));

            serviceJobs.RunCreateJobs();
        }

        /// <summary>
        /// Call this right before your game shuts down. This performs cleanup of managed and native resources.
        /// </summary>
        /// <remarks>No parts of the API will be usable after this.</remarks>
        public void Shutdown()
        {
            CheckIfUsable();

            ReleaseManagedResources();

            NativeMethods.ServicesGameServer_Shutdown();
        }

        /// <summary>
        /// This method dispatches all events. It needs to be run at regular intervals (like every frame).
        /// </summary>
        public void Update()
        {
            CheckIfUsable();

            NativeMethods.ServicesGameServer_HandleCallbacks();
            ReportExceptions();

            gameServer.InvokeEvents();
            gameServerStats.InvokeEvents();

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
            Callbacks = new Dictionary<CallbackID, NativeCallback>(16);
            ResultCallbacks = new Dictionary<ResultID, NativeResultCallback>(16);

            bufferedExceptions = new List<Exception>();

            NativeMethods.ServicesGameServer_RegisterManagedCallbacks(NativeCallbacks, NativeResultCallbacks);
        }

        private void RemoveManagedCallback()
        {
            NativeMethods.ServicesGameServer_RemoveManagedCallbacks();

            ResultCallbacks = null;
            Callbacks = null;
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
