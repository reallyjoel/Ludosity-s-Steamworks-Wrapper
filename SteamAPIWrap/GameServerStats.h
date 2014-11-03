#ifndef GameServerStats_h_interop_
#define GameServerStats_h_interop_

ManagedSteam_API void GameServerStats_RequestUserStats(SteamID steamIDUser);

ManagedSteam_API bool GameServerStats_GetUserStatInt(SteamID steamIDUser, PConstantString name, s32 *data);

ManagedSteam_API bool GameServerStats_GetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 *data);

ManagedSteam_API bool GameServerStats_GetUserAchievement(SteamID steamIDUser, PConstantString name, bool *achieved);

ManagedSteam_API bool GameServerStats_SetUserStatInt(SteamID steamIDUser, PConstantString name, s32 data);

ManagedSteam_API bool GameServerStats_SetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 data);

ManagedSteam_API bool GameServerStats_UpdateUserAvgRateStat(SteamID steamIDUser, PConstantString name, f32 countThisSession, f64 sessionLength);

ManagedSteam_API bool GameServerStats_SetUserAchievement(SteamID steamIDUser, PConstantString name);

ManagedSteam_API bool GameServerStats_ClearUserAchievement(SteamID steamIDUser, PConstantString name);

ManagedSteam_API void GameServerStats_StoreUserStats(SteamID steamIDUser);

#endif // GameServerStats_h_interop_