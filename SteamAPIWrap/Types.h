#ifndef Types_h_
#define Types_h_
// Main header for all types used in SteamAPIWrap

#include "steamtypes.h"

typedef uint8 u8;
typedef int8 s8;

typedef int16 s16;
typedef uint16 u16;
typedef int32 s32;
typedef uint32 u32;
typedef int64 s64;
typedef uint64 u64;

typedef intp sptr;
typedef uintp uptr;

typedef float f32;
typedef double f64;

typedef s32 Enum;

typedef char * PString;
typedef void * PUtf8String;
typedef char * PAnsiString;

typedef const char * PConstantString;
typedef const void * PConstantUtf8String;
typedef const char * PConstantAnsiString;

typedef const void * PConstantDataPointer;
typedef void * PDataPointer;

typedef u64 UGCHandle;
typedef u64 UGCQueryHandle;
typedef u64 SteamID;
typedef u64 SteamLeaderboard;
typedef u64 SteamLeaderboardEntries;
typedef u64 PublishedFileUpdateHandle;
typedef u64 PublishedFileId;
typedef u64 GameID;
typedef u32 AppID;
typedef u32 AuthTicket;
typedef u32 NetListenSocket;
typedef u32 NetSocket;
typedef u32 AccountID;


// Matchmaking stuff
typedef uptr ServerListRequest;
typedef s32 ServerQuery;


#ifdef WIN32
#define SW_MANAGED_CALLBACK_TYPE(returnType, callbackName, parameters) \
	typedef returnType (__stdcall *callbackName)parameters
#else
#define SW_MANAGED_CALLBACK_TYPE(returnType, callbackName, parameters) \
	typedef returnType (*callbackName)parameters __attribute__((stdcall))
#endif

SW_MANAGED_CALLBACK_TYPE(void, ManagedCallback, (Enum id, PConstantDataPointer data, s32 dataSize));
SW_MANAGED_CALLBACK_TYPE(void, ManagedResultCallback, (Enum id, PConstantDataPointer data, s32 dataSize, bool ioFailure));

SW_MANAGED_CALLBACK_TYPE(void, MatchmakingServerListResponse_ServerRespondedCallback, (uptr sender, uptr request, s32 server));
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingServerListResponse_ServerFailedToRespond, (uptr sender, uptr request, s32 server));
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingServerListResponse_RefreshComplete, (uptr sender, uptr request, Enum response));

SW_MANAGED_CALLBACK_TYPE(void, MatchmakingPingResponse_ServerRespondedCallback, (uptr sender, PDataPointer server, s32 serverSize));
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingPingResponse_ServerFailedToRespond, (uptr sender));

SW_MANAGED_CALLBACK_TYPE(void, MatchmakingPlayersResponse_AddPlayerToList, (uptr sender, PConstantDataPointer name, s32 score, f32 timePlayed)); 
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingPlayersResponse_PlayersFailedToRespond, (uptr sender));
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingPlayersResponse_PlayersRefreshComplete, (uptr sender));

SW_MANAGED_CALLBACK_TYPE(void, MatchmakingRulesResponse_RulesResponded, (uptr sender, PConstantDataPointer key, PConstantDataPointer value));
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingRulesResponse_RulesFailedToRespond, (uptr sender));
SW_MANAGED_CALLBACK_TYPE(void, MatchmakingRulesResponse_RulesRefreshComplete, (uptr sender));

/*
#ifndef INTEROP_CONVERSION
#define nullptr NULL
#endif
*/


#endif // Types_h_