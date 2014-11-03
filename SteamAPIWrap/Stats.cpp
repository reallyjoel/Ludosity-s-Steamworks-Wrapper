#include "Precompiled.hpp"
#include "Stats.hpp"

#include "MemoryHelpers.h"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CStats * CSingleton<CStats>::instance = nullptr;

	CStats::CStats()
		: nativeUserStatsReceivedCallback(this, &CStats::OnUserStatsReceived)
		, nativeUserStatsStoredCallback(this, &CStats::OnUserStatsStored)
		, nativeUserAchievementStoredCallback(this, &CStats::OnUserAchievementStored)
		, nativeUserStatsUnloadedCallback(this, &CStats::OnUserStatsUnloaded)
		, nativeUserAchievementIconFetchedCallback(this, &CStats::OnUserAchievementIconFetched)
		, stats(nullptr)
	{

	}

	void CStats::RunCallbackSizeCheck()
	{
		UserStatsReceived_t* userStatsReceived = new UserStatsReceived_t();
		OnUserStatsReceived(userStatsReceived);
        delete userStatsReceived;

		UserStatsStored_t* userStatsStored = new UserStatsStored_t();
		OnUserStatsStored(userStatsStored);
		delete userStatsStored;

		UserAchievementStored_t* userAchievementStored = new UserAchievementStored_t();
		OnUserAchievementStored(userAchievementStored);
		delete userAchievementStored;

		UserStatsUnloaded_t* userStatsUnloaded = new UserStatsUnloaded_t();
		OnUserStatsUnloaded(userStatsUnloaded);
		delete userStatsUnloaded;

		UserAchievementIconFetched_t* userAchievementIconFetched = new UserAchievementIconFetched_t();
		OnUserAchievementIconFetched(userAchievementIconFetched);
		delete userAchievementIconFetched;

        LeaderboardFindResult_t* leaderboardFindResult = new LeaderboardFindResult_t();
		OnLeaderboardFindResult(leaderboardFindResult, false);
        delete leaderboardFindResult;

		LeaderboardScoresDownloaded_t* leaderboardScoresDownloaded = new LeaderboardScoresDownloaded_t();
		OnLeaderboardScoresDownloaded(leaderboardScoresDownloaded, false);
		delete leaderboardScoresDownloaded;

		LeaderboardScoreUploaded_t* leaderboardScoreUploaded = new LeaderboardScoreUploaded_t();
		OnLeaderboardScoreUploaded(leaderboardScoreUploaded, false);
		delete leaderboardScoreUploaded;

		LeaderboardUGCSet_t* leaderboardUGCSet = new LeaderboardUGCSet_t();
		OnLeaderboardUGCSet(leaderboardUGCSet, false);
		delete leaderboardUGCSet;

		NumberOfCurrentPlayers_t* numberOfCurrentPlayers = new NumberOfCurrentPlayers_t();
		OnNumberOfCurrentPlayers(numberOfCurrentPlayers, false);
		delete numberOfCurrentPlayers;

		GlobalAchievementPercentagesReady_t* globalAchievementPercentagesReady = new GlobalAchievementPercentagesReady_t();
		OnGlobalAchievementPercentagesReady(globalAchievementPercentagesReady, false);
		delete globalAchievementPercentagesReady;

		GlobalStatsReceived_t* globalStatsReceived = new GlobalStatsReceived_t();
		OnGlobalStatsReceived(globalStatsReceived, false);
		delete globalStatsReceived;
	}

	void CStats::SetSteamInterface(ISteamUserStats *stats)
	{
		this->stats = stats;
	}

	bool CStats::RequestCurrentStats()
	{
		return stats->RequestCurrentStats();
	}

	bool CStats::GetStatInt(PConstantString name, s32 *data)
	{
		return stats->GetStat(name, data);
	}

	bool CStats::GetStatFloat(PConstantString name, float *data)
	{
		return stats->GetStat(name, data);
	}

	bool CStats::SetStatInt(PConstantString name, s32 data)
	{
		return stats->SetStat(name, data);
	}

	bool CStats::SetStatFloat(PConstantString name, float data)
	{
		return stats->SetStat(name, data);
	}

	bool CStats::UpdateAverageRateStat(PConstantString name, float countThisSession, double sessionLength)
	{
		return stats->UpdateAvgRateStat(name, countThisSession, sessionLength);
	}

	bool CStats::GetAchievement(PConstantString name, bool *achieved)
	{
		return stats->GetAchievement(name, achieved);
	}

	bool CStats::SetAchievement(PConstantString name)
	{
		return stats->SetAchievement(name);
	}

	bool CStats::ClearAchievement(PConstantString name)
	{
		return stats->ClearAchievement(name);
	}

	bool CStats::GetAchievementAndUnlockTime(PConstantString name, bool *achieved, u32 *unlockTime)
	{
		return stats->GetAchievementAndUnlockTime(name, achieved, unlockTime);
	}

	bool CStats::StoreStats()
	{
		return stats->StoreStats();
	}

	s32 CStats::GetAchievementIcon(PConstantString name)
	{
		return stats->GetAchievementIcon(name);
	}

	PConstantString CStats::GetAchievementDisplayAttribute(PConstantString name, PConstantString key)
	{
		return stats->GetAchievementDisplayAttribute(name, key);
	}

	bool CStats::IndicateAchievementProgress(PConstantString name, u32 currentProgress, u32 maxProgess)
	{
		return stats->IndicateAchievementProgress(name, currentProgress, maxProgess);
	}

	void CStats::RequestUserStats(SteamID steamID)
	{
		// Will use the same callback as RequestCurrentStats
		stats->RequestUserStats(CSteamID(steamID));
	}

	bool CStats::GetUserStat(SteamID steamID, PConstantString name, s32 *data)
	{
		return stats->GetUserStat(CSteamID(steamID), name, data);
	}

	bool CStats::GetUserStat(SteamID steamID, PConstantString name, float *data)
	{
		return stats->GetUserStat(CSteamID(steamID), name, data);
	}

	bool CStats::GetUserAchievement(SteamID steamID, PConstantString name, bool *achieved)
	{
		return stats->GetUserAchievement(CSteamID(steamID), name, achieved);
	}

	bool CStats::GetUserAchievementAndUnlockTime(SteamID steamID, PConstantString name, bool *achieved, u32 *unlockTime)
	{
		return stats->GetUserAchievementAndUnlockTime(CSteamID(steamID), name, achieved, unlockTime);
	}

	bool CStats::ResetAllStats(bool achievementsToo)
	{
		return stats->ResetAllStats(achievementsToo);
	}

	//////////////////////////////////////////////////////////////////////////
	// Leaderboards
	//////////////////////////////////////////////////////////////////////////

	void CStats::FindOrCreateLeaderboard(PConstantString name, Enum sortMethod, Enum displayType)
	{
		resultLeaderboardFindResult.Set(stats->FindOrCreateLeaderboard(name, 
			static_cast<ELeaderboardSortMethod>(sortMethod), static_cast<ELeaderboardDisplayType>(displayType)),
			this, &CStats::OnLeaderboardFindResult);
	}

	void CStats::FindLeaderboard(PConstantString name)
	{
		resultLeaderboardFindResult.Set(stats->FindLeaderboard(name), this, &CStats::OnLeaderboardFindResult);
	}

	PConstantString CStats::GetLeaderboardName(SteamLeaderboard handle)
	{
		return stats->GetLeaderboardName(handle);
	}

	s32 CStats::GetLeaderboardEntryCount(SteamLeaderboard handle)
	{
		return stats->GetLeaderboardEntryCount(handle);
	}

	Enum CStats::GetLeaderboardSortMethod(SteamLeaderboard handle)
	{
		return stats->GetLeaderboardSortMethod(handle);
	}

	Enum CStats::GetLeaderboardDisplayType(SteamLeaderboard handle)
	{
		return stats->GetLeaderboardDisplayType(handle);
	}

	void CStats::DownloadLeaderboardEntries(SteamLeaderboard handle, Enum dataRequest, s32 start, s32 end)
	{
		resultLeaderboardScoresDownloaded.Set(stats->DownloadLeaderboardEntries(handle, 
			static_cast<ELeaderboardDataRequest>(dataRequest), start, end),
			this, &CStats::OnLeaderboardScoresDownloaded);
	}

	void CStats::DownloadLeaderboardEntriesForUsers(SteamLeaderboard handle, PConstantDataPointer users, s32 numberOfUsers)
	{
		const SteamID *rawSteamUsers = static_cast<const SteamID *>(users);

		SSteamIDArray ids(rawSteamUsers, numberOfUsers);

		resultLeaderboardScoresDownloaded.Set(stats->DownloadLeaderboardEntriesForUsers(handle, ids.GetArray(), 
			numberOfUsers), this, &CStats::OnLeaderboardScoresDownloaded);
	}

	bool CStats::GetDownloadedLeaderboardEntry(SteamLeaderboardEntries entries, s32 index, PDataPointer entry, 
		PDataPointer detailsBuffer, s32 maxDetails)
	{
		LeaderboardEntry_t steamEntry;
		s32 *steamDetailsBuffer = static_cast<s32 *>(detailsBuffer);
		bool result = stats->GetDownloadedLeaderboardEntry(entries, index, &steamEntry, steamDetailsBuffer, maxDetails);
		
		// Copies the data to the memory allocated by C#. Also does some conversions.
		// We need to convert the struct as the steam struct can't be copied directly to C#
		SLeaderboardEntry::Create(entry, steamEntry);

		return result;
	}

	void CStats::UploadLeaderboardScore(SteamLeaderboard handle, Enum scoreMethod, s32 score, 
		PConstantDataPointer details, s32 detailsCount)
	{
		resultLeaderboardScoreUploaded.Set(stats->UploadLeaderboardScore(handle, 
			static_cast<ELeaderboardUploadScoreMethod>(scoreMethod), score, 
			static_cast<const s32 *>(details), detailsCount), 
			this, &CStats::OnLeaderboardScoreUploaded);
	}

	void CStats::AttachLeaderboardUGC(SteamLeaderboard handle, UGCHandle ugcHandle)
	{
		resultLeaderboardUGCSet.Set(stats->AttachLeaderboardUGC(handle, ugcHandle),
			this, &CStats::OnLeaderboardUGCSet);
	}

	void CStats::GetNumberOfCurrentPlayers()
	{
		resultNumberOfCurrentPlayers.Set(stats->GetNumberOfCurrentPlayers(), 
			this, &CStats::OnNumberOfCurrentPlayers);
	}

	void CStats::RequestGlobalAchievementPercentages()
	{
		resultGlobalAchievementPercentagesReady.Set(stats->RequestGlobalAchievementPercentages(),
			this, &CStats::OnGlobalAchievementPercentagesReady);
	}

	s32 CStats::GetMostAchievedAchievementInfo(PString name, u32 nameLength, float *percent, bool *achieved)
	{
		return stats->GetMostAchievedAchievementInfo(name, nameLength, percent, achieved);
	}

	s32 CStats::GetNextMostAchievedAchievementInfo(s32 iterator, PString name, u32 nameLength, float *percent, 
		bool *achieved)
	{
		return stats->GetNextMostAchievedAchievementInfo(iterator, name, nameLength, percent, achieved);
	}

	bool CStats::GetAchievementAchievedPercent(PConstantString name, float *percent)
	{
		return stats->GetAchievementAchievedPercent(name, percent);
	}

	void CStats::RequestGlobalStats(s32 historyDays)
	{
		resultGlobalStatsReceived.Set(stats->RequestGlobalStats(historyDays),
			this, &CStats::OnGlobalStatsReceived);
	}

	bool CStats::GetGlobalStat(PConstantString name, s64 *data)
	{
		return stats->GetGlobalStat(name, data);
	}

	bool CStats::GetGlobalStat(PConstantString name, double *data)
	{
		return stats->GetGlobalStat(name, data);
	}

	s32 CStats::GetGlobalStatHistoryInt(PConstantString name, PDataPointer dataBuffer, u32 bufferSize)
	{
		return stats->GetGlobalStatHistory(name, static_cast<s64 *>(dataBuffer), bufferSize);
	}

	s32 CStats::GetGlobalStatHistoryDouble(PConstantString name, PDataPointer dataBuffer, u32 bufferSize)
	{
		return stats->GetGlobalStatHistory(name, static_cast<double *>(dataBuffer), bufferSize);
	}

}

ManagedSteam_API_Lite bool Stats_RequestCurrentStats()
{
	return CStats::Instance().RequestCurrentStats();
}

ManagedSteam_API_Lite bool Stats_GetStatInt(PConstantString name, s32 *data)
{
	return CStats::Instance().GetStatInt(name, data);
}

ManagedSteam_API_Lite bool Stats_GetStatFloat(PConstantString name, float *data)
{
	return CStats::Instance().GetStatFloat(name, data);
}

ManagedSteam_API_Lite bool Stats_SetStatInt(PConstantString name, s32 data)
{
	return CStats::Instance().SetStatInt(name, data);
}

ManagedSteam_API_Lite bool Stats_SetStatFloat(PConstantString name, float data)
{
	return CStats::Instance().SetStatFloat(name, data);
}

ManagedSteam_API_Lite bool Stats_UpdateAverageRateStat(PConstantString name, float countThisSession, double sessionLength)
{
	return CStats::Instance().UpdateAverageRateStat(name, countThisSession, sessionLength);
}

ManagedSteam_API bool Stats_GetAchievement(PConstantString name, bool *achieved)
{
	return CStats::Instance().GetAchievement(name, achieved);
}

ManagedSteam_API bool Stats_SetAchievement(PConstantString name)
{
	return CStats::Instance().SetAchievement(name);
}

ManagedSteam_API bool Stats_ClearAchievement(PConstantString name)
{
	return CStats::Instance().ClearAchievement(name);
}

ManagedSteam_API bool Stats_GetAchievementAndUnlockTime(PConstantString name, bool *achieved, u32 *unlockTime)
{
	return CStats::Instance().GetAchievementAndUnlockTime(name, achieved, unlockTime);
}

ManagedSteam_API_Lite bool Stats_StoreStats()
{
	return CStats::Instance().StoreStats();
}

ManagedSteam_API s32 Stats_GetAchievementIcon(PConstantString name)
{
	return CStats::Instance().GetAchievementIcon(name);
}

ManagedSteam_API PConstantString Stats_GetAchievementDisplayAttribute(PConstantString name, PConstantString key)
{
	return CStats::Instance().GetAchievementDisplayAttribute(name, key);
}

ManagedSteam_API bool Stats_IndicateAchievementProgress(PConstantString name, u32 currentProgress, u32 maxProgess)
{
	return CStats::Instance().IndicateAchievementProgress(name, currentProgress, maxProgess);
}

ManagedSteam_API_Lite void Stats_RequestUserStats(SteamID steamID)
{
	return CStats::Instance().RequestUserStats(steamID);
}

ManagedSteam_API_Lite bool Stats_GetUserStatInt(SteamID steamID, PConstantString name, s32 *data)
{
	return CStats::Instance().GetUserStat(steamID, name, data);
}

ManagedSteam_API_Lite bool Stats_GetUserStatFloat(SteamID steamID, PConstantString name, float *data)
{
	return CStats::Instance().GetUserStat(steamID, name, data);
}

ManagedSteam_API bool Stats_GetUserAchievement(SteamID steamID, PConstantString name, bool *achieved)
{
	return CStats::Instance().GetUserAchievement(steamID, name, achieved);
}

ManagedSteam_API bool Stats_GetUserAchievementAndUnlockTime(SteamID steamID, PConstantString name, bool *achieved, u32 *unlockTime)
{
	return CStats::Instance().GetUserAchievementAndUnlockTime(steamID, name, achieved, unlockTime);
}

ManagedSteam_API_Lite bool Stats_ResetAllStats(bool achievementsToo)
{
	return CStats::Instance().ResetAllStats(achievementsToo);
}

//////////////////////////////////////////////////////////////////////////
// Leaderboards
//////////////////////////////////////////////////////////////////////////
ManagedSteam_API void Stats_FindOrCreateLeaderboard(PConstantString name, Enum sortMethod, Enum displayType)
{
	return CStats::Instance().FindOrCreateLeaderboard(name, sortMethod, displayType);
}

ManagedSteam_API void Stats_FindLeaderboard(PConstantString name)
{
	return CStats::Instance().FindLeaderboard(name);
}

ManagedSteam_API PConstantString Stats_GetLeaderboardName(SteamLeaderboard handle)
{
	return CStats::Instance().GetLeaderboardName(handle);
}

ManagedSteam_API s32 Stats_GetLeaderboardEntryCount(SteamLeaderboard handle)
{
	return CStats::Instance().GetLeaderboardEntryCount(handle);
}

ManagedSteam_API Enum Stats_GetLeaderboardSortMethod(SteamLeaderboard handle)
{
	return CStats::Instance().GetLeaderboardSortMethod(handle);
}

ManagedSteam_API Enum Stats_GetLeaderboardDisplayType(SteamLeaderboard handle)
{
	return CStats::Instance().GetLeaderboardDisplayType(handle);
}

ManagedSteam_API void Stats_DownloadLeaderboardEntries(SteamLeaderboard handle, Enum dataRequest, s32 start, s32 end)
{
	return CStats::Instance().DownloadLeaderboardEntries(handle, dataRequest, start, end);
}

ManagedSteam_API void Stats_DownloadLeaderboardEntriesForUsers(SteamLeaderboard handle, PConstantDataPointer users, s32 numberOfUsers)
{
	return CStats::Instance().DownloadLeaderboardEntriesForUsers(handle, users, numberOfUsers);
}

ManagedSteam_API bool Stats_GetDownloadedLeaderboardEntry(SteamLeaderboardEntries entries, s32 index, PDataPointer entry, PDataPointer detailsBuffer, s32 maxDetails)
{
	return CStats::Instance().GetDownloadedLeaderboardEntry(entries, index, entry, detailsBuffer, maxDetails);
}

ManagedSteam_API void Stats_UploadLeaderboardScore(SteamLeaderboard handle, Enum scoreMethod, s32 score, PConstantDataPointer details, s32 detailsCount)
{
	return CStats::Instance().UploadLeaderboardScore(handle, scoreMethod, score, details, detailsCount);
}

ManagedSteam_API void Stats_AttachLeaderboardUGC(SteamLeaderboard handle, UGCHandle ugcHandle)
{
	CStats::Instance().AttachLeaderboardUGC(handle, ugcHandle);
}

ManagedSteam_API void Stats_GetNumberOfCurrentPlayers()
{
	CStats::Instance().GetNumberOfCurrentPlayers();
}

ManagedSteam_API void Stats_RequestGlobalAchievementPercentages()
{
	CStats::Instance().RequestGlobalAchievementPercentages();
}

ManagedSteam_API s32 Stats_GetMostAchievedAchievementInfo(PString name, u32 nameLength, float *percent, bool *achieved)
{
	return CStats::Instance().GetMostAchievedAchievementInfo(name, nameLength, percent, achieved);
}

ManagedSteam_API s32 Stats_GetNextMostAchievedAchievementInfo(s32 iterator, PString name, u32 nameLength, float *percent, bool *achieved)
{
	return CStats::Instance().GetNextMostAchievedAchievementInfo(iterator, name, nameLength, percent, achieved);
}

ManagedSteam_API bool Stats_GetAchievementAchievedPercent(PConstantString name, float *percent)
{
	return CStats::Instance().GetAchievementAchievedPercent(name, percent);
}

ManagedSteam_API_Lite void Stats_RequestGlobalStats(s32 historyDays)
{
	return CStats::Instance().RequestGlobalStats(historyDays);
}

ManagedSteam_API_Lite bool Stats_GetGlobalStatInt(PConstantString name, s64 *data)
{
	return CStats::Instance().GetGlobalStat(name, data);
}

ManagedSteam_API_Lite bool Stats_GetGlobalStatDouble(PConstantString name, double *data)
{
	return CStats::Instance().GetGlobalStat(name, data);
}

ManagedSteam_API_Lite s32 Stats_GetGlobalStatHistoryInt(PConstantString name, PDataPointer dataBuffer, u32 bufferSize)
{
	return CStats::Instance().GetGlobalStatHistoryInt(name, dataBuffer, bufferSize);
}

ManagedSteam_API_Lite s32 Stats_GetGlobalStatHistoryDouble(PConstantString name, PDataPointer dataBuffer, u32 bufferSize)
{
	return CStats::Instance().GetGlobalStatHistoryDouble(name, dataBuffer, bufferSize);
}