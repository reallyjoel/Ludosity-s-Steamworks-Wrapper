using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    /// <summary>
    /// Steam utility functions
    /// </summary>
    public interface IUtils
    {
        event CallbackEvent<IPCountry> IPCountry;

        /// <summary>
        /// Registred event fires when device have less than 10 minutes batterypower remaining, then once every minute
        /// </summary>
        event CallbackEvent<LowBatteryPower> LowBatteryPower;
        event CallbackEvent<SteamAPICallCompleted> SteamAPICallCompleted;
        /// <summary>
        /// Registred event fires when steam wants to shut down, for example when the user rightclick on the steam icon and click Shutdown
        /// </summary>
        event CallbackEvent<SteamShutdown> SteamShutdown;
        event CallbackEvent<CheckFileSignature> CheckFileSignature;
        /// <summary>
        /// Registred event fires when the Big picture text input have shut down, this can either be cancled or submitted, result in GamepadTextInputDismissed struct
        /// </summary>
        event CallbackEvent<GamepadTextInputDismissed> GamepadTextInputDismissed;

        /// <summary>
        /// <returns>The number of seconds the app have been running</returns>
        /// </summary>
        uint GetSecondsSinceAppActive();
      
        /// <summary>
        /// <returns>The number of seconds the computer have been running</returns>
        /// </summary>
        uint GetSecondsSinceComputerActive();

        /// <summary>
        /// The universe the client is connected to
        /// <returns>Enum that lists the different universes the client can be connected to.</returns>
        /// </summary>
       Universe GetConnectedUniverse();

        /// <summary>
        /// Steam server time - in PST
        /// <returns>Number of seconds since Januari 1, 1970 (i.e. unix time)</returns>
        /// </summary>
        uint GetServerRealTime();

        /// <summary>
        /// Returns 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)
        /// eg. "US" or "UK"
        /// <returns></returns>
        /// </summary>
        string GetIPCountry();

        /// <summary>
        /// Gets dimensions of an image from a steam image handle
        /// <returns>True if the image exists</returns>
        /// </summary>
        bool GetImageSize(ImageHandle image, out uint width, out uint height);

        UtilsGetImageSizeResult GetImageSize(ImageHandle image);

        /// <summary>
        /// Fills the supplied buffer with the image data in RGBA format
        /// The destination buffer size should be 4 * height * width * sizeof(byte)
        /// <returns>True if the image exists and the buffer was successfully filled out</returns>
        /// </summary>
        bool GetImageRGBA(ImageHandle image, System.IntPtr buffer, int bufferSize);

        /// <summary>
        /// <returns></returns>
        /// </summary>
        bool GetCSERIPPort(out uint unIP, out ushort usPort);

        /// <summary>
        /// <returns></returns>
        /// </summary>
        UtilsGetCSERIPPortResult GetCSERIPPort();

        /// <summary>
        /// The amount of battery power left in the current system in % [0..100], 255 for beeing on AC power.
        /// <returns>Integer representing amount of power left</returns>
        /// </summary>
        int GetCurrentBatteryPower();
        
        /// <summary>
        /// Sets the position where the overlay instance for the currently calling game should show notifications. 
        /// This position is per-game and if this function is called from outside of a game context it will do nothing.
        /// <returns></returns>
        /// </summary>
        void SetOverlayNotificationPosition(NotificationPosition notificationPosition);

        /// <summary>
        /// <returns></returns>
        /// </summary>
        bool IsAPICallCompleted( SteamAPICall steamAPICall, out bool failed);

        /// <summary>
        /// <returns></returns>
        /// </summary>
        bool GetAPICallResult<T>( SteamAPICall steamAPICall, ref T callback, out bool failed) where T : struct;

        /// <summary>
        /// This needs to be called every frame to process matchmaking results.
        /// Redundant if you're already calling SteamAPI_RunCallbacks()
        /// <returns></returns>
        /// </summary>
        void RunFrame();

        /// <summary>
        /// Returns the number of IPC calls made since the last time this function was called.
        /// Used for perf debugging so you can understand how many IPC calls your game makes per frame.
        /// Every IPC call is at minimum a thread context switch if not a process one so you want to rate
        /// control how often you do them.
        /// <returns></returns>
        /// </summary>
        uint GetIPCCallCount();

        /// <summary>
        /// <returns></returns>
        /// </summary>
        //void SetWarningMessageHook(SteamAPIWarningMessageHook pFunction);


        /// <summary>
        /// The overlay process could take a few seconds to start and hook the game process, 
        /// so this function will initially return false while the overlay is loading.
        /// <returns> True if the overlay is running and the user can access it</returns>
        /// </summary>
        bool IsOverlayEnabled();
       
        /// <summary>
        /// Normally this call is unneeded if your game has a constantly running frame loop that calls the 
        /// D3D Present API, or OGL SwapBuffers API every frame.
        /// 
        /// However, if you have a game that only refreshes the screen on an event driven basis then that can break 
        /// the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also
        /// need to Present() to the screen any time an even needing a notification happens or when the overlay is
        /// brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present
        /// in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you
        /// refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.
        /// <returns></returns>
        /// </summary>
        bool OverlayNeedsPresent();

        /// <summary>
        /// <return></return>
        /// </summary>
        bool ShowGamepadTextInput(GamepadTextInputMode inputMode, GamepadTextInputLineMode lineInputMode, string description, uint charMax);

        /// <summary>
        /// <return></return>
        /// </summary>
        uint GetEnteredGamepadTextLength();

        /// <summary>
        /// 
        /// </summary>
        /// <return></return>
        bool GetEnteredGamepadTextInput(out string pchText);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        UtilsGetEnteredGamepadTextInputResult GetEnteredGamepadTextInput();

        /// <summary>
        /// Is Steam itself running in VR.
        /// </summary>
        /// <returns></returns>
        bool IsSteamRunningInVR();
    }

    /// <summary>
    /// ReturnStruct for the alternative verison of GetImageSize:
    /// 
    /// </summary>
    public struct UtilsGetImageSizeResult
    {
        public bool Result;
        public uint Width;
        public uint Height;
    }

    
    /// <summary>
    /// ReturnStruct for the alternative version of GetCSERIPPort:
    /// bool GetCSERIPPort(out uint unIP, out ushort usPort);
    /// </summary>
    public struct UtilsGetCSERIPPortResult
    {
        public bool Result;
        public uint IP;
        public ushort Port;
    }

    /// <summary>
    /// ReturnStruct for the alternative version of GetEnteredGamepadTextInput:
    /// bool GetEnteredGamepadTextInput(out string pchText);
    /// </summary>
    public struct UtilsGetEnteredGamepadTextInputResult
    {
        public bool Result;
        public string Text;
    }
}
