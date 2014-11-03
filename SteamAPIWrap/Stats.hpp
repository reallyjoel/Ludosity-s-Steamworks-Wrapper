#ifndef Stats_h_
#define Stats_h_

#include "Stats.h"
#include "Singleton.hpp"

#include "Services.hpp"

// Types
#include "ConvertedStructures.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

#include "Helper.hpp"

namespace SteamAPIWrap
{
	class CStats : public CSingleton<CStats>
	{
		SW_CALLBACK_CONVERTED(CStats, UserStatsReceived_t, UserStatsReceived,
		{
			SW_CALLBACK_ASSIGNMENT(GameID, m_nGameID);
			SW_CALLBACK_ASSIGNMENT_STEAM_RESULT;
			SW_CALLBACK_ASSIGNMENT(UserID, m_steamIDUser.ConvertToUint64());
		});
		SW_CALLBACK(CStats, UserStatsStored_t, UserStatsStored);
		SW_CALLBACK(CStats, UserAchievementStored_t, UserAchievementStored);

		SW_ASYNC_RESULT(CStats, LeaderboardFindResult_t, LeaderboardFindResult);
		SW_ASYNC_RESULT(CStats, LeaderboardScoresDownloaded_t, LeaderboardScoresDownloaded);
		SW_ASYNC_RESULT(CStats, LeaderboardScoreUploaded_t, LeaderboardScoreUploaded);
		SW_ASYNC_RESULT(CStats, LeaderboardUGCSet_t, LeaderboardUGCSet);
		SW_ASYNC_RESULT(CStats, NumberOfCurrentPlayers_t, NumberOfCurrentPlayers);
		SW_CALLBACK_CONVERTED(CStats, UserStatsUnloaded_t, UserStatsUnloaded,
		{
			SW_CALLBACK_ASSIGNMENT(UserID, m_steamIDUser.ConvertToUint64());
		});
		SW_CALLBACK(CStats, UserAchievementIconFetched_t, UserAchievementIconFetched);
		SW_ASYNC_RESULT(CStats, GlobalAchievementPercentagesReady_t, GlobalAchievementPercentagesReady);
		SW_ASYNC_RESULT(CStats, GlobalStatsReceived_t, GlobalStatsReceived);

	public:

		void SetSteamInterface(ISteamUserStats *stats);
		void RunCallbackSizeCheck();


		bool RequestCurrentStats();

		bool GetStatInt(PConstantString name, s32 *data);

		bool GetStatFloat(PConstantString name, float *data);

		bool SetStatInt(PConstantString name, s32 data);

		bool SetStatFloat(PConstantString name, float data);

		bool UpdateAverageRateStat(PConstantString name, float countThisSession, double sessionLength);


		bool GetAchievement(PConstantString name, bool *achieved);

		bool SetAchievement(PConstantString name);

		bool ClearAchievement(PConstantString name);

		bool GetAchievementAndUnlockTime(PConstantString name, bool *achieved, u32 *unlockTime);

		bool StoreStats();


		s32 GetAchievementIcon(PConstantString name);

		PConstantString GetAchievementDisplayAttribute(PConstantString name, PConstantString key);

		bool IndicateAchievementProgress(PConstantString name, u32 currentProgress, u32 maxProgess);

		void RequestUserStats(SteamID steamID);

		bool GetUserStat(SteamID steamID, PConstantString name, s32 *data);
		bool GetUserStat(SteamID steamID, PConstantString name, float *data);
		bool GetUserAchievement(SteamID steamID, PConstantString name, bool *achieved);
		bool GetUserAchievementAndUnlockTime(SteamID steamID, PConstantString name, bool *achieved, u32 *unlockTime);
		bool ResetAllStats(bool achievementsToo);
	
		//////////////////////////////////////////////////////////////////////////
		// Leaderboards
		//////////////////////////////////////////////////////////////////////////

		void FindOrCreateLeaderboard(PConstantString name, Enum sortMethod, Enum displayType);

		void FindLeaderboard(PConstantString name);

		PConstantString GetLeaderboardName(SteamLeaderboard handle);

		s32 GetLeaderboardEntryCount(SteamLeaderboard handle);

		Enum GetLeaderboardSortMethod(SteamLeaderboard handle);

		Enum GetLeaderboardDisplayType(SteamLeaderboard handle);


		void DownloadLeaderboardEntries(SteamLeaderboard handle, Enum dataRequest, s32 start, s32 end);
		void DownloadLeaderboardEntriesForUsers(SteamLeaderboard handle, PConstantDataPointer users, s32 numberOfUsers);

		bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries entries, s32 index, PDataPointer entry, PDataPointer detailsBuffer, s32 maxDetails);

		void UploadLeaderboardScore(SteamLeaderboard handle, Enum scoreMethod, s32 score, PConstantDataPointer details, s32 detailsCount);

		void AttachLeaderboardUGC(SteamLeaderboard handle, UGCHandle ugcHandle);

		void GetNumberOfCurrentPlayers();

		void RequestGlobalAchievementPercentages();

		s32 GetMostAchievedAchievementInfo(PString name, u32 nameLength, float *percent, bool *achieved);

		s32 GetNextMostAchievedAchievementInfo(s32 iterator, PString name, u32 nameLength, float *percent, bool *achieved);

		bool GetAchievementAchievedPercent(PConstantString name, float *percent);

		void RequestGlobalStats(s32 historyDays);

		bool GetGlobalStat(PConstantString name, s64 *data);
		bool GetGlobalStat(PConstantString name, double *data);

		s32 GetGlobalStatHistoryInt(PConstantString name, PDataPointer dataBuffer, u32 bufferSize);
		s32 GetGlobalStatHistoryDouble(PConstantString name, PDataPointer dataBuffer, u32 bufferSize);
	private:
		friend class CSingleton<CStats>;
		CStats();
		~CStats() {}
		DISALLOW_COPY_AND_ASSIGN(CStats);

		ISteamUserStats *stats;
	};
}

#endif // Stats_h_