using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Hmd : IHmd
    {
        public Hmd()
        {

        }

        void CheckIfUsable()
        {

        }

        public HmdError Init()
        {
            CheckIfUsable();

            return (HmdError)NativeMethods.VR_Init();
        }

        public void Shutdown()
        {
            CheckIfUsable();

            NativeMethods.VR_Shutdown();
        }

        public bool GetWindowBounds(out int X, out int Y, out uint Width, out uint Height)
        {
            CheckIfUsable();

            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;

            return NativeMethods.VR_Hmd_GetWindowBounds(ref X, ref Y, ref Width, ref Height);
        }

        public void GetRecommendedRenderTargetSize(out uint Width, out uint Height)
        {
            CheckIfUsable();

            Width = 0;
            Height = 0;

            NativeMethods.VR_Hmd_GetRecommendedRenderTargetSize(ref Width, ref Height);
        }

        public void GetEyeOutputViewport(HmdEye Eye, GraphicsAPIConvention APIType, out uint X, out uint Y, out uint Width, out uint Height)
        {
            CheckIfUsable();

            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;

            NativeMethods.VR_Hmd_GetEyeOutputViewport((int)Eye, (int)APIType, ref X, ref Y, ref Width, ref Height);
        }

        public HmdMatrix44 GetProjectionMatrix(HmdEye Eye, float NearZ, float FarZ, GraphicsAPIConvention ProjType)
        {
            CheckIfUsable();


            return NativeHelpers.ConvertStruct<HmdMatrix44>(NativeMethods.VR_Hmd_GetProjectionMatrix((int)Eye, NearZ, FarZ, (int)ProjType), Marshal.SizeOf(typeof(HmdMatrix44)));
        }

        public void GetProjectionRaw(HmdEye Eye, out float Left, out float Right, out float Top, out float Bottom)
        {
            CheckIfUsable();

            Left = 0;
            Right = 0;
            Top = 0;
            Bottom = 0;

            NativeMethods.VR_Hmd_GetProjectionRaw((int)Eye, ref Left, ref Right, ref Top, ref Bottom);
        }

        public DistortionCoordinates ComputeDistortion(HmdEye Eye, float U, float V)
        {
            CheckIfUsable();

            return NativeHelpers.ConvertStruct<DistortionCoordinates>(NativeMethods.VR_Hmd_ComputeDistortion((int)Eye, U, V), Marshal.SizeOf(typeof(DistortionCoordinates)));
        }

        public HmdMatrix44 GetEyeMatrix(HmdEye Eye)
        {
            CheckIfUsable();

            return NativeHelpers.ConvertStruct<HmdMatrix44>(NativeMethods.VR_Hmd_GetEyeMatrix((int)Eye), Marshal.SizeOf(typeof(HmdMatrix44)));
            //return NativeHelpers.ConvertStructToClass<HmdMatrix44>(NativeMethods.VR_Hmd_GetEyeMatrix((int)Eye), Marshal.SizeOf(typeof(HmdMatrix44)));
        }

        public bool GetViewMatrix(float SecondsFromNow, out HmdMatrix44 MatLeftView, out HmdMatrix44 MatRightView, out HmdTrackingResult Result)
        {
            CheckIfUsable();

            using (NativeBuffer LeftViewBuffer = new NativeBuffer(Marshal.SizeOf(typeof(HmdMatrix44))))
            {
                using (NativeBuffer RightViewBuffer = new NativeBuffer(Marshal.SizeOf(typeof(HmdMatrix44))))
                {
                    int TempResult = 0;
                    bool result = NativeMethods.VR_Hmd_GetViewMatrix(SecondsFromNow, LeftViewBuffer.UnmanagedMemory, RightViewBuffer.UnmanagedMemory, ref TempResult);

                    MatLeftView = NativeHelpers.ConvertStruct<HmdMatrix44>(LeftViewBuffer.UnmanagedMemory, LeftViewBuffer.UnmanagedSize);
                    MatRightView = NativeHelpers.ConvertStruct<HmdMatrix44>(RightViewBuffer.UnmanagedMemory, RightViewBuffer.UnmanagedSize);
                    Result = (HmdTrackingResult)TempResult;

                    return result;
                }
            }
        }

        public bool GetWorldFromHeadPose(float PredictedSecondsFromNow, out HmdMatrix34 Pose, out HmdTrackingResult Result)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Marshal.SizeOf(typeof(HmdMatrix34))))
            {
                int TempResult = 0;

                bool result = NativeMethods.VR_Hmd_GetWorldFromHeadPose(PredictedSecondsFromNow, buffer.UnmanagedMemory, ref TempResult);
                Pose = NativeHelpers.ConvertStruct<HmdMatrix34>(buffer.UnmanagedMemory, buffer.UnmanagedSize);
                Result = (HmdTrackingResult)TempResult;

                return result;
            }
        }

        public bool GetLastWorldFromHeadPose(out HmdMatrix34 Pose)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Marshal.SizeOf(typeof(HmdMatrix34))))
            {
                bool result = NativeMethods.VR_Hmd_GetLastWorldFromHeadPose(buffer.UnmanagedMemory);
                Pose = NativeHelpers.ConvertStruct<HmdMatrix34>(buffer.UnmanagedMemory, buffer.UnmanagedSize);

                return result;
            }
        }

        public bool WillDriftInYaw()
        {
            CheckIfUsable();

            return NativeMethods.VR_Hmd_WillDriftInYaw();
        }

        public void ZeroTracker()
        {
            CheckIfUsable();

            NativeMethods.VR_Hmd_ZeroTracker();
        }

        public uint GetDriverId(out string Buffer)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Constants.Hmd.MaxIDBufferSize))
            {
                uint result = NativeMethods.VR_Hmd_GetDriverId(buffer.UnmanagedMemory, (uint)buffer.UnmanagedSize);
                Buffer = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);

                return result;
            }
        }

        public uint GetDisplayId(out string Buffer)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Constants.Hmd.MaxIDBufferSize))
            {
                uint result = NativeMethods.VR_Hmd_GetDisplayId(buffer.UnmanagedMemory, (uint)buffer.UnmanagedSize);
                Buffer = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);

                return result;
            }
        }
    }
}
