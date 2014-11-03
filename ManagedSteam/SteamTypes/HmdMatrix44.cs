using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    public struct HmdMatrix44
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Hmd.Matrix44Elements)]
        public float[] m;
    }
}
