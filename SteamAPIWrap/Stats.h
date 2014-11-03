#ifndef Stats_h_interop_
#define Stats_h_interop_


//////////////////////////////////////////////////////////////////////////
// Stats and achievements
//////////////////////////////////////////////////////////////////////////

ManagedSteam_API_Lite bool Stats_RequestCurrentStats();

ManagedSteam_API_Lite bool Stats_GetStatInt(PConstantString name, s32 *data);

ManagedSteam_API_Lite bool Stats_GetStatFloat(PConstantString name, float *data);

ManagedSteam_API_Lite bool Stats_SetStatInt(PConstantString name, s32 data);

ManagedSteam_API_Lite bool Stats_SetStatFloat(PConstantString name, float data);

ManagedSteam_API_Lite bool Stats_UpdateAverageRateStat(PConstantString name, float countThisSession, double sessionLength);

ManagedSteam_API bool Stats_GetAchievement(PConstantString name, bool *achieved);

ManagedSteam_API bool Stats_SetAchievement(PConstantString name);

ManagedSteam_API bool Stats_ClearAchievement(PConstantString name);

ManagedSteam_API bool Stats_GetAchievementAndUnlockTime(PConstantString name, bool *achieved, u32 *unlockTime);

ManagedSteam_API_Lite bool Stats_StoreStats();

ManagedSteam_API s32 Stats_GetAchievementIcon(PConstantString name);

ManagedSteam_API PConstantString Stats_GetAchievementDisplayAttribute(PConstantString name, PConstantString key);

ManagedSteam_API bool Stats_IndicateAchievementProgress(PConstantString name, u32 currentProgress, u32 maxProgess);

ManagedSteam_API_Lite void Stats_RequestUserStats(SteamID steamID);
ManagedSteam_API_Lite bool Stats_GetUserStatInt(SteamID steamID, PConstantString name, s32 *data);
ManagedSteam_API_Lite bool Stats_GetUserStatFloat(SteamID steamID, PConstantString name, float *data);
ManagedSteam_API bool Stats_GetUserAchievement(SteamID steamID, PConstantString name, bool *achieved);
ManagedSteam_API bool Stats_GetUserAchievementAndUnlockTime(SteamID steamID, PConstantString name, bool *achieved, u32 *unlockTime);
ManagedSteam_API_Lite bool Stats_ResetAllStats(bool achievementsToo);


//////////////////////////////////////////////////////////////////////////
// Leaderboards
//////////////////////////////////////////////////////////////////////////

ManagedSteam_API void Stats_FindOrCreateLeaderboard(PConstantString name, Enum sortMethod, Enum displayType);

ManagedSteam_API void Stats_FindLeaderboard(PConstantString name);

ManagedSteam_API PConstantString Stats_GetLeaderboardName(SteamLeaderboard handle);

ManagedSteam_API s32 Stats_GetLeaderboardEntryCount(SteamLeaderboard handle);

ManagedSteam_API Enum Stats_GetLeaderboardSortMethod(SteamLeaderboard handle);

ManagedSteam_API Enum Stats_GetLeaderboardDisplayType(SteamLeaderboard handle);

ManagedSteam_API void Stats_DownloadLeaderboardEntries(SteamLeaderboard handle, Enum dataRequest, s32 start, s32 end);

ManagedSteam_API void Stats_DownloadLeaderboardEntriesForUsers(SteamLeaderboard handle, PConstantDataPointer users, s32 numberOfUsers);

ManagedSteam_API bool Stats_GetDownloadedLeaderboardEntry(SteamLeaderboardEntries entries, s32 index, PDataPointer entry, PDataPointer detailsBuffer, s32 maxDetails);

ManagedSteam_API void Stats_UploadLeaderboardScore(SteamLeaderboard handle, Enum scoreMethod, s32 score, PConstantDataPointer details, s32 detailsCount);


ManagedSteam_API void Stats_AttachLeaderboardUGC(SteamLeaderboard handle, UGCHandle ugcHandle);

//////////////////////////////////////////////////////////////////////////
// Global achievements
//////////////////////////////////////////////////////////////////////////

ManagedSteam_API void Stats_GetNumberOfCurrentPlayers();

ManagedSteam_API void Stats_RequestGlobalAchievementPercentages();

ManagedSteam_API s32 Stats_GetMostAchievedAchievementInfo(PString name, u32 nameLength, float *percent, bool *achieved);

ManagedSteam_API s32 Stats_GetNextMostAchievedAchievementInfo(s32 iterator, PString name, u32 nameLength, float *percent, bool *achieved);

ManagedSteam_API bool Stats_GetAchievementAchievedPercent(PConstantString name, float *percent);
//////////////////////////////////////////////////////////////////////////
// Global stats
//////////////////////////////////////////////////////////////////////////

ManagedSteam_API_Lite void Stats_RequestGlobalStats(s32 historyDays);

ManagedSteam_API_Lite bool Stats_GetGlobalStatInt(PConstantString name, s64 *data);
ManagedSteam_API_Lite bool Stats_GetGlobalStatDouble(PConstantString name, double *data);

ManagedSteam_API_Lite s32 Stats_GetGlobalStatHistoryInt(PConstantString name, PDataPointer dataBuffer, u32 bufferSize);
ManagedSteam_API_Lite s32 Stats_GetGlobalStatHistoryDouble(PConstantString name, PDataPointer dataBuffer, u32 bufferSize);


#endif // Stats_h_interop_