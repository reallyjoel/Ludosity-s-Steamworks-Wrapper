#ifndef HTTP_h_interop_
#define HTTP_h_interop_

ManagedSteam_API u32 HTTP_CreateHTTPRequest( Enum eHTTPRequestMethod, PConstantUtf8String pchAbsoluteURL );

ManagedSteam_API bool HTTP_SetHTTPRequestContextValue( u32 hRequest, u64 ulContextValue );

ManagedSteam_API bool HTTP_SetHTTPRequestNetworkActivityTimeout( u32 hRequest, u32 unTimeoutSeconds );

ManagedSteam_API bool HTTP_SetHTTPRequestHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, PConstantUtf8String pchHeaderValue );

ManagedSteam_API bool HTTP_SetHTTPRequestGetOrPostParameter( u32 hRequest, PConstantUtf8String pchParamName, PConstantUtf8String pchParamValue );

ManagedSteam_API bool HTTP_SendHTTPRequest( u32 hRequest, u64 *pCallHandle );

ManagedSteam_API bool HTTP_SendHTTPRequestAndStreamResponse( u32 hRequest, u64 *pCallHandle );

ManagedSteam_API bool HTTP_DeferHTTPRequest( u32 hRequest );

ManagedSteam_API bool HTTP_PrioritizeHTTPRequest( u32 hRequest );

ManagedSteam_API bool HTTP_GetHTTPResponseHeaderSize( u32 hRequest, PConstantUtf8String pchHeaderName, u32 *unResponseHeaderSize );

ManagedSteam_API bool HTTP_GetHTTPResponseHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, uint8 *pHeaderValueBuffer, u32 unBufferSize );

ManagedSteam_API bool HTTP_GetHTTPResponseBodySize( u32 hRequest, u32 *unBodySize );

ManagedSteam_API bool HTTP_GetHTTPResponseBodyData( u32 hRequest, uint8 *pBodyDataBuffer, u32 unBufferSize );

ManagedSteam_API bool HTTP_GetHTTPStreamingResponseBodyData( u32 hRequest, u32 cOffset, uint8 *pBodyDataBuffer, u32 unBufferSize );

ManagedSteam_API bool HTTP_ReleaseHTTPRequest( u32 hRequest );

ManagedSteam_API bool HTTP_GetHTTPDownloadProgressPct( u32 hRequest, float *pflPercentOut );

ManagedSteam_API bool HTTP_SetHTTPRequestRawPostBody( u32 hRequest, PConstantUtf8String pchContentType, uint8 *pubBody, u32 unBodyLen );

#endif/*HTTP_h_interop_*/