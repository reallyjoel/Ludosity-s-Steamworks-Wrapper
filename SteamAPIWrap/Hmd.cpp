#include "Precompiled.hpp"
#include <steamvr.h>
#include "Hmd.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	#pragma region HmdMatrix44
	struct HmdMatrix44_t
	{
		float m[16];
	};
	
	vr::HmdMatrix44_t* WrapperToValve_HmdMatrix44(const HmdMatrix44_t* source)
	{
		
		vr::HmdMatrix44_t* output = new vr::HmdMatrix44_t();
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				output->m[i][j] = source->m[(i * 4) + j];
			}
		}

		return output;
	}

	HmdMatrix44_t* ValveToWrapper_HmdMatrix44(const vr::HmdMatrix44_t* source)
	{
		HmdMatrix44_t* output = new HmdMatrix44_t();

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				output->m[(i * 4) + j] = source->m[i][j];
			}
		}

		return output;
	}
	#pragma endregion

	template <> CHmd * CSingleton<CHmd>::instance = nullptr;

	CHmd::CHmd()
		: hmd(nullptr)
	{
	}
	
	Enum CHmd::Init()
	{
		vr::HmdError hmdError;
		hmd = vr::VR_Init(&hmdError);

		return hmdError;
	}

	void CHmd::Shutdown()
	{
		vr::VR_Shutdown();
	}

	bool CHmd::GetWindowBounds( s32* X, s32* Y, u32* Width, u32* Height )
	{
		return hmd->GetWindowBounds( X, Y, Width, Height );
	}

	void CHmd::GetRecommendedRenderTargetSize( u32* Width, u32* Height )
	{
		hmd->GetRecommendedRenderTargetSize( Width, Height );
	}

	void CHmd::GetEyeOutputViewport( Enum Eye, Enum APIType, u32* X, u32* Y, u32* Width, u32* Height )
	{
		hmd->GetEyeOutputViewport(static_cast<vr::Hmd_Eye>(Eye), static_cast<vr::GraphicsAPIConvention>(APIType), X, Y, Width, Height);
	}

	PDataPointer CHmd::GetProjectionMatrix( Enum Eye, f32 NearZ, f32 FarZ, Enum ProjType )
	{
		static vr::HmdMatrix44_t result = hmd->GetProjectionMatrix(static_cast<vr::Hmd_Eye>(Eye), NearZ, FarZ, static_cast<vr::GraphicsAPIConvention>(ProjType));
		return &result;
	}

	void CHmd::GetProjectionRaw( Enum Eye, f32* Left, f32* Right, f32* Top, f32* Bottom )
	{
		hmd->GetProjectionRaw( static_cast<vr::Hmd_Eye>(Eye), Left, Right, Top, Bottom );
	}

	PDataPointer CHmd::ComputeDistortion( Enum Eye, f32 U, f32 V )
	{
		static vr::DistortionCoordinates_t result = hmd->ComputeDistortion(static_cast<vr::Hmd_Eye>(Eye), U, V);
		return &result;
	}

	PDataPointer CHmd::GetEyeMatrix( Enum Eye )
	{
		static vr::HmdMatrix44_t result = hmd->GetEyeMatrix( static_cast<vr::Hmd_Eye>(Eye));
		return &result;
	}

	bool CHmd::GetViewMatrix( f32 SecondsFromNow, PDataPointer MatLeftView, PDataPointer MatRightView, Enum* Result )
	{
		return hmd->GetViewMatrix( SecondsFromNow, reinterpret_cast<vr::HmdMatrix44_t *>( MatLeftView ), reinterpret_cast<vr::HmdMatrix44_t *>( MatRightView ), reinterpret_cast<vr::HmdTrackingResult*>(Result));
	}

	s32 CHmd::GetD3D9AdapterIndex()
	{
		return hmd->GetD3D9AdapterIndex();
	}

	// ------------------------------------
	// Tracking Methods
	// ------------------------------------

	bool CHmd::GetWorldFromHeadPose( f32 PredictedSecondsFromNow, PDataPointer Pose, Enum* Result )
	{
		return hmd->GetWorldFromHeadPose( PredictedSecondsFromNow, reinterpret_cast<vr::HmdMatrix34_t *>(Pose), reinterpret_cast<vr::HmdTrackingResult *>(Result) );
	}

	bool CHmd::GetLastWorldFromHeadPose( PDataPointer* Pose )
	{
		return hmd->GetLastWorldFromHeadPose( reinterpret_cast<vr::HmdMatrix34_t *>(Pose) );
	}

	bool CHmd::WillDriftInYaw()
	{
		return hmd->WillDriftInYaw();
	}

	void CHmd::ZeroTracker()
	{
		hmd->ZeroTracker();
	}

	// ------------------------------------
	// Administrative methods
	// ------------------------------------
	u32 CHmd::GetDriverId( PString Buffer, u32 BufferLen )
	{
		return hmd->GetDriverId( Buffer, BufferLen );
	}

	u32 CHmd::GetDisplayId( PString Buffer, u32 BufferLen )
	{
		return hmd->GetDisplayId( Buffer, BufferLen );
	}
};

ManagedSteam_API Enum VR_Hmd_Init()
{
	return CHmd::Instance().Init();
}

ManagedSteam_API void VR_Hmd_Shutdown()
{
	CHmd::Instance().Shutdown();
}

ManagedSteam_API bool VR_Hmd_GetWindowBounds( s32* X, s32* Y, u32* Width, u32* Height )
{
	return CHmd::Instance().GetWindowBounds(X, Y, Width, Height);
}

ManagedSteam_API void VR_Hmd_GetRecommendedRenderTargetSize( u32* Width, u32* Height )
{
	CHmd::Instance().GetRecommendedRenderTargetSize( Width, Height );
}

ManagedSteam_API void VR_Hmd_GetEyeOutputViewport( Enum Eye, Enum APIType, u32* X, u32* Y, u32* Width, u32* Height )
{
	CHmd::Instance().GetEyeOutputViewport( Eye, APIType, X, Y, Width, Height );
}
	
ManagedSteam_API PDataPointer VR_Hmd_GetProjectionMatrix( Enum Eye, f32 NearZ, f32 FarZ, Enum ProjType )
{
	return CHmd::Instance().GetProjectionMatrix( Eye, NearZ, FarZ, ProjType );
}

ManagedSteam_API void VR_Hmd_GetProjectionRaw( Enum Eye, f32* Left, f32* Right, f32* Top, f32* Bottom )
{
	CHmd::Instance().GetProjectionRaw( Eye, Left, Right, Top, Bottom );
}

ManagedSteam_API PDataPointer VR_Hmd_ComputeDistortion( Enum Eye, f32 U, f32 V )
{
	return CHmd::Instance().ComputeDistortion( Eye, U, V );
}

ManagedSteam_API PDataPointer VR_Hmd_GetEyeMatrix( Enum Eye )
{
	return CHmd::Instance().GetEyeMatrix( Eye );
}

ManagedSteam_API bool VR_Hmd_GetViewMatrix( f32 SecondsFromNow, PDataPointer MatLeftView, PDataPointer MatRightView, Enum* Result )
{
	return CHmd::Instance().GetViewMatrix( SecondsFromNow, MatLeftView, MatRightView, Result );
}

ManagedSteam_API s32 VR_Hmd_GetD3D9AdapterIndex()
{
	return CHmd::Instance().GetD3D9AdapterIndex();
}


// ------------------------------------
// Tracking Methods
// ------------------------------------
ManagedSteam_API bool VR_Hmd_GetWorldFromHeadPose( f32 PredictedSecondsFromNow, PDataPointer Pose, Enum* Result )
{
	return CHmd::Instance().GetWorldFromHeadPose( PredictedSecondsFromNow, Pose, Result );
}

ManagedSteam_API bool VR_Hmd_GetLastWorldFromHeadPose( PDataPointer* Pose )
{
	return CHmd::Instance().GetLastWorldFromHeadPose( Pose );
}

ManagedSteam_API bool VR_Hmd_WillDriftInYaw()
{
	return CHmd::Instance().WillDriftInYaw();
}

ManagedSteam_API void VR_Hmd_ZeroTracker()
{
	CHmd::Instance().ZeroTracker();
}


// ------------------------------------
// Administrative methods
// ------------------------------------
ManagedSteam_API u32 VR_Hmd_GetDriverId( PString Buffer, u32 BufferLen )
{
	return CHmd::Instance().GetDriverId( Buffer, BufferLen );
}

ManagedSteam_API u32 VR_Hmd_GetDisplayId( PString Buffer, u32 BufferLen )
{
	return CHmd::Instance().GetDisplayId( Buffer, BufferLen );
}
