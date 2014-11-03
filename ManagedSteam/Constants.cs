using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam
{
    /// <summary>
    /// This class contains all the constants that are defined in the Steamworks SDK
    /// </summary>
    public static class Constants
    {
        public static class Apps
        {
            public const int AppProofOfPurchaseKeyMax = 64;

            public const int MaxAchievementNameLength = 128;
            public const int MaxBetaNameLength = 128;
            public const int MaxGamepadTextInputLength = 256;
        }

        /// <summary>
        /// 
        /// </summary>
        public static class VersionInfo
        {
            public const uint InterfaceID = 19128; //1.9.128
        }

        /// <summary>
        /// Constants from ISteamRemoteStorage.h
        /// </summary>
        public static class Cloud
        {
            /// <summary>
            /// Defines the largest allowed file size. Cloud files cannot be
            ///	larger than 100MB.
            /// </summary>
            public const int MaxFileSize = 100 * 1024 * 1024;

            public static SteamTypes.UGCHandle InvalidUGCHandle { get { return SteamTypes.UGCHandle.Invalid; } }
            public static SteamTypes.PublishedFileUpdateHandle InvalidPublishFileUpdateHandle { get { return SteamTypes.PublishedFileUpdateHandle.Invalid; } }

            public const int PublishedDocumentTitleMax = 128 + 1;
            public const int PublishedDocumentDescriptionMax = 8000;
            public const int PublishedDocumentChangeDescriptionMax = 256;
            public const int EnumeratePublishedFilesMaxResults = 50;
            public const int TagListMax = 1024 + 1;
            public const int FileNameMax = 260;
            public const int PublishedFileURLMax = 256;
        }

        public static class User
        {
            public const int URLNameMax = 256;
        }

        /// <summary>
        /// Constants from ISteamUserStats.h
        /// </summary>
        public static class Stats
        {
            /// <summary>
            /// size limit on stat or achievement name (UTF-8 encoded)
            /// </summary>
            public const int StatNameMax = 128;
            /// <summary>
            /// maximum number of bytes for a leaderboard name (UTF-8 encoded)
            /// </summary>
            public const int LeaderboardNameMax = 128;
            /// <summary>
            /// maximum number of details int32's storable for a single leaderboard entry
            /// </summary>
            public const int LeaderboardDetailsMax = 64;
        }

        public static class Friends
        {
            /// <summary>
            /// maximum length of friend group name (not including terminating nul!)
            /// </summary>
            public const int MaxFriendsGroupName = 64;

            /// <summary>
            /// maximum number of groups a single user is allowed
            /// </summary>
            public const int FriendsGroupLimit = 100;

            public const int EnumerateFollowersMax = 50;

            public const int PersonaNameMaxUTF8 = 128;
            public const int PersonaNameMaxUTF16 = 32;

            public const int ChatMetadataMax = 8192;
            public const int MaxRichPresenceKeys = 20;
            public const int MaxRichPresenceKeyLength = 64;
            public const int MaxRichPresenceValueLength = 256;

            public const int ChatMsgLength = 256;

            public const int ServerAddressMaxLength = 64;
            public const int ServerPasswordMaxLength = 64;
        }

        /// <summary>
        /// Constants from the ISteamMatchmaking.h file
        /// </summary>
        public static class Matchmaking
        {
            public const int MaxLobbyKeyLength = 255;
            /// <summary>
            /// \note This value is not specified anywhere in the Steamworks SDK. It is based on a guess. 
            /// It might be wrong.
            /// </summary>
            public const int MaxLobbyValueLength = 255;

            public const uint FavoriteFlagNone = 0x00;
            /// <summary>
            /// this game favorite entry is for the favorites list
            /// </summary>
            public const uint FavoriteFlagFavorite = 0x01;
            /// <summary>
            /// this game favorite entry is for the history list
            /// </summary>
            public const uint FavoriteFlagHistory = 0x02;



            /// <summary>
            /// The max size of the string in bytes, not characters, including the null terminator.
            /// Use Utility.StringHelper.GetByteCount() to check the string size
            /// </summary>
            public const int KeyValuePairMaxKeySize = 256;

            /// <summary>
            /// The max size of the string in bytes, not characters, including the null terminator.
            /// Use Utility.StringHelper.GetByteCount() to check the string size
            /// </summary>
            public const int KeyValuePairMaxValueSize = 256;

            /// <summary>
            /// Max size (in bytes of UTF-8 data, not in characters) of server fields, including null terminator.
            /// </summary>
            public const int MaxGameServerGameDir = 32;
            /// <summary>
            /// Max size (in bytes of UTF-8 data, not in characters) of server fields, including null terminator.
            /// </summary>
            public const int MaxGameServerMapName = 32;
            /// <summary>
            /// Max size (in bytes of UTF-8 data, not in characters) of server fields, including null terminator.
            /// </summary>
            public const int MaxGameServerGameDescription = 64;
            /// <summary>
            /// Max size (in bytes of UTF-8 data, not in characters) of server fields, including null terminator.
            /// </summary>
            public const int MaxGameServerName = 64;
            /// <summary>
            /// Max size (in bytes of UTF-8 data, not in characters) of server fields, including null terminator.
            /// </summary>
            public const int MaxGameServerTags = 128;
            /// <summary>
            /// Max size (in bytes of UTF-8 data, not in characters) of server fields, including null terminator.
            /// </summary>
            public const int MaxGameServerGameData = 2048;
        }

        public static class GameServer
        {
            internal const int GSClientDenyText = 128;
            internal const int GSClientAchievementStatusText = 128;
        }

        public static class Networking
        {
            //"From ISteamNetworking": unreliable and a max packet size of 1200 bytes
            public const int PacketSize = 1200;

        }

        public static class Screenshots
        {
            public const int    ScreenshotThumbWidth                = 200;
            public const uint   ScreenshotMaxTaggedUsers            = 32;
            public const uint   ScreenshotMaxTaggedPublishedFiles   = 32;
            public const int    UFSTagTypeMax                       = 255;
            public const int    UFSTagValueMax                      = 255;
        }

        public static class UGC
        {
            public const int    PublishedDocumentTitleMax           = 129;
            public const int    PublishedDocumentDescriptionMax     = 8000;
            public const int    TagListMax                          = 1025;
            public const int    FilenameMax                         = 260;
            public const int    PublishedFileURLMax                 = 256;
        }

        public static class SteamController
        {
            public const int    MaxSteamControllers                 = 8;
        }

        public static class Hmd
        {
            public const int    MaxIDBufferSize                     = 128;
            public const int    Matrix44Elements                    = 16;
            public const int    Matrix34Elements                    = 12;
            public const int    DistortionCoordinatesArraySize      = 2;
        }
    }
}
