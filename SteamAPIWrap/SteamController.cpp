#include "Precompiled.hpp"
#include "SteamController.hpp"

#include "MemoryHelpers.h"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CSteamController * CSingleton<CSteamController>::instance = nullptr;

	CSteamController::CSteamController()
		: steamcontroller(nullptr)
	{
	}

	void CSteamController::SetSteamInterface(ISteamController *steamcontroller)
	{
		this->steamcontroller = steamcontroller;
	}

	bool CSteamController::Init( PConstantString absolutPathToControllerConfigVDF )
	{
		return steamcontroller->Init( absolutPathToControllerConfigVDF );
	}

	bool CSteamController::Shutdown()
	{
		return steamcontroller->Shutdown();
	}

	void CSteamController::RunFrame()
	{
		steamcontroller->RunFrame();
	}

	bool CSteamController::GetControllerState( u32 controllerIndex, PDataPointer state )
	{
		return steamcontroller->GetControllerState( controllerIndex, reinterpret_cast<SteamControllerState_t *>(state));
	}

	void CSteamController::TriggerHapticPulse( u32 controllerIndex, Enum targetPad, u16 durationMicroSec )
	{
		steamcontroller->TriggerHapticPulse(controllerIndex, static_cast<ESteamControllerPad>(targetPad), durationMicroSec);
	}

	void CSteamController::SetOverrideMode( PConstantString mode )
	{
		steamcontroller->SetOverrideMode(mode);
	}
};

ManagedSteam_API bool SteamController_Init( PConstantString absolutPathToControllerConfigVDF )
{
	return CSteamController::Instance().Init( absolutPathToControllerConfigVDF );
}

ManagedSteam_API bool SteamController_Shutdown()
{
	return CSteamController::Instance().Shutdown();
}

ManagedSteam_API void SteamController_RunFrame()
{
	CSteamController::Instance().RunFrame();
}

ManagedSteam_API bool SteamController_GetControllerState( u32 controllerIndex, PDataPointer state )
{
	return CSteamController::Instance().GetControllerState( controllerIndex, state );
}

ManagedSteam_API void SteamController_TriggerHapticPulse( u32 controllerIndex, Enum targetPad, u16 durationMicroSec )
{
	CSteamController::Instance().TriggerHapticPulse( controllerIndex, targetPad, durationMicroSec );
}

ManagedSteam_API void SteamController_SetOverrideMode( PConstantString mode )
{
	CSteamController::Instance().SetOverrideMode( mode );
}