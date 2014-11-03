#if !__cplusplus
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam
{
#endif

#if __cplusplus
namespace SteamAPIWrap
{
    struct ECallbackID
    {

    enum Enum
#else
    enum CallbackID
#endif
    {
        // <RemoteStorage>
        CloudPublishFileProgress,
        CloudPublishedFileUpdated,

        CloudPublishedFileSubscribed,
        CloudPublishedFileUnsubscribed,
        CloudPublishedFileDeleted,
        // </RemoteStorage>

        // <Stats>
        UserStatsReceived,
        UserStatsStored,
        UserAchievementStored,
        UserStatsUnloaded,
        UserAchievementIconFetched,
        // </Stats>

        // <Friends>
        PersonaStateChange,
        GameOverlayActivated,
        GameServerChangeRequested,
        GameLobbyJoinRequested,
        AvatarImageLoaded,
        GameRichPresenceJoinRequested,
        FriendRichPresenceUpdate,
        GameConnectedClanChatMsg,
        GameConnectedChatJoin,
        GameConnectedChatLeave,
        GameConnectedFriendChatMsg,
        // </Friends>

        //<MatchMaking>
        FavoritesListChanged,
        LobbyInvite,
        LobbyDataUpdate,
        LobbyChatUpdate,
        LobbyChatMsg,
        LobbyGameCreated,
        LobbyKicked,
        //</MatchMakin>

        // <SteamUser>
        SteamServersConnected,
        SteamServerConnectFailure,
        SteamServersDisconnected,
        ClientGameServerDeny,
        IPCFailure,
        ValidateAuthTicketResponse,
        MicroTxnAuthorizationResponse,
        GetAuthSessionTicketResponse,
        GameWebCallback,
        // </SteamUser>

        // <GameServer>
        GSClientApprove,
        GSClientDeny,
        GSClientKick,
        GSClientAchievementStatus,
        GSPolicyResponse,
        GSGameplayStats,
        GSClientGroupStatus,
        // </GameServer>


        //<GameServerStats>
        GSStatsUnloaded,
        //</GameServerStats>

        //<Networking>
        P2PSessionConnectFail,
        P2PSessionRequest,
        SocketStatusCallback,
        //</Networking>


        //<Utils>
        IPCountry,
        LowBatteryPower,
        SteamShutdown,
        CheckFileSignature,
        GamepadTextInputDismissed,
        //</Utils>


        //<Apps>
        DlcInstalled,
        RegisterActivationCodeResponse,
        AppProofOfPurchaseKeyResponse,
        NewLaunchQueryParameters,
        //</Apps>

        //<HTTP>
        HTTPRequestHeadersReceived,
        HTTPRequestDataReceived,
        //</HTTP>

        //<Screenshots>
        ScreenshotReady,
        ScreenshotRequested,
        //</Screenshots>
    }
#if __cplusplus
        ;
    };
#endif

} // namespace, used by both c# and C++
