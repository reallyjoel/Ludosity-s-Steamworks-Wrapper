using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;
using ManagedSteam.CallbackStructures;

namespace ManagedSteam
{
    /// <summary>
    /// Purpose: interface to steam for game servers
    /// </summary>
    public interface INetworking
    {
        event CallbackEvent<P2PSessionRequest> P2PSessionRequest;
        event CallbackEvent<P2PSessionConnectFail> P2PSessionConnectFail;
        event CallbackEvent<SocketStatusCallback> SocketStatusCallback;

        /// <summary>
        /// Sends a P2P packet to the specified user
        /// UDP-like, unreliable and a max packet size of 1200 bytes
        /// the first packet send may be delayed as the NAT-traversal code runs
        /// if we can't get through to the user, an error will be posted via the callback P2PSessionConnectFail_t
        /// see EP2PSend enum above for the descriptions of the different ways of sending packets
        ///
        /// nChannel is a routing number you can use to help route message to different systems 	- you'll have to call ReadP2PPacket() 
        /// with the same channel number in order to retrieve the data on the other end
        /// using different channels to talk to the same user will still use the same underlying p2p connection, saving on resource
        /// </summary>
        /// <param name="steamIDRemote"></param>
        /// <param name="data"></param>
        /// <param name="p2pSendType"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        bool SendP2PPacket(SteamID steamIDRemote, IntPtr data, uint dataSize, P2PSend p2pSendType, int channel = 0);
        bool SendP2PPacket(SteamID steamIDRemote, IntPtr data, uint dataSize, uint dataOffset, P2PSend p2pSendType, int channel = 0);
        //bool SendP2PPacket(SteamID steamIDRemote, byte[] data, P2PSend p2pSendType, int channel = 0);

        /// <summary>
        /// returns true if any data is available for read, and the amount of data that will need to be read
        /// </summary>
        /// <param name="msgSize"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        bool IsP2PPacketAvailable(out uint msgSize, int channel = 0);

        /// <summary>
        /// returns true if any data is available for read, and the amount of data that will need to be read
        /// </summary>
        /// <param name="msgSize"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        NetworkingIsP2PPacketAvailableResult IsP2PPacketAvailable(int channel = 0);

        /// <summary>
        /// reads in a packet that has been sent from another user via SendP2PPacket()
        /// returns the size of the message and the steamID of the user who sent it in the last two parameters
        /// if the buffer passed in is too small, the message will be truncated
        /// this call is not blocking, and will return false if no data is available
        /// </summary>
        /// <param name="Dest"></param>
        /// <param name="msgSize"></param>
        /// <param name="steamIDRemote"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        bool ReadP2PPacket(byte[] dest, out uint msgSize, out SteamID steamIDRemote, int channel = 0);

        /// <summary>
        /// reads in a packet that has been sent from another user via SendP2PPacket()
        /// returns the size of the message and the steamID of the user who sent it in the last two parameters
        /// if the buffer passed in is too small, the message will be truncated
        /// this call is not blocking, and will return false if no data is available
        /// </summary>
        /// <param name="Dest"></param>
        /// <param name="msgSize"></param>
        /// <param name="steamIDRemote"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        NetworkingReadP2PPacketResult ReadP2PPacket(byte[] dest, int channel = 0);

        /// <summary>
        /// AcceptP2PSessionWithUser() should only be called in response to a P2PSessionRequest_t callback
        /// P2PSessionRequest_t will be posted if another user tries to send you a packet that you haven't talked to yet
        /// if you don't want to talk to the user, just ignore the request
        /// if the user continues to send you packets, another P2PSessionRequest_t will be posted periodically
        /// this may be called multiple times for a single user
        /// (if you've called SendP2PPacket() on the other user, this implicitly accepts the session request)
        /// </summary>
        /// <param name="steamIDRemote"></param>
        /// <returns></returns>
        bool AcceptP2PSessionWithUser(SteamID steamIDRemote);

        /// <summary>
        /// call CloseP2PSessionWithUser() when you're done talking to a user, will free up resources under-the-hood
        /// if the remote user tries to send data to you again, another P2PSessionRequest_t callback will be posted
        /// </summary>
        /// <param name="steamIDRemote"></param>
        /// <returns></returns>
        bool CloseP2PSessionWithUser(SteamID steamIDRemote);

        /// <summary>
        /// call CloseP2PChannelWithUser() when you're done talking to a user on a specific channel. Once all channels
        /// open channels to a user have been closed, the open session to the user will be closed and new data from this
        /// user will trigger a P2PSessionRequest_t callbac
        /// </summary>
        /// <param name="steamIDRemote"></param>
        /// <param name="nChannel"></param>
        /// <returns></returns>
        bool CloseP2PChannelWithUser(SteamID steamIDRemote, int channel);

        /// <summary>
        /// fills out P2PSessionState_t structure with details about the underlying connection to the user
        /// should only needed for debugging purposes
        /// returns false if no connection exists to the specified user
        /// </summary>
        /// <param name="steamIDRemote"></param>
        /// <param name="connectionState"></param>
        /// <returns></returns>
        bool GetP2PSessionState(SteamID steamIDRemote, out P2PSessionState connectionState);


        /// <summary>
        /// fills out P2PSessionState_t structure with details about the underlying connection to the user
        /// should only needed for debugging purposes
        /// returns false if no connection exists to the specified user
        /// </summary>
        /// <param name="steamIDRemote"></param>
        /// <param name="connectionState"></param>
        /// <returns></returns>
        NetworkingGetP2PSessionStateResult GetP2PSessionState(SteamID steamIDRemote);

        /// <summary>
        /// Allow P2P connections to fall back to being relayed through the Steam servers if a direct connection
        /// or NAT-traversal cannot be established. Only applies to connections created after setting this value,
        /// or to existing connections that need to automatically reconnect after this value is set.
        ///
        /// P2P packet relay is allowed by default
        /// </summary>
        /// <param name="allow"></param>
        /// <returns></returns>
        bool AllowP2PPacketRelay(bool allow);

        /// <summary>
        /// creates a socket and listens others to connect
        /// will trigger a SocketStatusCallback_t callback on another client connecting
        /// nVirtualP2PPort is the unique ID that the client will connect to, in case you have multiple ports
        ///		this can usually just be 0 unless you want multiple sets of connections
        /// unIP is the local IP address to bind to
        ///		pass in 0 if you just want the default local IP
        /// unPort is the port to use
        ///		pass in 0 if you don't want users to be able to connect via IP/Port, but expect to be always peer-to-peer connections only
        /// </summary>
        /// <param name="virtualP2PPort"></param>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <param name="allowUseOfPacketRelay"></param>
        /// <returns></returns>
        NetListenSocketHandle CreateListenSocket(int virtualP2PPort, uint ip, ushort port, bool allowUseOfPacketRelay);

        /// <summary>
        /// creates a socket and begin connection to a remote destination
        /// can connect via a known steamID (client or game server), or directly to an IP
        /// on success will trigger a SocketStatusCallback_t callback
        /// on failure or timeout will trigger a SocketStatusCallback_t callback with a failure code in m_eSNetSocketStat
        /// </summary>
        /// <param name="steamIDTarget"></param>
        /// <param name="virtualPort"></param>
        /// <param name="timeoutSec"></param>
        /// <param name="allowUseOfPacketRelay"></param>
        /// <returns></returns>
        NetSocketHandle CreateP2PConnectionSocket(SteamID steamIDTarget, int virtualPort, int timeoutSec, bool allowUseOfPacketRelay);

        /// <summary>
        /// creates a socket and begin connection to a remote destination
        /// can connect via a known steamID (client or game server), or directly to an IP
        /// on success will trigger a SocketStatusCallback_t callback
        /// on failure or timeout will trigger a SocketStatusCallback_t callback with a failure code in m_eSNetSocketState
        /// </summary>
        /// <param name="nIP"></param>
        /// <param name="nPort"></param>
        /// <param name="nTimeoutSec"></param>
        /// <returns></returns>
        NetSocketHandle CreateConnectionSocket(uint ip, ushort port, int timeoutSec);


        /// <summary>
        /// disconnects the connection to the socket, if any, and invalidates the handle
        /// any unread data on the socket will be thrown away
        /// if bNotifyRemoteEnd is set, socket will not be completely destroyed until the remote end acknowledges the disconnect
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="notifyRemoteEnd"></param>
        /// <returns></returns>
        bool DestroySocket(NetSocketHandle socket, bool notifyRemoteEnd);

        /// <summary>
        /// destroying a listen socket will automatically kill all the regular sockets generated from it
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="notifyRemoteEnd"></param>
        /// <returns></returns>
        bool DestroyListenSocket(NetListenSocketHandle socket, bool notifyRemoteEnd);

        /// <summary>
        /// sending data
        /// must be a handle to a connected socket
        /// data is all sent via UDP, and thus send sizes are limited to 1200 bytes; after this, many routers will start dropping packets
        /// use the reliable flag with caution; although the resend rate is pretty aggressive,
        /// it can still cause stalls in receiving data (like TCP)
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        /// <param name="reliable"></param>
        /// <returns></returns>
        bool SendDataOnSocket(NetSocketHandle socket, byte[] data, bool reliable);

        /// <summary>
        /// receiving data
        /// returns false if there is no data remaining
        /// fills out *pcubMsgSize with the size of the next message, in bytes
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="msgSize"></param>
        /// <returns></returns>
        bool IsDataAvailableOnSocket(NetSocketHandle socket, out uint msgSize);

        /// <summary>
        /// receiving data
        /// returns false if there is no data remaining
        /// fills out *pcubMsgSize with the size of the next message, in bytes
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="msgSize"><
        NetworkingIsDataAvaibleOnSocketResult IsDataAvailableOnSocket(NetSocketHandle socket);

        /// <summary>
        /// fills in pubDest with the contents of the message
        /// messages are always complete, of the same size as was sent (i.e. packetized, not streaming)
        /// if *pcubMsgSize  cubDest, only partial data is written
        /// returns false if no data is available
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="dest"></param>
        /// <param name="msgSize"></param>
        /// <returns></returns>
        bool RetrieveDataFromSocket(NetSocketHandle socket, byte[] dest, out uint msgSize);

        /// <summary>
        /// fills in pubDest with the contents of the message
        /// messages are always complete, of the same size as was sent (i.e. packetized, not streaming)
        /// if *pcubMsgSize  cubDest, only partial data is written
        /// returns false if no data is available
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="dest"></param>
        /// <param name="msgSize"></param>
        /// <returns></returns>
        NetworkingRetrieveDataFromSocketResult RetrieveDataFromSocket(NetSocketHandle socket, byte[] dest);

        /// <summary>
        /// checks for data from any socket that has been connected off this listen socket
        /// returns false if there is no data remaining
        /// fills out *pcubMsgSize with the size of the next message, in bytes
        /// fills out *phSocket with the socket that data is available on
        /// </summary>
        /// <param name="listenSocket"></param>
        /// <param name="msgSize"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        bool IsDataAvailable(NetListenSocketHandle listenSocket, out uint msgSize, out NetSocketHandle socket);

        /// <summary>
        /// checks for data from any socket that has been connected off this listen socket
        /// returns false if there is no data remaining
        /// fills out *pcubMsgSize with the size of the next message, in bytes
        /// fills out *phSocket with the socket that data is available on
        /// </summary>
        /// <param name="listenSocket"></param>
        /// <param name="msgSize"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        NetworkingIsDataAvailableResult IsDataAvailable(NetListenSocketHandle listenSocket);

        /// <summary>
        /// retrieves data from any socket that has been connected off this listen socket
        /// fills in pubDest with the contents of the message
        /// messages are always complete, of the same size as was sent (i.e. packetized, not streaming)
        /// if *pcubMsgSize cubDest, only partial data is written
        /// returns false if no data is available
        /// fills out *phSocket with the socket that data is available on
        /// </summary>
        /// <param name="listenSocket"></param>
        /// <param name="dest"></param>
        /// <param name="cubDest"></param>
        /// <param name="msgSize"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        bool RetrieveData(NetListenSocketHandle listenSocket, byte[] dest, out uint msgSize, out NetSocketHandle socket);

        /// <summary>
        /// retrieves data from any socket that has been connected off this listen socket
        /// fills in pubDest with the contents of the message
        /// messages are always complete, of the same size as was sent (i.e. packetized, not streaming)
        /// if *pcubMsgSize cubDest, only partial data is written
        /// returns false if no data is available
        /// fills out *phSocket with the socket that data is available on
        /// </summary>
        /// <param name="listenSocket"></param>
        /// <param name="dest"></param>
        /// <param name="cubDest"></param>
        /// <param name="msgSize"></param>
        /// <param name="socket"></param>
        /// <returns></returns>
        NetworkingRetrieveDataResult RetrieveData(NetListenSocketHandle listenSocket, byte[] dest);


        /// <summary>
        /// returns information about the specified socket, filling out the contents of the pointers
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="steamIDRemote"></param>
        /// <param name="socketStatus"></param>
        /// <param name="ipRemote"></param>
        /// <param name="portRemote"></param>
        /// <returns></returns>
        bool GetSocketInfo(NetSocketHandle socket, out SteamID steamIDRemote, out SNetSocketState socketStatus, out uint ipRemote, out ushort portRemote);

        /// <summary>
        /// returns information about the specified socket, filling out the contents of the pointers
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="steamIDRemote"></param>
        /// <param name="socketStatus"></param>
        /// <param name="ipRemote"></param>
        /// <param name="portRemote"></param>
        /// <returns></returns>
        NetworkingGetSocketInfoResult GetSocketInfo(NetSocketHandle socket);

        /// <summary>
        /// returns which local port the listen socket is bound to
        /// *pnIP and *pnPort will be 0 if the socket is set to listen for P2P connections only
        /// </summary>
        /// <param name="hListenSocket"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        bool GetListenSocketInfo(NetListenSocketHandle listenSocket, out uint ip, out ushort port);

        /// <summary>
        /// returns which local port the listen socket is bound to
        /// *pnIP and *pnPort will be 0 if the socket is set to listen for P2P connections only
        /// </summary>
        /// <param name="hListenSocket"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        NetworkingGetListenSocketInfoResult GetListenSocketInfo(NetListenSocketHandle listenSocket);

        /// <summary>
        /// returns true to describe how the socket ended up connecting
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        NetSocketConnectionType GetSocketConnectionType(NetSocketHandle socket);

        /// <summary>
        /// max packet size, in bytes
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        int GetMaxPacketSize(NetSocketHandle socket);
    }


    public struct NetworkingIsP2PPacketAvailableResult
    {
        public bool Result;
        public uint MsgSize;
    }

    public struct NetworkingReadP2PPacketResult
    {
        public bool Result;
        public uint MsgSize;
        public SteamID SteamIDRemote;
    }

    public struct NetworkingGetP2PSessionStateResult
    {
        public bool Result;
        public P2PSessionState P2PSessionState;
    }

    public struct NetworkingIsDataAvaibleOnSocketResult
    {
        public bool Result;
        public uint MsgSize;
    }

    public struct NetworkingRetrieveDataFromSocketResult
    {
        public bool Result;
        public uint MsgSize;
    }

    public struct NetworkingIsDataAvailableResult
    {
        public bool Result;
        public uint MsgSize;
        public NetSocketHandle Socket;
    }

    public struct NetworkingRetrieveDataResult
    {
        public bool Result;
        public uint MsgSize;
        public NetSocketHandle Socket;
    }

    public struct NetworkingGetSocketInfoResult
    {
        public bool Result;
        public SteamID SteamIDRemote;
        public SNetSocketState SocketStatus;
        public uint IpRemote;
        public ushort PortRemote;
    }

    public struct NetworkingGetListenSocketInfoResult
    {
        public bool Result;
        public uint Ip;
        public ushort Port;
    }


}
