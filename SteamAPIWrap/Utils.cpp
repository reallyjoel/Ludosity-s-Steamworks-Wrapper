#include "Precompiled.hpp"
#include "Utils.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template<> CUtils *CSingleton<CUtils>::instance = nullptr;

	CUtils::CUtils()
		: nativeIPCountryCallback(this, &CUtils::OnIPCountry)
		, nativeLowBatteryPowerCallback(this, &CUtils::OnLowBatteryPower)
		//, nativeSteamAPICallCompletedCallback(this, &CUtils::OnSteamAPICallCompleted)
		, nativeSteamShutdownCallback(this, &CUtils::OnSteamShutdown)
		, nativeCheckFileSignatureCallback(this, &CUtils::OnCheckFileSignature)
		, nativeGamepadTextInputDismissedCallback(this, &CUtils::OnGamepadTextInputDismissed)
		, utils(nullptr)
	{

	}

	void CUtils::RunCallbackSizeCheck()
	{
		IPCountry_t* ipCountry = new IPCountry_t();
		OnIPCountry(ipCountry);
		delete ipCountry;

		LowBatteryPower_t* lowBatteryPower = new LowBatteryPower_t();
		OnLowBatteryPower(lowBatteryPower);
		delete lowBatteryPower;

		//SteamShutdown_t* steamShutdown = new SteamShutdown_t();
		//OnSteamShutdown(steamShutdown);
		//delete steamShutdown;

		CheckFileSignature_t* checkFileSignature = new CheckFileSignature_t();
		OnCheckFileSignature(checkFileSignature);
		delete checkFileSignature;

		GamepadTextInputDismissed_t* gamepadTextInputDismissed = new GamepadTextInputDismissed_t();
		OnGamepadTextInputDismissed(gamepadTextInputDismissed);
		delete gamepadTextInputDismissed;
	}

	u32 CUtils::GetSecondsSinceAppActive()
	{
		return utils->GetSecondsSinceAppActive();
	}

	u32 CUtils::GetSecondsSinceComputerActive()
	{
		return utils->GetSecondsSinceComputerActive();
	}

	Enum CUtils::GetConnectedUniverse()
	{
		return utils->GetConnectedUniverse();
	}

	u32 CUtils::GetServerRealTime()
	{
		return utils->GetServerRealTime();
	}

	PConstantString CUtils::GetIPCountry()
	{
		return utils->GetIPCountry();
	}
	
	bool CUtils::GetImageSize(int iImage, uint32 *pnWidth, uint32 *pnHeightr)
	{
		return utils->GetImageSize(iImage, pnWidth, pnHeightr);
	}
		
	bool CUtils::GetImageRGBA( int iImage, uint8 *pubDest, int nDestBufferSize)
	{
		return utils->GetImageRGBA(iImage, pubDest, nDestBufferSize);
	}

	bool CUtils::GetCSERIPPort( u32 *unIP, u16 *usPort)
	{
		return utils->GetCSERIPPort(unIP, usPort);
	}

	u8 CUtils::GetCurrentBatteryPower()
	{
		return utils->GetCurrentBatteryPower();
	}

	u32 CUtils::GetAppID()
	{
		return utils->GetAppID();
	}

	void CUtils::SetOverlayNotificationPosition( Enum eNotificationPosition )
	{
		return utils->SetOverlayNotificationPosition(static_cast<ENotificationPosition>(eNotificationPosition));
	}


	bool CUtils::IsAPICallCompleted( u64 hSteamAPICall, bool *pbFailed )
	{
		return utils->IsAPICallCompleted( hSteamAPICall, pbFailed );
	}

	bool CUtils::GetAPICallResult( u64 hSteamAPICall, PDataPointer pCallback, int cubCallback, int iCallbackExpected, bool *pbFailed )
	{
		return utils->GetAPICallResult( hSteamAPICall, pCallback, cubCallback, iCallbackExpected, pbFailed );
	}

	void CUtils::RunFrame()
	{
		return utils->RunFrame();
	}

	u32 CUtils::GetIPCCallCount()
	{
		return utils->GetIPCCallCount();
	}

	void CUtils::SetWarningMessageHook( SteamAPIWarningMessageHook_t pFunction )
	{
		return utils->SetWarningMessageHook( pFunction );
	}

	bool CUtils::IsOverlayEnabled()
	{
		return utils->IsOverlayEnabled();
	}

	bool CUtils::OverlayNeedsPresent()
	{
		return utils->BOverlayNeedsPresent();
	}

	bool CUtils::ShowGamepadTextInput( Enum eInputMode, Enum eLineInputMode, PConstantString pchDescription, uint32 unCharMax)
	{
		return utils->ShowGamepadTextInput(static_cast<EGamepadTextInputMode>(eInputMode), static_cast<EGamepadTextInputLineMode>(eLineInputMode), pchDescription, unCharMax);
	}

	uint32 CUtils::GetEnteredGamepadTextLength()
	{
		return utils->GetEnteredGamepadTextLength();
	}

	bool CUtils::GetEnteredGamepadTextInput( PString pchText, uint32 cchText)
	{
		return utils->GetEnteredGamepadTextInput(pchText, cchText);
	}

	bool CUtils::IsSteamRunningInVR()
	{
		return utils->IsSteamRunningInVR();
	}
}

ManagedSteam_API u32 Utils_GetSecondsSinceAppActive()
{
	return CUtils::Instance().GetSecondsSinceAppActive();
}

ManagedSteam_API u32 Utils_GetSecondsSinceComputerActive()
{
	return CUtils::Instance().GetSecondsSinceComputerActive();
}

ManagedSteam_API Enum Utils_GetConnectedUniverse()
{
	return CUtils::Instance().GetConnectedUniverse();
}

ManagedSteam_API u32 Utils_GetServerRealTime()
{
	return CUtils::Instance().GetServerRealTime();
}

ManagedSteam_API PConstantString Utils_GetIPCountry()
{
	return CUtils::Instance().GetIPCountry();
}

ManagedSteam_API bool Utils_GetImageSize(int iImage, uint32 *pnWidth, uint32 *pnHeightr)
{
	return CUtils::Instance().GetImageSize(iImage, pnWidth, pnHeightr);
}
		
ManagedSteam_API bool Utils_GetImageRGBA( int iImage, uint8 *pubDest, int nDestBufferSize)
{
	return CUtils::Instance().GetImageRGBA(iImage, pubDest, nDestBufferSize);
}

ManagedSteam_API bool Utils_GetCSERIPPort( u32 *unIP, u16 *usPort )
{
	return CUtils::Instance().GetCSERIPPort( unIP, usPort );
}

ManagedSteam_API u8 Utils_GetCurrentBatteryPower()
{
	return CUtils::Instance().GetCurrentBatteryPower();
}

ManagedSteam_API u32 Utils_GetAppID()
{
	return CUtils::Instance().GetAppID();
}

ManagedSteam_API void Utils_SetOverlayNotificationPosition( Enum eNotificationPosition )
{
	return CUtils::Instance().SetOverlayNotificationPosition( eNotificationPosition );
}

ManagedSteam_API bool Utils_IsAPICallCompleted( u64 hSteamAPICall, bool *pbFailed )
{
	return CUtils::Instance().IsAPICallCompleted(hSteamAPICall, pbFailed);
}

ManagedSteam_API bool Utils_GetAPICallResult( u64 hSteamCall, PDataPointer pCallback, int cubCallback, int iCallbackExpected, bool *pbFailed )
{
	return CUtils::Instance().GetAPICallResult( hSteamCall, pCallback, cubCallback, iCallbackExpected, pbFailed );
}

ManagedSteam_API void Utils_RunFrame()
{
	return CUtils::Instance().RunFrame();
}

ManagedSteam_API u32 Utils_GetIPCCallCount()
{
	return CUtils::Instance().GetIPCCallCount();
}

ManagedSteam_API void Utils_SetWarningMessageHook( SteamAPIWarningMessageHook_t pFunction )
{
	return CUtils::Instance().SetWarningMessageHook( pFunction );
}

ManagedSteam_API bool Utils_IsOverlayEnabled()
{
	return CUtils::Instance().IsOverlayEnabled();
}

ManagedSteam_API bool Utils_OverlayNeedsPresent()
{
	return CUtils::Instance().OverlayNeedsPresent();
}

ManagedSteam_API bool Utils_ShowGamepadTextInput( Enum eInputMode, Enum eLineInputMode, PConstantString pchDescription, uint32 unCharMax)
{
	return CUtils::Instance().ShowGamepadTextInput(eInputMode, eLineInputMode, pchDescription, unCharMax);
}

ManagedSteam_API uint32 Utils_GetEnteredGamepadTextLength()
{
	return CUtils::Instance().GetEnteredGamepadTextLength();
}

ManagedSteam_API bool Utils_GetEnteredGamepadTextInput(PString pchText, uint32 cchText)
{
	return CUtils::Instance().GetEnteredGamepadTextInput(pchText, cchText);
}

ManagedSteam_API bool Utils_IsSteamRunningInVR()
{
	return CUtils::Instance().IsSteamRunningInVR();
}