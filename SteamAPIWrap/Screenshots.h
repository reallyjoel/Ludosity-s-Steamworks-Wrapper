#ifndef Screenshots_h_interop_
#define Screenshots_h_interop_

ManagedSteam_API u32 Screenshots_WriteScreenshot(PDataPointer pubRGB, u32 cubRGB, s32 nWidth, s32 nHeight);

ManagedSteam_API u32 Screenshots_AddScreenshotToLibrary( PConstantString pchFilename, PConstantString pchThumbnailFilename, s32 nWidth, s32 nHeight );

ManagedSteam_API void Screenshots_TriggerScreenshot();

ManagedSteam_API void Screenshots_HookScreenshots( bool bHook );

ManagedSteam_API bool Screenshots_SetLocation( u32 hScreenshot, PConstantString pchLocation );

ManagedSteam_API bool Screenshots_TagUser( u32 hScreenshot, u64 steamID );

ManagedSteam_API bool Screenshots_TagPublishedFile( u32 hScreenshot, u64 unPublishedFileID );

#endif/*Screenshots_h_interop_*/