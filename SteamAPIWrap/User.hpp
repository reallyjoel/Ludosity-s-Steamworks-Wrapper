#ifndef SteamUser_h_
#define SteamUser_h_

#include "User.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CUser : public CSingleton<CUser>
	{

		SW_CALLBACK(CUser, SteamServersConnected_t, SteamServersConnected);
		SW_CALLBACK(CUser, SteamServerConnectFailure_t, SteamServerConnectFailure);
		SW_CALLBACK(CUser, SteamServersDisconnected_t, SteamServersDisconnected);
		SW_CALLBACK(CUser, ClientGameServerDeny_t, ClientGameServerDeny);
		SW_CALLBACK(CUser, IPCFailure_t, IPCFailure);
		SW_CALLBACK(CUser, ValidateAuthTicketResponse_t, ValidateAuthTicketResponse);
		SW_CALLBACK(CUser, MicroTxnAuthorizationResponse_t, MicroTxnAuthorizationResponse);
		SW_ASYNC_RESULT(CUser, EncryptedAppTicketResponse_t, EncryptedAppTicketResponse);
		SW_CALLBACK(CUser, GetAuthSessionTicketResponse_t, GetAuthSessionTicketResponse);
		SW_CALLBACK(CUser, GameWebCallback_t, GameWebCallback);

	public:

		void SetSteamInterface(ISteamUser *user) { this->user = user; }
		void RunCallbackSizeCheck();

		bool IsLoggedOn();

		SteamID GetSteamID();

		s32 InitiateGameConnection( PDataPointer authBlob, s32 maxAuthBlob, SteamID steamIDGameServer, u32 serverIP, u16 serverPort, bool secure );

		void TerminateGameConnection( u32 serverIP, u16 serverPort );
		
		void TrackAppUsageEvent( GameID gameID, s32 appUsageEvent, PConstantString extraInfo = "");

		bool GetUserDataFolder( PString buffer, s32 bufferLength );

		void StartVoiceRecording( );

		void StopVoiceRecording( );

		Enum GetAvailableVoice( u32* compressed, u32* uncompressed, u32 uncompressedVoiceDesiredSampleRate );

		Enum GetVoice( bool wantCompressed, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, bool wantUncompressed, PDataPointer uncompressedDestBuffer, u32 uncompressedDestBufferSize, u32 *uncompressedBytesWritten, u32 uncompressedVoiceDesiredSampleRate );

		Enum DecompressVoice(PConstantDataPointer compressed, u32 compressedSize, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, u32 desiredSampleRate);

		u32 GetVoiceOptimalSampleRate( );

		u32 GetAuthSessionTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength );

		Enum BeginAuthSession( PConstantDataPointer authTicket, s32 cbAuthTicket, SteamID steamID );

		void EndAuthSession( SteamID steamID );

		void CancelAuthTicket( u32 authTicket );

		Enum UserHasLicenseForApp( SteamID steamID, AppID appID );

		bool IsBehindNAT( );

		void AdvertiseGame( SteamID steamIDGameServer, u32 serverIP, u16 serverPort );

		void RequestEncryptedAppTicket( PDataPointer dataToInclude, s32 cbDataToInclude );

		bool GetEncryptedAppTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength );

		s32 GetGameBadgeLevel( s32 nSeries, bool bFoil );

		s32 GetPlayerSteamLevel( );

	private:
		friend class CSingleton<CUser>;
		CUser();
		~CUser() {}
		DISALLOW_COPY_AND_ASSIGN(CUser);

		ISteamUser *user;
	};
}

#endif // SteamUser_h_