using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.Implementations
{
    /// <summary>
    /// \internal 
    /// Base for all the 'Service' classes. Can't be used outside of the wrapper library.
    /// </summary>
    abstract class SteamService
    {
        internal SteamService()
        {
        }

        internal static Dictionary<CallbackID, NativeCallback> Callbacks
        {
            get { return Steam.Instance.Callbacks; }
        }
        internal static Dictionary<ResultID, NativeResultCallback> Results
        {
            get { return Steam.Instance.ResultCallbacks; }
        }


        /// <summary>
        /// This method does some general checks to see if the current instance can communicate with native dll.
        /// </summary>
        internal void CheckIfUsable()
        {
            Steam.Instance.CheckIfUsable();

            CheckIfUsableInternal();
        }

        internal abstract void CheckIfUsableInternal();

        internal abstract void ReleaseManagedResources();

        internal abstract void InvokeEvents();

        internal static void InvokeEvents<T>(List<Result<T>> values, ResultEvent<T> eventList)
            where T : struct
        {
            if (eventList != null)
            {
                foreach (var item in values)
                {
                    eventList(item.Data, item.Flag);
                }
            }
            values.Clear();
        }

        internal static void InvokeEvents<T>(List<T> values, CallbackEvent<T> eventList)
            where T : struct
        {
            if (eventList != null)
            {
                foreach (var item in values)
                {
                    eventList(item);
                }
            }
            values.Clear();
        }


        internal struct Result<T>
            where T : struct
        {
            public T Data;
            public bool Flag;

            public Result(T data, bool flag)
            {
                this.Data = data;
                this.Flag = flag;
            }
        }
    }
}
