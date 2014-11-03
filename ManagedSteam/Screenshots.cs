using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface IScreenshots
    {
        event CallbackEvent<ScreenshotReady> ScreenshotReady;
        event CallbackEvent<ScreenshotRequested> ScreenshotRequested;

        /// <summary>
        /// Writes a screenshot to the user's screenshot library given the raw image data, which must be in RGB format.
        /// The return value is a handle that is valid for the duration of the game process and can be used to apply tags.
        /// </summary>
        /// <param name="pubRGB"></param>
        /// <param name="cubRGB"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        ScreenshotHandle WriteScreenshot(System.IntPtr pubRGB, uint cubRGB, int width, int height);
        
        /// <summary>
        /// Adds a screenshot to the user's screenshot library from disk.  If a thumbnail is provided, it must be 200 pixels wide and the same aspect ratio
        /// as the screenshot, otherwise a thumbnail will be generated if the user uploads the screenshot.  The screenshots must be in either JPEG or TGA format.
        /// The return value is a handle that is valid for the duration of the game process and can be used to apply tags.
        /// JPEG, TGA, and PNG formats are supported.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="thumbnailFilename"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        ScreenshotHandle AddScreenshotToLibrary(string filename, string thumbnailFilename, int width, int height);

        /// <summary>
        /// Causes the Steam overlay to take a screenshot.  If screenshots are being hooked by the game then a ScreenshotRequested_t callback is sent back to the game instead. 
        /// </summary>
        void TriggerScreenshot();

        /// <summary>
        /// Toggles whether the overlay handles screenshots when the user presses the screenshot hotkey, or the game handles them.  If the game is hooking screenshots,
        /// then the ScreenshotRequested_t callback will be sent if the user presses the hotkey, and the game is expected to call WriteScreenshot or AddScreenshotToLibrary
        /// in response.
        /// </summary>
        /// <param name="hook"></param>
        void HookScreenshots(bool hook);

        /// <summary>
        /// Sets metadata about a screenshot's location (for example, the name of the map)
        /// </summary>
        /// <param name="screenshot"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        bool SetLocation(ScreenshotHandle screenshot, string location);

        /// <summary>
        /// Tags a user as being visible in the screenshot
        /// </summary>
        /// <param name="screenshot"></param>
        /// <param name="steamID"></param>
        /// <returns></returns>
        bool TagUser(ScreenshotHandle screenshot, SteamID steamID);

        /// <summary>
        /// Tags a published file as being visible in the screenshot
        /// </summary>
        /// <param name="screenshot"></param>
        /// <param name="publishedFileID"></param>
        /// <returns></returns>
        bool TagPublishedFile(ScreenshotHandle screenshot, PublishedFileId publishedFileID);
    }
}
