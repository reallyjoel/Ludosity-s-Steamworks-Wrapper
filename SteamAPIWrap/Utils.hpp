#ifndef Utils_h_
#define Utils_h_

#include "Utils.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CUtils : public CSingleton<CUtils>
	{
		SW_CALLBACK(CUtils, IPCountry_t, IPCountry);
		SW_CALLBACK(CUtils, LowBatteryPower_t, LowBatteryPower);
		SW_CALLBACK(CUtils, SteamShutdown_t, SteamShutdown);
		SW_CALLBACK(CUtils, CheckFileSignature_t, CheckFileSignature);
		SW_CALLBACK(CUtils, GamepadTextInputDismissed_t, GamepadTextInputDismissed);
	public:
		void SetSteamInterface(ISteamUtils *utils) { this->utils = utils; }
		void RunCallbackSizeCheck();

		u32 GetSecondsSinceAppActive();

		u32 GetSecondsSinceComputerActive();

		Enum GetConnectedUniverse();

		u32 GetServerRealTime();

		PConstantString GetIPCountry();

		bool GetImageSize(int iImage, uint32 *pnWidth, uint32 *pnHeightr);
		
		bool GetImageRGBA( int iImage, uint8 *pubDest, int nDestBufferSize);

		bool GetCSERIPPort( u32 *unIP, u16 *usPort);

		u8 GetCurrentBatteryPower();

		u32 GetAppID();

		void SetOverlayNotificationPosition( Enum eNotificationPosition );


		bool IsAPICallCompleted( u64 hSteamAPICall, bool *pbFailed );
		
		bool GetAPICallResult( u64 hSteamAPICall, PDataPointer pCallback, int cubCallback, int iCallbackExpected, bool *pbFailed );


		void RunFrame();

		u32 GetIPCCallCount();

		void SetWarningMessageHook( SteamAPIWarningMessageHook_t pFunction );

		bool IsOverlayEnabled();

		bool OverlayNeedsPresent();

		bool ShowGamepadTextInput( Enum eInputMode, Enum eLineInputMode, PConstantString pchDescription, uint32 unCharMax );
		
		uint32 GetEnteredGamepadTextLength();

		bool GetEnteredGamepadTextInput( PString pchText, uint32 cchText );	

		bool IsSteamRunningInVR();

	private:
		friend class CSingleton<CUtils>;
		CUtils();
		~CUtils() {}
		DISALLOW_COPY_AND_ASSIGN(CUtils);

		ISteamUtils *utils;
	};
}

#endif