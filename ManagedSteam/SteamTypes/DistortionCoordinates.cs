using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Used to return the post-distortion UVs for each color channel
    /// UVs range from 0 to 1 with 0,0 in the upper left corner of the 
    /// source render target. The 0,0 to 1,1 range covers a single eye.
    /// </summary>
    public struct DistortionCoordinates
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Hmd.DistortionCoordinatesArraySize)]
        public float[] Red;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Hmd.DistortionCoordinatesArraySize)]
        public float[] Green;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Hmd.DistortionCoordinatesArraySize)]
        public float[] Blue;
    }
    /*[StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public class DistortionCoordinates
    {
        public float[] Red = new float[2];
        public float[] Green = new float[2];
        public float[] Blue = new float[2];
    }*/
}
