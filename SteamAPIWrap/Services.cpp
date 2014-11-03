#include "Precompiled.hpp"
#include "Services.hpp"
#include "VersionInfo.hpp"
#include "ErrorCodes.hpp"


#include "Cloud.hpp"
#include "Stats.hpp"
#include "User.hpp"
#include "Friends.hpp"
#include "MatchMaking.hpp"
#include "MatchMakingServers.hpp"
#include "Networking.hpp"
#include "Utils.hpp"
#include "Apps.hpp"
#include "HTTP.hpp"
#include "Screenshots.hpp"
#include "UGC.hpp"
#include "SteamController.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CServices *CSingleton<CServices>::instance = nullptr;

	CServices::CServices()
		: CSteamAPIContext()
		, appID(0)
		, errorCode(EErrorCodes::Ok)
		, steamLoadStatus(ELoadStatus::NotLoaded)
		, managedCallback(nullptr)
		, managedResultCallback(nullptr)
	{

	}

	bool CServices::Startup(u32 interfaceVersion)
	{
		if (interfaceVersion != CVersionInfo::GetInterfaceID())
		{
			// The interface versions do not match
			SetErrorCode(EErrorCodes::InvalidInterfaceVersion);
			return false;
		}

		if (steamLoadStatus != ELoadStatus::NotLoaded)
		{
			// Steam have already been loaded once. This is not supported
			SetErrorCode(EErrorCodes::AlreadyLoaded);
			return false;
		}

		// Initialize Steam
		if (!SteamAPI_InitSafe())
		{
			SetErrorCode(EErrorCodes::SteamInitializeFailed);
			return false;
		}

		// Initialize the Steam interfaces
		if (!Init())
		{
			SetErrorCode(EErrorCodes::SteamInterfaceInitializeFailed);
			return false;
		}

		appID = SteamUtils()->GetAppID();

		// Setup all interfaces
		CCloud::Instance().SetSteamInterface(SteamRemoteStorage());
		CStats::Instance().SetSteamInterface(SteamUserStats());
		CUser::Instance().SetSteamInterface(SteamUser());
		CFriends::Instance().SetSteamInterface(SteamFriends());
		CMatchMaking::Instance().SetSteamInterface(SteamMatchmaking());
		CMatchmakingServers::Instance().SetSteamInterface(SteamMatchmakingServers());
		CNetworking::Instance().SetSteamInterface(SteamNetworking());
		CUtils::Instance().SetSteamInterface(SteamUtils());
		CApps::Instance().SetSteamInterface(SteamApps());
		CHTTP::Instance().SetSteamInterface(SteamHTTP());
		CScreenshots::Instance().SetSteamInterface(SteamScreenshots());
		CUGC::Instance().SetSteamInterface(SteamUGC());
		CSteamController::Instance().SetSteamInterface(SteamController());

		steamLoadStatus = ELoadStatus::Loaded;
		SetErrorCode(EErrorCodes::Ok);
		return true;
	}

	void CServices::Shutdown()
	{
		CNetworking::Destroy();
		CMatchmakingServers::Destroy();
		CMatchMaking::Destroy();
		CFriends::Destroy();
		CUser::Destroy();
		CStats::Destroy();
		CCloud::Destroy();
		CApps::Destroy();
		CUtils::Destroy();
		CHTTP::Destroy();
		CScreenshots::Destroy();
		CUGC::Destroy();
		CSteamController::Destroy();

		steamLoadStatus = ELoadStatus::Unloaded;
		SteamAPI_Shutdown();

		SetErrorCode(EErrorCodes::Ok);
	}

	bool CServices::IsSteamRunning()
	{
		return SteamAPI_IsSteamRunning();
	}

	bool CServices::RunCallbackSizeCheck()
	{
		CNetworking::Instance().RunCallbackSizeCheck();
		//CMatchmakingServers::Instance().RunCallbackSizeCheck();  //No callbacks
		CMatchMaking::Instance().RunCallbackSizeCheck();
		CFriends::Instance().RunCallbackSizeCheck();
		CUser::Instance().RunCallbackSizeCheck();
		CStats::Instance().RunCallbackSizeCheck();
		CCloud::Instance().RunCallbackSizeCheck();
		CApps::Instance().RunCallbackSizeCheck();
		CUtils::Instance().RunCallbackSizeCheck();
		CHTTP::Instance().RunCallbackSizeCheck();
		CScreenshots::Instance().RunCallbackSizeCheck();
		CUGC::Instance().RunCallbackSizeCheck();
		//CSteamController::Instance().RunCallbackSizeCheck();	//No callbacks

		return true; //Wow. very useful. such good code.
	}
}

ManagedSteam_API_Lite bool Services_IsSteamRunning()
{
	return CServices::Instance().IsSteamRunning();
}

ManagedSteam_API_Lite bool Services_RestartAppIfNecessary( u32 ownAppID )
{
	return SteamAPI_RestartAppIfNecessary( ownAppID );
}

ManagedSteam_API_Lite u32 Services_GetInterfaceVersion()
{
	return CVersionInfo::GetInterfaceID();
}

ManagedSteam_API_Lite Enum Services_GetErrorCode()
{
	return CServices::Instance().GetErrorCode();
}

ManagedSteam_API_Lite bool Services_Startup(u32 interfaceVersion)
{
	return CServices::Instance().Startup(interfaceVersion);
}

ManagedSteam_API_Lite void Services_Shutdown()
{
	CServices::Instance().Shutdown();
}

ManagedSteam_API_Lite Enum Services_GetSteamLoadStatus()
{
	return CServices::Instance().GetSteamLoadStatus();
}

ManagedSteam_API_Lite void Services_HandleCallbacks()
{
	SteamAPI_RunCallbacks();
}

ManagedSteam_API_Lite u32 Services_GetAppID()
{
	return CServices::Instance().GetAppID();
}

ManagedSteam_API bool Services_RunCallbackSizeCheck()
{
	return CServices::Instance().RunCallbackSizeCheck();
}

ManagedSteam_API_Lite void Services_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback)
{
	CServices::Instance().RegisterManagedCallbacks(callback, resultCallback);
}

ManagedSteam_API_Lite void Services_RemoveManagedCallbacks()
{
	CServices::Instance().RemoveManagedCallbacks();
}
