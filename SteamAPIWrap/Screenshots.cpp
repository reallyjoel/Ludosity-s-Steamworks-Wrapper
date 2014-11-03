#include "Precompiled.hpp"
#include "Screenshots.hpp"

#include "MemoryHelpers.h"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CScreenshots * CSingleton<CScreenshots>::instance = nullptr;

	CScreenshots::CScreenshots()
		: nativeScreenshotReadyCallback(this, &CScreenshots::OnScreenshotReady)
		, nativeScreenshotRequestedCallback(this, &CScreenshots::OnScreenshotRequested)
		, screenshots(nullptr)
	{
	}

	void CScreenshots::SetSteamInterface(ISteamScreenshots *screenshots)
	{
		this->screenshots = screenshots;
	}

	void CScreenshots::RunCallbackSizeCheck()
	{
		ScreenshotReady_t* screenshotReady = new ScreenshotReady_t();
		OnScreenshotReady(screenshotReady);
		delete screenshotReady;

		ScreenshotRequested_t* screenshotRequested = new ScreenshotRequested_t();
		OnScreenshotRequested(screenshotRequested);
		delete screenshotRequested;
	}

	u32	CScreenshots::WriteScreenshot(PDataPointer pubRGB, u32 cubRGB, s32 nWidth, s32 nHeight)
	{
		return screenshots->WriteScreenshot(pubRGB, cubRGB, nWidth, nHeight);
	}
	
	u32	CScreenshots::AddScreenshotToLibrary( PConstantString pchFilename, PConstantString pchThumbnailFilename, s32 nWidth, s32 nHeight )
	{
		return screenshots->AddScreenshotToLibrary(pchFilename, pchThumbnailFilename, nWidth, nHeight);
	}
	
	void CScreenshots::TriggerScreenshot()
	{
		screenshots->TriggerScreenshot();
	}
	
	void CScreenshots::HookScreenshots( bool bHook )
	{
		screenshots->HookScreenshots( bHook );
	}
	
	bool CScreenshots::SetLocation( u32 hScreenshot, PConstantString pchLocation )
	{
		return screenshots->SetLocation( static_cast<ScreenshotHandle>(hScreenshot), pchLocation );
	}
	
	bool CScreenshots::TagUser( u32 hScreenshot, u64 steamID )
	{
		return screenshots->TagUser( static_cast<ScreenshotHandle>(hScreenshot), steamID );
	}
	
	bool CScreenshots::TagPublishedFile( u32 hScreenshot, u64 unPublishedFileID )
	{
		return screenshots->TagPublishedFile( static_cast<ScreenshotHandle>(hScreenshot), unPublishedFileID );
	}
};


ManagedSteam_API u32 Screenshots_WriteScreenshot(PDataPointer pubRGB, u32 cubRGB, s32 nWidth, s32 nHeight)
{
	return CScreenshots::Instance().WriteScreenshot(pubRGB, cubRGB, nWidth, nHeight);
}

ManagedSteam_API u32 Screenshots_AddScreenshotToLibrary( PConstantString pchFilename, PConstantString pchThumbnailFilename, s32 nWidth, s32 nHeight )
{
	return CScreenshots::Instance().AddScreenshotToLibrary( pchFilename, pchThumbnailFilename, nWidth, nHeight );
}

ManagedSteam_API void Screenshots_TriggerScreenshot()
{
	CScreenshots::Instance().TriggerScreenshot();
}

ManagedSteam_API void Screenshots_HookScreenshots( bool bHook )
{
	CScreenshots::Instance().HookScreenshots( bHook );
}

ManagedSteam_API bool Screenshots_SetLocation( u32 hScreenshot, PConstantString pchLocation )
{
	return CScreenshots::Instance().SetLocation( hScreenshot, pchLocation );
}

ManagedSteam_API bool Screenshots_TagUser( u32 hScreenshot, u64 steamID )
{
	return CScreenshots::Instance().TagUser( hScreenshot, steamID );
}

ManagedSteam_API bool Screenshots_TagPublishedFile( u32 hScreenshot, u64 unPublishedFileID )
{
	return CScreenshots::Instance().TagPublishedFile( hScreenshot, unPublishedFileID );
}