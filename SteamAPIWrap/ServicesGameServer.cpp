#include "Precompiled.hpp"
#include "ServicesGameServer.hpp"
#include "VersionInfo.hpp"
#include "ErrorCodes.hpp"

#include "GameServer.hpp"
#include "GameServerStats.hpp"
#include "Networking.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CServicesGameServer *CSingleton<CServicesGameServer>::instance = nullptr;
	
	CServicesGameServer::CServicesGameServer()
		: CSteamGameServerAPIContext()
		, errorCode(EErrorCodes::Ok)
		, steamLoadStatus(ELoadStatus::NotLoaded)
		, managedCallback(nullptr)
		, managedResultCallback(nullptr)
	{

	}

	bool CServicesGameServer::Startup(u32 interfaceVersion, u32 ip, u16 steamPort, u16 gamePort, u16 queryPort, Enum serverMode, PConstantString versionString)
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

		//Initialize Steam
		if (!SteamGameServer_InitSafe(ip, steamPort, gamePort, queryPort, static_cast<EServerMode>(serverMode), versionString))
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


		// Setup all interfaces
		CGameServer::Instance().SetSteamInterface(SteamGameServer());
		CGameServerStats::Instance().SetSteamInterface(SteamGameServerStats());
		CNetworking::Instance().SetSteamInterface(SteamGameServerNetworking());


		steamLoadStatus = ELoadStatus::Loaded;
		SetErrorCode(EErrorCodes::Ok);
		return true;
	}

	void CServicesGameServer::Shutdown()
	{
		CGameServer::Destroy();
		CGameServerStats::Destroy();
		CNetworking::Destroy();

		steamLoadStatus = ELoadStatus::Unloaded;
		SteamAPI_Shutdown();

		SetErrorCode(EErrorCodes::Ok);
	}
}

ManagedSteam_API u32 ServicesGameServer_GetInterfaceVersion()
{
	return CVersionInfo::GetInterfaceID();
}

ManagedSteam_API Enum ServicesGameServer_GetErrorCode()
{
	return CServicesGameServer::Instance().GetErrorCode();
}

ManagedSteam_API bool ServicesGameServer_Startup(u32 interfaceVersion, u32 ip, u16 steamPort, u16 gamePort, u16 queryPort, Enum serverMode, PConstantString versionString)
{
	return CServicesGameServer::Instance().Startup(interfaceVersion, ip , steamPort, gamePort, queryPort, serverMode, versionString);
}

ManagedSteam_API void ServicesGameServer_Shutdown()
{
	CServicesGameServer::Instance().Shutdown();
}

ManagedSteam_API Enum ServicesGameServer_GetSteamLoadStatus()
{
	return CServicesGameServer::Instance().GetSteamLoadStatus();
}

ManagedSteam_API void ServicesGameServer_HandleCallbacks()
{
	SteamGameServer_RunCallbacks();
}

ManagedSteam_API void ServicesGameServer_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback)
{
	CServicesGameServer::Instance().RegisterManagedCallbacks(callback, resultCallback);
}

ManagedSteam_API void ServicesGameServer_RemoveManagedCallbacks()
{
	CServicesGameServer::Instance().RemoveManagedCallbacks();
}