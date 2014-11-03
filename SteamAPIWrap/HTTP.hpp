#ifndef HTTP_h_
#define HTTP_h_

#include "HTTP.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CHTTP : public CSingleton<CHTTP>
	{
		SW_ASYNC_RESULT(CHTTP, HTTPRequestCompleted_t, HTTPRequestCompleted);
		SW_CALLBACK(CHTTP, HTTPRequestHeadersReceived_t, HTTPRequestHeadersReceived);
		SW_CALLBACK(CHTTP, HTTPRequestDataReceived_t, HTTPRequestDataReceived);

	public:
		void SetSteamInterface(ISteamHTTP *http);
		void RunCallbackSizeCheck();

		u32 CreateHTTPRequest( Enum eHTTPRequestMethod, PConstantUtf8String pchAbsoluteURL );

		bool SetHTTPRequestContextValue( u32 hRequest, u64 ulContextValue );

		bool SetHTTPRequestNetworkActivityTimeout( u32 hRequest, u32 unTimeoutSeconds );

		bool SetHTTPRequestHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, PConstantUtf8String pchHeaderValue );

		bool SetHTTPRequestGetOrPostParameter( u32 hRequest, PConstantUtf8String pchParamName, PConstantUtf8String pchParamValue );

		bool SendHTTPRequest( u32 hRequest, u64 *pCallHandle );

		bool SendHTTPRequestAndStreamResponse( u32 hRequest, u64 *pCallHandle );

		bool DeferHTTPRequest( u32 hRequest );

		bool PrioritizeHTTPRequest( u32 hRequest );

		bool GetHTTPResponseHeaderSize( u32 hRequest, PConstantUtf8String pchHeaderName, u32 *unResponseHeaderSize );

		bool GetHTTPResponseHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, uint8 *pHeaderValueBuffer, u32 unBufferSize );

		bool GetHTTPResponseBodySize( u32 hRequest, u32 *unBodySize );

		bool GetHTTPResponseBodyData( u32 hRequest, uint8 *pBodyDataBuffer, u32 unBufferSize );

		bool GetHTTPStreamingResponseBodyData( u32 hRequest, u32 cOffset, uint8 *pBodyDataBuffer, u32 unBufferSize );

		bool ReleaseHTTPRequest( u32 hRequest );

		bool GetHTTPDownloadProgressPct( u32 hRequest, float *pflPercentOut );

		bool SetHTTPRequestRawPostBody( u32 hRequest, PConstantUtf8String pchContentType, uint8 *pubBody, u32 unBodyLen );

	private:
		friend class CSingleton<CHTTP>;
		CHTTP();
		~CHTTP()	{}
		DISALLOW_COPY_AND_ASSIGN(CHTTP);

		ISteamHTTP *http;
	};
};

#endif/*HTTP_h_*/