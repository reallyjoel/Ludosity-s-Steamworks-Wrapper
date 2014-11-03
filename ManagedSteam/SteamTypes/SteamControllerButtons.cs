using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    [Flags]
    public enum SteamControllerButtons : ulong
    {
        RightTrigger =          0x0000000000000001L,
        LeftTrigger =           0x0000000000000002L,
        RightBumper =           0x0000000000000004L,
        LeftBumper =            0x0000000000000008L,
        Button0 =               0x0000000000000010L,
        Button1 =               0x0000000000000020L,
        Button2 =               0x0000000000000040L,
        Button3 =               0x0000000000000080L,
        Touch0 =                0x0000000000000100L,
        Touch1 =                0x0000000000000200L,
        Touch2 =                0x0000000000000400L,
        Touch3 =                0x0000000000000800L,
        ButtonMenu =            0x0000000000001000L,
        ButtonSteam =           0x0000000000002000L,
        ButtonEscape =          0x0000000000004000L,
        ButtonBackLeft =        0x0000000000008000L,
        ButtonBackRight =       0x0000000000010000L,
        ButtonLeftpadClicked =  0x0000000000020000L,
        ButtonRightpadClicked = 0x0000000000040000L,
        LeftpadFingerDown =     0x0000000000080000L,
        RightpadFingerDown =    0x0000000000100000L
    }
}
