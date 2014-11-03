#ifndef ServicesGameServer_h_interop_
#define ServicesGameServer_h_interop_

ManagedSteam_API u32 ServicesGameServer_GetInterfaceVersion();

ManagedSteam_API Enum ServicesGameServer_GetErrorCode();

ManagedSteam_API bool ServicesGameServer_Startup(u32 interfaceVersion, u32 ip, u16 steamPort, u16 gamePort, u16 queryPort, Enum serverMode, PConstantString versionString);

ManagedSteam_API void ServicesGameServer_Shutdown();

ManagedSteam_API Enum ServicesGameServer_GetSteamLoadStatus();

ManagedSteam_API void ServicesGameServer_HandleCallbacks();

ManagedSteam_API void ServicesGameServer_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback);

ManagedSteam_API void ServicesGameServer_RemoveManagedCallbacks();

#endif // ServicesGameServer_h_interop_
