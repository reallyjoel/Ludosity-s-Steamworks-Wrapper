#ifndef Services_h_interop_
#define Services_h_interop_


ManagedSteam_API_Lite u32 Services_GetInterfaceVersion();

ManagedSteam_API_Lite Enum Services_GetErrorCode();

ManagedSteam_API_Lite bool Services_Startup(u32 interfaceVersion);

ManagedSteam_API_Lite void Services_Shutdown();

ManagedSteam_API_Lite bool Services_RestartAppIfNecessary( u32 ownAppID );

ManagedSteam_API_Lite bool Services_IsSteamRunning();

ManagedSteam_API_Lite Enum Services_GetSteamLoadStatus();

ManagedSteam_API_Lite void Services_HandleCallbacks();

ManagedSteam_API_Lite u32 Services_GetAppID();

ManagedSteam_API bool Services_RunCallbackSizeCheck();

ManagedSteam_API_Lite void Services_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback);

ManagedSteam_API_Lite void Services_RemoveManagedCallbacks();

#endif // Services_h_interop_