#ifndef SteamController_h_
#define SteamController_h_

#include "SteamController.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CSteamController : public CSingleton<CSteamController>
	{
	public:
		void SetSteamInterface(ISteamController *steamcontroller);

		bool Init( PConstantString absolutPathToControllerConfigVDF );
		bool Shutdown();

		void RunFrame();

		bool GetControllerState( u32 controllerIndex, PDataPointer state );

		void TriggerHapticPulse( u32 controllerIndex, Enum targetPad, u16 durationMicroSec );

		void SetOverrideMode( PConstantString mode );

	private:
		friend class CSingleton<CSteamController>;
		CSteamController();
		~CSteamController() {};
		DISALLOW_COPY_AND_ASSIGN(CSteamController);

		ISteamController *steamcontroller;
	};
};

#endif