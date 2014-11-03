#include "Precompiled.hpp"
#include "Apps.hpp"

#include "MemoryHelpers.h"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CApps * CSingleton<CApps>::instance = nullptr;

	CApps::CApps()
		: nativeDlcInstalledCallback(this, &CApps::OnDlcInstalled)
		, nativeRegisterActivationCodeResponseCallback(this, &CApps::OnRegisterActivationCodeResponse)
		, nativeAppProofOfPurchaseKeyResponseCallback(this, &CApps::OnAppProofOfPurchaseKeyResponse)
		, nativeNewLaunchQueryParametersCallback(this, &CApps::OnNewLaunchQueryParameters)
		, apps(nullptr)
	{
	}

	void CApps::SetSteamInterface(ISteamApps *apps)
	{
		this->apps = apps;
	}

	void CApps::RunCallbackSizeCheck()
	{
        DlcInstalled_t* dlcInstalled = new DlcInstalled_t();
		OnDlcInstalled(dlcInstalled);
		delete dlcInstalled;

        RegisterActivationCodeResponse_t* registerActivationCodeResponse = new RegisterActivationCodeResponse_t();
		OnRegisterActivationCodeResponse(registerActivationCodeResponse);
        delete registerActivationCodeResponse;

        AppProofOfPurchaseKeyResponse_t* appProofOfPurchaseKeyResponse = new AppProofOfPurchaseKeyResponse_t();
		OnAppProofOfPurchaseKeyResponse(appProofOfPurchaseKeyResponse);
        delete appProofOfPurchaseKeyResponse;

        NewLaunchQueryParameters_t* newLaunchQueryParameters = new NewLaunchQueryParameters_t();
		OnNewLaunchQueryParameters(newLaunchQueryParameters);
        delete newLaunchQueryParameters;
	}

	bool CApps::IsSubscribed()
	{
		return apps->BIsSubscribed();
	}

	bool CApps::IsLowViolence()
	{
		return apps->BIsLowViolence();
	}

	bool CApps::IsCybercafe()
	{
		return apps->BIsCybercafe();
	}

	bool CApps::IsVACBanned()
	{
		return apps->BIsVACBanned();
	}
	
	PConstantString CApps::GetCurrentGameLanguage()
	{
		return apps->GetCurrentGameLanguage();
	}

	PConstantString CApps::GetAvailableGameLanguages()
	{
		return apps->GetAvailableGameLanguages();
	}

	
	bool CApps::IsSubscribedApp( u32 appID )
	{
		return apps->BIsSubscribedApp( appID );
	}

	bool CApps::IsDlcInstalled( u32 appID )
	{
		return apps->BIsDlcInstalled( appID );
	}

	u32 CApps::GetEarliestPurchaseUnixTime( u32 appID )
	{
		return apps->GetEarliestPurchaseUnixTime( appID );
	}

	bool CApps::IsSubscribedFromFreeWeekend()
	{
		return apps->BIsSubscribedFromFreeWeekend();
	}

	int CApps::GetDLCCount()
	{
		return apps->GetDLCCount();
	}
	
	bool CApps::GetDLCDataByIndex( int iDLC, u32 *pAppID, bool *pbAvailable, PString pchName, int cchNameBufferSize )
	{
		return apps->BGetDLCDataByIndex(iDLC, pAppID, pbAvailable, pchName, cchNameBufferSize);
	}

	void CApps::InstallDLC( u32 appID )
	{
		apps->InstallDLC( appID );
	}

	void CApps::UninstallDLC( u32 appID )
	{
		apps->UninstallDLC( appID );
	}

	void CApps::RequestAppProofOfPurchaseKey( u32 appID )
	{
		apps->RequestAppProofOfPurchaseKey( appID );
	}

	bool CApps::GetCurrentBetaName( PString pchName, int cchNameBufferSize )
	{
		return apps->GetCurrentBetaName( pchName, cchNameBufferSize );
	}

	bool CApps::MarkContentCorrupt( bool bMissingFilesOnly )
	{
		return apps->MarkContentCorrupt( bMissingFilesOnly );
	}

	u32 CApps::GetInstalledDepots( u32 appID, u32 *pvecDepots, u32 cMaxDepots )
	{
		return apps->GetInstalledDepots( appID, pvecDepots, cMaxDepots );
	}

	SteamID CApps::GetAppOwner()
	{
		return apps->GetAppOwner().ConvertToUint64();
	}

	PConstantString CApps::GetLaunchQueryParam( PConstantString pchKey )
	{
		return apps->GetLaunchQueryParam( pchKey );
	}
};

ManagedSteam_API bool Apps_IsSubscribed()
{
	return CApps::Instance().IsSubscribed();
}

ManagedSteam_API bool Apps_IsLowViolence()
{
	return CApps::Instance().IsLowViolence();
}

ManagedSteam_API bool Apps_IsCybercafe()
{
	return CApps::Instance().IsCybercafe();
}

ManagedSteam_API bool Apps_IsVACBanned()
{
	return CApps::Instance().IsVACBanned();
}

ManagedSteam_API PConstantString Apps_GetCurrentGameLanguage()
{
	return CApps::Instance().GetCurrentGameLanguage();
}

ManagedSteam_API PConstantString Apps_GetAvailableGameLanguages()
{
	return CApps::Instance().GetAvailableGameLanguages();
}

ManagedSteam_API bool Apps_IsSubscribedApp( u32 appID )
{
	return CApps::Instance().IsSubscribedApp( appID );
}

ManagedSteam_API bool Apps_IsDlcInstalled( u32 appID )
{
	return CApps::Instance().IsDlcInstalled( appID );
}

ManagedSteam_API u32 Apps_GetEarliestPurchaseUnixTime( u32 appID )
{
	return CApps::Instance().GetEarliestPurchaseUnixTime( appID );
}

ManagedSteam_API bool Apps_IsSubscribedFromFreeWeekend()
{
	return CApps::Instance().IsSubscribedFromFreeWeekend();
}

ManagedSteam_API int Apps_GetDLCCount()
{
	return CApps::Instance().GetDLCCount();
}

ManagedSteam_API bool Apps_GetDLCDataByIndex( int iDLC, u32 *pAppID, bool *pbAvailable, PString pchName, int cchNameBufferSize )
{
	return CApps::Instance().GetDLCDataByIndex( iDLC, pAppID, pbAvailable, pchName, cchNameBufferSize );
}

ManagedSteam_API void Apps_InstallDLC( u32 appID )
{
	CApps::Instance().InstallDLC( appID );
}

ManagedSteam_API void Apps_UninstallDLC( u32 appID )
{
	CApps::Instance().UninstallDLC( appID );
}

ManagedSteam_API void Apps_RequestAppProofOfPurchaseKey( u32 appID )
{
	CApps::Instance().RequestAppProofOfPurchaseKey( appID );
}

ManagedSteam_API bool Apps_GetCurrentBetaName( PString pchName, int cchNameBufferSize )
{
	return CApps::Instance().GetCurrentBetaName( pchName, cchNameBufferSize );
}

ManagedSteam_API bool Apps_MarkContentCorrupt( bool bMissingFilesOnly )
{
	return CApps::Instance().MarkContentCorrupt( bMissingFilesOnly );
}

ManagedSteam_API u32 Apps_GetInstalledDepots( u32 appID, u32 *pvecDepots, u32 cMaxDepots )
{
	return CApps::Instance().GetInstalledDepots( appID, pvecDepots, cMaxDepots );
}

ManagedSteam_API SteamID Apps_GetAppOwner()
{
	return CApps::Instance().GetAppOwner();
}

PConstantString Apps_GetLaunchQueryParam( PConstantString pchKey )
{
	return CApps::Instance().GetLaunchQueryParam( pchKey );
}