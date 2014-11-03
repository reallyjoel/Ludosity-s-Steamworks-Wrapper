#include "Precompiled.hpp"
#include "User.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template<> CUser *CSingleton<CUser>::instance = nullptr;

	CUser::CUser()
		: nativeSteamServersConnectedCallback(this, &CUser::OnSteamServersConnected)
		, nativeSteamServerConnectFailureCallback(this, &CUser::OnSteamServerConnectFailure)
		, nativeSteamServersDisconnectedCallback(this, &CUser::OnSteamServersDisconnected)
		, nativeClientGameServerDenyCallback(this, &CUser::OnClientGameServerDeny)
		, nativeIPCFailureCallback(this, &CUser::OnIPCFailure)
		, nativeValidateAuthTicketResponseCallback(this, &CUser::OnValidateAuthTicketResponse)
		, nativeMicroTxnAuthorizationResponseCallback(this, &CUser::OnMicroTxnAuthorizationResponse)
		, nativeGetAuthSessionTicketResponseCallback(this, &CUser::OnGetAuthSessionTicketResponse)
		, nativeGameWebCallbackCallback(this, &CUser::OnGameWebCallback)
		, user(nullptr)
	{

	}

	void CUser::RunCallbackSizeCheck()
	{
		SteamServersConnected_t* steamServersConnected = new SteamServersConnected_t();
		OnSteamServersConnected(steamServersConnected);
		delete steamServersConnected;
		
		SteamServerConnectFailure_t* steamServerConnectFailure = new SteamServerConnectFailure_t();
		OnSteamServerConnectFailure(steamServerConnectFailure);
		delete steamServerConnectFailure;
		
		SteamServersDisconnected_t* steamServersDisconnected = new SteamServersDisconnected_t();
		OnSteamServersDisconnected(steamServersDisconnected);
		delete steamServersDisconnected;
		
		ClientGameServerDeny_t* clientGameServerDeny = new ClientGameServerDeny_t();
		OnClientGameServerDeny(clientGameServerDeny);
		delete clientGameServerDeny;
		
		IPCFailure_t* ipcFailure = new IPCFailure_t();
		OnIPCFailure(ipcFailure);
		delete ipcFailure;
		
		ValidateAuthTicketResponse_t* validateAuthTicketResponse = new ValidateAuthTicketResponse_t();
		OnValidateAuthTicketResponse(validateAuthTicketResponse);
		delete validateAuthTicketResponse;
		
		MicroTxnAuthorizationResponse_t* microTxnAuthorizationResponse = new MicroTxnAuthorizationResponse_t();
		OnMicroTxnAuthorizationResponse(microTxnAuthorizationResponse);
		delete microTxnAuthorizationResponse;
		
		GetAuthSessionTicketResponse_t* getAuthSessionTicketResponse = new GetAuthSessionTicketResponse_t();
		OnGetAuthSessionTicketResponse(getAuthSessionTicketResponse);
		delete getAuthSessionTicketResponse;
		
		GameWebCallback_t* gameWebCallback = new GameWebCallback_t();
		OnGameWebCallback(gameWebCallback);
		delete gameWebCallback;
		
		EncryptedAppTicketResponse_t* encryptedAppTicketResponse = new EncryptedAppTicketResponse_t();
		OnEncryptedAppTicketResponse(encryptedAppTicketResponse, false);
		delete encryptedAppTicketResponse;
	}

	bool CUser::IsLoggedOn()
	{
		return user->BLoggedOn();
	}

	SteamID CUser::GetSteamID()
	{
		return user->GetSteamID().ConvertToUint64();
	}

	s32 CUser::InitiateGameConnection( PDataPointer authBlob, s32 maxAuthBlob, SteamID steamIDGameServer, u32 serverIP, u16 serverPort, bool secure )
	{
		return user->InitiateGameConnection( authBlob, maxAuthBlob, steamIDGameServer, serverIP, serverPort, secure );
	}

	void CUser::TerminateGameConnection( u32 serverIP, u16 serverPort )
	{
		return user->TerminateGameConnection( serverIP, serverPort );
	}
		
	void CUser::TrackAppUsageEvent( GameID gameID, s32 appUsageEvent, PConstantString extraInfo)
	{
		user->TrackAppUsageEvent( CGameID(gameID), appUsageEvent, extraInfo );
	}

	bool CUser::GetUserDataFolder( PString buffer, s32 bufferLength )
	{
		return user->GetUserDataFolder( buffer, bufferLength );
	}

	void CUser::StartVoiceRecording( )
	{
		user->StartVoiceRecording( );
	}

	void CUser::StopVoiceRecording( )
	{
		user->StopVoiceRecording( );
	}

	Enum CUser::GetAvailableVoice( u32* compressed, u32* uncompressed, u32 uncompressedVoiceDesiredSampleRate )
	{
		return user->GetAvailableVoice( compressed, uncompressed, uncompressedVoiceDesiredSampleRate );
	}

	Enum CUser::GetVoice( bool wantCompressed, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, bool wantUncompressed, PDataPointer uncompressedDestBuffer, u32 uncompressedDestBufferSize, u32 *uncompressedBytesWritten, u32 uncompressedVoiceDesiredSampleRate )
	{
		return user->GetVoice( wantCompressed, destBuffer, destBufferSize, bytesWritten, wantUncompressed, uncompressedDestBuffer, uncompressedDestBufferSize, uncompressedBytesWritten, uncompressedVoiceDesiredSampleRate );
	}

	Enum CUser::DecompressVoice(PConstantDataPointer compressed, u32 compressedSize, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, u32 desiredSampleRate)
	{
		return user->DecompressVoice( compressed, compressedSize, destBuffer, destBufferSize, bytesWritten, desiredSampleRate );
	}

	u32 CUser::GetVoiceOptimalSampleRate( )
	{
		return user->GetVoiceOptimalSampleRate( );
	}

	u32 CUser::GetAuthSessionTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength )
	{
		return user->GetAuthSessionTicket( ticket, maxTicket, ticketLength );
	}

	Enum CUser::BeginAuthSession( PConstantDataPointer authTicket, s32 cbAuthTicket, SteamID steamID )
	{
		return user->BeginAuthSession( authTicket, cbAuthTicket, steamID );
	}

	void CUser::EndAuthSession( SteamID steamID )
	{
		user->EndAuthSession( steamID );
	}

	void CUser::CancelAuthTicket( u32 authTicket )
	{
		user->CancelAuthTicket( authTicket );
	}

	Enum CUser::UserHasLicenseForApp( SteamID steamID, AppID appID )
	{
		return user->UserHasLicenseForApp( steamID, appID );
	}

	bool CUser::IsBehindNAT( )
	{
		return user->BIsBehindNAT( );
	}

	void CUser::AdvertiseGame( SteamID steamIDGameServer, u32 serverIP, u16 serverPort )
	{
		user->AdvertiseGame( steamIDGameServer, serverIP, serverPort );
	}

	void CUser::RequestEncryptedAppTicket( PDataPointer dataToInclude, s32 cbDataToInclude )
	{
		resultEncryptedAppTicketResponse.Set(user->RequestEncryptedAppTicket(dataToInclude, cbDataToInclude),
			this, &CUser::OnEncryptedAppTicketResponse);
	}

	bool CUser::GetEncryptedAppTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength )
	{
		return user->GetEncryptedAppTicket( ticket, maxTicket, ticketLength );
	}

	s32 CUser::GetGameBadgeLevel( s32 nSeries, bool bFoil )
	{
		return user->GetGameBadgeLevel( nSeries, bFoil );
	}

	s32 CUser::GetPlayerSteamLevel( )
	{
		return user->GetPlayerSteamLevel( );
	}
}

ManagedSteam_API_Lite bool User_IsLoggedOn()
{
	return CUser::Instance().IsLoggedOn();
}

ManagedSteam_API_Lite SteamID User_GetSteamID()
{
	return CUser::Instance().GetSteamID();
}

ManagedSteam_API s32 User_InitiateGameConnection( PDataPointer authBlob, s32 maxAuthBlob, SteamID steamIDGameServer, u32 serverIP, u16 serverPort, bool secure )
{
	return CUser::Instance().InitiateGameConnection( authBlob, maxAuthBlob, steamIDGameServer, serverIP, serverPort, secure );
}

ManagedSteam_API void User_TerminateGameConnection( u32 serverIP, u16 serverPort )
{
	CUser::Instance().TerminateGameConnection( serverIP, serverPort );
}

ManagedSteam_API void User_TrackAppUsageEvent( GameID gameID, s32 appUsageEvent, PConstantString extraInfo)
{
	CUser::Instance().TrackAppUsageEvent( gameID, appUsageEvent, extraInfo );
}

ManagedSteam_API_Lite bool User_GetUserDataFolder( PString buffer, s32 bufferLength )
{
	return CUser::Instance().GetUserDataFolder( buffer, bufferLength );
}

ManagedSteam_API void User_StartVoiceRecording( )
{
	CUser::Instance().StartVoiceRecording( );
}

ManagedSteam_API void User_StopVoiceRecording( )
{
	CUser::Instance().StopVoiceRecording( );
}

ManagedSteam_API Enum User_GetAvailableVoice( u32* compressed, u32* uncompressed, u32 uncompressedVoiceDesiredSampleRate )
{
	return CUser::Instance().GetAvailableVoice( compressed, uncompressed, uncompressedVoiceDesiredSampleRate );
}

ManagedSteam_API Enum User_GetVoice( bool wantCompressed, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, bool wantUncompressed, PDataPointer uncompressedDestBuffer, u32 uncompressedDestBufferSize, u32 *uncompressedBytesWritten, u32 uncompressedVoiceDesiredSampleRate )
{
	return CUser::Instance().GetVoice( wantCompressed, destBuffer, destBufferSize, bytesWritten, wantUncompressed, uncompressedDestBuffer, uncompressedDestBufferSize, uncompressedBytesWritten, uncompressedVoiceDesiredSampleRate );
}

ManagedSteam_API Enum User_DecompressVoice(PConstantDataPointer compressed, u32 compressedSize, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, u32 desiredSampleRate)
{
	return CUser::Instance().DecompressVoice( compressed, compressedSize, destBuffer, destBufferSize, bytesWritten, desiredSampleRate );
}

ManagedSteam_API u32 User_GetVoiceOptimalSampleRate( )
{
	return CUser::Instance().GetVoiceOptimalSampleRate( );
}

ManagedSteam_API u32 User_GetAuthSessionTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength )
{
	return CUser::Instance().GetAuthSessionTicket( ticket, maxTicket, ticketLength );
}

ManagedSteam_API Enum User_BeginAuthSession( PConstantDataPointer authTicket, s32 cbAuthTicket, SteamID steamID )
{
	return CUser::Instance().BeginAuthSession( authTicket, cbAuthTicket, steamID );
}

ManagedSteam_API void User_EndAuthSession( SteamID steamID )
{
	CUser::Instance().EndAuthSession( steamID );
}

ManagedSteam_API void User_CancelAuthTicket( u32 authTicket )
{
	CUser::Instance().CancelAuthTicket( authTicket );
}

ManagedSteam_API Enum User_UserHasLicenseForApp( SteamID steamID, AppID appID )
{
	return CUser::Instance().UserHasLicenseForApp( steamID, appID );
}

ManagedSteam_API bool User_IsBehindNAT( )
{
	return CUser::Instance().IsBehindNAT( );
}

ManagedSteam_API void User_AdvertiseGame( SteamID steamIDGameServer, u32 serverIP, u16 serverPort )
{
	CUser::Instance().AdvertiseGame( steamIDGameServer, serverIP, serverPort );
}

ManagedSteam_API void User_RequestEncryptedAppTicket( PDataPointer dataToInclude, s32 cbDataToInclude )
{
	CUser::Instance().RequestEncryptedAppTicket( dataToInclude, cbDataToInclude );
}

ManagedSteam_API bool User_GetEncryptedTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength )
{
	return CUser::Instance().GetEncryptedAppTicket( ticket, maxTicket, ticketLength );
}

ManagedSteam_API s32 User_GetGameBadgeLevel( s32 nSeries, bool bFoil )
{
	return CUser::Instance().GetGameBadgeLevel( nSeries, bFoil );
}

ManagedSteam_API s32 User_GetPlayerSteamLevel( )
{
	return CUser::Instance().GetPlayerSteamLevel( );
}