#ifndef Networking_h_
#define Networking_h_

#include "Networking.h"
#include "Singleton.hpp"

#include "Services.hpp"

// Types
#include "ConvertedStructures.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

#include "Helper.hpp"

namespace SteamAPIWrap
{
	class CNetworking : public CSingleton<CNetworking>
	{
		SW_CALLBACK(CNetworking, P2PSessionConnectFail_t, P2PSessionConnectFail);
		SW_CALLBACK(CNetworking, P2PSessionRequest_t, P2PSessionRequest);
		SW_CALLBACK(CNetworking, SocketStatusCallback_t, SocketStatusCallback);


	public:
		void SetSteamInterface(ISteamNetworking *networking) { this->networking = networking; }
		void RunCallbackSizeCheck();

		bool SendP2PPacket(SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, Enum p2pSendType, int channel);
		bool SendP2PPacketOffset(SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, uint32 dataOffset, Enum p2pSendType, int channel);

		bool IsP2PPacketAvailable( u32 *msgSize, int channel);

		bool ReadP2PPacket(PDataPointer dest, u32 cubDest, u32 *msgSize, SteamID *steamIDRemote, int channel);

		bool AcceptP2PSessionWithUser(SteamID steamIDRemote);

		bool CloseP2PSessionWithUser(SteamID steamIDRemote);

		bool CloseP2PChannelWithUser(SteamID steamIDRemote, int channel);

		bool GetP2PSessionState(SteamID steamIDRemote, PDataPointer connectionState);

		bool AllowP2PPacketRelay(bool allow);

		NetListenSocket CreateListenSocket(int virtualP2PPort, u32 ip, u16 port, bool allowUseOfPacketRelay);

		NetSocket CreateP2PConnectionSocket(SteamID steamIDTarget, int virtualPort, int timeoutSec, bool allowUseOfPacketRelay);

		NetSocket CreateConnectionSocket(u32 ip, u16 port, int timeoutSec);

		bool DestroySocket(NetSocket socket, bool notifyRemoteEnd);

		bool DestroyListenSocket(NetListenSocket socket, bool notifyRemoteEnd);

		bool SendDataOnSocket(NetSocket socket, PDataPointer data, u32 cubData, bool reliable);

		bool IsDataAvailableOnSocket(NetSocket socket, u32* msgSize);

		bool RetrieveDataFromSocket(NetSocket socket, void* dest, u32 cubDest, u32* msgSize);

		bool IsDataAvailable(NetListenSocket listenSocket, u32* msgSize, NetSocket* socket);

		bool RetrieveData(NetListenSocket listenSocket, void* pubDest, u32 cubDest, u32* msgSize, NetSocket* socket);

		bool GetSocketInfo(NetSocket socket, SteamID* steamIDRemote, Enum* socketStatus, u32* ipRemote, u16* portRemote);

		bool GetListenSocketInfo(NetListenSocket listenSocket, u32* ip, u16* port);

		Enum GetSocketConnectionType(NetSocket socket);

		int GetMaxPacketSize(u32 socket); 
		


	private:
		friend class CSingleton<CNetworking>;
		CNetworking();
		~CNetworking() {}
		DISALLOW_COPY_AND_ASSIGN(CNetworking);

		ISteamNetworking *networking;
	};

}

#endif // Networking_h_