using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Utility
{
    public class DisposableClass : IDisposable
    {
        public void Dispose()
        {
            CleanUpManagedResources();
            CleanUpNativeResources();
            GC.SuppressFinalize(this);
        }

        protected virtual void CleanUpManagedResources()
        {
        }

        protected virtual void CleanUpNativeResources()
        {
        }

        ~DisposableClass()
        {
            CleanUpNativeResources();
        }

    }
}
