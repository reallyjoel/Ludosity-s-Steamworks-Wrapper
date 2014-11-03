#ifndef Hmd_h_interop
#define Hmd_h_interop

ManagedSteam_API Enum VR_Hmd_Init();

ManagedSteam_API void VR_Hmd_Shutdown();

ManagedSteam_API bool VR_Hmd_GetWindowBounds( s32* X, s32* Y, u32* Width, u32* Height );

ManagedSteam_API void VR_Hmd_GetRecommendedRenderTargetSize( u32* Width, u32* Height );

ManagedSteam_API void VR_Hmd_GetEyeOutputViewport( Enum Eye, Enum APIType, u32* X, u32* Y, u32* Width, u32* Height );
	
ManagedSteam_API PDataPointer VR_Hmd_GetProjectionMatrix( Enum Eye, f32 NearZ, f32 FarZ, Enum ProjType );

ManagedSteam_API void VR_Hmd_GetProjectionRaw( Enum Eye, f32* Left, f32* Right, f32* Top, f32* Bottom );

ManagedSteam_API PDataPointer VR_Hmd_ComputeDistortion( Enum Eye, f32 U, f32 V );

ManagedSteam_API PDataPointer VR_Hmd_GetEyeMatrix( Enum Eye );

ManagedSteam_API bool VR_Hmd_GetViewMatrix( f32 SecondsFromNow, PDataPointer MatLeftView, PDataPointer MatRightView, Enum* Result );

ManagedSteam_API s32 VR_Hmd_GetD3D9AdapterIndex();


// ------------------------------------
// Tracking Methods
// ------------------------------------
ManagedSteam_API bool VR_Hmd_GetWorldFromHeadPose( f32 PredictedSecondsFromNow, PDataPointer Pose, Enum* Result );

ManagedSteam_API bool VR_Hmd_GetLastWorldFromHeadPose( PDataPointer* Pose );

ManagedSteam_API bool VR_Hmd_WillDriftInYaw();

ManagedSteam_API void VR_Hmd_ZeroTracker();


// ------------------------------------
// Administrative methods
// ------------------------------------
ManagedSteam_API u32 VR_Hmd_GetDriverId( PString Buffer, u32 BufferLen );

ManagedSteam_API u32 VR_Hmd_GetDisplayId( PString Buffer, u32 BufferLen );

#endif