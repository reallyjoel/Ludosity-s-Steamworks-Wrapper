#ifndef Hmd_h_
#define Hmd_h_

#include "Hmd.h"

#include "Singleton.hpp"

namespace SteamAPIWrap
{
	class CHmd : public CSingleton<CHmd>
	{
	public:
		Enum Init();

		void Shutdown();

		bool GetWindowBounds( s32* X, s32* Y, u32* Width, u32* Height );

		void GetRecommendedRenderTargetSize( u32* Width, u32* Height );

		void GetEyeOutputViewport( Enum Eye, Enum APIType, u32* X, u32* Y, u32* Width, u32* Height );
	
		PDataPointer GetProjectionMatrix( Enum Eye, f32 NearZ, f32 FarZ, Enum ProjType );

		void GetProjectionRaw( Enum Eye, f32* Left, f32* Right, f32* Top, f32* Bottom );

		PDataPointer ComputeDistortion( Enum Eye, f32 U, f32 V );

		PDataPointer GetEyeMatrix( Enum Eye );

		bool GetViewMatrix( f32 SecondsFromNow, PDataPointer MatLeftView, PDataPointer MatRightView, Enum* Result );

		s32 GetD3D9AdapterIndex();

		// ------------------------------------
		// Tracking Methods
		// ------------------------------------

		bool GetWorldFromHeadPose( f32 PredictedSecondsFromNow, PDataPointer Pose, Enum* Result );

		bool GetLastWorldFromHeadPose( PDataPointer* Pose );

		bool WillDriftInYaw();

		void ZeroTracker();

		// ------------------------------------
		// Administrative methods
		// ------------------------------------
		u32 GetDriverId( PString Buffer, u32 BufferLen );

		u32 GetDisplayId( PString Buffer, u32 BufferLen );

	private:
		friend class CSingleton<CHmd>;
		CHmd();
		~CHmd() {}
		DISALLOW_COPY_AND_ASSIGN(CHmd);
		vr::IHmd *hmd;
	};
};

#endif