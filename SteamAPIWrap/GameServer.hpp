#ifndef GameServer_h_
#define GameServer_h_

#include "GameServer.h"
#include "Singleton.hpp"
#include "ServicesGameServer.hpp"

// Types
#include "ConvertedStructures.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

#include "Helper.hpp"

namespace SteamAPIWrap
{
	class CGameServer : public CSingleton<CGameServer>
	{
		// TODO Move these four to the SteamUSer class once it exists
		SW_GS_CALLBACK(CGameServer, SteamServersConnected_t, SteamServersConnected);
		SW_GS_CALLBACK(CGameServer, SteamServerConnectFailure_t, SteamServerConnectFailure);
		SW_GS_CALLBACK(CGameServer, SteamServersDisconnected_t, SteamServersDisconnected);
		SW_GS_CALLBACK(CGameServer, ValidateAuthTicketResponse_t, ValidateAuthTicketResponse);


		SW_GS_CALLBACK(CGameServer, GSClientApprove_t, GSClientApprove);
		SW_GS_CALLBACK(CGameServer, GSClientDeny_t, GSClientDeny);
		SW_GS_CALLBACK(CGameServer, GSClientKick_t, GSClientKick);
		SW_GS_CALLBACK(CGameServer, GSClientAchievementStatus_t, GSClientAchievementStatus);
		SW_GS_CALLBACK(CGameServer, GSPolicyResponse_t, GSPolicyResponse);
		SW_GS_CALLBACK(CGameServer, GSGameplayStats_t, GSGameplayStats);
		SW_GS_CALLBACK(CGameServer, GSClientGroupStatus_t, GSClientGroupStatus);
		SW_GS_ASYNC_RESULT(CGameServer, GSReputation_t, GSReputation);
		SW_GS_ASYNC_RESULT(CGameServer, AssociateWithClanResult_t, AssociateWithClanResult);
		SW_GS_ASYNC_RESULT(CGameServer, ComputeNewPlayerCompatibilityResult_t, ComputeNewPlayerCompatibilityResult);



	public:
		void SetSteamInterface(ISteamGameServer *gameServer) { this->gameServer = gameServer; }
		bool InitGameServer(u32 ip, u16 gamePort, u16 queryPort, u32 flags, AppID gameAppId, PConstantString versionString);
		
		void SetProduct(PConstantString product);
		
		void SetGameDescription(PConstantString gameDescription );

		void SetModDir( PConstantString modDir );

		void SetDedicatedServer( bool dedicated );

		void LogOn(PConstantString accountName, PConstantString password);

		void LogOnAnonymous();

		void LogOff();

		bool BLoggedOn(); 

		bool BSecure();

		SteamID GetSteamID(); 

		bool WasRestartRequested();

		void SetMaxPlayerCount( s32 playersMax ); 

		void SetBotPlayerCount( s32 botplayers );

		void SetServerName(PConstantString serverName );

		void SetMapName(PConstantString mapName );

		void SetPasswordProtected( bool passwordProtected ); 

		void SetSpectatorPort( u16 spectatorPort );

		void SetSpectatorServerName(PConstantString spectatorServerName );

		void ClearAllKeyValues() ;

		void SetKeyValue( PConstantString key, PConstantString value );

		void SetGameTags( PConstantString gameTags );

		void SetGameData(PConstantString gameData);

		void SetRegion(PConstantString region );

		bool SendUserConnectAndAuthenticate( u32 ipClient, PConstantDataPointer authBlob, u32 authBlobSize, SteamID *steamIDUser );

		SteamID CreateUnauthenticatedUserConnection();

		void SendUserDisconnect(SteamID steamIDUser );

		bool BUpdateUserData(SteamID steamIDUser, PConstantString playerName, u32 core );

		AuthTicket GetAuthSessionTicket( PDataPointer ticket, s32 maxTicket, uint32 *ticketSize );

		Enum BeginAuthSession( PConstantDataPointer authTicket, s32 authTicketSize, SteamID steamID );

		void EndAuthSession(SteamID steamID );

		void CancelAuthTicket(AuthTicket authTicket );

		Enum UserHasLicenseForApp( SteamID steamID, AppID appID );

		bool RequestUserGroupStatus(SteamID steamIDUser, SteamID steamIDGroup );

		void GetGameplayStats();

		void GetServerReputation();

		u32 GetPublicIP();

		bool HandleIncomingPacket(PConstantDataPointer data, s32 dataSize, u32 ip, u16 srcPort );

		int GetNextOutgoingPacket(PDataPointer out, s32 maxOut, u32 *netAdr, u16 *port );

		void EnableHeartbeats( bool active );

		void SetHeartbeatInterval( s32 heartbeatInterval );

		void ForceHeartbeat();

		void AssociateWithClan(SteamID steamIDClan );

		void ComputeNewPlayerCompatibility(SteamID steamIDNewPlayer ) ;


	private:
		friend class CSingleton<CGameServer>;
		CGameServer();
		~CGameServer() {}
		DISALLOW_COPY_AND_ASSIGN(CGameServer);

		ISteamGameServer *gameServer;


	};

}


#endif