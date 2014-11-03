using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;

namespace ManagedSteam.Utility
{
    class NativeBuffer : DisposableClass
    {
        public NativeBuffer(byte[] managedData)
        {
            if (managedData == null || managedData.Length == 0)
            {
                throw new ArgumentException("managedData is null or empty.", "managedData");
            }

            this.ManagedData = managedData;
            UnmanagedSize = ManagedData.Length;
            UnmanagedMemory = Marshal.AllocHGlobal(UnmanagedSize);
        }

        public NativeBuffer(int bufferSize)
        {
            if (bufferSize < 0)
            {
                throw new ArgumentOutOfRangeException("bufferSize");
            }

            UnmanagedSize = bufferSize;
            if (bufferSize == 0)
            {
                UnmanagedMemory = IntPtr.Zero;
            }
            else
            {
                UnmanagedMemory = Marshal.AllocHGlobal(UnmanagedSize);
            }
        }

        public byte[] ManagedData { get; private set; }
        public IntPtr UnmanagedMemory { get; private set; }
        public int UnmanagedSize { get; private set; }

        protected override void CleanUpNativeResources()
        {
            Marshal.FreeHGlobal(UnmanagedMemory);
            UnmanagedMemory = IntPtr.Zero;
            base.CleanUpNativeResources();
        }

        /// <summary>
        /// Will copy data from the unmanaged memory buffer to the managed byte array
        /// </summary>
        public void ReadFromUnmanagedMemory()
        {
            ReadFromUnmanagedMemory(UnmanagedSize);
        }

        public void ReadFromUnmanagedMemory(int bytesToRead)
        {
            if (bytesToRead < 0 || bytesToRead > UnmanagedSize)
            {
                throw new ArgumentOutOfRangeException("bytesToRead");
            }
            if (ManagedData == null)
            {
                throw new InvalidOperationException();
            }
            Marshal.Copy(UnmanagedMemory, ManagedData, 0, bytesToRead);
        }

        /// <summary>
        /// Will copy data from the managed byte array into the unmanaged memory
        /// </summary>
        public void WriteToUnmanagedMemory()
        {
            if (ManagedData == null)
            {
                throw new InvalidOperationException();
            }
            Marshal.Copy(ManagedData, 0, UnmanagedMemory, UnmanagedSize);
        }


        public static byte[] ToBytes(int[] values)
        {
            return ToBytes(values, BitConverter.GetBytes);
        }

        public static byte[] ToBytes(long[] values)
        {
            return ToBytes(values, BitConverter.GetBytes);
        }

        public static byte[] ToBytes(SteamID[] values)
        {
            return ToBytes(values, (id) => BitConverter.GetBytes(id.AsUInt64));
        }


        public static double[] ToDouble(byte[] rawData)
        {
            return FromBytes(rawData, BitConverter.ToDouble);
        }

        public static long[] ToLong(byte[] rawData)
        {
            return FromBytes(rawData, BitConverter.ToInt64);
        }

        public static int[] ToInt(byte[] rawData)
        {
            return FromBytes(rawData, BitConverter.ToInt32);
        }

        /// <summary>
        /// Creates a native copy of the passed in object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>A NativeBuffer that contains all the data of the passed in object</returns>
        public static NativeBuffer CopyToNative<T>(T obj)
            where T : struct
        {
            int nativeSize = Marshal.SizeOf(obj);
            NativeBuffer buffer = new NativeBuffer(nativeSize);
            Marshal.StructureToPtr(obj, buffer.UnmanagedMemory, false);
            return buffer;
        }

        private static T[] FromBytes<T>(byte[] rawData, ConvertFromBytes<T> fromBytes)
        {
            int bytesPerElement = Marshal.SizeOf(typeof(T));
            T[] data = new T[rawData.Length / bytesPerElement];
            if (rawData.Length % bytesPerElement != 0)
            {
                throw new ArgumentException("rawData");
            }

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = fromBytes(rawData, i * bytesPerElement);
            }

            return data;
        }

        private static byte[] ToBytes<T>(T[] values, GetBytes<T> getBytes)
        {
            int bytesPerElement = Marshal.SizeOf(typeof(T));
            byte[] rawData = new byte[values.Length * bytesPerElement];
            for (int i = 0; i < values.Length; i++)
            {
                byte[] currentData = getBytes(values[i]);
                for (int k = 0; k < currentData.Length; k++)
                {
                    rawData[(i * bytesPerElement) + k] = currentData[k];
                }
            }
            return rawData;
        }

        private delegate byte[] GetBytes<T>(T value);
        private delegate T ConvertFromBytes<T>(byte[] rawData, int offset);
    }
}
