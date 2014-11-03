using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class UGC : SteamService, IUGC
    {
        private List<Result<UGCQueryCompleted>> ugcQueryCompleted;
        private List<Result<UGCRequestUGCDetailsResult>> ugcRequestUGCDetailsResult;

        public UGC()
        {
            ugcQueryCompleted = new List<Result<UGCQueryCompleted>>();
            ugcRequestUGCDetailsResult = new List<Result<UGCRequestUGCDetailsResult>>();

            Results[ResultID.UGCQueryCompleted] = (data, size, flag) => ugcQueryCompleted.Add(new Result<UGCQueryCompleted>(CallbackStructures.UGCQueryCompleted.Create(data, size), flag));
            Results[ResultID.UGCRequestUGCDetailsResult] = (data, size, flag) => ugcRequestUGCDetailsResult.Add(new Result<UGCRequestUGCDetailsResult>(CallbackStructures.UGCRequestUGCDetailsResult.Create(data, size), flag));
        }

        public event ResultEvent<UGCQueryCompleted> UGCQueryCompleted;
        public event ResultEvent<UGCRequestUGCDetailsResult> UGCRequestUGCDetailsResult;

        internal override void CheckIfUsableInternal()
        {
            
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(ugcQueryCompleted, UGCQueryCompleted);
            InvokeEvents(ugcRequestUGCDetailsResult, UGCRequestUGCDetailsResult);
        }

        internal override void ReleaseManagedResources()
        {
            ugcQueryCompleted = null;
            UGCQueryCompleted = null;

            ugcRequestUGCDetailsResult = null;
            UGCRequestUGCDetailsResult = null;
        }

        public UGCQueryHandle CreateQueryUserUGCRequest(AccountID accountId, UserUGCList listType, EUGCMatchingUGCType matchingUGCType, EUserUGCListSortOrder sortOrder, AppID creatorAppID, AppID consumerAppID, uint page)
        {
            CheckIfUsable();

            return new UGCQueryHandle(NativeMethods.UGC_CreateQueryUserUGCRequest(accountId.AsUInt32, (int)listType, (int)matchingUGCType, (int)sortOrder, creatorAppID.AsUInt32, creatorAppID.AsUInt32, page));
        }

        public UGCQueryHandle CreateQueryAllUGCRequest(EUGCQuery queryType, EUGCMatchingUGCType matchingeMatchingUGCTypeFileType, AppID creatorAppID, AppID consumerAppID, uint page)
        {
            CheckIfUsable();

            return new UGCQueryHandle(NativeMethods.UGC_CreateQueryAllUGCRequest((int)queryType, (int)matchingeMatchingUGCTypeFileType, creatorAppID.AsUInt32, consumerAppID.AsUInt32, page));
        }

        public void SendQueryUGCRequest(UGCQueryHandle handle)
        {
            CheckIfUsable();

            NativeMethods.UGC_SendQueryUGCRequest( handle.AsUInt64 );
        }

        public bool GetQueryUGCResult(UGCQueryHandle handle, uint index, out UGCDetails details)
        {
            CheckIfUsable();

            using (NativeBuffer bufferKey = new NativeBuffer(Marshal.SizeOf(typeof(UGCDetails))))
            {
                bool result = NativeMethods.UGC_GetQueryUGCResult(handle.AsUInt64, index, bufferKey.UnmanagedMemory);
                details = NativeHelpers.ConvertStruct<UGCDetails>(bufferKey.UnmanagedMemory, bufferKey.UnmanagedSize);

                return result;
            }
        }

        public UGCGetQueryUGCResultResult GetQueryUGCResult(UGCQueryHandle handle, uint index)
        {
            UGCGetQueryUGCResultResult result = new UGCGetQueryUGCResultResult();
            result.Result = GetQueryUGCResult(handle, index, out result.Details);

            return result;
        }

        public bool ReleaseQueryUGCRequest(UGCQueryHandle handle)
        {
            return NativeMethods.UGC_ReleaseQueryUGCRequest( handle.AsUInt64 );
        }

        public bool AddRequiredTag(UGCQueryHandle handle, string tagName)
        {
            return NativeMethods.UGC_AddRequiredTag( handle.AsUInt64, tagName );
        }

        public bool AddExcludedTag(UGCQueryHandle handle, string tagName)
        {
            return NativeMethods.UGC_AddExcludedTag( handle.AsUInt64, tagName );
        }
        
        public bool SetReturnLongDescription(UGCQueryHandle handle, bool returnLongDescription)
        {
            return NativeMethods.UGC_SetReturnLongDescription( handle.AsUInt64, returnLongDescription );
        }
    
        public bool SetReturnTotalOnly(UGCQueryHandle handle, bool returnTotalOnly)
        {
            return NativeMethods.UGC_SetReturnTotalOnly( handle.AsUInt64, returnTotalOnly );
        }

        public bool SetCloudFileNameFilter(UGCQueryHandle handle, string matchCloudFileName)
        {
            return NativeMethods.UGC_SetCloudFileNameFilter( handle.AsUInt64, matchCloudFileName );
        }

        public bool SetMatchAnyTag(UGCQueryHandle handle, bool matchAnyTag)
        {
            return NativeMethods.UGC_SetMatchAnyTag( handle.AsUInt64, matchAnyTag );
        }

        public bool SetSearchText(UGCQueryHandle handle, string searchText)
        {
            return NativeMethods.UGC_SetSearchText( handle.AsUInt64, searchText );
        }

        public bool SetRankedByTrendDays(UGCQueryHandle handle, uint days)
        {
            return NativeMethods.UGC_SetRankedByTrendDays( handle.AsUInt64, days );
        }

        public void RequestUGCDetails(PublishedFileId publishedFileId)
        {
            NativeMethods.UGC_RequestUGCDetails( publishedFileId.AsUInt64 );
        }
    }
}
