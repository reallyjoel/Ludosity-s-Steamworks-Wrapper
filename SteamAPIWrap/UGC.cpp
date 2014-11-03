#include "Precompiled.hpp"
#include "UGC.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template<> CUGC *CSingleton<CUGC>::instance = nullptr;


	CUGC::CUGC()
		: //nativeUGCQueryCompletedCallback(this, &CUGC::OnUGCQueryCompleted)
		//, resultUGCRequestUGCDetailsResult(this, &CUGC::OnUGCRequestUGCDetailsResult)
		ugc(nullptr)
	{

	}

	void CUGC::RunCallbackSizeCheck()
	{
		SteamUGCQueryCompleted_t* steamUGCQueryCompleted = new SteamUGCQueryCompleted_t();
		OnUGCQueryCompleted(steamUGCQueryCompleted, false);
		delete steamUGCQueryCompleted;

		SteamUGCRequestUGCDetailsResult_t* steamUGCRequestUGCDetailsResult = new SteamUGCRequestUGCDetailsResult_t();
		OnUGCRequestUGCDetailsResult(steamUGCRequestUGCDetailsResult, false);
		delete steamUGCRequestUGCDetailsResult;
	}

	// Query UGC associated with a user. Creator app id or consumer app id must be valid and be set to the current running app.
	UGCQueryHandle CUGC::CreateQueryUserUGCRequest( AccountID unAccountID, Enum eListType, Enum eMatchingUGCType, Enum eSortOrder, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage )
	{
		return ugc->CreateQueryUserUGCRequest( unAccountID,	static_cast<EUserUGCList>(eListType), static_cast<EUGCMatchingUGCType>(eMatchingUGCType),
			static_cast<EUserUGCListSortOrder>(eSortOrder), nCreatorAppID, nConsumerAppID, unPage);
	}

	// Query for all matching UGC. Creator app id or consumer app id must be valid and be set to the current running app.
	UGCQueryHandle CUGC::CreateQueryAllUGCRequest( Enum eQueryType, Enum eMatchingeMatchingUGCTypeFileType, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage )
	{
		return ugc->CreateQueryAllUGCRequest( static_cast<EUGCQuery>(eQueryType), static_cast<EUGCMatchingUGCType>(eMatchingeMatchingUGCTypeFileType),
			nCreatorAppID, nConsumerAppID, unPage);
	}

	// Send the query to Steam
	void CUGC::SendQueryUGCRequest( UGCQueryHandle handle )
	{
		resultUGCQueryCompleted.Set( ugc->SendQueryUGCRequest( handle ), this, &CUGC::OnUGCQueryCompleted );
	}

	// Retrieve an individual result after receiving the callback for querying UGC
	bool CUGC::GetQueryUGCResult( UGCQueryHandle handle, u32 index, PDataPointer pDetails )
	{
		return ugc->GetQueryUGCResult( handle, index, reinterpret_cast<SteamUGCDetails_t *>(pDetails));
	}

	// Release the request to free up memory, after retrieving results
	bool CUGC::ReleaseQueryUGCRequest( UGCQueryHandle handle )
	{
		return ugc->ReleaseQueryUGCRequest( handle );
	}

	// Options to set for querying UGC
	bool CUGC::AddRequiredTag( UGCQueryHandle handle, PConstantString pTagName )
	{
		return ugc->AddRequiredTag( handle, pTagName );
	}

	bool CUGC::AddExcludedTag( UGCQueryHandle handle, PConstantString pTagName )
	{
		return ugc->AddExcludedTag( handle, pTagName );
	}

	bool CUGC::SetReturnLongDescription( UGCQueryHandle handle, bool bReturnLongDescription )
	{
		return ugc->SetReturnLongDescription( handle, bReturnLongDescription );
	}

	bool CUGC::SetReturnTotalOnly( UGCQueryHandle handle, bool bReturnTotalOnly )
	{
		return ugc->SetReturnTotalOnly( handle, bReturnTotalOnly );
	}

	// Options only for querying user UGC
	bool CUGC::SetCloudFileNameFilter( UGCQueryHandle handle, PConstantString pMatchCloudFileName )
	{
		return ugc->SetCloudFileNameFilter( handle, pMatchCloudFileName );
	}

	// Options only for querying all UGC
	bool CUGC::SetMatchAnyTag( UGCQueryHandle handle, bool bMatchAnyTag )
	{
		return ugc->SetMatchAnyTag( handle, bMatchAnyTag );
	}

	bool CUGC::SetSearchText( UGCQueryHandle handle, PConstantString pSearchText )
	{
		return ugc->SetSearchText( handle, pSearchText );
	}

	bool CUGC::SetRankedByTrendDays( UGCQueryHandle handle, u32 unDays )
	{
		return ugc->SetRankedByTrendDays( handle, unDays );
	}

	// Request full details for one piece of UGC
	void CUGC::RequestUGCDetails( u64 nPublishedFileID )
	{
		resultUGCRequestUGCDetailsResult.Set(ugc->RequestUGCDetails(nPublishedFileID),
			this, &CUGC::OnUGCRequestUGCDetailsResult);
	}
};

ManagedSteam_API UGCQueryHandle UGC_CreateQueryUserUGCRequest( AccountID unAccountID, Enum eListType, Enum eMatchingUGCType, Enum eSortOrder, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage )
{
	return CUGC::Instance().CreateQueryUserUGCRequest(unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage );
}

ManagedSteam_API UGCQueryHandle UGC_CreateQueryAllUGCRequest( Enum eQueryType, Enum eMatchingeMatchingUGCTypeFileType, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage )
{
	return CUGC::Instance().CreateQueryAllUGCRequest( eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage );
}

ManagedSteam_API void UGC_SendQueryUGCRequest( UGCQueryHandle handle )
{
	CUGC::Instance().SendQueryUGCRequest( handle );
}

ManagedSteam_API bool UGC_GetQueryUGCResult( UGCQueryHandle handle, u32 index, PDataPointer pDetails )
{
	return CUGC::Instance().GetQueryUGCResult( handle, index, pDetails );
}

ManagedSteam_API bool UGC_ReleaseQueryUGCRequest( UGCQueryHandle handle )
{
	return CUGC::Instance().ReleaseQueryUGCRequest( handle );
}

ManagedSteam_API bool UGC_AddRequiredTag( UGCQueryHandle handle, PConstantString pTagName )
{
	return CUGC::Instance().AddRequiredTag( handle, pTagName );
}

ManagedSteam_API bool UGC_AddExcludedTag( UGCQueryHandle handle, PConstantString pTagName )
{
	return CUGC::Instance().AddExcludedTag( handle, pTagName );
}

ManagedSteam_API bool UGC_SetReturnLongDescription( UGCQueryHandle handle, bool bReturnLongDescription )
{
	return CUGC::Instance().SetReturnLongDescription( handle, bReturnLongDescription );
}

ManagedSteam_API bool UGC_SetReturnTotalOnly( UGCQueryHandle handle, bool bReturnTotalOnly )
{
	return CUGC::Instance().SetReturnTotalOnly( handle, bReturnTotalOnly );
}

ManagedSteam_API bool UGC_SetCloudFileNameFilter( UGCQueryHandle handle, PConstantString pMatchCloudFileName )
{
	return CUGC::Instance().SetCloudFileNameFilter( handle, pMatchCloudFileName );
}

ManagedSteam_API bool UGC_SetMatchAnyTag( UGCQueryHandle handle, bool bMatchAnyTag )
{
	return CUGC::Instance().SetMatchAnyTag( handle, bMatchAnyTag );
}

ManagedSteam_API bool UGC_SetSearchText( UGCQueryHandle handle, PConstantString pSearchText )
{
	return CUGC::Instance().SetSearchText( handle, pSearchText );
}

ManagedSteam_API bool UGC_SetRankedByTrendDays( UGCQueryHandle handle, u32 unDays )
{
	return CUGC::Instance().SetRankedByTrendDays( handle, unDays );
}

// Request full details for one piece of UGC
ManagedSteam_API void UGC_RequestUGCDetails( u64 nPublishedFileID )
{
	CUGC::Instance().RequestUGCDetails( nPublishedFileID );
}