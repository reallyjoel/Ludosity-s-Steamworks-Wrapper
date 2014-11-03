using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// used in PersonaStateChange_t::m_nChangeFlags to describe what's changed about a user.
    /// These flags describe what the client has learned has changed recently, so on startup 
    /// you'll see a name, avatar and relationship change for every friend
    /// </summary>
    [Flags]
    public enum PersonaChange
    {
        Name = 0x001,
        Status = 0x002,
        ComeOnline = 0x004,
        GoneOffline = 0x008,
        GamePlayed = 0x010,
        GameServer = 0x020,
        Avatar = 0x040,
        JoinedSource = 0x080,
        LeftSource = 0x100,
        RelationshipChanged = 0x200,
        NameFirstSet = 0x400,
        FacebookInfo = 0x800,
    }
}
