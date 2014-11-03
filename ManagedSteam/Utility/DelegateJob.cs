using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Utility
{
    class DelegateJob : IJob
    {
        public DelegateJob()
            : this(null, null)
        {

        }

        public DelegateJob(Method create, Method destroy)
        {
            CreateMethod = create;
            DestroyMethod = destroy;
        }

        public delegate void Method();

        public Method CreateMethod { get; set; }
        public Method DestroyMethod { get; set; }

        public void Create()
        {
            if (CreateMethod != null)
            {
                CreateMethod();
            }
        }

        public void Destroy()
        {
            if (DestroyMethod != null)
            {
                DestroyMethod();
            }
        }
    }
}
