using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Screenshots : SteamService, IScreenshots
    {
        private List<ScreenshotReady> screenshotReady;
        private List<ScreenshotRequested> screenshotRequested;

        public Screenshots()
        {
            screenshotReady = new List<ScreenshotReady>();
            screenshotRequested = new List<ScreenshotRequested>();

            Callbacks[CallbackID.ScreenshotReady] = (data, dataSize) => screenshotReady.Add(CallbackStructures.ScreenshotReady.Create(data, dataSize));
            Callbacks[CallbackID.ScreenshotRequested] = (data, dataSize) => screenshotRequested.Add(CallbackStructures.ScreenshotRequested.Create(data, dataSize));
        }

        public event CallbackEvent<ScreenshotReady> ScreenshotReady;
        public event CallbackEvent<ScreenshotRequested> ScreenshotRequested;
        
        internal override void CheckIfUsableInternal()
        {
        }

        internal override void ReleaseManagedResources()
        {
            screenshotReady = null;
            ScreenshotReady = null;

            screenshotRequested = null;
            ScreenshotRequested = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(screenshotReady, ScreenshotReady);
            InvokeEvents(screenshotRequested, ScreenshotRequested);
        }

        public ScreenshotHandle WriteScreenshot(System.IntPtr pubRGB, uint cubRGB, int width, int height)
        {
            return new ScreenshotHandle(NativeMethods.Screenshots_WriteScreenshot(pubRGB, cubRGB, width, height));
        }

        public ScreenshotHandle AddScreenshotToLibrary(string filename, string thumbnailFilename, int width, int height)
        {
            return new ScreenshotHandle(NativeMethods.Screenshots_AddScreenshotToLibrary(filename, thumbnailFilename, width, height));
        }

        public void TriggerScreenshot()
        {
            NativeMethods.Screenshots_TriggerScreenshot();
        }

        public void HookScreenshots(bool hook)
        {
            NativeMethods.Screenshots_HookScreenshots( hook );
        }

        public bool SetLocation(ScreenshotHandle screenshot, string location)
        {
            return NativeMethods.Screenshots_SetLocation( screenshot.AsUInt32, location );
        }

        public bool TagUser(ScreenshotHandle screenshot, SteamID steamID)
        {
            return NativeMethods.Screenshots_TagUser( screenshot.AsUInt32, steamID.AsUInt64 );
        }

        public bool TagPublishedFile(ScreenshotHandle screenshot, PublishedFileId publishedFileID)
        {
            return NativeMethods.Screenshots_TagPublishedFile( screenshot.AsUInt32, publishedFileID.AsUInt64 );
        }
    }
}
