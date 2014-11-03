#include "Precompiled.hpp"
#include "HTTP.hpp"

#include "MemoryHelpers.h"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CHTTP * CSingleton<CHTTP>::instance = nullptr;

	CHTTP::CHTTP()
		: nativeHTTPRequestHeadersReceivedCallback(this, &CHTTP::OnHTTPRequestHeadersReceived)
		, nativeHTTPRequestDataReceivedCallback(this, &CHTTP::OnHTTPRequestDataReceived)
		, http(nullptr)
	{
	}

	void CHTTP::SetSteamInterface(ISteamHTTP *http)
	{
		this->http = http;
	}

	void CHTTP::RunCallbackSizeCheck()
	{
		HTTPRequestHeadersReceived_t* httpRequestHeadersReceived = new HTTPRequestHeadersReceived_t();
		OnHTTPRequestHeadersReceived(httpRequestHeadersReceived);
		delete httpRequestHeadersReceived;

		HTTPRequestDataReceived_t* httpRequestDataReceived = new HTTPRequestDataReceived_t();
		OnHTTPRequestDataReceived(httpRequestDataReceived);
		delete httpRequestDataReceived;

		HTTPRequestCompleted_t* httpRequestCompleted = new HTTPRequestCompleted_t();
		OnHTTPRequestCompleted(httpRequestCompleted, false);
		delete httpRequestCompleted;
	}

	u32 CHTTP::CreateHTTPRequest( Enum eHTTPRequestMethod, PConstantUtf8String pchAbsoluteURL )
	{
		return http->CreateHTTPRequest( static_cast<EHTTPMethod>(eHTTPRequestMethod), reinterpret_cast<const char*>(pchAbsoluteURL) );
	}

	bool CHTTP::SetHTTPRequestContextValue( u32 hRequest, u64 ulContextValue )
	{
		return http->SetHTTPRequestContextValue( hRequest, ulContextValue );
	}

	bool CHTTP::SetHTTPRequestNetworkActivityTimeout( u32 hRequest, u32 unTimeoutSeconds )
	{
		return http->SetHTTPRequestNetworkActivityTimeout( hRequest, unTimeoutSeconds );
	}

	bool CHTTP::SetHTTPRequestHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, PConstantUtf8String pchHeaderValue )
	{
		return http->SetHTTPRequestHeaderValue( hRequest, reinterpret_cast<const char*>(pchHeaderName), reinterpret_cast<const char*>(pchHeaderValue) );
	}

	bool CHTTP::SetHTTPRequestGetOrPostParameter( u32 hRequest, PConstantUtf8String pchParamName, PConstantUtf8String pchParamValue )
	{
		return http->SetHTTPRequestGetOrPostParameter( hRequest, reinterpret_cast<const char*>(pchParamName), reinterpret_cast<const char*>(pchParamValue) );
	}

	bool CHTTP::SendHTTPRequest( u32 hRequest, u64 *pCallHandle )
	{
		SteamAPICall_t hSteamAPICall;
		bool result = http->SendHTTPRequest(hRequest, &hSteamAPICall);

		resultHTTPRequestCompleted.Set( hSteamAPICall, this, &CHTTP::OnHTTPRequestCompleted);
		pCallHandle = &hSteamAPICall;
		return result;
	}

	bool CHTTP::SendHTTPRequestAndStreamResponse( u32 hRequest, u64 *pCallHandle )
	{
		SteamAPICall_t hSteamAPICall;
		bool result = http->SendHTTPRequestAndStreamResponse(hRequest, &hSteamAPICall);

		resultHTTPRequestCompleted.Set( hSteamAPICall, this, &CHTTP::OnHTTPRequestCompleted);
		pCallHandle = &hSteamAPICall;
		return result;
	}

	bool CHTTP::DeferHTTPRequest( u32 hRequest )
	{
		return http->DeferHTTPRequest( hRequest );
	}

	bool CHTTP::PrioritizeHTTPRequest( u32 hRequest )
	{
		return http->PrioritizeHTTPRequest( hRequest );
	}

	bool CHTTP::GetHTTPResponseHeaderSize( u32 hRequest, PConstantUtf8String pchHeaderName, u32 *unResponseHeaderSize )
	{
		return http->GetHTTPResponseHeaderSize( hRequest, reinterpret_cast<const char*>(pchHeaderName), unResponseHeaderSize );
	}

	bool CHTTP::GetHTTPResponseHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, uint8 *pHeaderValueBuffer, u32 unBufferSize )
	{
		return http->GetHTTPResponseHeaderValue( hRequest, reinterpret_cast<const char*>(pchHeaderName), pHeaderValueBuffer, unBufferSize );
	}

	bool CHTTP::GetHTTPResponseBodySize( u32 hRequest, u32 *unBodySize )
	{
		return http->GetHTTPResponseBodySize( hRequest, unBodySize );
	}

	bool CHTTP::GetHTTPResponseBodyData( u32 hRequest, uint8 *pBodyDataBuffer, u32 unBufferSize )
	{
		return http->GetHTTPResponseBodyData( hRequest, pBodyDataBuffer, unBufferSize );
	}

	bool CHTTP::GetHTTPStreamingResponseBodyData( u32 hRequest, u32 cOffset, uint8 *pBodyDataBuffer, u32 unBufferSize )
	{
		return http->GetHTTPStreamingResponseBodyData( hRequest, cOffset, pBodyDataBuffer, unBufferSize );
	}

	bool CHTTP::ReleaseHTTPRequest( u32 hRequest )
	{
		return http->ReleaseHTTPRequest( hRequest );
	}

	bool CHTTP::GetHTTPDownloadProgressPct( u32 hRequest, float *pflPercentOut )
	{
		return http->GetHTTPDownloadProgressPct( hRequest, pflPercentOut );
	}

	bool CHTTP::SetHTTPRequestRawPostBody( u32 hRequest, PConstantUtf8String pchContentType, uint8 *pubBody, u32 unBodyLen )
	{
		return http->SetHTTPRequestRawPostBody( hRequest, reinterpret_cast<const char*>(pchContentType), pubBody, unBodyLen );
	}
};

ManagedSteam_API u32 HTTP_CreateHTTPRequest( Enum eHTTPRequestMethod, PConstantUtf8String pchAbsoluteURL )
{
	return CHTTP::Instance().CreateHTTPRequest( static_cast<EHTTPMethod>(eHTTPRequestMethod), pchAbsoluteURL );
}

ManagedSteam_API bool HTTP_SetHTTPRequestContextValue( u32 hRequest, u64 ulContextValue )
{
	return CHTTP::Instance().SetHTTPRequestContextValue( hRequest, ulContextValue );
}

ManagedSteam_API bool HTTP_SetHTTPRequestNetworkActivityTimeout( u32 hRequest, u32 unTimeoutSeconds )
{
	return CHTTP::Instance().SetHTTPRequestNetworkActivityTimeout( hRequest, unTimeoutSeconds );
}

ManagedSteam_API bool HTTP_SetHTTPRequestHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, PConstantUtf8String pchHeaderValue )
{
	return CHTTP::Instance().SetHTTPRequestHeaderValue( hRequest, pchHeaderName, pchHeaderValue );
}

ManagedSteam_API bool HTTP_SetHTTPRequestGetOrPostParameter( u32 hRequest, PConstantUtf8String pchParamName, PConstantUtf8String pchParamValue )
{
	return CHTTP::Instance().SetHTTPRequestGetOrPostParameter( hRequest, pchParamName, pchParamValue );
}

ManagedSteam_API bool HTTP_SendHTTPRequest( u32 hRequest, u64 *pCallHandle )
{
	return CHTTP::Instance().SendHTTPRequest(hRequest, pCallHandle);
}

ManagedSteam_API bool HTTP_SendHTTPRequestAndStreamResponse( u32 hRequest, u64 *pCallHandle )
{
	return CHTTP::Instance().SendHTTPRequestAndStreamResponse(hRequest, pCallHandle);
}

ManagedSteam_API bool HTTP_DeferHTTPRequest( u32 hRequest )
{
	return CHTTP::Instance().DeferHTTPRequest( hRequest );
}

ManagedSteam_API bool HTTP_PrioritizeHTTPRequest( u32 hRequest )
{
	return CHTTP::Instance().PrioritizeHTTPRequest( hRequest );
}

ManagedSteam_API bool HTTP_GetHTTPResponseHeaderSize( u32 hRequest, PConstantUtf8String pchHeaderName, u32 *unResponseHeaderSize )
{
	return CHTTP::Instance().GetHTTPResponseHeaderSize( hRequest, pchHeaderName, unResponseHeaderSize );
}

ManagedSteam_API bool HTTP_GetHTTPResponseHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, uint8 *pHeaderValueBuffer, u32 unBufferSize )
{
	return CHTTP::Instance().GetHTTPResponseHeaderValue( hRequest, pchHeaderName, pHeaderValueBuffer, unBufferSize );
}

ManagedSteam_API bool HTTP_GetHTTPResponseBodySize( u32 hRequest, u32 *unBodySize )
{
	return CHTTP::Instance().GetHTTPResponseBodySize( hRequest, unBodySize );
}

ManagedSteam_API bool HTTP_GetHTTPResponseBodyData( u32 hRequest, uint8 *pBodyDataBuffer, u32 unBufferSize )
{
	return CHTTP::Instance().GetHTTPResponseBodyData( hRequest, pBodyDataBuffer, unBufferSize );
}

ManagedSteam_API bool HTTP_GetHTTPStreamingResponseBodyData( u32 hRequest, u32 cOffset, uint8 *pBodyDataBuffer, u32 unBufferSize )
{
	return CHTTP::Instance().GetHTTPStreamingResponseBodyData( hRequest, cOffset, pBodyDataBuffer, unBufferSize );
}

ManagedSteam_API bool HTTP_ReleaseHTTPRequest( u32 hRequest )
{
	return CHTTP::Instance().ReleaseHTTPRequest( hRequest );
}

ManagedSteam_API bool HTTP_GetHTTPDownloadProgressPct( u32 hRequest, float *pflPercentOut )
{
	return CHTTP::Instance().GetHTTPDownloadProgressPct( hRequest, pflPercentOut );
}

ManagedSteam_API bool HTTP_SetHTTPRequestRawPostBody( u32 hRequest, PConstantUtf8String pchContentType, uint8 *pubBody, u32 unBodyLen )
{
	return CHTTP::Instance().SetHTTPRequestRawPostBody( hRequest, pchContentType, pubBody, unBodyLen );
}