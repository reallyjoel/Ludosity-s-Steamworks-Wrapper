using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface IUGC
    {
        event ResultEvent<UGCQueryCompleted> UGCQueryCompleted;
        event ResultEvent<UGCRequestUGCDetailsResult> UGCRequestUGCDetailsResult;

        /// <summary>
        /// Query UGC associated with a user. Creator app id or consumer app id must be valid and be set to the current running app.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="listType"></param>
        /// <param name="matchingUGCType"></param>
        /// <param name="sortOrder"></param>
        /// <param name="creatorAppID"></param>
        /// <param name="consumerAppID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        UGCQueryHandle CreateQueryUserUGCRequest(AccountID accountId, UserUGCList listType, EUGCMatchingUGCType matchingUGCType, EUserUGCListSortOrder sortOrder, AppID creatorAppID, AppID consumerAppID, uint page);
        
        /// <summary>
        /// Query for all matching UGC. Creator app id or consumer app id must be valid and be set to the current running app.
        /// </summary>
        /// <param name="queryType"></param>
        /// <param name="matchingeMatchingUGCTypeFileType"></param>
        /// <param name="creatorAppID"></param>
        /// <param name="consumerAppID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        UGCQueryHandle CreateQueryAllUGCRequest(EUGCQuery queryType, EUGCMatchingUGCType matchingeMatchingUGCTypeFileType, AppID creatorAppID, AppID consumerAppID, uint page);

        /// <summary>
        /// Send the query to Steam
        /// </summary>
        /// <param name="handle"></param>
        void SendQueryUGCRequest(UGCQueryHandle handle);

        /// <summary>
        /// Retrieve an individual result after receiving the callback for querying UGC
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="index"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        bool GetQueryUGCResult(UGCQueryHandle handle, uint index, out UGCDetails details);
        /// <summary>
        /// Retrieve an individual result after receiving the callback for querying UGC
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        UGCGetQueryUGCResultResult GetQueryUGCResult(UGCQueryHandle handle, uint index);

        /// <summary>
        /// Release the request to free up memory, after retrieving results
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        bool ReleaseQueryUGCRequest(UGCQueryHandle handle);

        // Options to set for querying UGC
        bool AddRequiredTag(UGCQueryHandle handle, string tagName);
        bool AddExcludedTag(UGCQueryHandle handle, string tagName);
        bool SetReturnLongDescription(UGCQueryHandle handle, bool returnLongDescription);
        bool SetReturnTotalOnly(UGCQueryHandle handle, bool returnTotalOnly);

        // Options only for querying user UGC
        bool SetCloudFileNameFilter(UGCQueryHandle handle, string matchCloudFileName);

        // Options only for querying all UGC
        bool SetMatchAnyTag(UGCQueryHandle handle, bool matchAnyTag);
        bool SetSearchText(UGCQueryHandle handle, string searchText);
        bool SetRankedByTrendDays(UGCQueryHandle handle, uint days);

        // Request full details for one piece of UGC
        void RequestUGCDetails(PublishedFileId publishedFileId);
    }

    public struct UGCGetQueryUGCResultResult
    {
        public bool Result;
        public UGCDetails Details;
    }
}
