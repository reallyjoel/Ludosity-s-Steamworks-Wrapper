using System;
using System.Collections.Generic;
using System.Text;
using ManagedSteam;

namespace ManagedTest
{
    public class Test
    {
        private CloudTest cloud;
        private StatsTest stats;
        private bool ownsSteam;

        public Test(Action<string> printMethod)
            : this(printMethod, Steam.Initialize())
        {
            ownsSteam = true;
        }

        public Test(Action<string> printMethod, Steam steam)
        {
            this.Print = printMethod;
            this.Steam = steam;
            this.ownsSteam = false;


            cloud = new CloudTest(this);
            stats = new StatsTest(this);
        }

        public Action<string> Print { get; private set; }
        public Steam Steam { get; private set; }

        public bool TestsDone
        {
            get
            {
                return cloud.TestsDone && stats.TestsDone;
            }
        }

        public void Run()
        {
            Steam.ExceptionThrown += ExceptionThrown;

            cloud.Run();
            stats.Run();


            if (ownsSteam)
            {
                while (!TestsDone)
                {
                    Steam.Update();
                }

                Steam.Shutdown();
            }
        }

        private void ExceptionThrown(Exception e)
        {
            Print(e.GetType().Name + ": " + e.Message + "\n" + e.StackTrace);
        }

        public static void TestFailed()
        {
            throw new Exception();
        }
    }
}
