#ifndef Precompiled_h_
#define Precompiled_h_


// ManagedSteam_API_Lite means that the function is exposed in both full and Lite mode
// ManagedSteam_API means that the function is only exposed in full mode.


#ifdef WIN32

	#ifdef STEAMAPIWRAP_LITE
		#define ManagedSteam_API 
		#define ManagedSteam_API_Lite extern "C" __declspec( dllexport )
	#else
		#define ManagedSteam_API extern "C" __declspec( dllexport )
		#define ManagedSteam_API_Lite ManagedSteam_API
	#endif

#else
	#ifdef STEAMAPIWRAP_LITE
		#define ManagedSteam_API 
		#define ManagedSteam_API_Lite extern "C" __attribute__ ((visibility("default"))) 
	#else
		#define ManagedSteam_API extern "C" __attribute__ ((visibility("default"))) 
		#define ManagedSteam_API_Lite ManagedSteam_API
	#endif
	
#endif

// Global warning disable
#ifdef WIN32
	#pragma warning(disable: 4355) // 'this' : used in base member initializer list
#endif



// Disable warnings before including steam headers
#ifdef WIN32
	#pragma warning(push)
	#pragma warning(disable : 4127) // conditional expression is constant

#else
#endif

#include "steam_api.h"
#include "steam_gameserver.h"

#ifdef WIN32
	#pragma warning(pop)
#else

#endif

#include "Macros.hpp"
#include "Types.h"

#include "ErrorCodes.hpp"


#endif // Precompiled_h_