using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class HTTP : SteamService, IHTTP
    {
        private List<Result<HTTPRequestCompleted>> httpRequestCompleted;
        private List<HTTPRequestHeadersReceived> httpRequestHeadersReceived;
        private List<HTTPRequestDataReceived> httpRequestDataReceived;

        public HTTP()
        {
            httpRequestCompleted =          new List<Result<HTTPRequestCompleted>>();
            httpRequestHeadersReceived =    new List<HTTPRequestHeadersReceived>();
            httpRequestDataReceived =       new List<HTTPRequestDataReceived>();

            Results[ResultID.HTTPRequestCompleted] = (data, dataSize, flag) => httpRequestCompleted.Add(new Result<HTTPRequestCompleted>(CallbackStructures.HTTPRequestCompleted.Create(data, dataSize), flag));
            Callbacks[CallbackID.HTTPRequestHeadersReceived] = (data, dataSize) => httpRequestHeadersReceived.Add(CallbackStructures.HTTPRequestHeadersReceived.Create(data, dataSize));
            Callbacks[CallbackID.HTTPRequestDataReceived] = (data, dataSize) => httpRequestDataReceived.Add(CallbackStructures.HTTPRequestDataReceived.Create(data, dataSize));
        }

        public event ResultEvent<HTTPRequestCompleted> HTTPRequestCompleted;
        public event CallbackEvent<HTTPRequestHeadersReceived> HTTPRequestHeadersReceived;
        public event CallbackEvent<HTTPRequestDataReceived> HTTPRequestDataReceived;

        internal override void CheckIfUsableInternal()
        {
        }

        internal override void ReleaseManagedResources()
        {
            httpRequestCompleted = null;
            HTTPRequestCompleted = null;

            httpRequestHeadersReceived = null;
            HTTPRequestHeadersReceived = null;

            httpRequestDataReceived = null;
            HTTPRequestDataReceived = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(httpRequestCompleted, HTTPRequestCompleted);
            InvokeEvents(httpRequestHeadersReceived, HTTPRequestHeadersReceived);
            InvokeEvents(httpRequestDataReceived, HTTPRequestDataReceived);
        }

        public HTTPRequestHandle CreateHTTPRequest(HTTPMethod HTTPRequestMethod, string absoluteURL)
        {
            CheckIfUsable();

            using (NativeString nativeString = new NativeString(absoluteURL))
            {
                return new HTTPRequestHandle(NativeMethods.HTTP_CreateHTTPRequest((int)HTTPRequestMethod, nativeString.ToNativeAsUtf8()));
            }
        }

        public bool SetHTTPRequestContextValue(HTTPRequestHandle request, ulong contextValue)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_SetHTTPRequestContextValue(request.AsUInt32, contextValue);
        }

        public bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle request, uint timeoutSeconds)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_SetHTTPRequestNetworkActivityTimeout(request.AsUInt32, timeoutSeconds);
        }

        public bool SetHTTPRequestHeaderValue(HTTPRequestHandle request, string headerName, string headerValue)
        {
            CheckIfUsable();

            using (NativeString nativeHeaderName = new NativeString(headerName))
            {
                using (NativeString nativeHeaderValue = new NativeString(headerValue))
                {
                    return NativeMethods.HTTP_SetHTTPRequestHeaderValue(request.AsUInt32, nativeHeaderName.ToNativeAsUtf8(), nativeHeaderValue.ToNativeAsUtf8());
                }
            }
        }

        public bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle request, string paramName, string paramValue)
        {
            CheckIfUsable();

            using (NativeString nativeParamName = new NativeString(paramName))
            {
                using (NativeString nativeParamValue = new NativeString(paramValue))
                {
                    return NativeMethods.HTTP_SetHTTPRequestGetOrPostParameter(request.AsUInt32, nativeParamName.ToNativeAsUtf8(), nativeParamValue.ToNativeAsUtf8());
                }
            }
        }

        public bool SendHTTPRequest(HTTPRequestHandle request, out SteamAPICall callHandle)
        {
            CheckIfUsable();

            ulong tempCallHandle = 0;

            bool result = NativeMethods.HTTP_SendHTTPRequest(request.AsUInt32, ref tempCallHandle);

            callHandle = new SteamAPICall(tempCallHandle);

            return result;
        }

        public HTTPSendHTTPRequest SendHTTPRequest(HTTPRequestHandle request)
        {
            HTTPSendHTTPRequest result = new HTTPSendHTTPRequest();

            result.Result = SendHTTPRequest(request, out result.CallHandle);

            return result;
        }

        public bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle request, out SteamAPICall callHandle)
        {
            CheckIfUsable();

            ulong tempCallHandle = 0;

            bool result = NativeMethods.HTTP_SendHTTPRequestAndStreamResponse(request.AsUInt32, ref tempCallHandle);

            callHandle = new SteamAPICall(tempCallHandle);

            return result;
        }

        public HTTPSendHTTPRequestAndStreamResponse SendHTTPRequestAndStreamResponse(HTTPRequestHandle request)
        {
            HTTPSendHTTPRequestAndStreamResponse result = new HTTPSendHTTPRequestAndStreamResponse();

            result.Result = SendHTTPRequestAndStreamResponse(request, out result.CallHandle);

            return result;
        }

        public bool DeferHTTPRequest(HTTPRequestHandle request)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_DeferHTTPRequest(request.AsUInt32);
        }

        public bool PrioritizeHTTPRequest(HTTPRequestHandle request)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_PrioritizeHTTPRequest(request.AsUInt32);
        }

        public bool GetHTTPResponseHeaderSize(HTTPRequestHandle request, string headerName, out uint responseHeaderSize)
        {
            CheckIfUsable();

            responseHeaderSize = 0;

            using (NativeString nativeHeaderName = new NativeString(headerName))
            {
                return NativeMethods.HTTP_GetHTTPResponseHeaderSize(request.AsUInt32, nativeHeaderName.ToNativeAsUtf8(), ref responseHeaderSize);
            }
        }

        public HTTPGetHTTPResponseHeaderSize GetHTTPResponseHeaderSize(HTTPRequestHandle request, string headerName)
        {
            HTTPGetHTTPResponseHeaderSize result = new HTTPGetHTTPResponseHeaderSize();

            result.Result = GetHTTPResponseHeaderSize(request, headerName, out result.ResponseHeaderSize);

            return result;
        }

        public bool GetHTTPResponseHeaderValue(HTTPRequestHandle request, string headerName, System.IntPtr headerValueBuffer, uint bufferSize)
        {
            CheckIfUsable();

            using (NativeString nativeHeaderName = new NativeString(headerName))
            {
                return NativeMethods.HTTP_GetHTTPResponseHeaderValue(request.AsUInt32, nativeHeaderName.ToNativeAsUtf8(), headerValueBuffer, bufferSize);
            }
        }

        public bool GetHTTPResponseBodySize(HTTPRequestHandle request, out uint bodySize)
        {
            CheckIfUsable();

            bodySize = 0;

            return NativeMethods.HTTP_GetHTTPResponseBodySize(request.AsUInt32, ref bodySize);
        }
        public HTTPGetHTTPResponseBodySize GetHTTPResponseBodySize(HTTPRequestHandle request)
        {
            HTTPGetHTTPResponseBodySize result = new HTTPGetHTTPResponseBodySize();

            result.Result = GetHTTPResponseBodySize(request, out result.BodySize);

            return result;
        }

        public bool GetHTTPResponseBodyData(HTTPRequestHandle request, IntPtr bodyDataBuffer, uint bufferSize)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_GetHTTPResponseBodyData(request.AsUInt32, bodyDataBuffer, bufferSize);
        }

        public bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle request, uint offset, System.IntPtr bodyDataBuffer, uint bufferSize)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_GetHTTPStreamingResponseBodyData(request.AsUInt32, offset, bodyDataBuffer, bufferSize);
        }

        public bool ReleaseHTTPRequest(HTTPRequestHandle request)
        {
            CheckIfUsable();

            return NativeMethods.HTTP_ReleaseHTTPRequest(request.AsUInt32);
        }

        public bool GetHTTPDownloadProgressPct(HTTPRequestHandle request, out float percent)
        {
            CheckIfUsable();

            percent = 0;

            return NativeMethods.HTTP_GetHTTPDownloadProgressPct(request.AsUInt32, ref percent);
        }
        public HTTPGetHTTPDownloadProgressPct GetHTTPDownloadProgressPct(HTTPRequestHandle request)
        {
            HTTPGetHTTPDownloadProgressPct result = new HTTPGetHTTPDownloadProgressPct();

            result.Result = GetHTTPDownloadProgressPct(request, out result.Percent);

            return result;
        }


        public bool SetHTTPRequestRawPostBody(HTTPRequestHandle request, string contentType, System.IntPtr body, uint bodyLength)
        {
            CheckIfUsable();

            using (NativeString nativeContentType = new NativeString(contentType))
            {
                return NativeMethods.HTTP_SetHTTPRequestRawPostBody(request.AsUInt32, nativeContentType.ToNativeAsUtf8(), body, bodyLength);
            }
        }
    }
}
