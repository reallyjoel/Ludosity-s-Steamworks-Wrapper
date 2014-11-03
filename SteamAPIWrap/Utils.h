#ifndef Utils_h_interop_
#define Utils_h_interop_

ManagedSteam_API u32 Utils_GetSecondsSinceAppActive();

ManagedSteam_API u32 Utils_GetSecondsSinceComputerActive();

ManagedSteam_API Enum Utils_GetConnectedUniverse();

ManagedSteam_API u32 Utils_GetServerRealTime();

ManagedSteam_API PConstantString Utils_GetIPCountry();

ManagedSteam_API bool Utils_GetImageSize(int iImage, uint32 *pnWidth, uint32 *pnHeightr);
		
ManagedSteam_API bool Utils_GetImageRGBA( int iImage, uint8 *pubDest, int nDestBufferSize);

ManagedSteam_API bool Utils_GetCSERIPPort( u32 *unIP, u16 *usPort);

ManagedSteam_API u8 Utils_GetCurrentBatteryPower();

ManagedSteam_API u32 Utils_GetAppID();

ManagedSteam_API void Utils_SetOverlayNotificationPosition( Enum eNotificationPosition );


ManagedSteam_API bool Utils_IsAPICallCompleted( u64 hSteamAPICall, bool *pbFailed );

ManagedSteam_API bool Utils_GetAPICallResult( u64 hSteamAPICall, PDataPointer pCallback, int cubCallback, int iCallbackExpected, bool *pbFailed );


ManagedSteam_API void Utils_RunFrame();

ManagedSteam_API u32 Utils_GetIPCCallCount();

ManagedSteam_API void Utils_SetWarningMessageHook( SteamAPIWarningMessageHook_t pFunction );

ManagedSteam_API bool Utils_IsOverlayEnabled();

ManagedSteam_API bool Utils_OverlayNeedsPresent();

ManagedSteam_API bool Utils_ShowGamepadTextInput( Enum eInputMode, Enum eLineInputMode, PConstantString pchDescription, uint32 unCharMax);

ManagedSteam_API uint32 Utils_GetEnteredGamepadTextLength();

ManagedSteam_API bool Utils_GetEnteredGamepadTextInput( PString pchText, uint32 cchText);

ManagedSteam_API bool Utils_IsSteamRunningInVR();

#endif // Utils_h_interop_