#ifndef SteamController_h_interop_
#define SteamController_h_interop_

ManagedSteam_API bool SteamController_Init( PConstantString absolutPathToControllerConfigVDF );
ManagedSteam_API bool SteamController_Shutdown();

ManagedSteam_API void SteamController_RunFrame();

ManagedSteam_API bool SteamController_GetControllerState( u32 controllerIndex, PDataPointer state );
ManagedSteam_API void SteamController_TriggerHapticPulse( u32 controllerIndex, Enum targetPad, u16 durationMicroSec );
ManagedSteam_API void SteamController_SetOverrideMode( PConstantString mode );

#endif