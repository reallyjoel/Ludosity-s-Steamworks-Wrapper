
[System.CodeDom.Compiler.GeneratedCode("InteropSignatureToolkit", "")]
internal partial class NativeConstants {
    
    /// INTEROP_CONVERSION -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string INTEROP_CONVERSION = "";
    
    /// ManagedSteam_API -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string ManagedSteam_API = "";
    
    /// ManagedSteam_API_Lite -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string ManagedSteam_API_Lite = "";
    
    /// Types_h_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string Types_h_ = "";
    
    /// STEAMTYPES_H -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string STEAMTYPES_H = "";
    
    /// Warning: Generation of Method Macros is not supported at this time
    /// SW_MANAGED_CALLBACK_TYPE -> "(returnType,callbackName,parameters) typedef returnType (__stdcall *callbackName)parameters"
    internal const string SW_MANAGED_CALLBACK_TYPE = "(returnType,callbackName,parameters) typedef returnType (__stdcall *callbackName)" +
        "parameters";
    
    /// RemoteStorage_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string RemoteStorage_h_interop_ = "";
    
    /// Services_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string Services_h_interop_ = "";
    
    /// Stats_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string Stats_h_interop_ = "";
    
    /// SteamUser_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string SteamUser_h_interop_ = "";
    
    /// Friends_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string Friends_h_interop_ = "";
    
    /// MatchMaking_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string MatchMaking_h_interop_ = "";
    
    /// MatchmakingServers_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string MatchmakingServers_h_interop_ = "";
    
    /// MatchmakingServerListResponse_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string MatchmakingServerListResponse_h_interop_ = "";
    
    /// MatchmakingPingResponse_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string MatchmakingPingResponse_h_interop_ = "";
    
    /// MatchmakingPlayers_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string MatchmakingPlayers_h_interop_ = "";
    
    /// MatchmakingRulesPlayers_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string MatchmakingRulesPlayers_h_interop_ = "";
    
    /// GameServer_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string GameServer_h_interop_ = "";
    
    /// GameServerStats_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string GameServerStats_h_interop_ = "";
    
    /// Networking_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string Networking_h_interop_ = "";
    
    /// ServicesGameServer_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string ServicesGameServer_h_interop_ = "";
    
    /// Utils_h_interop_ -> 
    /// Error generating expression: Value cannot be null.
    ///Parameter name: node
    internal const string Utils_h_interop_ = "";
}

/// Return Type: void
///id: Enum->s32->int32->int
///data: PConstantDataPointer->void*
///dataSize: s32->int32->int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void ManagedCallback(int id, System.IntPtr data, int dataSize);

/// Return Type: void
///id: Enum->s32->int32->int
///data: PConstantDataPointer->void*
///dataSize: s32->int32->int
///ioFailure: boolean
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void ManagedResultCallback(int id, System.IntPtr data, int dataSize, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool ioFailure);

/// Return Type: void
///sender: uptr->uintp->unsigned int
///request: uptr->uintp->unsigned int
///server: s32->int32->int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingServerListResponse_ServerRespondedCallback(uint sender, uint request, int server);

/// Return Type: void
///sender: uptr->uintp->unsigned int
///request: uptr->uintp->unsigned int
///server: s32->int32->int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingServerListResponse_ServerFailedToRespond(uint sender, uint request, int server);

/// Return Type: void
///sender: uptr->uintp->unsigned int
///request: uptr->uintp->unsigned int
///response: Enum->s32->int32->int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingServerListResponse_RefreshComplete(uint sender, uint request, int response);

/// Return Type: void
///sender: uptr->uintp->unsigned int
///server: PDataPointer->void*
///serverSize: s32->int32->int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingPingResponse_ServerRespondedCallback(uint sender, System.IntPtr server, int serverSize);

/// Return Type: void
///sender: uptr->uintp->unsigned int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingPingResponse_ServerFailedToRespond(uint sender);

/// Return Type: void
///sender: uptr->uintp->unsigned int
///name: PConstantDataPointer->void*
///score: s32->int32->int
///timePlayed: f32->float
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingPlayersResponse_AddPlayerToList(uint sender, System.IntPtr name, int score, float timePlayed);

/// Return Type: void
///sender: uptr->uintp->unsigned int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingPlayersResponse_PlayersFailedToRespond(uint sender);

/// Return Type: void
///sender: uptr->uintp->unsigned int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingPlayersResponse_PlayersRefreshComplete(uint sender);

/// Return Type: void
///sender: uptr->uintp->unsigned int
///key: PConstantDataPointer->void*
///value: PConstantDataPointer->void*
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingRulesResponse_RulesResponded(uint sender, System.IntPtr key, System.IntPtr value);

/// Return Type: void
///sender: uptr->uintp->unsigned int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingRulesResponse_RulesFailedToRespond(uint sender);

/// Return Type: void
///sender: uptr->uintp->unsigned int
[System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.StdCall)]
internal delegate void MatchmakingRulesResponse_RulesRefreshComplete(uint sender);

[System.CodeDom.Compiler.GeneratedCode("InteropSignatureToolkit", "")]

internal partial class NativeMethods
{

    /// Return Type: boolean
    ///fileName: PConstantString->char*
    ///buffer: PConstantDataPointer->void*
    ///bufferLength: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Write")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_Write([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName, System.IntPtr buffer, int bufferLength);


    /// Return Type: s32->int32->int
    ///fileName: PConstantString->char*
    ///buffer: PDataPointer->void*
    ///bufferLength: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Read")]
    internal static extern int Cloud_Read([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName, System.IntPtr buffer, int bufferLength);


    /// Return Type: boolean
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Forget")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_Forget([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: boolean
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Delete")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_Delete([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: void
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Share")]
    internal static extern void Cloud_Share([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: boolean
    ///fileName: PConstantString->char*
    ///remoteStoragePlatform: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_SetSyncPlatforms")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_SetSyncPlatforms([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName, int remoteStoragePlatform);


    /// Return Type: boolean
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Exists")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_Exists([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: boolean
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Persisted")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_Persisted([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: s32->int32->int
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetSize")]
    internal static extern int Cloud_GetSize([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: s64->int64->__int64
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_Timestamp")]
    internal static extern long Cloud_Timestamp([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: Enum->s32->int32->int
    ///fileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetSyncPlatforms")]
    internal static extern int Cloud_GetSyncPlatforms([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetFileCount")]
    internal static extern int Cloud_GetFileCount();


    /// Return Type: PConstantString->char*
    ///fileID: s32->int32->int
    ///fileSize: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetFileNameAndSize")]
    internal static extern System.IntPtr Cloud_GetFileNameAndSize(int fileID, ref int fileSize);


    /// Return Type: boolean
    ///totalBytes: s32*
    ///availableBytes: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetQuota")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_GetQuota(ref int totalBytes, ref int availableBytes);


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_IsEnabledForAccount")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_IsEnabledForAccount();


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_IsEnabledForApplication")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_IsEnabledForApplication();


    /// Return Type: void
    ///enabled: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_SetEnabledForApplication")]
    internal static extern void Cloud_SetEnabledForApplication([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool enabled);


    /// Return Type: void
    ///handle: UGCHandle->u64->uint64->unsigned __int64
    ///unPriority: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UGCDownload")]
    internal static extern void Cloud_UGCDownload(ulong handle, uint unPriority);


    /// Return Type: boolean
    ///handle: UGCHandle->u64->uint64->unsigned __int64
    ///bytesDownloaded: s32*
    ///bytesExpected: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetUGCDownloadProgress")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_GetUGCDownloadProgress(ulong handle, ref int bytesDownloaded, ref int bytesExpected);


    /// Return Type: boolean
    ///handle: UGCHandle->u64->uint64->unsigned __int64
    ///appID: u32*
    ///name: char**
    ///fileSize: s32*
    ///creator: SteamID*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetUGCDetails")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_GetUGCDetails(ulong handle, ref uint appID, ref System.IntPtr name, ref int fileSize, ref ulong creator);


    /// Return Type: s32->int32->int
    ///handle: UGCHandle->u64->uint64->unsigned __int64
    ///buffer: PDataPointer->void*
    ///bufferLength: s32->int32->int
    ///offset: u32->uint32->unsigned int
    ///action: Enum->s32->int32->int

    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UGCRead")]
    internal static extern int Cloud_UGCRead(ulong handle, System.IntPtr buffer, int bufferLength, uint offset, int action);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetCachedUGCCount")]
    internal static extern int Cloud_GetCachedUGCCount();


    /// Return Type: UGCHandle->u64->uint64->unsigned __int64
    ///handleID: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetUGCHandle")]
    internal static extern ulong Cloud_GetUGCHandle(int handleID);


    /// Return Type: void
    ///fileName: PConstantString->char*
    ///previewFile: PConstantString->char*
    ///consumerAppId: u32->uint32->unsigned int
    ///title: PConstantString->char*
    ///description: PConstantString->char*
    ///visibility: Enum->s32->int32->int
    ///tags: PDataPointer->void*
    ///workshopFileType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_PublishWorkshopFile")]
    internal static extern void Cloud_PublishWorkshopFile([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string fileName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string previewFile, uint consumerAppId, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string title, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string description, int visibility, System.IntPtr tags, int workshopFileType);


    /// Return Type: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_CreatePublishedFileUpdateRequest")]
    internal static extern ulong Cloud_CreatePublishedFileUpdateRequest(ulong publishedFileId);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///file: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFileFile")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFileFile(ulong updateHandle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string file);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///previewFile: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFilePreviewFile")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFilePreviewFile(ulong updateHandle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string previewFile);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///title: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFileTitle")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFileTitle(ulong updateHandle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string title);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///description: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFileDescription")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFileDescription(ulong updateHandle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string description);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///visibility: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFileVisibility")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFileVisibility(ulong updateHandle, int visibility);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///tags: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFileTags")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFileTags(ulong updateHandle, System.IntPtr tags);


    /// Return Type: void
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_CommitPublishedFileUpdate")]
    internal static extern void Cloud_CommitPublishedFileUpdate(ulong updateHandle);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    ///maxSecondsOld: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetPublishedFileDetails")]
    internal static extern void Cloud_GetPublishedFileDetails(ulong publishedFileId, uint maxSecondsOld);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_DeletePublishedFile")]
    internal static extern void Cloud_DeletePublishedFile(ulong publishedFileId);


    /// Return Type: void
    ///startIndex: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_EnumerateUserPublishedFiles")]
    internal static extern void Cloud_EnumerateUserPublishedFiles(uint startIndex);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_SubscribePublishedFile")]
    internal static extern void Cloud_SubscribePublishedFile(ulong publishedFileId);


    /// Return Type: void
    ///startIndex: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_EnumerateUserSubscribedFiles")]
    internal static extern void Cloud_EnumerateUserSubscribedFiles(uint startIndex);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UnsubscribePublishedFile")]
    internal static extern void Cloud_UnsubscribePublishedFile(ulong publishedFileId);


    /// Return Type: boolean
    ///updateHandle: PublishedFileUpdateHandle->u64->uint64->unsigned __int64
    ///changeDescription: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdatePublishedFileSetChangeDescription")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Cloud_UpdatePublishedFileSetChangeDescription(ulong updateHandle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string changeDescription);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetPublishedItemVoteDetails")]
    internal static extern void Cloud_GetPublishedItemVoteDetails(ulong publishedFileId);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    ///voteUp: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UpdateUserPublishedItemVote")]
    internal static extern void Cloud_UpdateUserPublishedItemVote(ulong publishedFileId, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool voteUp);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_GetUserPublishedItemVoteDetails")]
    internal static extern void Cloud_GetUserPublishedItemVoteDetails(ulong publishedFileId);


    /// Return Type: void
    ///steamId: SteamID->u64->uint64->unsigned __int64
    ///startIndex: u32->uint32->unsigned int
    ///requiredTags: PDataPointer->void*
    ///excludedTags: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_EnumerateUserSharedWorkshopFiles")]
    internal static extern void Cloud_EnumerateUserSharedWorkshopFiles(ulong steamId, uint startIndex, System.IntPtr requiredTags, System.IntPtr excludedTags);


    /// Return Type: void
    /// videoProvider: Enum->s32->int32->int
    /// videoAccount: PConstantString->char*
    /// videoIdentifier: PConstantString->char*
    /// videoPreview: PConstantString->char*
    /// consumerAppId: AppID->u32->uint32->unsigned int
    /// title: PConstantString->char*
    /// description: PConstantString->char*
    /// visibility: Enum->s32->int32->int
    /// PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_PublishVideo")]
    internal static extern void Cloud_PublishVideo(int videoProvider, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string videoAccount, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string videoIdentifier, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string videoPreview, uint consumerAppId, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string title, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string description, int visibility, System.IntPtr tags);


    /// Return Type: void
    ///publishedFileId: PublishedFileId->u64->uint64->unsigned __int64
    ///action: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_SetUserPublishedFileAction")]
    internal static extern void Cloud_SetUserPublishedFileAction(ulong publishedFileId, int action);


    /// Return Type: void
    ///action: Enum->s32->int32->int
    ///startIndex: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_EnumeratePublishedFilesByUserAction")]
    internal static extern void Cloud_EnumeratePublishedFilesByUserAction(int action, uint startIndex);

    /// Return Type: void
    ///enumerationType: Enum->s32->int32->int
    ///startIndex: u32->uint32->unsigned int
    ///count: u32->uint32->unsigned int
    ///days: u32->uint32->unsigned int
    ///tags: PDataPointer->void*
    ///userTags: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_EnumeratePublishedWorkshopFiles")]
    internal static extern void Cloud_EnumeratePublishedWorkshopFiles(int enumerationType, uint startIndex, uint count, uint days, System.IntPtr tags, System.IntPtr userTags);

    /// Return Type: void
    /// content: UGCHandle->u64->uint64->unsigned __int64
    /// location: PConstantString->char*
    /// priority: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Cloud_UGCDownloadToLocation")]
    internal static extern void Cloud_UGCDownloadToLocation(ulong content, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string location, uint priority);


    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_GetInterfaceVersion")]
    internal static extern uint Services_GetInterfaceVersion();


    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_GetErrorCode")]
    internal static extern int Services_GetErrorCode();


    /// Return Type: boolean
    ///interfaceVersion: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_Startup")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Services_Startup(uint interfaceVersion);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_Shutdown")]
    internal static extern void Services_Shutdown();


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_IsSteamRunning")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Services_IsSteamRunning();


    /// Return Type: boolean
    /// ownAppID: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_RestartAppIfNecessary")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Services_RestartAppIfNecessary(uint ownAppID);


    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_GetSteamLoadStatus")]
    internal static extern int Services_GetSteamLoadStatus();


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_HandleCallbacks")]
    internal static extern void Services_HandleCallbacks();


    /// Return Type: u32->uint->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_GetAppID")]
    internal static extern uint Services_GetAppID();


    /// Return Type: void
    ///callback: ManagedCallback
    ///resultCallback: ManagedResultCallback
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_RegisterManagedCallbacks")]
    internal static extern void Services_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_RemoveManagedCallbacks")]
    internal static extern void Services_RemoveManagedCallbacks();

    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Services_RunCallbackSizeCheck")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Services_RunCallbackSizeCheck();

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_RequestCurrentStats")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_RequestCurrentStats();


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///data: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetStatInt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetStatInt([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref int data);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///data: float*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetStatFloat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetStatFloat([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref float data);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///data: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_SetStatInt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_SetStatInt([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, int data);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///data: float
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_SetStatFloat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_SetStatFloat([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, float data);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///countThisSession: float
    ///sessionLength: double
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_UpdateAverageRateStat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_UpdateAverageRateStat([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, float countThisSession, double sessionLength);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///achieved: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetAchievement([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref bool achieved);


    /// Return Type: boolean
    ///name: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_SetAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_SetAchievement([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name);


    /// Return Type: boolean
    ///name: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_ClearAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_ClearAchievement([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///achieved: boolean*
    ///unlockTime: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetAchievementAndUnlockTime")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetAchievementAndUnlockTime([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref bool achieved, ref uint unlockTime);


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_StoreStats")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_StoreStats();


    /// Return Type: s32->int32->int
    ///name: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetAchievementIcon")]
    internal static extern int Stats_GetAchievementIcon([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name);


    /// Return Type: PConstantString->char*
    ///name: PConstantString->char*
    ///key: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetAchievementDisplayAttribute")]
    internal static extern System.IntPtr Stats_GetAchievementDisplayAttribute([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///currentProgress: u32->uint32->unsigned int
    ///maxProgess: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_IndicateAchievementProgress")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_IndicateAchievementProgress([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, uint currentProgress, uint maxProgess);


    /// Return Type: void
    ///steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_RequestUserStats")]
    internal static extern void Stats_RequestUserStats(ulong steamID);


    /// Return Type: boolean
    ///steamID: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///data: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetUserStatInt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetUserStatInt(ulong steamID, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref int data);


    /// Return Type: boolean
    ///steamID: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///data: float*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetUserStatFloat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetUserStatFloat(ulong steamID, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref float data);


    /// Return Type: boolean
    ///steamID: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///achieved: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetUserAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetUserAchievement(ulong steamID, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref bool achieved);


    /// Return Type: boolean
    ///steamID: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///achieved: boolean*
    ///unlockTime: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetUserAchievementAndUnlockTime")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetUserAchievementAndUnlockTime(ulong steamID, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref bool achieved, ref uint unlockTime);


    /// Return Type: boolean
    ///achievementsToo: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_ResetAllStats")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_ResetAllStats([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool achievementsToo);


    /// Return Type: void
    ///name: PConstantString->char*
    ///sortMethod: Enum->s32->int32->int
    ///displayType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_FindOrCreateLeaderboard")]
    internal static extern void Stats_FindOrCreateLeaderboard([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, int sortMethod, int displayType);


    /// Return Type: void
    ///name: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_FindLeaderboard")]
    internal static extern void Stats_FindLeaderboard([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name);


    /// Return Type: PConstantString->char*
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetLeaderboardName")]
    internal static extern System.IntPtr Stats_GetLeaderboardName(ulong handle);


    /// Return Type: s32->int32->int
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetLeaderboardEntryCount")]
    internal static extern int Stats_GetLeaderboardEntryCount(ulong handle);


    /// Return Type: Enum->s32->int32->int
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetLeaderboardSortMethod")]
    internal static extern int Stats_GetLeaderboardSortMethod(ulong handle);


    /// Return Type: Enum->s32->int32->int
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetLeaderboardDisplayType")]
    internal static extern int Stats_GetLeaderboardDisplayType(ulong handle);


    /// Return Type: void
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    ///dataRequest: Enum->s32->int32->int
    ///start: s32->int32->int
    ///end: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_DownloadLeaderboardEntries")]
    internal static extern void Stats_DownloadLeaderboardEntries(ulong handle, int dataRequest, int start, int end);


    /// Return Type: void
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    ///users: PConstantDataPointer->void*
    ///numberOfUsers: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_DownloadLeaderboardEntriesForUsers")]
    internal static extern void Stats_DownloadLeaderboardEntriesForUsers(ulong handle, System.IntPtr users, int numberOfUsers);


    /// Return Type: boolean
    ///entries: SteamLeaderboardEntries->u64->uint64->unsigned __int64
    ///index: s32->int32->int
    ///entry: PDataPointer->void*
    ///detailsBuffer: PDataPointer->void*
    ///maxDetails: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetDownloadedLeaderboardEntry")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetDownloadedLeaderboardEntry(ulong entries, int index, System.IntPtr entry, System.IntPtr detailsBuffer, int maxDetails);


    /// Return Type: void
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    ///scoreMethod: Enum->s32->int32->int
    ///score: s32->int32->int
    ///details: PConstantDataPointer->void*
    ///detailsCount: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_UploadLeaderboardScore")]
    internal static extern void Stats_UploadLeaderboardScore(ulong handle, int scoreMethod, int score, System.IntPtr details, int detailsCount);


    /// Return Type: void
    ///handle: SteamLeaderboard->u64->uint64->unsigned __int64
    ///ugcHandle: UGCHandle->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_AttachLeaderboardUGC")]
    internal static extern void Stats_AttachLeaderboardUGC(ulong handle, ulong ugcHandle);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetNumberOfCurrentPlayers")]
    internal static extern void Stats_GetNumberOfCurrentPlayers();


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_RequestGlobalAchievementPercentages")]
    internal static extern void Stats_RequestGlobalAchievementPercentages();


    /// Return Type: s32->int32->int
    ///name: PString->char*
    ///nameLength: u32->uint32->unsigned int
    ///percent: float*
    ///achieved: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetMostAchievedAchievementInfo")]
    internal static extern int Stats_GetMostAchievedAchievementInfo(System.IntPtr name, uint nameLength, ref float percent, ref bool achieved);


    /// Return Type: s32->int32->int
    ///iterator: s32->int32->int
    ///name: PString->char*
    ///nameLength: u32->uint32->unsigned int
    ///percent: float*
    ///achieved: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetNextMostAchievedAchievementInfo")]
    internal static extern int Stats_GetNextMostAchievedAchievementInfo(int iterator, System.IntPtr name, uint nameLength, ref float percent, ref bool achieved);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///percent: float*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetAchievementAchievedPercent")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetAchievementAchievedPercent([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref float percent);


    /// Return Type: void
    ///historyDays: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_RequestGlobalStats")]
    internal static extern void Stats_RequestGlobalStats(int historyDays);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///data: s64*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetGlobalStatInt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetGlobalStatInt([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref long data);


    /// Return Type: boolean
    ///name: PConstantString->char*
    ///data: double*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetGlobalStatDouble")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Stats_GetGlobalStatDouble([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref double data);


    /// Return Type: s32->int32->int
    ///name: PConstantString->char*
    ///dataBuffer: PDataPointer->void*
    ///bufferSize: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetGlobalStatHistoryInt")]
    internal static extern int Stats_GetGlobalStatHistoryInt([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, System.IntPtr dataBuffer, uint bufferSize);


    /// Return Type: s32->int32->int
    ///name: PConstantString->char*
    ///dataBuffer: PDataPointer->void*
    ///bufferSize: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Stats_GetGlobalStatHistoryDouble")]
    internal static extern int Stats_GetGlobalStatHistoryDouble([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, System.IntPtr dataBuffer, uint bufferSize);


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_IsLoggedOn")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool User_IsLoggedOn();


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetSteamID")]
    internal static extern ulong User_GetSteamID();

    /// Return Type: s32->int32->int
    /// authBlob: PDataPointer->void*
    /// maxAuthBlob: s32->int->int
    /// steamIDGameServer: SteamID->u64->uint64->unsigned __int64 (ulong)
    /// serverIP: u32->uint32->unsigned int
    /// serverPort: u16->uint16->unsigned short
    /// secure: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_InitiateGameConnection")]
    internal static extern int User_InitiateGameConnection(System.IntPtr authBlob, int maxAuthBlob, ulong steamIDGameServer, uint serverIP,
            ushort serverPort, bool secure);

    /// Return Type: void
    /// serverIP: u32->uint32->unsigned int
    /// serverPort: u16->uint16->unsigned short
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_TerminateGameConnection")]
    internal static extern void User_TerminateGameConnection(uint serverIP, ushort serverPort);

    /// Return Type: void
    /// gameID: GameID->u64->uint64->unsigned __int64
    /// appUsageEvent: s32->int32->int
    /// extraInfo: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_TrackAppUsageEvent")]
    internal static extern void User_TrackAppUsageEvent(ulong gameID, int appUsageEvent, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string extraInfo);

    /// Return Type: boolean
    /// buffer: PString->char*
    /// bufferLength: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetUserDataFolder")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool User_GetUserDataFolder(System.IntPtr buffer, int bufferLength);

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_StartVoiceRecording")]
    internal static extern void User_StartVoiceRecording();

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_StopVoiceRecording")]
    internal static extern void User_StopVoiceRecording();

    /// Return Type: Enum->s32->int32->int
    /// compressed: u32*
    /// uncompressed: u32*
    /// uncompressedVoiceDesiredSampleRate: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetAvailableVoice")]
    internal static extern int User_GetAvailableVoice(ref uint compressed, ref uint uncompressed, uint uncompressedVoiceDesiredSampleRate);

    /// Return Type: Enum->s32->int32->int
    /// wantCompressed: boolean
    /// destBuffer: PDataPointer->void*
    /// destBufferSize: u32->uint32->unsigned int
    /// bytesWritten: u32*
    /// wantUncompressed: boolean
    /// uncompressedDestBuffer: PDataPointer->void*
    /// uncompressedDestBufferSize: u32->uint32->unsigned int 
    /// uncompressedBytesWritten: u32*
    /// uncompressedVoiceDesiredSampleRate: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetVoice")]
    internal static extern int User_GetVoice(bool wantCompressed, System.IntPtr destBuffer, uint destBufferSize, ref uint bytesWritten, bool wantUncompressed, System.IntPtr uncompressedDestBuffer, uint uncompressedDestBufferSize, ref uint uncompressedBytesWritten, uint uncompressedVoiceDesiredSampleRate);

    /// Return Type: Enum->s32->int32->int
    /// compressed: PConstantDataPointer->void*
    /// compressedSize: u32->uint32->unsigned int
    /// destBuffer: PDataPointer->void*
    /// destBufferSize: u32->uint32->unsigned int
    /// bytesWritten: u32*
    /// desiredSampleRate: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_DecompressVoice")]
    internal static extern int User_DecompressVoice(System.IntPtr compressed, uint compressedSize, System.IntPtr destBuffer, uint destBufferSize, ref uint bytesWritten, uint desiredSampleRate);

    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetVoiceOptimalSampleRate")]
    internal static extern uint User_GetVoiceOptimalSampleRate();

    /// Return Type: AuthTicket->u32->uint32->unsigned int
    /// ticket: PDataPointer->void*
    /// maxTicket: s32->int32->int
    /// ticketLength: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetAuthSessionTicket")]
    internal static extern uint User_GetAuthSessionTicket(System.IntPtr ticket, int maxTicket, ref uint ticketLength);

    /// Return Type: Enum->s32->int32->int
    /// authTicket: PConstantDataPointer->void*
    /// cbAuthTicket: s32->int32->int
    /// steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_BeginAuthSession")]
    internal static extern int User_BeginAuthSession(System.IntPtr authTicket, int cbAuthTicket, ulong steamID);

    /// Return Type: void
    /// steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_EndAuthSession")]
    internal static extern void User_EndAuthSession(ulong steamID);

    /// Return Type: void
    /// authTicket: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_CancelAuthTicket")]
    internal static extern void User_CancelAuthTicket(uint authTicket);

    /// Return Type: Enum->s32->int32->int
    /// steamID: SteamID->u64->uint64->unsigned __int64
    /// appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_UserHasLicenseForApp")]
    internal static extern int User_UserHasLicenseForApp(ulong steamID, uint appID);

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_IsBehindNAT")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool User_IsBehindNAT();

    /// Return Type: void
    /// steamIDGameServer: SteamID->u64->uint64->unsigned __int64
    /// serverIP: u32->uint32->unsigned int
    /// serverPort: u16->uint16->unsigned short
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_AdvertiseGame")]
    internal static extern void User_AdvertiseGame(ulong steamIDGameServer, uint serverIP, ushort serverPort);

    /// Return Type: void
    /// dataToInclude: PDataPointer->void*
    /// cbDataToInclude: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_RequestEncryptedAppTicket")]
    internal static extern void User_RequestEncryptedAppTicket(System.IntPtr dataToInclude, int cbDataToInclude);

    /// Return Type: boolean
    /// ticket: PDataPointer->void*
    /// maxTicket: s32->int32->int
    /// ticketLength: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetEncryptedAppTicket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool User_GetEncryptedAppTicket(System.IntPtr ticket, int maxTicket, ref uint ticketLength);

    /// Return Type: s32->int32->int
    /// nSeries: s32->int32->int
    /// bFoil: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetGameBadgeLevel")]
    internal static extern int User_GetGameBadgeLevel(int nSeries, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool bFoil);

    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "User_GetPlayerSteamLevel")]
    internal static extern int User_GetPlayerSteamLevel();

    /// Return Type: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetPersonaName")]
    internal static extern System.IntPtr Friends_GetPersonaName();


    /// Return Type: void
    ///personaName: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_SetPersonaName")]
    internal static extern void Friends_SetPersonaName(System.IntPtr personaName);


    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetPersonaState")]
    internal static extern int Friends_GetPersonaState();


    /// Return Type: s32->int32->int
    ///friendFlags: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendCount")]
    internal static extern int Friends_GetFriendCount(int friendFlags);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///friendIndex: s32->int32->int
    ///friendFlags: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendByIndex")]
    internal static extern ulong Friends_GetFriendByIndex(int friendIndex, int friendFlags);


    /// Return Type: Enum->s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendRelationship")]
    internal static extern int Friends_GetFriendRelationship(ulong steamIDFriend);


    /// Return Type: Enum->s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendPersonaState")]
    internal static extern int Friends_GetFriendPersonaState(ulong steamIDFriend);


    /// Return Type: PConstantUtf8String->void*
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendPersonaName")]
    internal static extern System.IntPtr Friends_GetFriendPersonaName(ulong steamIDFriend);


    /// Return Type: boolean
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///friendGameInfo: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendGamePlayed")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_GetFriendGamePlayed(ulong steamIDFriend, System.IntPtr friendGameInfo);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendGameInfoSize")]
    internal static extern int Friends_GetFriendGameInfoSize();


    /// Return Type: PConstantUtf8String->void*
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///personaName: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendPersonaNameHistory")]
    internal static extern System.IntPtr Friends_GetFriendPersonaNameHistory(ulong steamIDFriend, int personaName);

    /// Return Type: PConstantUtf8String->void*
    ///steamIDPlayer: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetPlayerNickname")]
    internal static extern System.IntPtr Friends_GetPlayerNickname(ulong steamIDPlayer);

    /// Return Type: boolean
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///friendFlags: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_HasFriend")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_HasFriend(ulong steamIDFriend, int friendFlags);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanCount")]
    internal static extern int Friends_GetClanCount();


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///clan: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanByIndex")]
    internal static extern ulong Friends_GetClanByIndex(int clan);


    /// Return Type: PConstantString->char*
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanName")]
    internal static extern System.IntPtr Friends_GetClanName(ulong steamIDClan);


    /// Return Type: PConstantString->char*
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanTag")]
    internal static extern System.IntPtr Friends_GetClanTag(ulong steamIDClan);


    /// Return Type: boolean
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    ///online: s32*
    ///inGame: s32*
    ///chatting: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanActivityCounts")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_GetClanActivityCounts(ulong steamIDClan, ref int online, ref int inGame, ref int chatting);


    /// Return Type: void
    ///steamIDClans: PConstantDataPointer->void*
    ///clansToRequest: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_DownloadClanActivityCounts")]
    internal static extern void Friends_DownloadClanActivityCounts(System.IntPtr steamIDClans, int clansToRequest);


    /// Return Type: s32->int32->int
    ///steamIDSource: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendCountFromSource")]
    internal static extern int Friends_GetFriendCountFromSource(ulong steamIDSource);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///steamIDSource: SteamID->u64->uint64->unsigned __int64
    ///friendIndex: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendFromSourceByIndex")]
    internal static extern ulong Friends_GetFriendFromSourceByIndex(ulong steamIDSource, int friendIndex);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///steamIDSource: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_IsUserInSource")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_IsUserInSource(ulong steamIDUser, ulong steamIDSource);


    /// Return Type: void
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///speaking: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_SetInGameVoiceSpeaking")]
    internal static extern void Friends_SetInGameVoiceSpeaking(ulong steamIDUser, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool speaking);


    /// Return Type: void
    ///dialogType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ActivateGameOverlay")]
    internal static extern void Friends_ActivateGameOverlay(int dialogType);


    /// Return Type: void
    ///dialogType: Enum->s32->int32->int
    ///steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ActivateGameOverlayToUser")]
    internal static extern void Friends_ActivateGameOverlayToUser(int dialogType, ulong steamID);


    /// Return Type: void
    ///url: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ActivateGameOverlayToWebPage")]
    internal static extern void Friends_ActivateGameOverlayToWebPage([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string url);


    /// Return Type: void
    /// appID: AppID->u32->uint32->unsigned int
    /// flag: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ActivateGameOverlayToStore")]
    internal static extern void Friends_ActivateGameOverlayToStore(uint appId, int flag);

    /// Return Type: void
    ///steamIDUserPlayedWith: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_SetPlayedWith")]
    internal static extern void Friends_SetPlayedWith(ulong steamIDUserPlayedWith);


    /// Return Type: void
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ActivateGameOverlayInviteDialog")]
    internal static extern void Friends_ActivateGameOverlayInviteDialog(ulong steamIDLobby);


    /// Return Type: s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetSmallFriendAvatar")]
    internal static extern int Friends_GetSmallFriendAvatar(ulong steamIDFriend);


    /// Return Type: s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetMediumFriendAvatar")]
    internal static extern int Friends_GetMediumFriendAvatar(ulong steamIDFriend);


    /// Return Type: s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetLargeFriendAvatar")]
    internal static extern int Friends_GetLargeFriendAvatar(ulong steamIDFriend);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///requireNameOnly: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_RequestUserInformation")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_RequestUserInformation(ulong steamIDUser, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool requireNameOnly);


    /// Return Type: void
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_RequestClanOfficerList")]
    internal static extern void Friends_RequestClanOfficerList(ulong steamIDClan);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanOwner")]
    internal static extern ulong Friends_GetClanOwner(ulong steamIDClan);


    /// Return Type: s32->int32->int
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanOfficerCount")]
    internal static extern int Friends_GetClanOfficerCount(ulong steamIDClan);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    ///officer: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanOfficerByIndex")]
    internal static extern ulong Friends_GetClanOfficerByIndex(ulong steamIDClan, int officer);


    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetUserRestrictions")]
    internal static extern uint Friends_GetUserRestrictions();


    /// Return Type: boolean
    ///key: PConstantString->char*
    ///value: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_SetRichPresence")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_SetRichPresence([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, System.IntPtr value);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ClearRichPresence")]
    internal static extern void Friends_ClearRichPresence();


    /// Return Type: PConstantUtf8String->void*
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///key: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendRichPresence")]
    internal static extern System.IntPtr Friends_GetFriendRichPresence(ulong steamIDFriend, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


    /// Return Type: s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendRichPresenceKeyCount")]
    internal static extern int Friends_GetFriendRichPresenceKeyCount(ulong steamIDFriend);


    /// Return Type: PConstantUtf8String->void*
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///key: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendRichPresenceKeyByIndex")]
    internal static extern System.IntPtr Friends_GetFriendRichPresenceKeyByIndex(ulong steamIDFriend, int key);


    /// Return Type: void
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_RequestFriendRichPresence")]
    internal static extern void Friends_RequestFriendRichPresence(ulong steamIDFriend);


    /// Return Type: boolean
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///connectString: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_InviteUserToGame")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_InviteUserToGame(ulong steamIDFriend, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string connectString);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetCoplayFriendCount")]
    internal static extern int Friends_GetCoplayFriendCount();


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///coplayFriend: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetCoplayFriend")]
    internal static extern ulong Friends_GetCoplayFriend(int coplayFriend);


    /// Return Type: s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendCoplayTime")]
    internal static extern int Friends_GetFriendCoplayTime(ulong steamIDFriend);


    /// Return Type: AppID->u32->uint32->unsigned int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendCoplayGame")]
    internal static extern uint Friends_GetFriendCoplayGame(ulong steamIDFriend);


    /// Return Type: void
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_JoinClanChatRoom")]
    internal static extern void Friends_JoinClanChatRoom(ulong steamIDClan);


    /// Return Type: boolean
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_LeaveClanChatRoom")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_LeaveClanChatRoom(ulong steamIDClan);


    /// Return Type: s32->int32->int
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanChatMemberCount")]
    internal static extern int Friends_GetClanChatMemberCount(ulong steamIDClan);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    ///user: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetChatMemberByIndex")]
    internal static extern ulong Friends_GetChatMemberByIndex(ulong steamIDClan, int user);


    /// Return Type: boolean
    ///steamIDClanChat: SteamID->u64->uint64->unsigned __int64
    ///text: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_SendClanChatMessage")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_SendClanChatMessage(ulong steamIDClanChat, System.IntPtr text);


    /// Return Type: s32->int32->int
    ///steamIDClanChat: SteamID->u64->uint64->unsigned __int64
    ///message: s32->int32->int
    ///text: PUtf8String->void*
    ///textSize: s32->int32->int
    ///chatEntryType: Enum*
    ///sender: SteamID*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetClanChatMessage")]
    internal static extern int Friends_GetClanChatMessage(ulong steamIDClanChat, int message, System.IntPtr text, int textSize, ref int chatEntryType, ref ulong sender);


    /// Return Type: boolean
    ///steamIDClanChat: SteamID->u64->uint64->unsigned __int64
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_IsClanChatAdmin")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_IsClanChatAdmin(ulong steamIDClanChat, ulong steamIDUser);


    /// Return Type: boolean
    ///steamIDClanChat: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_IsClanChatWindowOpenInSteam")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_IsClanChatWindowOpenInSteam(ulong steamIDClanChat);


    /// Return Type: boolean
    ///steamIDClanChat: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_OpenClanChatWindowInSteam")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_OpenClanChatWindowInSteam(ulong steamIDClanChat);


    /// Return Type: boolean
    ///steamIDClanChat: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_CloseClanChatWindowInSteam")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_CloseClanChatWindowInSteam(ulong steamIDClanChat);


    /// Return Type: boolean
    ///interceptEnabled: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_SetListenForFriendsMessages")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_SetListenForFriendsMessages([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool interceptEnabled);


    /// Return Type: boolean
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///msgToSend: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_ReplyToFriendMessage")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Friends_ReplyToFriendMessage(ulong steamIDFriend, System.IntPtr msgToSend);


    /// Return Type: s32->int32->int
    ///steamIDFriend: SteamID->u64->uint64->unsigned __int64
    ///messageID: s32->int32->int
    ///text: PUtf8String->void*
    ///textSize: s32->int32->int
    ///chatEntryType: Enum*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFriendMessage")]
    internal static extern int Friends_GetFriendMessage(ulong steamIDFriend, int messageID, System.IntPtr text, int textSize, ref int chatEntryType);


    /// Return Type: void
    ///steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_GetFollowerCount")]
    internal static extern void Friends_GetFollowerCount(ulong steamID);


    /// Return Type: void
    ///steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_IsFollowing")]
    internal static extern void Friends_IsFollowing(ulong steamID);


    /// Return Type: void
    ///startIndex: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Friends_EnumerateFollowingList")]
    internal static extern void Friends_EnumerateFollowingList(uint startIndex);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetFavoriteGameCount")]
    internal static extern int MatchMaking_GetFavoriteGameCount();


    /// Return Type: boolean
    ///game: s32->int32->int
    ///appID: u32*
    ///ip: u32*
    ///connPort: u16*
    ///queryPort: u16*
    ///flags: u32*
    ///time32LastPlayedOnServer: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetFavoriteGame")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_GetFavoriteGame(int game, ref uint appID, ref uint ip, ref ushort connPort, ref ushort queryPort, ref uint flags, ref uint time32LastPlayedOnServer);


    /// Return Type: s32->int32->int
    ///appID: u32->uint32->unsigned int
    ///ip: u32->uint32->unsigned int
    ///connPort: u16->uint16->unsigned short
    ///queryPort: u16->uint16->unsigned short
    ///flags: u32->uint32->unsigned int
    ///time32LastPlayedOnServer: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddFavoriteGame")]
    internal static extern int MatchMaking_AddFavoriteGame(uint appID, uint ip, ushort connPort, ushort queryPort, uint flags, uint time32LastPlayedOnServer);


    /// Return Type: boolean
    ///appID: u32->uint32->unsigned int
    ///IP: u32->uint32->unsigned int
    ///connPort: u16->uint16->unsigned short
    ///queryPort: u16->uint16->unsigned short
    ///flags: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_RemoveFavoriteGame")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_RemoveFavoriteGame(uint appID, uint IP, ushort connPort, ushort queryPort, uint flags);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_RequestLobbyList")]
    internal static extern void MatchMaking_RequestLobbyList();


    /// Return Type: void
    ///keyToMatch: PConstantString->char*
    ///valueToMatch: PConstantString->char*
    ///comparisonType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListStringFilter")]
    internal static extern void MatchMaking_AddRequestLobbyListStringFilter([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string keyToMatch, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string valueToMatch, int comparisonType);


    /// Return Type: void
    ///keyToMatch: PConstantString->char*
    ///valueToMatch: s32->int32->int
    ///comparisonType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListNumericalFilter")]
    internal static extern void MatchMaking_AddRequestLobbyListNumericalFilter([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string keyToMatch, int valueToMatch, int comparisonType);


    /// Return Type: void
    ///keyToMatch: PConstantString->char*
    ///valueToBeCloseTo: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListNearValueFilter")]
    internal static extern void MatchMaking_AddRequestLobbyListNearValueFilter([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string keyToMatch, int valueToBeCloseTo);


    /// Return Type: void
    ///SlotsAvailable: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListFilterSlotsAvailable")]
    internal static extern void MatchMaking_AddRequestLobbyListFilterSlotsAvailable(int SlotsAvailable);


    /// Return Type: void
    ///lobbyDistanceFilter: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListDistanceFilter")]
    internal static extern void MatchMaking_AddRequestLobbyListDistanceFilter(int lobbyDistanceFilter);


    /// Return Type: void
    ///maxResults: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListResultCountFilter")]
    internal static extern void MatchMaking_AddRequestLobbyListResultCountFilter(int maxResults);


    /// Return Type: void
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_AddRequestLobbyListCompatibleMembersFilter")]
    internal static extern void MatchMaking_AddRequestLobbyListCompatibleMembersFilter(ulong steamIDLobby);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///lobby: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyByIndex")]
    internal static extern ulong MatchMaking_GetLobbyByIndex(int lobby);


    /// Return Type: void
    ///lobbyType: Enum->s32->int32->int
    ///maxMembers: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_CreateLobby")]
    internal static extern void MatchMaking_CreateLobby(int lobbyType, int maxMembers);


    /// Return Type: void
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_JoinLobby")]
    internal static extern void MatchMaking_JoinLobby(ulong steamIDLobby);


    /// Return Type: void
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_LeaveLobby")]
    internal static extern void MatchMaking_LeaveLobby(ulong steamIDLobby);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///steamIDInvitee: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_InviteUserToLobby")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_InviteUserToLobby(ulong steamIDLobby, ulong steamIDInvitee);


    /// Return Type: s32->int32->int
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetNumLobbyMembers")]
    internal static extern int MatchMaking_GetNumLobbyMembers(ulong steamIDLobby);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///member: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyMemberByIndex")]
    internal static extern ulong MatchMaking_GetLobbyMemberByIndex(ulong steamIDLobby, int member);


    /// Return Type: PConstantString->char*
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///key: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyData")]
    internal static extern System.IntPtr MatchMaking_GetLobbyData(ulong steamIDLobby, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///key: PConstantString->char*
    ///value: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SetLobbyData(ulong steamIDLobby, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string value);


    /// Return Type: s32->int32->int
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyDataCount")]
    internal static extern int MatchMaking_GetLobbyDataCount(ulong steamIDLobby);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///lobbyData: s32->int32->int
    ///key: PString->char*
    ///keyBufferSize: s32->int32->int
    ///value: PString->char*
    ///valueBufferSize: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyDataByIndex")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_GetLobbyDataByIndex(ulong steamIDLobby, int lobbyData, System.IntPtr key, int keyBufferSize, System.IntPtr value, int valueBufferSize);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///key: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_DeleteLobbyData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_DeleteLobbyData(ulong steamIDLobby, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


    /// Return Type: PConstantString->char*
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///SteamIDUser: SteamID->u64->uint64->unsigned __int64
    ///key: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyMemberData")]
    internal static extern System.IntPtr MatchMaking_GetLobbyMemberData(ulong steamIDLobby, ulong SteamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key);


    /// Return Type: void
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///key: PConstantString->char*
    ///value: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyMemberData")]
    internal static extern void MatchMaking_SetLobbyMemberData(ulong steamIDLobby, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string value);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///msg: PConstantDataPointer->void*
    ///cubMsg: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SendLobbyChatMsg")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SendLobbyChatMsg(ulong steamIDLobby, System.IntPtr msg, int cubMsg);


    /// Return Type: s32->int32->int
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///chatID: s32->int32->int
    ///steamIDUser: SteamID*
    ///data: PDataPointer->void*
    ///dataBufferSize: s32->int32->int
    ///chatEntryType: Enum*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyChatEntry")]
    internal static extern int MatchMaking_GetLobbyChatEntry(ulong steamIDLobby, int chatID, ref ulong steamIDUser, System.IntPtr data, int dataBufferSize, ref int chatEntryType);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_RequestLobbyData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_RequestLobbyData(ulong steamIDLobby);


    /// Return Type: void
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///gameServerIP: u32->uint32->unsigned int
    ///gameServerPort: u16->uint16->unsigned short
    ///steamIDGameServer: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyGameServer")]
    internal static extern void MatchMaking_SetLobbyGameServer(ulong steamIDLobby, uint gameServerIP, ushort gameServerPort, ulong steamIDGameServer);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///gameServerIP: u32*
    ///gameServerPort: u16*
    ///steamIDGameServer: SteamID*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyGameServer")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_GetLobbyGameServer(ulong steamIDLobby, ref uint gameServerIP, ref ushort gameServerPort, ref ulong steamIDGameServer);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///maxMembers: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyMemberLimit")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SetLobbyMemberLimit(ulong steamIDLobby, int maxMembers);


    /// Return Type: s32->int32->int
    ///steamIDlobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyMemberLimit")]
    internal static extern int MatchMaking_GetLobbyMemberLimit(ulong steamIDlobby);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///lobbyType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyType")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SetLobbyType(ulong steamIDLobby, int lobbyType);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///lobbyJoinable: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyJoinable")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SetLobbyJoinable(ulong steamIDLobby, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool lobbyJoinable);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_GetLobbyOwner")]
    internal static extern ulong MatchMaking_GetLobbyOwner(ulong steamIDLobby);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///steamIDNewOwner: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLobbyOwner")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SetLobbyOwner(ulong steamIDLobby, ulong steamIDNewOwner);


    /// Return Type: boolean
    ///steamIDLobby: SteamID->u64->uint64->unsigned __int64
    ///steamIDLobbyDependent: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchMaking_SetLinkedLobby")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchMaking_SetLinkedLobby(ulong steamIDLobby, ulong steamIDLobbyDependent);


    /// Return Type: PConstantAnsiString->char*
    ///instance: PConstantDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServerNetworkAddress_GetConnectionString")]
    internal static extern System.IntPtr MatchmakingServerNetworkAddress_GetConnectionString(System.IntPtr instance);


    /// Return Type: PConstantAnsiString->char*
    ///instance: PConstantDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServerNetworkAddress_GetQueryString")]
    internal static extern System.IntPtr MatchmakingServerNetworkAddress_GetQueryString(System.IntPtr instance);


    /// Return Type: ServerListRequest->uptr->uintp->unsigned int
    ///appId: u32->uint32->unsigned int
    ///filters: PDataPointer->void*
    ///filterCount: u32->uint32->unsigned int
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RequestInternetServerList")]
    internal static extern uint MatchmakingServers_RequestInternetServerList(uint appId, System.IntPtr filters, uint filterCount, uint requestServersResponse);


    /// Return Type: ServerListRequest->uptr->uintp->unsigned int
    ///appId: u32->uint32->unsigned int
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RequestLANServerList")]
    internal static extern uint MatchmakingServers_RequestLANServerList(uint appId, uint requestServersResponse);


    /// Return Type: ServerListRequest->uptr->uintp->unsigned int
    ///appId: u32->uint32->unsigned int
    ///filters: PDataPointer->void*
    ///filtersCount: u32->uint32->unsigned int
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RequestFriendsServerList")]
    internal static extern uint MatchmakingServers_RequestFriendsServerList(uint appId, System.IntPtr filters, uint filtersCount, uint requestServersResponse);


    /// Return Type: ServerListRequest->uptr->uintp->unsigned int
    ///appId: u32->uint32->unsigned int
    ///filters: PDataPointer->void*
    ///filterCount: u32->uint32->unsigned int
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RequestFavoritesServerList")]
    internal static extern uint MatchmakingServers_RequestFavoritesServerList(uint appId, System.IntPtr filters, uint filterCount, uint requestServersResponse);


    /// Return Type: ServerListRequest->uptr->uintp->unsigned int
    ///appId: u32->uint32->unsigned int
    ///filters: PDataPointer->void*
    ///filterCount: u32->uint32->unsigned int
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RequestHistoryServerList")]
    internal static extern uint MatchmakingServers_RequestHistoryServerList(uint appId, System.IntPtr filters, uint filterCount, uint requestServersResponse);


    /// Return Type: ServerListRequest->uptr->uintp->unsigned int
    ///appId: u32->uint32->unsigned int
    ///filters: PDataPointer->void*
    ///filterCount: u32->uint32->unsigned int
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RequestSpectatorServerList")]
    internal static extern uint MatchmakingServers_RequestSpectatorServerList(uint appId, System.IntPtr filters, uint filterCount, uint requestServersResponse);


    /// Return Type: void
    ///request: ServerListRequest->uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_ReleaseRequest")]
    internal static extern void MatchmakingServers_ReleaseRequest(uint request);


    /// Return Type: PDataPointer->void*
    ///request: ServerListRequest->uptr->uintp->unsigned int
    ///server: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_GetServerDetails")]
    internal static extern System.IntPtr MatchmakingServers_GetServerDetails(uint request, int server);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_GetGameServerItemSize")]
    internal static extern int MatchmakingServers_GetGameServerItemSize();


    /// Return Type: void
    ///request: ServerListRequest->uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_CancelQuery")]
    internal static extern void MatchmakingServers_CancelQuery(uint request);


    /// Return Type: void
    ///request: ServerListRequest->uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RefreshQuery")]
    internal static extern void MatchmakingServers_RefreshQuery(uint request);


    /// Return Type: boolean
    ///request: ServerListRequest->uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_IsRefreshing")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool MatchmakingServers_IsRefreshing(uint request);


    /// Return Type: s32->int32->int
    ///request: ServerListRequest->uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_GetServerCount")]
    internal static extern int MatchmakingServers_GetServerCount(uint request);


    /// Return Type: void
    ///request: ServerListRequest->uptr->uintp->unsigned int
    ///server: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_RefreshServer")]
    internal static extern void MatchmakingServers_RefreshServer(uint request, int server);


    /// Return Type: ServerQuery->s32->int32->int
    ///ip: u32->uint32->unsigned int
    ///port: u16->uint16->unsigned short
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_PingServer")]
    internal static extern int MatchmakingServers_PingServer(uint ip, ushort port, uint requestServersResponse);


    /// Return Type: ServerQuery->s32->int32->int
    ///ip: u32->uint32->unsigned int
    ///port: u16->uint16->unsigned short
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_PlayerDetails")]
    internal static extern int MatchmakingServers_PlayerDetails(uint ip, ushort port, uint requestServersResponse);


    /// Return Type: ServerQuery->s32->int32->int
    ///ip: u32->uint32->unsigned int
    ///port: u16->uint16->unsigned short
    ///requestServersResponse: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_ServerRules")]
    internal static extern int MatchmakingServers_ServerRules(uint ip, ushort port, uint requestServersResponse);


    /// Return Type: void
    ///serverQuery: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServers_CancelServerQuery")]
    internal static extern void MatchmakingServers_CancelServerQuery(int serverQuery);


    /// Return Type: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServerListResponse_CreateObject")]
    internal static extern uint MatchmakingServerListResponse_CreateObject();


    /// Return Type: void
    ///obj: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServerListResponse_DestroyObject")]
    internal static extern void MatchmakingServerListResponse_DestroyObject(uint obj);


    /// Return Type: void
    ///serverResponded: MatchmakingServerListResponse_ServerRespondedCallback
    ///serverFailedToRespond: MatchmakingServerListResponse_ServerFailedToRespond
    ///refreshComplete: MatchmakingServerListResponse_RefreshComplete
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServerListResponse_RegisterCallbacks")]
    internal static extern void MatchmakingServerListResponse_RegisterCallbacks(MatchmakingServerListResponse_ServerRespondedCallback serverResponded, MatchmakingServerListResponse_ServerFailedToRespond serverFailedToRespond, MatchmakingServerListResponse_RefreshComplete refreshComplete);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingServerListResponse_RemoveCallbacks")]
    internal static extern void MatchmakingServerListResponse_RemoveCallbacks();


    /// Return Type: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPingResponse_CreateObject")]
    internal static extern uint MatchmakingPingResponse_CreateObject();


    /// Return Type: void
    ///obj: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPingResponse_DestroyObject")]
    internal static extern void MatchmakingPingResponse_DestroyObject(uint obj);


    /// Return Type: void
    ///serverResponded: MatchmakingPingResponse_ServerRespondedCallback
    ///serverFailedToRespond: MatchmakingPingResponse_ServerFailedToRespond
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPingResponse_RegisterCallbacks")]
    internal static extern void MatchmakingPingResponse_RegisterCallbacks(MatchmakingPingResponse_ServerRespondedCallback serverResponded, MatchmakingPingResponse_ServerFailedToRespond serverFailedToRespond);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPingResponse_RemoveCallbacks")]
    internal static extern void MatchmakingPingResponse_RemoveCallbacks();


    /// Return Type: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPlayersResponse_CreateObject")]
    internal static extern uint MatchmakingPlayersResponse_CreateObject();


    /// Return Type: void
    ///obj: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPlayersResponse_DestroyObject")]
    internal static extern void MatchmakingPlayersResponse_DestroyObject(uint obj);


    /// Return Type: void
    ///addPlayerToList: MatchmakingPlayersResponse_AddPlayerToList
    ///playersFailedToRespond: MatchmakingPlayersResponse_PlayersFailedToRespond
    ///playersRefreshComplete: MatchmakingPlayersResponse_PlayersRefreshComplete
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPlayersResponse_RegisterCallbacks")]
    internal static extern void MatchmakingPlayersResponse_RegisterCallbacks(MatchmakingPlayersResponse_AddPlayerToList addPlayerToList, MatchmakingPlayersResponse_PlayersFailedToRespond playersFailedToRespond, MatchmakingPlayersResponse_PlayersRefreshComplete playersRefreshComplete);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingPlayersResponse_RemoveCallbacks")]
    internal static extern void MatchmakingPlayersResponse_RemoveCallbacks();


    /// Return Type: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingRulesResponse_CreateObject")]
    internal static extern uint MatchmakingRulesResponse_CreateObject();


    /// Return Type: void
    ///obj: uptr->uintp->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingRulesResponse_DestroyObject")]
    internal static extern void MatchmakingRulesResponse_DestroyObject(uint obj);


    /// Return Type: void
    ///rulesResponded: MatchmakingRulesResponse_RulesResponded
    ///rulesFailedToRespond: MatchmakingRulesResponse_RulesFailedToRespond
    ///rulesRefreshComplete: MatchmakingRulesResponse_RulesRefreshComplete
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingRulesResponse_RegisterCallbacks")]
    internal static extern void MatchmakingRulesResponse_RegisterCallbacks(MatchmakingRulesResponse_RulesResponded rulesResponded, MatchmakingRulesResponse_RulesFailedToRespond rulesFailedToRespond, MatchmakingRulesResponse_RulesRefreshComplete rulesRefreshComplete);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "MatchmakingRulesResponse_RemoveCallbacks")]
    internal static extern void MatchmakingRulesResponse_RemoveCallbacks();


    /// Return Type: boolean
    ///ip: u32->uint32->unsigned int
    ///gamePort: u16->uint16->unsigned short
    ///queryPort: u16->uint16->unsigned short
    ///flags: u32->uint32->unsigned int
    ///gameAppId: AppID->u32->uint32->unsigned int
    ///versionString: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_InitGameServer")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_InitGameServer(uint ip, ushort gamePort, ushort queryPort, uint flags, uint gameAppId, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string versionString);


    /// Return Type: void
    ///product: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetProduct")]
    internal static extern void GameServer_SetProduct([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string product);


    /// Return Type: void
    ///gameDescription: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetGameDescription")]
    internal static extern void GameServer_SetGameDescription([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string gameDescription);


    /// Return Type: void
    ///modDir: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetModDir")]
    internal static extern void GameServer_SetModDir([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string modDir);


    /// Return Type: void
    ///dedicated: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetDedicatedServer")]
    internal static extern void GameServer_SetDedicatedServer([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool dedicated);


    /// Return Type: void
    ///accountName: PConstantString->char*
    ///password: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_LogOn")]
    internal static extern void GameServer_LogOn([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string accountName, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string password);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_LogOnAnonymous")]
    internal static extern void GameServer_LogOnAnonymous();


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_LogOff")]
    internal static extern void GameServer_LogOff();


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_LoggedOn")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_LoggedOn();


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_Secure")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_Secure();


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_GetSteamID")]
    internal static extern ulong GameServer_GetSteamID();


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_WasRestartRequested")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_WasRestartRequested();


    /// Return Type: void
    ///playersMax: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetMaxPlayerCount")]
    internal static extern void GameServer_SetMaxPlayerCount(int playersMax);


    /// Return Type: void
    ///botplayers: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetBotPlayerCount")]
    internal static extern void GameServer_SetBotPlayerCount(int botplayers);


    /// Return Type: void
    ///serverName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetServerName")]
    internal static extern void GameServer_SetServerName([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string serverName);


    /// Return Type: void
    ///mapName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetMapName")]
    internal static extern void GameServer_SetMapName([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string mapName);


    /// Return Type: void
    ///passwordProtected: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetPasswordProtected")]
    internal static extern void GameServer_SetPasswordProtected([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool passwordProtected);


    /// Return Type: void
    ///spectatorPort: u16->uint16->unsigned short
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetSpectatorPort")]
    internal static extern void GameServer_SetSpectatorPort(ushort spectatorPort);


    /// Return Type: void
    ///spectatorServerName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetSpectatorServerName")]
    internal static extern void GameServer_SetSpectatorServerName([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string spectatorServerName);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_ClearAllKeyValues")]
    internal static extern void GameServer_ClearAllKeyValues();


    /// Return Type: void
    ///key: PConstantString->char*
    ///value: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetKeyValue")]
    internal static extern void GameServer_SetKeyValue([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string key, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string value);


    /// Return Type: void
    ///gameTags: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetGameTags")]
    internal static extern void GameServer_SetGameTags([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string gameTags);


    /// Return Type: void
    ///gameData: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetGameData")]
    internal static extern void GameServer_SetGameData([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string gameData);


    /// Return Type: void
    ///region: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetRegion")]
    internal static extern void GameServer_SetRegion([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string region);


    /// Return Type: boolean
    ///ipClient: u32->uint32->unsigned int
    ///authBlob: PConstantDataPointer->void*
    ///authBlobSize: u32->uint32->unsigned int
    ///steamIDUser: SteamID*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SendUserConnectAndAuthenticate")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_SendUserConnectAndAuthenticate(uint ipClient, System.IntPtr authBlob, uint authBlobSize, ref ulong steamIDUser);


    /// Return Type: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_CreateUnauthenticatedUserConnection")]
    internal static extern ulong GameServer_CreateUnauthenticatedUserConnection();


    /// Return Type: void
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SendUserDisconnect")]
    internal static extern void GameServer_SendUserDisconnect(ulong steamIDUser);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///playerName: PConstantString->char*
    ///core: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_UpdateUserData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_UpdateUserData(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string playerName, uint core);


    /// Return Type: AuthTicket->u32->uint32->unsigned int
    ///ticket: PDataPointer->void*
    ///maxTicket: s32->int32->int
    ///ticketSize: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_GetAuthSessionTicket")]
    internal static extern uint GameServer_GetAuthSessionTicket(System.IntPtr ticket, int maxTicket, ref uint ticketSize);


    /// Return Type: Enum->s32->int32->int
    ///authTicket: PConstantDataPointer->void*
    ///authTicketSize: s32->int32->int
    ///steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_BeginAuthSession")]
    internal static extern int GameServer_BeginAuthSession(System.IntPtr authTicket, int authTicketSize, ulong steamID);


    /// Return Type: void
    ///steamID: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_EndAuthSession")]
    internal static extern void GameServer_EndAuthSession(ulong steamID);


    /// Return Type: void
    ///authTicket: AuthTicket->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_CancelAuthTicket")]
    internal static extern void GameServer_CancelAuthTicket(uint authTicket);


    /// Return Type: Enum->s32->int32->int
    ///steamID: SteamID->u64->uint64->unsigned __int64
    ///appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_UserHasLicenseForApp")]
    internal static extern int GameServer_UserHasLicenseForApp(ulong steamID, uint appID);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///steamIDGroup: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_RequestUserGroupStatus")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_RequestUserGroupStatus(ulong steamIDUser, ulong steamIDGroup);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_GetGameplayStats")]
    internal static extern void GameServer_GetGameplayStats();


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_GetServerReputation")]
    internal static extern void GameServer_GetServerReputation();


    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_GetPublicIP")]
    internal static extern uint GameServer_GetPublicIP();


    /// Return Type: boolean
    ///data: PConstantDataPointer->void*
    ///dataSize: s32->int32->int
    ///ip: u32->uint32->unsigned int
    ///srcPort: u16->uint16->unsigned short
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_HandleIncomingPacket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServer_HandleIncomingPacket(System.IntPtr data, int dataSize, uint ip, ushort srcPort);


    /// Return Type: s32->int32->int
    ///out: PDataPointer->void*
    ///maxOut: s32->int32->int
    ///netAdr: u32*
    ///port: u16*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_GetNextOutgoingPacket")]
    internal static extern int GameServer_GetNextOutgoingPacket(System.IntPtr @out, int maxOut, ref uint netAdr, ref ushort port);


    /// Return Type: void
    ///active: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_EnableHeartbeats")]
    internal static extern void GameServer_EnableHeartbeats([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool active);


    /// Return Type: void
    ///heartbeatInterval: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_SetHeartbeatInterval")]
    internal static extern void GameServer_SetHeartbeatInterval(int heartbeatInterval);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_ForceHeartbeat")]
    internal static extern void GameServer_ForceHeartbeat();


    /// Return Type: void
    ///steamIDClan: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_AssociateWithClan")]
    internal static extern void GameServer_AssociateWithClan(ulong steamIDClan);


    /// Return Type: void
    ///steamIDNewPlayer: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServer_ComputeNewPlayerCompatibility")]
    internal static extern void GameServer_ComputeNewPlayerCompatibility(ulong steamIDNewPlayer);


    /// Return Type: void
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_RequestUserStats")]
    internal static extern void GameServerStats_RequestUserStats(ulong steamIDUser);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///data: s32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_GetUserStatInt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_GetUserStatInt(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref int data);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///data: f32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_GetUserStatFloat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_GetUserStatFloat(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref float data);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///achieved: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_GetUserAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_GetUserAchievement(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, ref bool achieved);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///data: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_SetUserStatInt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_SetUserStatInt(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, int data);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///data: f32->float
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_SetUserStatFloat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_SetUserStatFloat(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, float data);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    ///countThisSession: f32->float
    ///sessionLength: f64->double
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_UpdateUserAvgRateStat")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_UpdateUserAvgRateStat(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name, float countThisSession, double sessionLength);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_SetUserAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_SetUserAchievement(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name);


    /// Return Type: boolean
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    ///name: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_ClearUserAchievement")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool GameServerStats_ClearUserAchievement(ulong steamIDUser, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string name);


    /// Return Type: void
    ///steamIDUser: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "GameServerStats_StoreUserStats")]
    internal static extern void GameServerStats_StoreUserStats(ulong steamIDUser);


    /// Return Type: boolean
    ///steamIDRemote: SteamID->u64->uint64->unsigned __int64
    ///data: PConstantDataPointer->void*
    ///cubData: uint32->unsigned int
    ///p2pSendType: Enum->s32->int32->int
    ///channel: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_SendP2PPacket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_SendP2PPacket(ulong steamIDRemote, System.IntPtr data, uint cubData, int p2pSendType, int channel);
    
    
    /// Return Type: boolean
    ///steamIDRemote: SteamID->u64->uint64->unsigned __int64
    ///data: PConstantDataPointer->void*
    ///cubData: uint32->unsigned int
    ///dataOffset: uint32->unsigned int
    ///p2pSendType: Enum->s32->int32->int
    ///channel: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_SendP2PPacketOffset")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_SendP2PPacketOffset(ulong steamIDRemote, System.IntPtr data, uint cubData, uint dataOffset, int p2pSendType, int channel);


    /// Return Type: boolean
    ///msgSize: u32*
    ///channel: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_IsP2PPacketAvailable")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_IsP2PPacketAvailable(ref uint msgSize, int channel);


    /// Return Type: boolean
    ///dest: PDataPointer->void*
    ///cubDest: u32->uint32->unsigned int
    ///msgSize: u32*
    ///steamIDRemote: SteamID*
    ///channel: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_ReadP2PPacket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_ReadP2PPacket(System.IntPtr dest, uint cubDest, ref uint msgSize, ref ulong steamIDRemote, int channel);


    /// Return Type: boolean
    ///steamIDRemote: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_AcceptP2PSessionWithUser")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_AcceptP2PSessionWithUser(ulong steamIDRemote);


    /// Return Type: boolean
    ///steamIDRemote: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_CloseP2PSessionWithUser")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_CloseP2PSessionWithUser(ulong steamIDRemote);


    /// Return Type: boolean
    ///steamIDRemote: SteamID->u64->uint64->unsigned __int64
    ///channel: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_CloseP2PChannelWithUser")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_CloseP2PChannelWithUser(ulong steamIDRemote, int channel);


    /// Return Type: boolean
    ///steamIDRemote: SteamID->u64->uint64->unsigned __int64
    ///connectionState: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_GetP2PSessionState")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_GetP2PSessionState(ulong steamIDRemote, System.IntPtr connectionState);


    /// Return Type: boolean
    ///allow: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_AllowP2PPacketRelay")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_AllowP2PPacketRelay([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool allow);


    /// Return Type: NetListenSocket->u32->uint32->unsigned int
    ///virtualP2PPort: int
    ///ip: u32->uint32->unsigned int
    ///port: u16->uint16->unsigned short
    ///allowUseOfPacketRelay: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_CreateListenSocket")]
    internal static extern uint Networking_CreateListenSocket(int virtualP2PPort, uint ip, ushort port, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool allowUseOfPacketRelay);


    /// Return Type: NetSocket->u32->uint32->unsigned int
    ///steamIDTarget: SteamID->u64->uint64->unsigned __int64
    ///virtualPort: int
    ///timeoutSec: int
    ///allowUseOfPacketRelay: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_CreateP2PConnectionSocket")]
    internal static extern uint Networking_CreateP2PConnectionSocket(ulong steamIDTarget, int virtualPort, int timeoutSec, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool allowUseOfPacketRelay);


    /// Return Type: NetSocket->u32->uint32->unsigned int
    ///ip: u32->uint32->unsigned int
    ///port: u16->uint16->unsigned short
    ///timeoutSec: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_CreateConnectionSocket")]
    internal static extern uint Networking_CreateConnectionSocket(uint ip, ushort port, int timeoutSec);


    /// Return Type: boolean
    ///socket: NetSocket->u32->uint32->unsigned int
    ///notifyRemoteEnd: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_DestroySocket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_DestroySocket(uint socket, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool notifyRemoteEnd);


    /// Return Type: boolean
    ///socket: NetListenSocket->u32->uint32->unsigned int
    ///notifyRemoteEnd: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_DestroyListenSocket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_DestroyListenSocket(uint socket, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool notifyRemoteEnd);


    /// Return Type: boolean
    ///socket: NetSocket->u32->uint32->unsigned int
    ///data: PDataPointer->void*
    ///cubData: u32->uint32->unsigned int
    ///reliable: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_SendDataOnSocket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_SendDataOnSocket(uint socket, System.IntPtr data, uint cubData, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool reliable);


    /// Return Type: boolean
    ///socket: NetSocket->u32->uint32->unsigned int
    ///msgSize: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_IsDataAvailableOnSocket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_IsDataAvailableOnSocket(uint socket, ref uint msgSize);


    /// Return Type: boolean
    ///socket: NetSocket->u32->uint32->unsigned int
    ///dest: void*
    ///cubDest: u32->uint32->unsigned int
    ///msgSize: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_RetrieveDataFromSocket")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_RetrieveDataFromSocket(uint socket, System.IntPtr dest, uint cubDest, ref uint msgSize);


    /// Return Type: boolean
    ///listenSocket: NetListenSocket->u32->uint32->unsigned int
    ///msgSize: u32*
    ///socket: NetSocket*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_IsDataAvailable")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_IsDataAvailable(uint listenSocket, ref uint msgSize, ref uint socket);


    /// Return Type: boolean
    ///listenSocket: NetListenSocket->u32->uint32->unsigned int
    ///pubDest: void*
    ///cubDest: u32->uint32->unsigned int
    ///msgSize: u32*
    ///socket: NetSocket*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_RetrieveData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_RetrieveData(uint listenSocket, System.IntPtr pubDest, uint cubDest, ref uint msgSize, ref uint socket);


    /// Return Type: boolean
    ///socket: NetSocket->u32->uint32->unsigned int
    ///steamIDRemote: SteamID*
    ///socketStatus: Enum*
    ///ipRemote: u32*
    ///portRemote: u16*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_GetSocketInfo")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_GetSocketInfo(uint socket, ref ulong steamIDRemote, ref int socketStatus, ref uint ipRemote, ref ushort portRemote);


    /// Return Type: boolean
    ///listenSocket: NetListenSocket->u32->uint32->unsigned int
    ///ip: u32*
    ///port: u16*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_GetListenSocketInfo")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Networking_GetListenSocketInfo(uint listenSocket, ref uint ip, ref ushort port);


    /// Return Type: Enum->s32->int32->int
    ///socket: NetSocket->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_GetSocketConnectionType")]
    internal static extern int Networking_GetSocketConnectionType(uint socket);


    /// Return Type: int
    ///socket: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_GetMaxPacketSize")]
    internal static extern int Networking_GetMaxPacketSize(uint socket);


    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Networking_GetP2PSessionStateSize")]
    internal static extern int Networking_GetP2PSessionStateSize();


    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_GetInterfaceVersion")]
    internal static extern uint ServicesGameServer_GetInterfaceVersion();


    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_GetErrorCode")]
    internal static extern int ServicesGameServer_GetErrorCode();


    /// Return Type: boolean
    ///interfaceVersion: u32->uint32->unsigned int
    ///ip: u32->uint32->unsigned int
    ///steamPort: u16->uint16->unsigned short
    ///gamePort: u16->uint16->unsigned short
    ///queryPort: u16->uint16->unsigned short
    ///serverMode: Enum->s32->int32->int
    ///versionString: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_Startup")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool ServicesGameServer_Startup(uint interfaceVersion, uint ip, ushort steamPort, ushort gamePort, ushort queryPort, int serverMode, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string versionString);


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_Shutdown")]
    internal static extern void ServicesGameServer_Shutdown();


    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_GetSteamLoadStatus")]
    internal static extern int ServicesGameServer_GetSteamLoadStatus();


    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_HandleCallbacks")]
    internal static extern void ServicesGameServer_HandleCallbacks();


    /// Return Type: void
    ///callback: ManagedCallback
    ///resultCallback: ManagedResultCallback
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_RegisterManagedCallbacks")]
    internal static extern void ServicesGameServer_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback);

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "ServicesGameServer_RemoveManagedCallbacks")]
    internal static extern void ServicesGameServer_RemoveManagedCallbacks();


    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetSecondsSinceAppActive")]
    internal static extern uint Utils_GetSecondsSinceAppActive();

    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetSecondsSinceComputerActive")]
    internal static extern uint Utils_GetSecondsSinceComputerActive();

    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetConnectedUniverse")]
    internal static extern int Utils_GetConnectedUniverse();

    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetServerRealTime")]
    internal static extern uint Utils_GetServerRealTime();

    /// Return Type: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetIPCountry")]
    internal static extern System.IntPtr Utils_GetIPCountry();

    /// Return Type: boolean
    ///iImage: int
    ///pnWidth: uint32*
    ///pnHeightr: uint32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetImageSize")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_GetImageSize(int iImage, ref uint pnWidth, ref uint pnHeightr);

    /// Return Type: boolean
    ///iImage: int
    ///pubDest: uint8*
    ///nDestBufferSize: int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetImageRGBA")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_GetImageRGBA(int iImage, System.IntPtr pubDest, int nDestBufferSize);

    /// Return Type: boolean
    ///unIP: u32*
    ///usPort: u16*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetCSERIPPort")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_GetCSERIPPort(ref uint unIP, ref ushort usPort);

    /// Return Type: u8->uint8->unsigned char
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetCurrentBatteryPower")]
    internal static extern byte Utils_GetCurrentBatteryPower();

    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetAppID")]
    internal static extern uint Utils_GetAppID();

    /// Return Type: void
    /// eNotificationPosition: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_SetOverlayNotificationPosition")]
    internal static extern void Utils_SetOverlayNotificationPosition(int eNotificationPosition);

    /// Return Type: boolean
    ///hSteamAPICall: SteamAPICall_t->uint64->unsigned __int64
    ///pbFailed: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_IsAPICallCompleted")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_IsAPICallCompleted(ulong hSteamAPICall, ref bool pbFailed);

    /// Return Type: boolean
    ///hSteamAPICall: SteamAPICall_t->uint64->unsigned __int64
    ///pCallback: void*
    ///cubCallback: int
    ///iCallbackExpected: int
    ///pbFailed: boolean*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetAPICallResult")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_GetAPICallResult(ulong hSteamAPICall, System.IntPtr pCallback, int cubCallback, int iCallbackExpected, ref bool pbFailed);

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_RunFrame")]
    internal static extern void Utils_RunFrame();

    /// Return Type: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetIPCCallCount")]
    internal static extern uint Utils_GetIPCCallCount();

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_IsOverlayEnabled")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_IsOverlayEnabled();

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_OverlayNeedsPresent")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_OverlayNeedsPresent();

    /// Return Type: boolean
    /// inputMode: Enum->s32->int32->int
    /// lineInputMode: Enum->s32->int32->int
    /// description: PConstantString->char*
    /// charMax: uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_ShowGamepadTextInput")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_ShowGamepadTextInput(int inputMode, int lineInputMode, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string description, uint charMax);

    /// Return Type: uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetEnteredGamepadTextLength")]
    internal static extern uint Utils_GetEnteredGamepadTextLength();

    /// Return Type: boolean
    ///pchText: PString->char*
    ///cchText: uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_GetEnteredGamepadTextInput")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_GetEnteredGamepadTextInput(System.IntPtr pchText, uint cchText);

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Utils_IsSteamRunningInVR")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Utils_IsSteamRunningInVR();


    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsSubscribed")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_IsSubscribed();

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsLowViolence")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_IsLowViolence();

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsCybercafe")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_IsCybercafe();

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsVACBanned")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_IsVACBanned();

    /// Return Type: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetCurrentGameLanguage")]
    internal static extern System.IntPtr Apps_GetCurrentGameLanguage();

    /// Return Type: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetAvailableGameLanguages")]
    internal static extern System.IntPtr Apps_GetAvailableGameLanguages();

    /// Return Type: boolean
    /// appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsSubscribedApp")]
    internal static extern bool Apps_IsSubscribedApp(uint appID);

    /// Return Type: boolean
    /// appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsDlcInstalled")]
    internal static extern bool Apps_IsDlcInstalled(uint appID);

    /// Return Type: u32->uint32->unsigned int
    /// appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetEarliestPurchaseUnixTime")]
    internal static extern uint Apps_GetEarliestPurchaseUnixTime(uint appID);

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_IsSubscribedFromFreeWeekend")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_IsSubscribedFromFreeWeekend();

    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetDLCCount")]
    internal static extern int Apps_GetDLCCount();

    /// Return Type: boolean
    /// iDLC: s32->int32->int
    /// pAppID: u32*
    /// pbAvailable: boolean*
    /// pchName: PString->char*
    /// cchnameBufferSize: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetDLCDataByIndex")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_GetDLCDataByIndex(int iDLC, ref uint pAppID, ref bool pbAvailable, System.IntPtr pchName, int cchNameBufferSize);

    /// Return Type: void
    /// appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_InstallDLC")]
    internal static extern void Apps_InstallDLC(uint appID);

    /// Return Type: void
    /// appID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_UninstallDLC")]
    internal static extern void Apps_UninstallDLC(uint appID);

    /// Return Type: void
    /// AppID: AppID->u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_RequestAppProofOfPurchaseKey")]
    internal static extern void Apps_RequestAppProofOfPurchaseKey(uint appID);

    /// Return Type: boolean
    /// pchName: PString->char*
    /// cchNameBufferSize: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetCurrentBetaName")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_GetCurrentBetaName(System.IntPtr pchName, int cchNameBufferSize);

    /// Return Type: boolean
    /// bMissingFilesOnly: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_MarkContentCorrupt")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Apps_MarkContentCorrupt([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool bMissingFilesOnly);

    /// Return Type: u32->uint32->unsigned int
    /// appID: AppID->u32->uint32->unsigned int
    /// pvecDepots: u32*
    /// cMaxDepots: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetInstalledDepots")]
    internal static extern uint Apps_GetInstalledDepots(uint appID, ref uint pDepots, uint maxDepots);

    /// Return Type: SteamID->u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetAppOwner")]
    internal static extern ulong Apps_GetAppOwner();

    /// Return Type: PConstantString->char*
    /// Key: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Apps_GetLaunchQueryParam")]
    internal static extern System.IntPtr Apps_GetLaunchQueryParam([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]string key);

    /// Return Type: u32->uint32->unsigned int
    /// eHTTPRequestMethod: Enum->s32->int32->int
    /// pchAbsoluteURL: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_CreateHTTPRequest")]
    internal static extern uint HTTP_CreateHTTPRequest(int eHTTPRequestMethod, System.IntPtr pchAbsoluteURL);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// ulContextValue: u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SetHTTPRequestContextValue")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SetHTTPRequestContextValue(uint hRequest, ulong ulContextValue);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// unTimeoutSeconds: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SetHTTPRequestNetworkActivityTimeout")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SetHTTPRequestNetworkActivityTimeout(uint hRequest, uint unTimeoutSeconds);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pchHeaderName: PConstantUtf8String->void*
    /// pchHeaderValue: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SetHTTPRequestHeaderValue")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SetHTTPRequestHeaderValue(uint hRequest, System.IntPtr pchHeaderName, System.IntPtr pchHeaderValue);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pchParamName: PConstantUtf8String->void*
    /// pchParamValue: PConstantUtf8String->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SetHTTPRequestGetOrPostParameter")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SetHTTPRequestGetOrPostParameter(uint hRequest, System.IntPtr pchParamName, System.IntPtr pchParamValue);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pCallhandle: u64*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SendHTTPRequest")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SendHTTPRequest(uint hRequest, ref ulong pCallHandle);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pCallhandle: u64*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SendHTTPRequestAndStreamResponse")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SendHTTPRequestAndStreamResponse(uint hRequest, ref ulong pCallHandle);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_DeferHTTPRequest")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_DeferHTTPRequest(uint hRequest);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_PrioritizeHTTPRequest")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_PrioritizeHTTPRequest(uint hRequest);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pchHeaderName: PConstantUtf8String->void*
    /// unResponseHeaderSize: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_GetHTTPResponseHeaderSize")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_GetHTTPResponseHeaderSize(uint hRequest, System.IntPtr pchHeaderName, ref uint unResponseHeaderSize);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pchHeaderName: PConstantUtf8String->void*
    /// pHeaderValueBuffer: uint8*
    /// unBufferSize: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_GetHTTPResponseHeaderValue")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_GetHTTPResponseHeaderValue(uint hRequest, System.IntPtr pchHeaderName, System.IntPtr pHeaderValueBuffer, uint unBufferSize);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// unBodySize: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_GetHTTPResponseBodySize")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_GetHTTPResponseBodySize(uint hRequest, ref uint unBodySize);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// PBodyDataBuffer: uint8*
    /// unBufferSize: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_GetHTTPResponseBodyData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_GetHTTPResponseBodyData(uint hRequest, System.IntPtr pBodyDataBuffer, uint unBufferSize);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// cOffset: u32->uint32->unsigned int
    /// pBodyDataBuffer: uint8*
    /// unBufferSize: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_GetHTTPStreamingResponseBodyData")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_GetHTTPStreamingResponseBodyData(uint hRequest, uint cOffset, System.IntPtr pBodyDataBuffer, uint unBufferSize);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_ReleaseHTTPRequest")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_ReleaseHTTPRequest(uint hRequest);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pflPercentOut: 
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_GetHTTPDownloadProgressPct")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_GetHTTPDownloadProgressPct(uint hRequest, ref float pflPercentOut);

    /// Return Type: boolean
    /// hRequest: u32->uint32->unsigned int
    /// pchContentType: PConstantUtf8String->void*
    /// pubBody: uint8*
    /// unBodyLen: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "HTTP_SetHTTPRequestRawPostBody")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool HTTP_SetHTTPRequestRawPostBody(uint hRequest, System.IntPtr pchContentType, System.IntPtr pubBody, uint unBodyLen);

    /// Return Type: u32->uint32->unsigned int
    /// pubRGB: PDataPointer->void*
    /// cubRGB: u32->uint32->unsigned int
    /// nWidth: s32->int32->int
    /// nHeight: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_WriteScreenshot")]
    internal static extern uint Screenshots_WriteScreenshot(System.IntPtr pubRGB, uint cubRGB, int nWidth, int nHeight);

    /// Return Type: u32->uint32->unsigned int
    /// pchFilename: PConstantString->char*
    /// pchThumbnailFileName: PConstantString->char*
    /// nWidth: s32->int32->int
    /// nHeight: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_AddScreenshotToLibrary")]
    internal static extern uint Screenshots_AddScreenshotToLibrary([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pchFilename, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pchThumbnailFilename, int nWidth, int nHeight);

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_TriggerScreenshot")]
    internal static extern void Screenshots_TriggerScreenshot();

    /// Return Type: void
    /// bHook: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_HookScreenshots")]
    internal static extern void Screenshots_HookScreenshots(bool bHook);

    /// Return Type: boolean
    /// hScreenshot: u32->uint32->unsigned int
    /// pchLocation: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_SetLocation")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Screenshots_SetLocation(uint hScreenshot, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pchLocation);

    /// Return Type: boolean
    /// hScreenshot: u32->uint32->unsigned int
    /// steamID: u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_TagUser")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Screenshots_TagUser(uint hScreenshot, ulong steamID);

    /// Return Type: boolean
    /// hScreenshot: u32->uint32->unsigned int
    /// unPublishedFileID: u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "Screenshots_TagPublishedFile")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool Screenshots_TagPublishedFile(uint hScreenshot, ulong unPublishedFileID);

    /// Return Type: u64->uint64->unsigned __int64
    /// AccountID: u32->uint32->unsigned int
    /// eListType: Enum->s32->int32->int
    /// eMatchingUGCType: Enum->s32->int32->int
    /// eSortOrder: Enum->s32->int32->int
    /// nCreatorAppID: AppID->u32->uint32->unsigned int
    /// nConsumerAppID: AppID->u32->uint32->unsigned int
    /// unPage: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_CreateQueryUserUGCRequest")]
    internal static extern ulong UGC_CreateQueryUserUGCRequest(uint unAccountID, int eListType, int eMatchingUGCType, int eSortOrder, uint nCreatorAppID, uint nConsumerAppID, uint unPage);

    /// Return Type: u64->uint64->unsigned __int64
    /// eQueryType: Enum->s32->int32->int
    /// eMatchingeMatchingUGCTypeFileType: Enum->s32->int32->int
    /// nCreatorAppID: AppID->u32->uint32->unsigned int
    /// nConsumerAppID: AppID->u32->uint32->unsigned int
    /// unPage: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_CreateQueryAllUGCRequest")]
    internal static extern ulong UGC_CreateQueryAllUGCRequest(int eQueryType, int eMatchingeMatchingUGCTypeFileType, uint nCreatorAppID, uint nConsumerAppID, uint unPage);

    /// Return Type: void
    /// handle: u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SendQueryUGCRequest")]
    internal static extern void UGC_SendQueryUGCRequest(ulong handle);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// index: u32->uint32->unsigned int
    /// pubRGB: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_GetQueryUGCResult")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_GetQueryUGCResult(ulong handle, uint index, System.IntPtr pDetails);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_ReleaseQueryUGCRequest")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_ReleaseQueryUGCRequest(ulong handle);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// pTagName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_AddRequiredTag")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_AddRequiredTag(ulong handle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pTagName);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// pTagName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_AddExcludedTag")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_AddExcludedTag(ulong handle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pTagName);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// bReturnLongDescription: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SetReturnLongDescription")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_SetReturnLongDescription(ulong handle, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool bReturnLongDescription);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// bReturnTotalOnly: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SetReturnTotalOnly")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_SetReturnTotalOnly(ulong handle, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool bReturnTotalOnly);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// pMatchCloudFileName: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SetCloudFileNameFilter")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_SetCloudFileNameFilter(ulong handle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pMatchCloudFileName);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// bMatchAnyTag: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SetMatchAnyTag")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_SetMatchAnyTag(ulong handle, [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)] bool bMatchAnyTag);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// pSearchString: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SetSearchText")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_SetSearchText(ulong handle, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pSearchText);

    /// Return Type: boolean
    /// handle: u64->uint64->unsigned __int64
    /// unDays: u32->uint32->unsigned int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_SetRankedByTrendDays")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool UGC_SetRankedByTrendDays(ulong handle, uint unDays);

    /// Return Type: void
    /// nPublishedFileID: u64->uint64->unsigned __int64
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "UGC_RequestUGCDetails")]
    internal static extern void UGC_RequestUGCDetails(ulong nPublishedFileID);

    /// Return Type: boolean
    /// absolutPathToControllerConfigVDF: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "SteamController_Init")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool SteamController_Init([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string absolutPathToControllerConfigVDF);

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "SteamController_Shutdown")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool SteamController_Shutdown();

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "SteamController_RunFrame")]
    internal static extern void SteamController_RunFrame();

    /// Return Type: boolean
    /// controllerIndex: u32->uint32->unsigned int
    /// state: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "SteamController_GetControllerState")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool SteamController_GetControllerState(uint controllerIndex, System.IntPtr state);

    /// Return Type: void
    /// controllerIndex: u32->uint32->unsigned int
    /// targetPad: Enum->s32->int32->int
    /// durationMicroSec: u16->uint16->unsigned short
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "SteamController_TriggerHapticPulse")]
    internal static extern void SteamController_TriggerHapticPulse(uint controllerIndex, int targetPad, ushort durationMicroSec);

    /// Return Type: void
    /// mode: PConstantString->char*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "SteamController_SetOverrideMode")]
    internal static extern void SteamController_SetOverrideMode([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]string mode);


    /// Return Type: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_Init")]
    internal static extern int VR_Init();

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_Shutdown")]
    internal static extern void VR_Shutdown();

    /// Return Type: boolean
    /// X: s32*
    /// Y: s32*
    /// Width: u32*
    /// Height: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetWindowBounds")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool VR_Hmd_GetWindowBounds(ref int X, ref int Y, ref uint Width, ref uint Height);

    /// Return Type: void
    /// Width: u32*
    /// Height: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetRecommendedRenderTargetSize")]
    internal static extern void VR_Hmd_GetRecommendedRenderTargetSize(ref uint Width, ref uint Height);

    /// Return Type: void
    /// Eye: Enum->s32->int32->int
    /// APIType: Enum->s32->int32->int
    /// X: u32*
    /// Y: u32*
    /// Width: u32*
    /// Height: u32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetEyeOutputViewport")]
    internal static extern void VR_Hmd_GetEyeOutputViewport(int Eye, int APIType, ref uint X, ref uint Y, ref uint Width, ref uint Height);

    /// Return Type: PDataPointer->void*
    /// Eye: Enum->s32->int32->int
    /// NearZ: f32->float
    /// FarZ: f32->float
    /// ProjType: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetProjectionMatrix")]
    internal static extern System.IntPtr VR_Hmd_GetProjectionMatrix(int Eye, float NearZ, float FarZ, int ProjType);

    /// Return Type: void
    /// Eye: Enum->s32->int32->int
    /// Left: f32*
    /// Right: f32*
    /// Top: f32*
    /// Bottom: f32*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetProjectionRaw")]
    internal static extern void VR_Hmd_GetProjectionRaw(int Eye, ref float Left, ref float Right, ref float Top, ref float Bottom);

    /// Return Type: PDataPointer->void*
    /// Eye: Enum->s32->int32->int
    /// U: f32->float
    /// V: f32->float
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_ComputeDistortion")]
    internal static extern System.IntPtr VR_Hmd_ComputeDistortion(int Eye, float U, float V);

    /// Return Type: PDataPointer->void*
    /// Eye: Enum->s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetEyeMatrix")]
    internal static extern System.IntPtr VR_Hmd_GetEyeMatrix(int Eye);

    /// Return Type: boolean
    /// SecondsFromNow: f32->float
    /// MatLeftView: PDataPointer->void*
    /// MatRightView: PDataPointer->void*
    /// MatLeftView: PDataPointer->void*
    /// Result: Enum*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetViewMatrix")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool VR_Hmd_GetViewMatrix(float SecondsFromNow, System.IntPtr MatLeftView, System.IntPtr MatRightView, ref int Result);

    /// Return Type: s32->int32->int
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetD3D9AdapterIndex")]
    internal static extern int VR_Hmd_GetD3D9AdapterIndex();

    /// Return Type: boolean
    /// PredictSecondsFromNow: f32->float
    /// Pose: PDataPointer->void*
    /// Result: Enum*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetWorldFromHeadPose")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool VR_Hmd_GetWorldFromHeadPose(float PredictedSecondsFromNow, System.IntPtr Pose, ref int Result);

    /// Return Type: boolean
    /// Pose: PDataPointer->void*
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetLastWorldFromHeadPose")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool VR_Hmd_GetLastWorldFromHeadPose(System.IntPtr Pose);

    /// Return Type: boolean
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_WillDriftInYaw")]
    [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.I1)]
    internal static extern bool VR_Hmd_WillDriftInYaw();

    /// Return Type: void
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_ZeroTracker")]
    internal static extern void VR_Hmd_ZeroTracker();

    /// Return Type: u32->uint32->uint
    /// Buffer: PString->char*
    /// BufferLen: u32->uint32->uint
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetDriverId")]
    internal static extern uint VR_Hmd_GetDriverId(System.IntPtr Buffer, uint BufferLen);

    /// Return Type: u32->uint32->uint
    /// Buffer: PString->char*
    /// BufferLen: u32->uint32->uint
    [System.Runtime.InteropServices.DllImportAttribute("SteamworksNative", EntryPoint = "VR_Hmd_GetDisplayId")]
    internal static extern uint VR_Hmd_GetDisplayId(System.IntPtr Buffer, uint BufferLen);
    
}