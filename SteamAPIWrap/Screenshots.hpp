#ifndef _Screenshots_h_
#define _Screenshots_h_

#include "Screenshots.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CScreenshots : public CSingleton<CScreenshots>
	{
		SW_CALLBACK(CScreenshots, ScreenshotReady_t, ScreenshotReady);
		SW_CALLBACK(CScreenshots, ScreenshotRequested_t, ScreenshotRequested);

	public:
		void SetSteamInterface(ISteamScreenshots *screenshots);
		void RunCallbackSizeCheck();

		u32 WriteScreenshot(PDataPointer pubRGB, u32 cubRGB, s32 nWidth, s32 nHeight);

		u32 AddScreenshotToLibrary( PConstantString pchFilename, PConstantString pchThumbnailFilename, s32 nWidth, s32 nHeight );

		void TriggerScreenshot();

		void HookScreenshots( bool bHook );

		bool SetLocation( u32 hScreenshot, PConstantString pchLocation );

		bool TagUser( u32 hScreenshot, u64 steamID );

		bool TagPublishedFile( u32 hScreenshot, u64 unPublishedFileID );
	private:
		friend class CSingleton<CScreenshots>;
		CScreenshots();
		~CScreenshots()	{}
		DISALLOW_COPY_AND_ASSIGN(CScreenshots);

		ISteamScreenshots *screenshots;
	};
};

#endif/*_Screenshots_h_*/