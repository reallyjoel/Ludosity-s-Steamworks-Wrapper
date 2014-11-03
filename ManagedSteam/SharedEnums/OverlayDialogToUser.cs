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
    struct EOverlayDialogToUser
    {

    enum Enum
#else
    public enum OverlayDialogToUser
#endif
    {
        SteamId,
        Chat,
        JoinTrade,
        Stats,
        Achievements,
        FriendAdd,
        FriendRemove,
        FriendRequestAccept,
        FriendRequestIgnore
    }
#if __cplusplus
        ;
    };
#endif

} // namespace, used by both C# and C++
