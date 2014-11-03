#include "Precompiled.hpp"
#include "GameServer.hpp"

#include "OverlayDialog.hpp"
#include "OverlayDialogToUser.hpp"

#include "MemoryHelpers.h"


using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CGameServer* CSingleton<CGameServer>::instance = nullptr;

	CGameServer::CGameServer() 
		: nativeSteamServersConnectedCallback(this, &CGameServer::OnSteamServersConnected)
		, nativeSteamServerConnectFailureCallback(this, &CGameServer::OnSteamServerConnectFailure)
		, nativeSteamServersDisconnectedCallback(this, &CGameServer::OnSteamServersDisconnected)
		, nativeValidateAuthTicketResponseCallback(this, &CGameServer::OnValidateAuthTicketResponse)
		, nativeGSClientApproveCallback(this, &CGameServer::OnGSClientApprove)
		, nativeGSClientDenyCallback(this, &CGameServer::OnGSClientDeny)
		, nativeGSClientKickCallback(this, &CGameServer::OnGSClientKick)
		, nativeGSClientAchievementStatusCallback(this, &CGameServer::OnGSClientAchievementStatus)
		, nativeGSPolicyResponseCallback(this, &CGameServer::OnGSPolicyResponse)
		, nativeGSGameplayStatsCallback(this, &CGameServer::OnGSGameplayStats)
		, nativeGSClientGroupStatusCallback(this, &CGameServer::OnGSClientGroupStatus)
		, gameServer(nullptr)
	{
		
	}

	bool CGameServer::InitGameServer( u32 ip, u16 gamePort, u16 queryPort, u32 flags, 
		AppID gameAppId, PConstantString versionString )
	{
		return gameServer->InitGameServer(ip,gamePort,queryPort,flags,gameAppId,versionString);
	}

	void CGameServer::SetProduct( PConstantString product )
	{
		gameServer->SetProduct(product);
	}

	void CGameServer::SetGameDescription( PConstantString gameDescription )
	{
		gameServer->SetGameDescription(gameDescription);
	}

	void CGameServer::SetModDir( PConstantString modDir )
	{
		gameServer->SetModDir(modDir);
	}

	void CGameServer::SetDedicatedServer( bool dedicated )
	{
		gameServer->SetDedicatedServer(dedicated);
	}

	void CGameServer::LogOn(PConstantString  accountName, PConstantString password )
	{
		gameServer->LogOn(accountName,password);
	}

	void CGameServer::LogOnAnonymous()
	{
		gameServer->LogOnAnonymous();
	}

	void CGameServer::LogOff()
	{
		gameServer->LogOff();
	}

	bool CGameServer::BLoggedOn()
	{
		return gameServer->BLoggedOn();
	}


	bool CGameServer::BSecure()
	{
		return gameServer->BSecure();
	}

	bool CGameServer::WasRestartRequested()
	{
		return gameServer->WasRestartRequested();
	}

	SteamID CGameServer::GetSteamID()
	{
		return gameServer->GetSteamID().ConvertToUint64();
	}

	void CGameServer::SetMaxPlayerCount( int cPlayersMax )
	{
		gameServer->SetMaxPlayerCount(cPlayersMax);
	}

	void CGameServer::SetBotPlayerCount( int cBotplayers )
	{
		gameServer->SetBotPlayerCount(cBotplayers);
	}

	void CGameServer::SetServerName(PConstantString serverName )
	{
		gameServer->SetServerName(serverName);
	}

	void CGameServer::SetMapName(PConstantString  mapName )
	{
		gameServer->SetMapName(mapName);
	}

	void CGameServer::SetPasswordProtected( bool passwordProtected )
	{
		gameServer->SetPasswordProtected(passwordProtected);
	}

	void CGameServer::SetSpectatorPort( u16 spectatorPort )
	{
		gameServer->SetSpectatorPort(spectatorPort);
	}

	void CGameServer::SetSpectatorServerName(PConstantString  spectatorServerName )
	{
		gameServer->SetSpectatorServerName(spectatorServerName);
	}

	void CGameServer::ClearAllKeyValues()
	{
		gameServer->ClearAllKeyValues();
	}

	void CGameServer::SetKeyValue( PConstantString key, PConstantString value )
	{
		gameServer->SetKeyValue(key, value);
	}

	void CGameServer::SetGameTags( PConstantString gameTags )
	{
		gameServer->SetGameTags(gameTags);
	}

	void CGameServer::SetGameData( PConstantString gameData )
	{
		gameServer->SetGameData(gameData);
	}

	void CGameServer::SetRegion( PConstantString region )
	{
		gameServer->SetRegion(region);
	}

	bool CGameServer::SendUserConnectAndAuthenticate( u32 ipClient, PConstantDataPointer authBlob, u32 authBlobSize, SteamID *steamIDUser )
	{
		CSteamID idUser;
		bool results = gameServer->SendUserConnectAndAuthenticate(ipClient, authBlob, authBlobSize, &idUser);
		*steamIDUser = idUser.ConvertToUint64();
		return results;
	}

	SteamID CGameServer::CreateUnauthenticatedUserConnection()
	{
		return gameServer->CreateUnauthenticatedUserConnection().ConvertToUint64();
	}

	void CGameServer::SendUserDisconnect( SteamID steamIDUser )
	{
		gameServer->SendUserDisconnect(steamIDUser);
	}

	bool CGameServer::BUpdateUserData( SteamID steamIDUser, PConstantString  playerName, u32 core )
	{
		return gameServer->BUpdateUserData(steamIDUser, playerName, core);
	}

	HAuthTicket CGameServer::GetAuthSessionTicket( PDataPointer ticket, int maxTicket, uint32 *ticketSize )
	{
		return gameServer->GetAuthSessionTicket(ticket, maxTicket, ticketSize);
	}

	Enum CGameServer::BeginAuthSession( PConstantDataPointer authTicket, s32 authTicketSize, SteamID steamID )
	{
		return gameServer->BeginAuthSession(authTicket, authTicketSize, steamID);
	}

	void CGameServer::EndAuthSession(SteamID steamID )
	{
		gameServer->EndAuthSession(steamID);
	}

	void CGameServer::CancelAuthTicket( u32 authTicket )
	{
		gameServer->CancelAuthTicket(authTicket);
	}

	Enum CGameServer::UserHasLicenseForApp( SteamID steamID, u32 appID )
	{
		return gameServer->UserHasLicenseForApp(steamID, appID);
	}

	bool CGameServer::RequestUserGroupStatus( SteamID steamIDUser, SteamID steamIDGroup )
	{
		return gameServer->RequestUserGroupStatus(steamIDUser, steamIDGroup);
	}

	void CGameServer::GetGameplayStats()
	{
		gameServer->GetGameplayStats();
	}

	void CGameServer::GetServerReputation()
	{
		resultGSReputation.Set(gameServer->GetServerReputation(),this, &CGameServer::OnGSReputation);
	}

	uint32 CGameServer::GetPublicIP()
	{
		return gameServer->GetPublicIP();
	}

	bool CGameServer::HandleIncomingPacket( PConstantDataPointer data, int dataSize, u32 ip, u16 srcPort )
	{
		return gameServer->HandleIncomingPacket(data, dataSize, ip, srcPort);
	}

	int CGameServer::GetNextOutgoingPacket( PDataPointer out, int maxOut, u32 *netAdr, u16 *port )
	{
		return gameServer->GetNextOutgoingPacket(out, maxOut, netAdr, port);
	}

	void CGameServer::EnableHeartbeats( bool active )
	{
		gameServer->EnableHeartbeats(active);
	}

	void CGameServer::SetHeartbeatInterval( int heartbeatInterval )
	{
		gameServer->SetHeartbeatInterval(heartbeatInterval);
	}

	void CGameServer::ForceHeartbeat()
	{
		gameServer->ForceHeartbeat();
	}

	void CGameServer::AssociateWithClan( SteamID steamIDClan )
	{
		resultAssociateWithClanResult.Set(gameServer->AssociateWithClan(SteamID(steamIDClan)), 
			this, &CGameServer::OnAssociateWithClanResult);
	}

	void CGameServer::ComputeNewPlayerCompatibility( SteamID steamIDNewPlayer )
	{
		resultComputeNewPlayerCompatibilityResult.Set(gameServer->ComputeNewPlayerCompatibility(steamIDNewPlayer),
			this, &CGameServer::OnComputeNewPlayerCompatibilityResult);
	}
}

ManagedSteam_API bool GameServer_InitGameServer( u32 ip, u16 gamePort, u16 queryPort, u32 flags, 
	AppID gameAppId, PConstantString versionString )
{
	return CGameServer::Instance().InitGameServer(ip,gamePort,queryPort,flags,gameAppId,versionString);

}

ManagedSteam_API void GameServer_SetProduct( PConstantString product )
{
	CGameServer::Instance().SetProduct(product);
}

ManagedSteam_API void GameServer_SetGameDescription(PConstantString  gameDescription )
{
	CGameServer::Instance().SetGameDescription(gameDescription);
}

ManagedSteam_API void GameServer_SetModDir( PConstantString modDir )
{
	CGameServer::Instance().SetModDir(modDir);
}

ManagedSteam_API void GameServer_SetDedicatedServer( bool dedicated )
{
	CGameServer::Instance().SetDedicatedServer(dedicated);
}

ManagedSteam_API void GameServer_LogOn(PConstantString accountName, PConstantString password )
{
	CGameServer::Instance().LogOn(accountName,password);
}

ManagedSteam_API void GameServer_LogOnAnonymous()
{
	CGameServer::Instance().LogOnAnonymous();
}

ManagedSteam_API void GameServer_LogOff()
{
	CGameServer::Instance().LogOff();
}

ManagedSteam_API bool GameServer_LoggedOn()
{
	return CGameServer::Instance().BLoggedOn();
}

ManagedSteam_API bool GameServer_Secure()
{
	return CGameServer::Instance().BSecure();
}

ManagedSteam_API SteamID GameServer_GetSteamID()
{
	return CGameServer::Instance().GetSteamID();
}

ManagedSteam_API bool GameServer_WasRestartRequested()
{
	return CGameServer::Instance().WasRestartRequested();
}

ManagedSteam_API void GameServer_SetMaxPlayerCount( int cPlayersMax )
{
	CGameServer::Instance().SetMaxPlayerCount(cPlayersMax);
}

ManagedSteam_API void GameServer_SetBotPlayerCount( int cBotplayers )
{
	CGameServer::Instance().SetBotPlayerCount(cBotplayers);
}

ManagedSteam_API void GameServer_SetServerName(PConstantString  serverName )
{
	CGameServer::Instance().SetServerName(serverName);
}

ManagedSteam_API void GameServer_SetMapName(PConstantString  mapName )
{
	CGameServer::Instance().SetMapName(mapName);
}

ManagedSteam_API void GameServer_SetPasswordProtected( bool passwordProtected )
{
	CGameServer::Instance().SetPasswordProtected(passwordProtected);
}

ManagedSteam_API void GameServer_SetSpectatorPort( u16 spectatorPort )
{
	CGameServer::Instance().SetSpectatorPort(spectatorPort);
}

ManagedSteam_API void GameServer_SetSpectatorServerName(PConstantString spectatorServerName )
{
	CGameServer::Instance().SetSpectatorServerName(spectatorServerName);
}

ManagedSteam_API void GameServer_ClearAllKeyValues()
{
	CGameServer::Instance().ClearAllKeyValues();
}

ManagedSteam_API void GameServer_SetKeyValue( PConstantString key, PConstantString value )
{
	CGameServer::Instance().SetKeyValue(key, value);
}

ManagedSteam_API void GameServer_SetGameTags( PConstantString gameTags )
{
	CGameServer::Instance().SetGameTags(gameTags);
}

ManagedSteam_API void GameServer_SetGameData( PConstantString gameData )
{
	CGameServer::Instance().SetGameData(gameData);
}

ManagedSteam_API void GameServer_SetRegion( PConstantString region )
{
	CGameServer::Instance().SetRegion(region);
}

ManagedSteam_API bool GameServer_SendUserConnectAndAuthenticate( u32 ipClient, PConstantDataPointer authBlob, u32 authBlobSize, SteamID *steamIDUser )
{
	return CGameServer::Instance().SendUserConnectAndAuthenticate(ipClient,authBlob,authBlobSize,steamIDUser);
}

ManagedSteam_API SteamID GameServer_CreateUnauthenticatedUserConnection()
{
	return CGameServer::Instance().CreateUnauthenticatedUserConnection();
}

ManagedSteam_API void GameServer_SendUserDisconnect( SteamID steamIDUser )
{
	CGameServer::Instance().SendUserDisconnect(steamIDUser);
}

ManagedSteam_API bool GameServer_BUpdateUserData( SteamID steamIDUser, PConstantString  playerName, u32 core )
{
	return CGameServer::Instance().BUpdateUserData(steamIDUser,playerName,core);
}

ManagedSteam_API HAuthTicket GameServer_GetAuthSessionTicket( PDataPointer ticket, int maxTicket, uint32 *ticketSize )
{
	return CGameServer::Instance().GetAuthSessionTicket(ticket,maxTicket,ticketSize);
}

ManagedSteam_API Enum GameServer_BeginAuthSession( PConstantDataPointer authTicket, s32 authTicketSize, SteamID steamID )
{
	return (int)CGameServer::Instance().BeginAuthSession(authTicket, authTicketSize, steamID);
}

ManagedSteam_API void GameServer_EndAuthSession(SteamID steamID )
{
	CGameServer::Instance().EndAuthSession(steamID);
}

ManagedSteam_API void GameServer_CancelAuthTicket( u32 authTicket )
{
	CGameServer::Instance().CancelAuthTicket(authTicket);
}

ManagedSteam_API Enum GameServer_UserHasLicenseForApp( SteamID steamID, u32 appID )
{
	return (int)CGameServer::Instance().UserHasLicenseForApp(steamID,appID);
}

ManagedSteam_API bool GameServer_RequestUserGroupStatus( SteamID steamIDUser, SteamID steamIDGroup )
{
	return CGameServer::Instance().RequestUserGroupStatus(steamIDUser,steamIDGroup);
}

ManagedSteam_API void GameServer_GetGameplayStats()
{
	CGameServer::Instance().GetGameplayStats();
}

ManagedSteam_API void GameServer_GetServerReputation()
{
	CGameServer::Instance().GetServerReputation();
}

ManagedSteam_API uint32 GameServer_GetPublicIP()
{
	return CGameServer::Instance().GetPublicIP();
}

ManagedSteam_API bool GameServer_HandleIncomingPacket( PConstantDataPointer data, int dataSize, u32 ip, u16 srcPort )
{
	return CGameServer::Instance().HandleIncomingPacket(data,dataSize,ip,srcPort);
}

ManagedSteam_API int GameServer_GetNextOutgoingPacket( PDataPointer out, int maxOut, u32 *netAdr, u16 *port )
{
	return CGameServer::Instance().GetNextOutgoingPacket(out,maxOut,netAdr,port);
}

ManagedSteam_API void GameServer_EnableHeartbeats( bool active )
{
	CGameServer::Instance().EnableHeartbeats(active);
}

ManagedSteam_API void GameServer_SetHeartbeatInterval( int heartbeatInterval )
{
	CGameServer::Instance().SetHeartbeatInterval(heartbeatInterval);
}

ManagedSteam_API void GameServer_ForceHeartbeat()
{
	CGameServer::Instance().ForceHeartbeat();
}

ManagedSteam_API void GameServer_AssociateWithClan( SteamID steamIDClan )
{
	CGameServer::Instance().AssociateWithClan(steamIDClan);
}

ManagedSteam_API void GameServer_ComputeNewPlayerCompatibility( SteamID steamIDNewPlayer )
{
	CGameServer::Instance().ComputeNewPlayerCompatibility(steamIDNewPlayer);
}


