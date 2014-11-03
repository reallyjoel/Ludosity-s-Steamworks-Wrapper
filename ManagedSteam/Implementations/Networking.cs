using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Networking : SteamService, INetworking
    {
        private List<P2PSessionRequest> p2pSessionRequest;
        private List<P2PSessionConnectFail> p2pSessionConnectFail;
        private List<SocketStatusCallback> socketStatusCallback;


        public Networking()
        {
            p2pSessionRequest = new List<P2PSessionRequest>();
            p2pSessionConnectFail = new List<P2PSessionConnectFail>();
            socketStatusCallback = new List<SocketStatusCallback>();

            Callbacks[CallbackID.P2PSessionRequest] = (data, size) => p2pSessionRequest.Add(CallbackStructures.P2PSessionRequest.Create(data, size));
            Callbacks[CallbackID.P2PSessionConnectFail] = (data, size) => p2pSessionConnectFail.Add(CallbackStructures.P2PSessionConnectFail.Create(data, size));
            Callbacks[CallbackID.SocketStatusCallback] = (data, size) => socketStatusCallback.Add(CallbackStructures.SocketStatusCallback.Create(data, size));
        }

        public event CallbackEvent<P2PSessionRequest> P2PSessionRequest;
        public event CallbackEvent<P2PSessionConnectFail> P2PSessionConnectFail;
        public event CallbackEvent<SocketStatusCallback> SocketStatusCallback;

        internal override void CheckIfUsableInternal()
        {

        }

        internal override void ReleaseManagedResources()
        {
            p2pSessionRequest = null;
            P2PSessionRequest = null;
            p2pSessionConnectFail = null;
            P2PSessionConnectFail = null;
            socketStatusCallback = null;
            SocketStatusCallback = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(p2pSessionRequest, P2PSessionRequest);
            InvokeEvents(p2pSessionConnectFail, P2PSessionConnectFail);
            InvokeEvents(socketStatusCallback, SocketStatusCallback);
        }
        /*
        public bool SendP2PPacket(SteamID steamIDRemote, byte[] data, P2PSend p2pSendType, int channel = 0)
        {
            CheckIfUsable();

            using (NativeBuffer bufferKey = new NativeBuffer(data))
            {
                bufferKey.WriteToUnmanagedMemory();
                return NativeMethods.Networking_SendP2PPacket(steamIDRemote.AsUInt64, bufferKey.UnmanagedMemory,
                    (uint)bufferKey.UnmanagedSize, (int)p2pSendType, channel);
            }
        }*/

        public bool SendP2PPacket(SteamID steamIDRemote, IntPtr data, uint dataSize, P2PSend p2pSendType, int channel = 0)
        {
            CheckIfUsable();

            return NativeMethods.Networking_SendP2PPacket(steamIDRemote.AsUInt64, data, dataSize, (int)p2pSendType, channel);
        }
        public bool SendP2PPacket(SteamID steamIDRemote, IntPtr data, uint dataSize, uint dataOffset, P2PSend p2pSendType, int channel = 0)
        {
            CheckIfUsable();

            return NativeMethods.Networking_SendP2PPacketOffset(steamIDRemote.AsUInt64, data, dataSize, dataOffset, (int)p2pSendType, channel);
        }


        public bool IsP2PPacketAvailable(out uint msgSize, int channel = 0)
        {
            CheckIfUsable();
            msgSize = 0;
            return NativeMethods.Networking_IsP2PPacketAvailable(ref msgSize, channel);
        }

        public NetworkingIsP2PPacketAvailableResult IsP2PPacketAvailable(int channel = 0)
        {
            NetworkingIsP2PPacketAvailableResult result = new NetworkingIsP2PPacketAvailableResult();
            result.Result = IsP2PPacketAvailable(out result.MsgSize, channel);
            return result;
        }

        public bool ReadP2PPacket(byte[] dest, out uint msgSize, out SteamID steamIDRemote, int channel = 0)
        {
            CheckIfUsable();
            msgSize = 0;

            using (NativeBuffer bufferKey = new NativeBuffer(dest))
            {
                ulong rawCreator = 0;
                bool returnvalue = NativeMethods.Networking_ReadP2PPacket(bufferKey.UnmanagedMemory,
                    (uint)bufferKey.UnmanagedSize, ref msgSize, ref rawCreator, channel);
                steamIDRemote = new SteamID(rawCreator);
                bufferKey.ReadFromUnmanagedMemory((int)msgSize);
                return returnvalue;
            }
        }

        public NetworkingReadP2PPacketResult ReadP2PPacket(byte[] dest, int channel = 0)
        {
            NetworkingReadP2PPacketResult result = new NetworkingReadP2PPacketResult();
            result.Result = ReadP2PPacket(dest, out result.MsgSize, out result.SteamIDRemote, channel);
            return result;
        }

        public bool AcceptP2PSessionWithUser(SteamID steamIDRemote)
        {
            CheckIfUsable();
            return NativeMethods.Networking_AcceptP2PSessionWithUser(steamIDRemote.AsUInt64);
        }

        public bool CloseP2PSessionWithUser(SteamID steamIDRemote)
        {
            CheckIfUsable();
            return NativeMethods.Networking_CloseP2PSessionWithUser(steamIDRemote.AsUInt64);
        }

        public bool CloseP2PChannelWithUser(SteamID steamIDRemote, int channel)
        {
            CheckIfUsable();
            return NativeMethods.Networking_CloseP2PChannelWithUser(steamIDRemote.AsUInt64, channel);
        }

        public bool GetP2PSessionState(SteamID steamIDRemote, out P2PSessionState connectionState)
        {
            CheckIfUsable();
            using (NativeBuffer bufferKey = new NativeBuffer(Marshal.SizeOf(typeof(P2PSessionState))))
            {
                int rawSize = NativeMethods.Networking_GetP2PSessionStateSize();
                if (rawSize != bufferKey.UnmanagedSize)
                {
                    Error.ThrowError(ErrorCodes.CallbackStructSizeMissmatch, typeof(P2PSessionState).Name);
                }
                bool result = NativeMethods.Networking_GetP2PSessionState(steamIDRemote.AsUInt64, bufferKey.UnmanagedMemory);
                connectionState = NativeHelpers.ConvertStruct<P2PSessionState>(bufferKey.UnmanagedMemory, bufferKey.UnmanagedSize);
                return result;
            }

        }

        public NetworkingGetP2PSessionStateResult GetP2PSessionState(SteamID steamIDRemote)
        {
            NetworkingGetP2PSessionStateResult result = new NetworkingGetP2PSessionStateResult();
            result.Result = GetP2PSessionState(steamIDRemote, out result.P2PSessionState);
            return result;
        }

        public bool AllowP2PPacketRelay(bool allow)
        {
            CheckIfUsable();
            return NativeMethods.Networking_AllowP2PPacketRelay(allow);
        }

        public NetListenSocketHandle CreateListenSocket(int virtualP2PPort, uint ip, ushort port, bool allowUseOfPacketRelay)
        {
            CheckIfUsable();
            var result = NativeMethods.Networking_CreateListenSocket(virtualP2PPort, ip, port, allowUseOfPacketRelay);
            return new NetListenSocketHandle(result);
        }

        public NetSocketHandle CreateP2PConnectionSocket(SteamID steamIDTarget, int virtualPort, int timeoutSec, bool allowUseOfPacketRelay)
        {
            CheckIfUsable();
            var result = NativeMethods.Networking_CreateP2PConnectionSocket(steamIDTarget.AsUInt64, virtualPort, timeoutSec, allowUseOfPacketRelay);
            return new NetSocketHandle(result);
        }

        public NetSocketHandle CreateConnectionSocket(uint ip, ushort port, int timeoutSec)
        {
            CheckIfUsable();
            var result = NativeMethods.Networking_CreateConnectionSocket(ip, port, timeoutSec);
            return new NetSocketHandle(result);
        }

        public bool DestroySocket(NetSocketHandle socket, bool notifyRemoteEnd)
        {
            CheckIfUsable();
            return NativeMethods.Networking_DestroySocket(socket.AsUInt32, notifyRemoteEnd);
        }

        public bool DestroyListenSocket(NetListenSocketHandle socket, bool notifyRemoteEnd)
        {
            CheckIfUsable();
            return NativeMethods.Networking_DestroyListenSocket(socket.AsUInt32, notifyRemoteEnd);
        }

        public bool SendDataOnSocket(NetSocketHandle socket, byte[] data, bool reliable)
        {
            CheckIfUsable();
            using (NativeBuffer bufferKey = new NativeBuffer(data))
            {
                bufferKey.WriteToUnmanagedMemory();
                return NativeMethods.Networking_SendDataOnSocket(socket.AsUInt32, bufferKey.UnmanagedMemory, (uint)bufferKey.UnmanagedSize, reliable);
            }
        }

        public bool IsDataAvailableOnSocket(NetSocketHandle socket, out uint msgSize)
        {
            CheckIfUsable();
            msgSize = 0;
            return NativeMethods.Networking_IsDataAvailableOnSocket(socket.AsUInt32, ref msgSize);
        }

        public NetworkingIsDataAvaibleOnSocketResult IsDataAvailableOnSocket(NetSocketHandle socket)
        {
            NetworkingIsDataAvaibleOnSocketResult result = new NetworkingIsDataAvaibleOnSocketResult();
            result.Result = IsDataAvailableOnSocket(socket, out result.MsgSize);
            return result;
        }

        public bool RetrieveDataFromSocket(NetSocketHandle socket, byte[] dest, out uint msgSize)
        {
            CheckIfUsable();
            msgSize = 0;
            using (NativeBuffer bufferKey = new NativeBuffer(dest))
            {
                bool result = NativeMethods.Networking_RetrieveDataFromSocket(socket.AsUInt32,
                    bufferKey.UnmanagedMemory, (uint)bufferKey.UnmanagedSize, ref msgSize);
                bufferKey.ReadFromUnmanagedMemory((int)msgSize);

                return result;
            }
        }

        public NetworkingRetrieveDataFromSocketResult RetrieveDataFromSocket(NetSocketHandle socket, byte[] dest)
        {
            NetworkingRetrieveDataFromSocketResult result = new NetworkingRetrieveDataFromSocketResult();
            result.Result = RetrieveDataFromSocket(socket, dest, out result.MsgSize);
            return result;
        }

        public bool IsDataAvailable(NetListenSocketHandle listenSocket, out uint msgSize, out NetSocketHandle socket)
        {
            CheckIfUsable();
            msgSize = 0;
            uint rawSocket = 0;
            var result = NativeMethods.Networking_IsDataAvailable(listenSocket.AsUInt32, ref msgSize, ref rawSocket);
            socket = new NetSocketHandle(rawSocket);
            return result;
        }

        public NetworkingIsDataAvailableResult IsDataAvailable(NetListenSocketHandle listenSocket)
        {
            NetworkingIsDataAvailableResult result = new NetworkingIsDataAvailableResult();
            result.Result = IsDataAvailable(listenSocket, out result.MsgSize, out result.Socket);
            return result;
        }

        public bool RetrieveData(NetListenSocketHandle listenSocket, byte[] dest, out uint msgSize, out NetSocketHandle socket)
        {
            CheckIfUsable();
            msgSize = 0;
            uint rawSocket = 0;
            using (NativeBuffer bufferKey = new NativeBuffer(dest))
            {
                bool result = NativeMethods.Networking_RetrieveData(listenSocket.AsUInt32,
                    bufferKey.UnmanagedMemory, (uint)bufferKey.UnmanagedSize, ref msgSize, ref rawSocket);
                bufferKey.ReadFromUnmanagedMemory((int)msgSize);
                socket = new NetSocketHandle(rawSocket);
                return result;
            }
        }

        public NetworkingRetrieveDataResult RetrieveData(NetListenSocketHandle listenSocket, byte[] dest)
        {
            NetworkingRetrieveDataResult result = new NetworkingRetrieveDataResult();
            result.Result = RetrieveData(listenSocket, dest, out result.MsgSize, out result.Socket);
            return result;
        }

        public bool GetSocketInfo(NetSocketHandle socket, out SteamID steamIDRemote,
            out SNetSocketState socketStatus, out uint ipRemote, out ushort portRemote)
        {
            CheckIfUsable();
            ulong rawCreator = 0;
            int rawSocketStatus = 0;
            ipRemote = 0;
            portRemote = 0;
            bool result = NativeMethods.Networking_GetSocketInfo(socket.AsUInt32, ref rawCreator,
                ref rawSocketStatus, ref ipRemote, ref portRemote);
            steamIDRemote = new SteamID(rawCreator);
            socketStatus = (SNetSocketState)rawSocketStatus;
            return result;
        }

        public NetworkingGetSocketInfoResult GetSocketInfo(NetSocketHandle socket)
        {
            NetworkingGetSocketInfoResult result = new NetworkingGetSocketInfoResult();
            result.Result = GetSocketInfo(socket, out result.SteamIDRemote, out result.SocketStatus, out result.IpRemote, out result.PortRemote);
            return result;
        }

        public bool GetListenSocketInfo(NetListenSocketHandle listenSocket, out uint ip, out ushort port)
        {
            CheckIfUsable();
            ip = 0;
            port = 0;
            return NativeMethods.Networking_GetListenSocketInfo(listenSocket.AsUInt32, ref ip, ref port);
        }

        public NetworkingGetListenSocketInfoResult GetListenSocketInfo(NetListenSocketHandle listenSocket)
        {
            NetworkingGetListenSocketInfoResult result = new NetworkingGetListenSocketInfoResult();
            result.Result = GetListenSocketInfo(listenSocket, out result.Ip, out result.Port);
            return result;
        }

        public NetSocketConnectionType GetSocketConnectionType(NetSocketHandle socket)
        {
            CheckIfUsable();
            int tempReturn = NativeMethods.Networking_GetSocketConnectionType(socket.AsUInt32);
            return (NetSocketConnectionType)tempReturn;
        }

        public int GetMaxPacketSize(NetSocketHandle socket)
        {
            CheckIfUsable();
            return NativeMethods.Networking_GetMaxPacketSize(socket.AsUInt32);
        }
    }
}
