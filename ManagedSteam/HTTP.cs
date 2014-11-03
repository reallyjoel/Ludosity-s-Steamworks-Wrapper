using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface IHTTP
    {
        event ResultEvent<HTTPRequestCompleted> HTTPRequestCompleted;
        event CallbackEvent<HTTPRequestHeadersReceived> HTTPRequestHeadersReceived;
        event CallbackEvent<HTTPRequestDataReceived> HTTPRequestDataReceived;

        /// <summary>
        /// Initializes a new HTTP request, returning a handle to use in further operations on it.  Requires
        /// the method (GET or POST) and the absolute URL for the request.  Only http requests (ie, not https) are
        /// currently supported, so this string must start with http:// or https:// and should look like http://store.steampowered.com/app/250/ 
        /// or such.
        /// </summary>
        /// <param name="eHTTPRequestMethod"></param>
        /// <param name="pchAbsoluteURL"></param>
        /// <returns></returns>
        HTTPRequestHandle CreateHTTPRequest(HTTPMethod HTTPRequestMethod, string absoluteURL);
        
        /// <summary>
        /// Set a context value for the request, which will be returned in the HTTPRequestCompleted_t callback after
        /// sending the request.  This is just so the caller can easily keep track of which callbacks go with which request data.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="ulContextValue"></param>
        /// <returns></returns>
        bool SetHTTPRequestContextValue(HTTPRequestHandle request, ulong contextValue);
        
        /// <summary>
        /// Set a timeout in seconds for the HTTP request, must be called prior to sending the request.  Default
        /// timeout is 60 seconds if you don't call this.  Returns false if the handle is invalid, or the request
        /// has already been sent.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="unTimeoutSeconds"></param>
        /// <returns></returns>
        bool SetHTTPRequestNetworkActivityTimeout( HTTPRequestHandle request, uint timeoutSeconds );
        
        /// <summary>
        /// Set a request header value for the request, must be called prior to sending the request.  Will 
        /// return false if the handle is invalid or the request is already sent.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pchHeaderName"></param>
        /// <param name="pchHeaderValue"></param>
        /// <returns></returns>
        bool SetHTTPRequestHeaderValue(HTTPRequestHandle request, string headerName, string headerValue);
        
        /// <summary>
        /// Set a GET or POST parameter value on the request, which is set will depend on the EHTTPMethod specified
        /// when creating the request.  Must be called prior to sending the request.  Will return false if the 
        /// handle is invalid or the request is already sent.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pchParamName"></param>
        /// <param name="pchParamValue"></param>
        /// <returns></returns>
        bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle request, string paramName, string paramValue);
        
        /// <summary>
        /// Sends the HTTP request, will return false on a bad handle, otherwise use SteamCallHandle to wait on
        /// asynchronous response via callback.
        /// 
        /// Note: If the user is in offline mode in Steam, then this will add a only-if-cached cache-control 
        /// header and only do a local cache lookup rather than sending any actual remote request.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pCallHandle"></param>
        /// <returns></returns>
        bool SendHTTPRequest(HTTPRequestHandle request, out SteamAPICall callHandle);
        HTTPSendHTTPRequest SendHTTPRequest(HTTPRequestHandle request);

        /// <summary>
        /// Sends the HTTP request, will return false on a bad handle, otherwise use SteamCallHandle to wait on
        /// asynchronous response via callback for completion, and listen for HTTPRequestHeadersReceived_t and 
        /// HTTPRequestDataReceived_t callbacks while streaming.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pCallHandle"></param>
        /// <returns></returns>
        bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle request, out SteamAPICall callHandle);
        HTTPSendHTTPRequestAndStreamResponse SendHTTPRequestAndStreamResponse(HTTPRequestHandle request);
        /// <summary>
        /// Defers a request you have sent, the actual HTTP client code may have many requests queued, and this will move
        /// the specified request to the tail of the queue.  Returns false on invalid handle, or if the request is not yet sent.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <returns></returns>
        bool DeferHTTPRequest(HTTPRequestHandle request);
        
        /// <summary>
        /// Prioritizes a request you have sent, the actual HTTP client code may have many requests queued, and this will move
        /// the specified request to the head of the queue.  Returns false on invalid handle, or if the request is not yet sent.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <returns></returns>
        bool PrioritizeHTTPRequest(HTTPRequestHandle request);
        
        /// <summary>
        /// Checks if a response header is present in a HTTP response given a handle from HTTPRequestCompleted_t, also 
        /// returns the size of the header value if present so the caller and allocate a correctly sized buffer for
        /// GetHTTPResponseHeaderValue.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pchHeaderName"></param>
        /// <param name="unResponseHeaderSize"></param>
        /// <returns></returns>
        bool GetHTTPResponseHeaderSize(HTTPRequestHandle request, string headerName, out uint responseHeaderSize);
        HTTPGetHTTPResponseHeaderSize GetHTTPResponseHeaderSize(HTTPRequestHandle request, string headerName);

        /// <summary>
        /// Gets header values from a HTTP response given a handle from HTTPRequestCompleted_t, will return false if the
        /// header is not present or if your buffer is too small to contain it's value.  You should first call 
        /// BGetHTTPResponseHeaderSize to check for the presence of the header and to find out the size buffer needed.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pchHeaderName"></param>
        /// <param name="pHeaderValueBuffer"></param>
        /// <param name="unBufferSize"></param>
        /// <returns></returns>
        bool GetHTTPResponseHeaderValue(HTTPRequestHandle request, string headerName, System.IntPtr headerValueBuffer, uint bufferSize);

        /// <summary>
        /// Gets the size of the body data from a HTTP response given a handle from HTTPRequestCompleted_t, will return false if the 
        /// handle is invalid.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="unBodySize"></param>
        /// <returns></returns>
        bool GetHTTPResponseBodySize(HTTPRequestHandle request, out uint bodySize);
        HTTPGetHTTPResponseBodySize GetHTTPResponseBodySize(HTTPRequestHandle request);

        /// <summary>
        /// Gets the body data from a HTTP response given a handle from HTTPRequestCompleted_t, will return false if the 
        /// handle is invalid or is to a streaming response, or if the provided buffer is not the correct size.  Use BGetHTTPResponseBodySize first to find out
        /// the correct buffer size to use.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pBodyDataBuffer"></param>
        /// <param name="unBufferSize"></param>
        /// <returns></returns>
        bool GetHTTPResponseBodyData(HTTPRequestHandle request, System.IntPtr bodyDataBuffer, uint bufferSize);

        /// <summary>
        /// Gets the body data from a streaming HTTP response given a handle from HTTPRequestCompleted_t. Will return false if the 
        /// handle is invalid or is to a non-streaming response (meaning it wasn't sent with SendHTTPRequestAndStreamResponse), or if the buffer size and offset 
        /// do not match the size and offset sent in HTTPRequestDataReceived_t.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="cOffset"></param>
        /// <param name="pBodyDataBuffer"></param>
        /// <param name="unBufferSize"></param>
        /// <returns></returns>
        bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle request, uint offset, System.IntPtr bodyDataBuffer, uint bufferSize);

        /// <summary>
        /// Releases an HTTP response handle, should always be called to free resources after receiving a HTTPRequestCompleted_t
        /// callback and finishing using the response.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <returns></returns>
        bool ReleaseHTTPRequest(HTTPRequestHandle request);
        
        /// <summary>
        /// Gets progress on downloading the body for the request.  This will be zero unless a response header has already been
        /// received which included a content-length field.  For responses that contain no content-length it will report
        /// zero for the duration of the request as the size is unknown until the connection closes.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pflPercentOut"></param>
        /// <returns></returns>
        bool GetHTTPDownloadProgressPct(HTTPRequestHandle request, out float percent);
        HTTPGetHTTPDownloadProgressPct GetHTTPDownloadProgressPct(HTTPRequestHandle request);

        /// <summary>
        /// Sets the body for an HTTP Post request.  Will fail and return false on a GET request, and will fail if POST params
        /// have already been set for the request.  Setting this raw body makes it the only contents for the post, the pchContentType
        /// parameter will set the content-type header for the request so the server may know how to interpret the body.
        /// </summary>
        /// <param name="hRequest"></param>
        /// <param name="pchContentType"></param>
        /// <param name="pubBody"></param>
        /// <param name="unBodyLen"></param>
        /// <returns></returns>
        bool SetHTTPRequestRawPostBody(HTTPRequestHandle request, string contentType, System.IntPtr body, uint bodyLength);
    }

    public struct HTTPSendHTTPRequest
    {
        public bool Result;
        public SteamAPICall CallHandle;
    }

    public struct HTTPSendHTTPRequestAndStreamResponse
    {
        public bool Result;
        public SteamAPICall CallHandle;
    }

    public struct HTTPGetHTTPResponseHeaderSize
    {
        public bool Result;
        public uint ResponseHeaderSize;
    }

    public struct HTTPGetHTTPResponseBodySize
    {
        public bool Result;
        public uint BodySize;
    }


    public struct HTTPGetHTTPDownloadProgressPct
    {
        public bool Result;
        public float Percent;
    }
}
