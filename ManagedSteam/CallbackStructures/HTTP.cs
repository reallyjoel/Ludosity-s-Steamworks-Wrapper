using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;

namespace ManagedSteam.CallbackStructures
{
    using u8 = Byte;
    using s8 = SByte;
    using u16 = UInt16;
    using s16 = Int16;
    using u32 = UInt32;
    using s32 = Int32;
    using u64 = UInt64;
    using s64 = Int64;
    using f32 = Single;
    using f64 = Double;

    using Enum = Int32;

    public struct HTTPRequestCompleted
    {
        private HTTPRequestHandle   request;
        private u64                 contextValue;
        private bool                requestSuccessful;
        private HTTPStatusCode      statusCode;

        internal static HTTPRequestCompleted Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<HTTPRequestCompleted>(data, dataSize);
        }

        /// <summary>
        /// Handle value for the request that has completed.
        /// </summary>
        public HTTPRequestHandle    Request             { get { return request; } }

        /// <summary>
        /// Context value that the user defined on the request that this callback is associated with, 0 if
        /// no context value was set.
        /// </summary>
        public u64                  ContextValue        { get { return contextValue; } }

        /// <summary>
        /// This will be true if we actually got any sort of response from the server (even an error).  
        /// It will be false if we failed due to an internal error or client side network failure.
        /// </summary>
        public bool                 RequestSuccessful   { get { return requestSuccessful; } }

        /// <summary>
        /// Will be the HTTP status code value returned by the server, k_EHTTPStatusCode200OK is the normal
        /// OK response, if you get something else you probably need to treat it as a failure.
        /// </summary>
        public HTTPStatusCode       StatusCode          { get { return statusCode; } }
    }

    public struct HTTPRequestHeadersReceived
    {
        private HTTPRequestHandle   request;
        private u64                 contextValue;

        internal static HTTPRequestHeadersReceived Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<HTTPRequestHeadersReceived>(data, dataSize);
        }

        /// <summary>
        /// Handle value for the request that has received headers.
        /// </summary>
        public HTTPRequestHandle    Request         { get { return request; } }

        /// <summary>
        /// Context value that the user defined on the request that this callback is associated with, 0 if
        /// no context value was set.
        /// </summary>
        public u64                  ContextValue    { get { return contextValue; } }
    }

    
    public struct HTTPRequestDataReceived
    {
	    private HTTPRequestHandle   request;
        private u64                 contextValue;
        private u32                 offset;
	    private u32                 bytesReceived;

        internal static HTTPRequestDataReceived Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<HTTPRequestDataReceived>(data, dataSize);
        }

        /// <summary>
        /// Handle value for the request that has received data.
        /// </summary>
        public HTTPRequestHandle Request            { get { return request; } }

        /// <summary>
        /// Context value that the user defined on the request that this callback is associated with, 0 if no context value was set.
        /// </summary>
        public u64              ContextValue        { get { return contextValue; } }

        /// <summary>
	    /// Offset to provide to GetHTTPStreamingResponseBodyData to get this chunk of data
        /// </summary>
        public u32              Offset              { get { return offset; } }

        /// <summary>
	    /// Size to provide to GetHTTPStreamingResponseBodyData to get this chunk of data
        /// </summary>
        public u32              BytesReceived       { get { return bytesReceived; } }
    }


}
