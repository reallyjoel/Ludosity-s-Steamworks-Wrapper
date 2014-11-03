using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Utility
{
    interface IJob
    {
        void Create();

        void Destroy();
    }
}
