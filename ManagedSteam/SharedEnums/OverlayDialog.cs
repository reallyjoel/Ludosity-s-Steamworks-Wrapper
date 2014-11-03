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
    struct EOverlayDialog
    {

    enum Enum
#else
    /// <summary>
    /// The different overlay types that exist
    /// </summary>
    public enum OverlayDialog
#endif
    {
        None,
        Friends,
        Community,
        Players,
        Settings,
        OfficialGameGroup,
        Stats,
        Achievements

#if !__cplusplus
, // Have to be placed here as C++ does not like , at the last item
        [Obsolete("ActivateGameOverlayInviteDialog should probably be used instead", true)]
        LobbyInvite
#endif
    }
#if __cplusplus
        ;
    };
#endif

} // namespace, used by both C# and C++
