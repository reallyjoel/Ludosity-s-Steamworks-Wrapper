#ifndef SteamUGC_h_
#define SteamUGC_h_

#include "UGC.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CUGC : public CSingleton<CUGC>
	{
		SW_ASYNC_RESULT(CUGC, SteamUGCQueryCompleted_t, UGCQueryCompleted);
		SW_ASYNC_RESULT(CUGC, SteamUGCRequestUGCDetailsResult_t, UGCRequestUGCDetailsResult);

	public:
		void SetSteamInterface(ISteamUGC *ugc) { this->ugc = ugc; }
		void RunCallbackSizeCheck();

		// Query UGC associated with a user. Creator app id or consumer app id must be valid and be set to the current running app.
		UGCQueryHandle CreateQueryUserUGCRequest( AccountID unAccountID, Enum eListType, Enum eMatchingUGCType, Enum eSortOrder, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage );

		// Query for all matching UGC. Creator app id or consumer app id must be valid and be set to the current running app.
		UGCQueryHandle CreateQueryAllUGCRequest( Enum eQueryType, Enum eMatchingeMatchingUGCTypeFileType, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage );

		// Send the query to Steam
		void SendQueryUGCRequest( UGCQueryHandle handle );

		// Retrieve an individual result after receiving the callback for querying UGC
		bool GetQueryUGCResult( UGCQueryHandle handle, u32 index, PDataPointer pDetails );

		// Release the request to free up memory, after retrieving results
		bool ReleaseQueryUGCRequest( UGCQueryHandle handle );

		// Options to set for querying UGC
		bool AddRequiredTag( UGCQueryHandle handle, PConstantString pTagName );
		bool AddExcludedTag( UGCQueryHandle handle, PConstantString pTagName );
		bool SetReturnLongDescription( UGCQueryHandle handle, bool bReturnLongDescription );
		bool SetReturnTotalOnly( UGCQueryHandle handle, bool bReturnTotalOnly );

		// Options only for querying user UGC
		bool SetCloudFileNameFilter( UGCQueryHandle handle, PConstantString pMatchCloudFileName );

		// Options only for querying all UGC
		bool SetMatchAnyTag( UGCQueryHandle handle, bool bMatchAnyTag );
		bool SetSearchText( UGCQueryHandle handle, PConstantString pSearchText );
		bool SetRankedByTrendDays( UGCQueryHandle handle, u32 unDays );

		// Request full details for one piece of UGC
		void RequestUGCDetails( u64 nPublishedFileID );

	private:
		friend class CSingleton<CUGC>;
		CUGC();
		~CUGC() {}
		DISALLOW_COPY_AND_ASSIGN(CUGC);

		ISteamUGC* ugc;
	};
};

#endif // SteamUGC_h_