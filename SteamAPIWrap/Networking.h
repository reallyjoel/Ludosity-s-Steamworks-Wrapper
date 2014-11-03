#ifndef Networking_h_interop_
#define Networking_h_interop_

ManagedSteam_API bool Networking_SendP2PPacket(SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, Enum p2pSendType, int channel);

ManagedSteam_API bool Networking_SendP2PPacketOffset(SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, uint32 dataOffset, Enum p2pSendType, int channel);

ManagedSteam_API bool Networking_IsP2PPacketAvailable( u32 *msgSize, int channel);

ManagedSteam_API bool Networking_ReadP2PPacket(PDataPointer dest, u32 cubDest, u32 *msgSize, SteamID *steamIDRemote, int channel);

ManagedSteam_API bool Networking_AcceptP2PSessionWithUser(SteamID steamIDRemote);

ManagedSteam_API bool Networking_CloseP2PSessionWithUser(SteamID steamIDRemote);

ManagedSteam_API bool Networking_CloseP2PChannelWithUser(SteamID steamIDRemote, int channel);

ManagedSteam_API bool Networking_GetP2PSessionState(SteamID steamIDRemote, PDataPointer connectionState);

ManagedSteam_API bool Networking_AllowP2PPacketRelay(bool allow);

ManagedSteam_API NetListenSocket Networking_CreateListenSocket(int virtualP2PPort, u32 ip, u16 port, bool allowUseOfPacketRelay);

ManagedSteam_API NetSocket Networking_CreateP2PConnectionSocket(SteamID steamIDTarget, int virtualPort, int timeoutSec, bool allowUseOfPacketRelay);

ManagedSteam_API NetSocket Networking_CreateConnectionSocket(u32 ip, u16 port, int timeoutSec);

ManagedSteam_API bool Networking_DestroySocket(NetSocket socket, bool notifyRemoteEnd);

ManagedSteam_API bool Networking_DestroyListenSocket(NetListenSocket socket, bool notifyRemoteEnd);

ManagedSteam_API bool Networking_SendDataOnSocket(NetSocket socket, PDataPointer data, u32 cubData, bool reliable);

ManagedSteam_API bool Networking_IsDataAvailableOnSocket(NetSocket socket, u32* msgSize);

ManagedSteam_API bool Networking_RetrieveDataFromSocket(NetSocket socket, void* dest, u32 cubDest, u32* msgSize);

ManagedSteam_API bool Networking_IsDataAvailable(NetListenSocket listenSocket, u32* msgSize, NetSocket* socket);

ManagedSteam_API bool Networking_RetrieveData(NetListenSocket listenSocket, void* pubDest, u32 cubDest, u32* msgSize, NetSocket* socket);

ManagedSteam_API bool Networking_GetSocketInfo(NetSocket socket, SteamID* steamIDRemote, Enum* socketStatus, u32* ipRemote, u16* portRemote);

ManagedSteam_API bool Networking_GetListenSocketInfo(NetListenSocket listenSocket, u32* ip, u16* port);

ManagedSteam_API Enum Networking_GetSocketConnectionType(NetSocket socket);

ManagedSteam_API int Networking_GetMaxPacketSize(u32 socket); 


ManagedSteam_API s32 Networking_GetP2PSessionStateSize();

#endif