#ifndef PackedStructures_h_
#define PackedStructures_h_

// This file defines copies of steam structures that have to be sent to the managed environment.
// They are defined again here so we can control the packing and ordering of the data.
//

#pragma pack(push)
#pragma pack(8)
namespace SteamAPIWrap
{
	struct SUserStatsReceived
	{
		u64 GameID;
		Enum Result;
		u64 UserID;
	};
	//SW_STATIC_ASSERT(sizeof(SUserStatsReceived) == sizeof(UserStatsReceived_t));

	struct SLeaderboardEntry
	{
		u64 User;
		s32 Rank;
		s32 Score;
		s32 NumberOfDetails;
		u64 Handle;

		static void Create(PDataPointer targetLocation, const LeaderboardEntry_t &source)
		{
			SLeaderboardEntry *entry = static_cast<SLeaderboardEntry *>(targetLocation);
			entry->User = source.m_steamIDUser.ConvertToUint64();
			entry->Rank = source.m_nGlobalRank;
			entry->Score = source.m_nScore;
			entry->NumberOfDetails = source.m_cDetails;
			entry->Handle = source.m_hUGC;
		}
	};
	//SW_STATIC_ASSERT(sizeof(SLeaderboardEntry) == sizeof(LeaderboardEntry_t));


	struct SUserStatsUnloaded
	{
		u64 UserID;
	};
	//SW_STATIC_ASSERT(sizeof(SUserStatsUnloaded) == sizeof(UserStatsUnloaded_t));
}
#pragma pack(pop)

#endif // PackedStructures_h_
