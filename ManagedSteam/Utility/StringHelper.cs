using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Utility
{
    /// <summary>
    /// Helper class for some string related operations
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Counts how many bytes the string will use, including the null terminator. Uses UTF8 encoding.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetByteCountUtf8(string value)
        {
            return Encoding.UTF8.GetByteCount(value);
        }
    }
}
