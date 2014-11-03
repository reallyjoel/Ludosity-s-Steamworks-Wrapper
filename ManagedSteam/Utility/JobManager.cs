using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Utility
{
    class JobManager
    {
        private List<IJob> jobs;

        public JobManager()
        {
            jobs = new List<IJob>();
        }

        /// <summary>
        /// Invoked before each job in RunCreateJobs
        /// </summary>
        public event Action<IJob> PreCreateJob;

        /// <summary>
        /// Invoked after each job in RunCreateJobs
        /// </summary>
        public event Action<IJob> PostCreateJob;

        /// <summary>
        /// Invoked before each job is run
        /// </summary>
        public event Action<IJob> PreDestroyJob;

        /// <summary>
        /// Invoked after each job is run
        /// </summary>
        public event Action<IJob> PostDestroyJob;

        public void AddJob(IJob job)
        {
            jobs.Add(job);
        }

        public void RunCreateJobs()
        {
            foreach (var item in jobs)
            {
                if (PreCreateJob != null)
                {
                    PreCreateJob(item);
                }
                item.Create();
                if (PostCreateJob != null)
                {
                    PostCreateJob(item);
                }
            }
        }

        public void RunDestroyJobs()
        {
            foreach (var item in jobs)
            {
                if (PreDestroyJob != null)
                {
                    PreDestroyJob(item);
                }
                item.Destroy();
                if (PostDestroyJob != null)
                {
                    PostDestroyJob(item);
                }
            }
        }
    }
}
