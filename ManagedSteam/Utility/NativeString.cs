using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.Utility
{
    /// <summary>
    /// A wrapper class that can convert to and from a managed string in different encodings
    /// </summary>
    class NativeString : DisposableClass
    {
        private IntPtr nativeString;
        private IntPtr nativeUtf8;
        private IntPtr nativeAnsi;
        private string managedString;
        private bool originatedFromManaged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeString">Pointer to the unmanaged memory containing the string. 
        /// Will only read from this memory location</param>
        public NativeString(IntPtr nativeString)
        {
            this.nativeString = nativeString;
            this.nativeUtf8 = IntPtr.Zero;
            this.nativeAnsi = IntPtr.Zero;
            this.managedString = string.Empty;
            originatedFromManaged = false;
        }

        public NativeString(string managedString)
        {
            this.nativeString = IntPtr.Zero;
            this.nativeUtf8 = IntPtr.Zero;
            this.nativeAnsi = IntPtr.Zero;
            this.managedString = managedString;
            originatedFromManaged = true;
        }

        public string ToStringFromUtf8()
        {
            if (originatedFromManaged)
            {
                return managedString;
            }


            if (IntPtr.Zero == nativeString)
            {
                return string.Empty;
            }

            // Count the string length
            int length = 0;
            while (Marshal.ReadByte(nativeString, length) != 0)
            {
                ++length;
            }

            if (length == 0)
            {
                return string.Empty;
            }

            // Copy the raw character values
            byte[] buffer = new byte[length];
            Marshal.Copy(nativeString, buffer, 0, buffer.Length);

            // Get the actual string using UTF 8 encoding
            return Encoding.UTF8.GetString(buffer);
        }

        public string ToStringFromAnsi()
        {
            if (originatedFromManaged)
            {
                return managedString;
            }

            return Marshal.PtrToStringAnsi(nativeString);
        }

        public IntPtr ToNativeAsUtf8()
        {
            if (!originatedFromManaged)
            {
                throw new Exceptions.ManagedException(ErrorCodes.CantChangeEncoding);
            }
            if (nativeUtf8 != IntPtr.Zero)
            {
                return nativeUtf8;
            }

            Encoding encoder = Encoding.UTF8;

            int length = encoder.GetByteCount(managedString);
            byte[] buffer = new byte[length + 1];

            // Copy the string data to the byte buffer
            encoder.GetBytes(managedString, 0, managedString.Length, buffer, 0);

            // Allocate native memory for the string and copy the raw character data into it
            nativeUtf8 = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, nativeUtf8, buffer.Length);
            return nativeUtf8;
        }

        public IntPtr ToNativeAsAnsi()
        {
            if (!originatedFromManaged)
            {
                throw new Exceptions.ManagedException(ErrorCodes.CantChangeEncoding);
            }
            if (nativeAnsi != IntPtr.Zero)
            {
                return nativeAnsi;
            }

            nativeAnsi = Marshal.StringToHGlobalAnsi(managedString);
            return nativeAnsi;
        }

        protected override void CleanUpNativeResources()
        {
            if (nativeUtf8 != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeUtf8);
            }
            if (nativeAnsi != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeAnsi);
            }
            base.CleanUpNativeResources();
        }
    }
}
