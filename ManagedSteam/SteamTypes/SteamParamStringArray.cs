using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.Utility;

namespace ManagedSteam.SteamTypes
{

    /*
    struct SteamParamStringArray_t
    {
        const char ** m_ppStrings;
        int32 m_nNumStrings;
    };
    */

    /// <summary>
    /// Wrapper for the \a SteamParamStringArray_t struct.
    /// Contains a collection of strings.
    /// </summary>
    class SteamParamStringArray : DisposableClass
    {
        private IntPtr nativeDoubleStringArray; // const char ** m_ppStrings;
        private IntPtr[] nativeStrings;
        private IntPtr nativeStructMemory;

        public SteamParamStringArray(IList<string> values)
        {
            // Need one buffer per string
            nativeStrings = new IntPtr[values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                // Create native strings for all values
                nativeStrings[i] = Marshal.StringToHGlobalAnsi(values[i]);
            }

            // Create one array of string pointers
            nativeDoubleStringArray = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)) * nativeStrings.Length);
            Marshal.Copy(nativeStrings, 0, nativeDoubleStringArray, nativeStrings.Length);

            NativeStruct nativeStruct = new NativeStruct()
            {
                Strings = nativeDoubleStringArray,
                StringCount = nativeStrings.Length,
            };

            nativeStructMemory = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NativeStruct)));
            Marshal.StructureToPtr(nativeStruct, nativeStructMemory, false);
        }

        public IntPtr UnmanagedMemory { get { return nativeStructMemory; } }

        protected override void CleanUpNativeResources()
        {
            Marshal.FreeHGlobal(nativeStructMemory);
            Marshal.FreeHGlobal(nativeDoubleStringArray);

            foreach (var item in nativeStrings)
            {
                Marshal.FreeHGlobal(item);
            }
            base.CleanUpNativeResources();
        }


        [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
        private struct NativeStruct
        {
            public IntPtr Strings;
            public int StringCount;
        }
    }
}
