#include "Precompiled.hpp"
#include "Networking.hpp"

#include "OverlayDialog.hpp"
#include "OverlayDialogToUser.hpp"

#include "MemoryHelpers.h"
#include "isteamnetworking.h"


using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CNetworking* CSingleton<CNetworking>::instance = nullptr;

	CNetworking::CNetworking() 
		: nativeP2PSessionConnectFailCallback(this, &CNetworking::OnP2PSessionConnectFail)
		, nativeP2PSessionRequestCallback(this, &CNetworking::OnP2PSessionRequest)
		, nativeSocketStatusCallbackCallback(this, &CNetworking::OnSocketStatusCallback)
		, networking(nullptr)
	{

	}

	void CNetworking::RunCallbackSizeCheck()
	{
		P2PSessionConnectFail_t* p2pSessionConnectFail = new P2PSessionConnectFail_t();
		OnP2PSessionConnectFail(p2pSessionConnectFail);
		delete p2pSessionConnectFail;

		P2PSessionRequest_t* p2pSessionRequest = new P2PSessionRequest_t();
		OnP2PSessionRequest(p2pSessionRequest);
		delete p2pSessionRequest;

		SocketStatusCallback_t* socketStatusCallback = new SocketStatusCallback_t();
		OnSocketStatusCallback(socketStatusCallback);
		delete socketStatusCallback;
	}

	bool CNetworking::SendP2PPacket( SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, Enum p2pSendType, int channel)
	{
		return networking->SendP2PPacket(steamIDRemote, data, cubData, static_cast<EP2PSend>(p2pSendType), channel);
	}

	bool CNetworking::SendP2PPacketOffset( SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, uint32 dataOffset, Enum p2pSendType, int channel)
	{
		return networking->SendP2PPacket(steamIDRemote, (&data + dataOffset), cubData, static_cast<EP2PSend>(p2pSendType), channel);
	}

	bool CNetworking::IsP2PPacketAvailable(uint32 *msgSize, int channel)
	{
		return networking->IsP2PPacketAvailable(msgSize, channel);
	}

	bool CNetworking::ReadP2PPacket(PDataPointer dest, u32 cubDest, u32 *msgSize, SteamID *steamIDRemote, int channel)
	{
		CSteamID idRemote;
		bool returnvalue  = networking->ReadP2PPacket(dest, cubDest, msgSize, &idRemote, channel);
		*steamIDRemote = idRemote.ConvertToUint64();
		return returnvalue;
	}

	bool CNetworking::AcceptP2PSessionWithUser(SteamID steamIDRemote)
	{
		return networking->AcceptP2PSessionWithUser(steamIDRemote);
	}

	bool CNetworking::CloseP2PSessionWithUser(SteamID steamIDRemote)
	{
		return networking->CloseP2PSessionWithUser(steamIDRemote);
	}

	bool CNetworking::CloseP2PChannelWithUser(SteamID steamIDRemote, int channel)
	{
		return networking->CloseP2PChannelWithUser(steamIDRemote,channel);
	}

	bool CNetworking::GetP2PSessionState(SteamID steamIDRemote, PDataPointer connectionState)
	{
		return networking->GetP2PSessionState(steamIDRemote,static_cast<P2PSessionState_t *>(connectionState));
	}

	bool CNetworking::AllowP2PPacketRelay( bool allow )
	{
		return networking->AllowP2PPacketRelay(allow);
	}

	u32 CNetworking::CreateListenSocket(int virtualP2PPort, u32 ip, u16 port, bool allowUseOfPacketRelay)
	{
		return networking->CreateListenSocket(virtualP2PPort,ip,port,allowUseOfPacketRelay);
	}

	u32 CNetworking::CreateP2PConnectionSocket(SteamID steamIDTarget, int virtualPort, int timeoutSec, bool allowUseOfPacketRelay )
	{
		return networking->CreateP2PConnectionSocket(steamIDTarget, virtualPort, timeoutSec, allowUseOfPacketRelay);
	}

	u32 CNetworking::CreateConnectionSocket(u32 ip, u16 port, int timeoutSec)
	{
		return networking->CreateConnectionSocket(ip, port, timeoutSec);
	}

	bool CNetworking::DestroySocket(u32 socket, bool notifyRemoteEnd)
	{
		return networking->DestroySocket(socket, notifyRemoteEnd);
	}

	bool CNetworking::DestroyListenSocket(u32 socket, bool notifyRemoteEnd)
	{
		return networking->DestroyListenSocket(socket, notifyRemoteEnd);
	}

	bool CNetworking::SendDataOnSocket(u32 socket, PDataPointer data, u32 cubData, bool reliable)
	{
		return networking->SendDataOnSocket(socket, data, cubData, reliable);
	}

	bool CNetworking::IsDataAvailableOnSocket( u32 socket, u32* msgSize )
	{
		return networking->IsDataAvailableOnSocket(socket, msgSize);
	}

	bool CNetworking::RetrieveDataFromSocket( u32 socket, PDataPointer dest, u32 cubDest, u32* msgSize )
	{
		return networking->RetrieveDataFromSocket(socket, dest, cubDest, msgSize);
	}

	bool CNetworking::IsDataAvailable( u32 listenSocket, u32* msgSize, u32* socket )
	{
		return networking->IsDataAvailable(listenSocket, msgSize, socket);
	}

	bool CNetworking::RetrieveData( u32 listenSocket, PDataPointer dest, u32 cubDest, u32* msgSize, u32* socket )
	{
		return networking->RetrieveData(listenSocket, dest, cubDest, msgSize, socket);
	}

	bool CNetworking::GetSocketInfo( u32 socket, SteamID* steamIDRemote, int* socketStatus, u32* ipRemote, u16* portRemote )
	{
		CSteamID idRemote;
		bool returnvalue  = networking->GetSocketInfo(socket, &idRemote, socketStatus, ipRemote, portRemote);
		*steamIDRemote = idRemote.ConvertToUint64();
		return returnvalue;
	}

	bool CNetworking::GetListenSocketInfo( u32 listenSocket, u32* ip, u16* port )
	{
		return networking->GetListenSocketInfo(listenSocket, ip, port);
	}

	Enum CNetworking::GetSocketConnectionType( u32 socket )
	{
		return networking->GetSocketConnectionType(socket);
	}

	int CNetworking::GetMaxPacketSize( u32 socket)
	{
		return networking->GetMaxPacketSize(socket);
	}

}

ManagedSteam_API bool Networking_SendP2PPacket( SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, Enum p2pSendType, int channel)
{
	return CNetworking::Instance().SendP2PPacket(steamIDRemote,data,cubData,p2pSendType,channel);
}

ManagedSteam_API bool Networking_SendP2PPacketOffset(SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, uint32 dataOffset, Enum p2pSendType, int channel)
{
	return CNetworking::Instance().SendP2PPacketOffset(steamIDRemote, data, cubData, dataOffset, p2pSendType, channel);
}

ManagedSteam_API bool Networking_IsP2PPacketAvailable(u32 *msgSize, int channel)
{
	return CNetworking::Instance().IsP2PPacketAvailable(msgSize,channel);
}

ManagedSteam_API bool Networking_ReadP2PPacket(PDataPointer dest, u32 cubDest, u32 *msgSize, SteamID *steamIDRemote, int channel)
{
	return CNetworking::Instance().ReadP2PPacket(dest,cubDest,msgSize,steamIDRemote,channel);
}

ManagedSteam_API bool Networking_AcceptP2PSessionWithUser(SteamID steamIDRemote )
{
	return CNetworking::Instance().AcceptP2PSessionWithUser(steamIDRemote);
}

ManagedSteam_API bool Networking_CloseP2PSessionWithUser(SteamID steamIDRemote)
{
	return CNetworking::Instance().CloseP2PSessionWithUser(steamIDRemote);
}

ManagedSteam_API bool Networking_CloseP2PChannelWithUser(SteamID steamIDRemote, int channel)
{
	return CNetworking::Instance().CloseP2PChannelWithUser(steamIDRemote,channel);
}

ManagedSteam_API bool Networking_GetP2PSessionState(SteamID steamIDRemote, PDataPointer connectionState)
{
	return CNetworking::Instance().GetP2PSessionState(steamIDRemote,connectionState);
}

ManagedSteam_API bool Networking_AllowP2PPacketRelay( bool bAllow )
{
	return CNetworking::Instance().AllowP2PPacketRelay(bAllow);
}

ManagedSteam_API u32 Networking_CreateListenSocket(int virtualP2PPort, u32 ip, u16 port, bool allowUseOfPacketRelay)
{
	return CNetworking::Instance().CreateListenSocket(virtualP2PPort,ip,port,allowUseOfPacketRelay);
}

ManagedSteam_API u32 Networking_CreateConnectionSocket(u32 ip, u16 port, int timeoutSec)
{
	return CNetworking::Instance().CreateConnectionSocket(ip,port,timeoutSec);
}

ManagedSteam_API bool Networking_DestroySocket(u32 socket, bool notifyRemoteEnd)
{
	return CNetworking::Instance().DestroySocket(socket,notifyRemoteEnd);
}

ManagedSteam_API bool Networking_DestroyListenSocket(u32 socket, bool notifyRemoteEnd)
{
	return CNetworking::Instance().DestroyListenSocket(socket,notifyRemoteEnd);
}

ManagedSteam_API bool Networking_SendDataOnSocket(u32 socket, PDataPointer data, u32 cubData, bool reliable)
{
	return CNetworking::Instance().SendDataOnSocket(socket,data,cubData,reliable);
}

ManagedSteam_API bool Networking_IsDataAvailableOnSocket( u32 socket, u32* msgSize )
{
	return CNetworking::Instance().IsDataAvailableOnSocket(socket,msgSize);
}

ManagedSteam_API bool Networking_RetrieveDataFromSocket( u32 socket, void* dest, u32 cubDest, u32* msgSize )
{
	return CNetworking::Instance().RetrieveDataFromSocket(socket,dest, cubDest, msgSize);
}

ManagedSteam_API bool Networking_IsDataAvailable( u32 listenSocket, u32* msgSize, u32* socket )
{
	return CNetworking::Instance().IsDataAvailable(listenSocket,msgSize,socket);
}

ManagedSteam_API bool Networking_RetrieveData( u32 listenSocket, void* pubDest, u32 cubDest, u32* msgSize, u32* socket )
{
	return CNetworking::Instance().RetrieveData(listenSocket,pubDest,cubDest, msgSize, socket);
}

ManagedSteam_API bool Networking_GetSocketInfo( u32 socket, SteamID* steamIDRemote, int* socketStatus, u32* ipRemote, u16* portRemote )
{
	return CNetworking::Instance().GetSocketInfo(socket, steamIDRemote, socketStatus, ipRemote, portRemote);
}

ManagedSteam_API bool Networking_GetListenSocketInfo( u32 listenSocket, u32* ip, u16* port )
{
	return CNetworking::Instance().GetListenSocketInfo(listenSocket,ip,port);
}

ManagedSteam_API Enum Networking_GetSocketConnectionType( u32 socket )
{
	return CNetworking::Instance().GetSocketConnectionType(socket);
}

ManagedSteam_API int Networking_GetMaxPacketSize(u32 socket )
{
	return CNetworking::Instance().GetMaxPacketSize(socket);
}

ManagedSteam_API s32 Networking_GetP2PSessionStateSize()
{
	return sizeof(P2PSessionState_t);
}