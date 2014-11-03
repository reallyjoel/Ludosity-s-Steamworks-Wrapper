using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    public enum GraphicsAPIConvention
    {
        /// <summary>
        /// Normalized Z goes from 0 at the viewer to 1 at the far clip plane
        /// </summary>
        DirectX = 0,

        /// <summary>
        /// Normalized Z goes from 1 at the viewer to -1 at the far clip plane
        /// </summary>
        OpenGL = 1
    };
}
