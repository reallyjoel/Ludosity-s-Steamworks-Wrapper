using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// right-handed system
    /// +y is up
    /// +x is to the right
    /// -z is going away from you
    /// Distance unit is  meters
    /// </summary>
    public struct HmdMatrix34
    {
        /// <summary>
        /// right-handed system
        /// +y is up
        /// +x is to the right
        /// -z is going away from you
        /// Distance unit is  meters
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Hmd.Matrix34Elements)]
        public float[] m;
    }
}
