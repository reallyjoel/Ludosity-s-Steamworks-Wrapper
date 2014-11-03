// This header is used by the interop converter tool.
// This header will setup some typedefs and structures that will look different in the 
// actual code. Their purpose is to make the manual work after an automatic conversion simpler.

// This symbol is only defined when the automatic interop conversion tool is running.
#define INTEROP_CONVERSION
#define WIN32

#define ManagedSteam_API 
#define ManagedSteam_API_Lite 

#include "Types.h"

#include "Cloud.h"
#include "Services.h"
#include "Stats.h"
#include "User.h"
#include "Friends.h"
#include "MatchMaking.h"
#include "MatchmakingServers.h"
#include "MatchmakingServerListResponse.h"
#include "MatchmakingPingResponse.h"
#include "MatchmakingPlayersResponse.h"
#include "MatchMakingRulesResponse.h"
#include "GameServer.h"
#include "GameServerStats.h"
#include "Networking.h"
#include "ServicesGameServer.h"
#include "Utils.h"