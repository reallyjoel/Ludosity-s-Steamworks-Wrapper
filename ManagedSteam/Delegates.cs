using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;

namespace ManagedSteam
{
    internal delegate void NativeCallback(IntPtr dataPointer, int dataSize);
    internal delegate void NativeResultCallback(IntPtr dataPointer, int dataSize, bool ioFailure);



    public delegate void ResultEvent<T>(T value, bool ioFailure);
    public delegate void CallbackEvent<T>(T value);
}
