using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface IHmd
    {
        HmdError Init();

        void Shutdown();

        /// <summary>
        /// Size and position that the window needs to be on the VR display.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        bool GetWindowBounds( out int X, out int Y, out uint Width, out uint Height );

        /// <summary>
        /// Suggested size for the intermediate render target that the distortion pulls from.
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        void GetRecommendedRenderTargetSize( out uint Width, out uint Height );

        /// <summary>
        /// Gets the viewport in the frame buffer to draw the output of the disortion into.
        /// </summary>
        /// <param name="Eye"></param>
        /// <param name="APIType"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        void GetEyeOutputViewport( HmdEye Eye, GraphicsAPIConvention APIType, out uint X, out uint Y, out uint Width, out uint Height );

        /// <summary>
        /// The projection matrix for the specified eye.
        /// </summary>
        /// <param name="Eye"></param>
        /// <param name="NearZ"></param>
        /// <param name="FarZ"></param>
        /// <param name="ProjType"></param>
        /// <returns></returns>
        HmdMatrix44 GetProjectionMatrix( HmdEye Eye, float NearZ, float FarZ, GraphicsAPIConvention ProjType );

        /// <summary>
        /// The components necessary to build your own projection matrix in case your application is doing something fancy like infinite Z.
        /// </summary>
        /// <param name="Eye"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        /// <param name="Top"></param>
        /// <param name="Bottom"></param>
        void GetProjectionRaw( HmdEye Eye, out float Left, out float Right, out float Top, out float Bottom );

        /// <summary>
        /// Returns the result of the distortion function for the specified eye and input UVs. UVs go from 0,0 in the upper left of that eye's viewport and 1,1 in the lower right of that eye's viewport.
        /// </summary>
        /// <param name="Eye"></param>
        /// <param name="U"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        DistortionCoordinates ComputeDistortion( HmdEye Eye, float U, float V );

        /// <summary>
        /// Returns the transform between the view space and eye space. Eye space is the per-eye flavor of view
	    /// space that provides stereo disparity. Instead of Model * View * Projection the model is Model * View * Eye * Projection. 
	    /// Normally View and Eye will be multiplied together and treated as View in your application. 
        /// </summary>
        /// <param name="Eye"></param>
        /// <returns></returns>
        HmdMatrix44 GetEyeMatrix( HmdEye Eye );

        /// <summary>
        /// For use in simple VR apps, this method returns the concatenation of the 
	    /// tracking pose and the eye matrix to get a full view matrix for each eye.
	    /// This is ( GetEyeMatrix() ) * (GetWorldFromHeadPose() ^ -1 )
        /// </summary>
        /// <param name="SecondsFromNow"></param>
        /// <param name="MatLeftView"></param>
        /// <param name="MatRightView"></param>
        /// <param name="peResult"></param>
        /// <returns></returns>
        bool GetViewMatrix( float SecondsFromNow, out HmdMatrix44 MatLeftView, out HmdMatrix44 MatRightView, out HmdTrackingResult Result );

        /// <summary>
        /// The pose that the tracker thinks that the HMD will be in at the specified
	    /// number of seconds into the future. Pass 0 to get the current state. 
	    /// 
	    /// This is roughly analagous to the inverse of the view matrix in most applications, though 
	    /// many games will need to do some additional rotation or translation on top of the rotation
	    /// and translation provided by the head pose.
	    /// 
	    /// If this function returns true the pose has been populated with a pose that can be used by the application.
	    /// Check peResult for details about the pose, including messages that should be displayed to the user.
        /// </summary>
        /// <param name="PredictedSecondsFromNow"></param>
        /// <param name="Pose"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        bool GetWorldFromHeadPose( float PredictedSecondsFromNow, out HmdMatrix34 Pose, out HmdTrackingResult Result );

        /// <summary>
        /// Passes back the pose matrix from the last successful call to GetWorldFromHeadPose(). Returns true if that matrix is 
	    /// valid (because there has been a previous successful pose.)
        /// </summary>
        /// <param name="Pose"></param>
        /// <returns></returns>
        bool GetLastWorldFromHeadPose( out HmdMatrix34 Pose );

        /// <summary>
        /// Returns true if the tracker for this HMD will drift the Yaw component of its pose over time regardless of
	    /// actual head motion. This is true for gyro-based trackers with no ground truth.
        /// </summary>
        /// <returns></returns>
        bool WillDriftInYaw();

        /// <summary>
        /// Sets the zero pose for the tracker coordinate system. After this call all WorldFromHead poses will be relative 
	    /// to the pose whenever this was called. The new zero coordinate system will not change the fact that the Y axis is
	    /// up in the real world, so the next pose returned from GetWorldFromHeadPose after a call to ZeroTracker may not be
	    /// exactly an identity matrix.
        /// </summary>
        void ZeroTracker();

        /// <summary>
        /// The ID of the driver this HMD uses as a UTF-8 string. Returns the length of the ID in bytes. If 
	    /// the buffer is not large enough to fit the ID an empty string will be returned. In general, 128 bytes
	    /// will be enough to fit any ID.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferLength"></param>
        /// <returns></returns>
        uint GetDriverId( out string Buffer );
        
        /// <summary>
        /// The ID of this display within its driver this HMD uses as a UTF-8 string. Returns the length of the ID in bytes. If 
	    /// the buffer is not large enough to fit the ID an empty string will be returned. In general, 128 bytes
	    /// will be enough to fit any ID.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="BufferLength"></param>
        /// <returns></returns>
        uint GetDisplayId( out string Buffer );
    }
}
