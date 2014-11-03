using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam
{
    static class NativeHelpers
    {
        //Windows
        //public const int SteamStructPacking = 8;
        //Mac/Linux
        public const int SteamStructPacking = 4;

        public static LoadStatus Services_GetSteamLoadStatus()
        {
            return (LoadStatus)NativeMethods.Services_GetSteamLoadStatus();
        }

        public static ErrorCodes Services_GetErrorCode()
        {
            return (ErrorCodes)NativeMethods.Services_GetErrorCode();
        }

        public static LoadStatus ServicesGameServer_GetSteamLoadStatus()
        {
            return (LoadStatus)NativeMethods.ServicesGameServer_GetSteamLoadStatus();
        }

        public static ErrorCodes ServicesGameServer_GetErrorCode()
        {
            return (ErrorCodes)NativeMethods.ServicesGameServer_GetErrorCode();
        }

        public static T ConvertStruct<T>(IntPtr dataPointer, int dataSize)
            where T : struct
        {
            if (dataSize != Marshal.SizeOf(typeof(T)))
            {
                Error.ThrowError(ErrorCodes.CallbackStructSizeMissmatch, typeof(T).Name + ". Ours is: " + Marshal.SizeOf(typeof(T)) + ", should be: " + dataSize);
            }

            return (T)Marshal.PtrToStructure(dataPointer, typeof(T));
        }

        public static T ConvertStructToClass<T>(IntPtr dataPointer, int dataSize)
            where T : class
        {
            if (dataSize != Marshal.SizeOf(typeof(T)))
            {
                Error.ThrowError(ErrorCodes.CallbackStructSizeMissmatch, typeof(T).Name + ". Ours is " + Marshal.SizeOf(typeof(T)) + ", should be: " + dataSize);
            }

            return (T)Marshal.PtrToStructure(dataPointer, typeof(T));
        }
        
        public static string ToStringAnsi(IntPtr pointer)
        {
            return Marshal.PtrToStringAnsi(pointer);
        }

        public static string ToStringUtf8(IntPtr pointer)
        {
            using (NativeString result = new NativeString(pointer))
            {
                return result.ToStringFromUtf8();
            }
        }

    }
}
