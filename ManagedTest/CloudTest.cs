using System;
using System.Collections.Generic;
using System.Text;
using ManagedSteam;
using System.Diagnostics;

namespace ManagedTest
{
    class CloudTest
    {
        private Test owner;

        private bool shareUGCDone;
        private bool downloadUGCDone;

        public CloudTest(Test owner)
        {
            this.owner = owner;

            shareUGCDone = true;
            downloadUGCDone = true;
        }

        public Action<string> Print { get { return owner.Print; } }
        public Steam Steam { get { return owner.Steam; } }
        public ICloud Cloud { get { return Steam.Cloud; } }

        public bool TestsDone { get { return shareUGCDone && downloadUGCDone; } }

        [Conditional("STEAMAPIWRAP_FULL")]
        public void Run()
        {
            shareUGCDone = false;
            downloadUGCDone = false;

            TestReadAndWrite();
            TestForget();
            TestIterateFiles();
            TestUGC();
        }

        private void TestReadAndWrite()
        {
            string fileName = "ReadAndWrite.txt";
            CreateFile(fileName);


            int fileSize = Cloud.GetSize(fileName);
            byte[] readData = new byte[fileSize];
            int bytesRead = Cloud.Read(fileName, readData);

            string readFileString = GetStringData(readData, bytesRead);

            if (readFileString != fileName)
            {
                Failed();
            }
            //Print("TestReadAndWrite Done");
        }

        private void TestForget()
        {
            string name = "TestForget";
            int totalBytes;
            int availableBytes;
            Cloud.GetQuota(out totalBytes, out availableBytes);
            CreateFile(name);


            int middleAvailable;
            Cloud.GetQuota(out totalBytes, out middleAvailable);

            if (!Cloud.Forget(name))
            {
                Failed();
            }

            if (Cloud.Persisted(name))
            {
                Failed();
            }
            else
            {
                if (Cloud.Exists(name))
                {
                    int newAvailable;
                    Cloud.GetQuota(out totalBytes, out newAvailable);
                    if (availableBytes == newAvailable && middleAvailable < availableBytes)
                    {
                        //Print("TestForget Done");
                    }
                    else
                    {
                        Failed();
                    }
                }
                else
                {
                    Failed();
                }
            }
        }

        private void TestIterateFiles()
        {
            //Print("TestIterateFiles");
            int fileCount = Cloud.GetFileCount();
            for (int i = 0; i < fileCount; i++)
            {
                int fileSize;
                string fileName = Cloud.GetFileNameAndSize(i, out fileSize);
                //Print(String.Format("File: {0}, Name: {1}, Size: {2}", i, fileName, fileSize));
            }

            //Print("TestIterateFiles Done");
        }

        private void TestUGC()
        {
            string fileName = "ReadAndWrite.txt";

            Cloud.CloudFileShareResult += (result, flag) =>
                {
                    //Print("CloudFileShareResult");
                    //Print(flag.ToString());
                    //Print(result.Result.ToString());
                    //Print(result.Handle.AsUInt64.ToString());


                    Cloud.UGCDownload(result.Handle);

                    Print("ShareUGC Done");
                    shareUGCDone = true;
                };
            Cloud.CloudDownloadUGCResult += (result, flag) =>
                {
                    //Print("CloudDownloadUGCResult");
                    //Print(flag.ToString());
                    //Print(result.AppID.ToString());
                    //Print(result.CreatorID.AsUInt64.ToString());
                    //Print(result.FileName);
                    //Print(result.Handle.AsUInt64.ToString());
                    //Print(result.Result.ToString());
                    //Print(result.Size.ToString());


                    GetUGCDetails(result.Handle);

                    ReadUGCData(result.Handle, result.Size);

                    //Print("CloudDownloadUGCResult Done");


                    Print("TestUGC Done");
                    downloadUGCDone = true;
                };

            Cloud.Share(fileName);
        }

        private void ReadUGCData(ManagedSteam.SteamTypes.UGCHandle handle, int fileSize)
        {
            byte[] fileData = new byte[fileSize];
            int bytesRead = Cloud.UGCRead(handle, fileData);
            if (bytesRead != fileSize)
            {
                Failed();
            }

            string sharedString = GetStringData(fileData, bytesRead);
            //Print(sharedString);
        }

        private void GetUGCDetails(ManagedSteam.SteamTypes.UGCHandle handle)
        {
            //Print("GetUGCDetails");

            ManagedSteam.SteamTypes.AppID appID;
            string name;
            int fileSize;
            ManagedSteam.SteamTypes.SteamID steamID;

            bool result = Cloud.GetUGCDetails(handle, out appID, out name, out fileSize, out steamID);

            //Print(result.ToString());
            if (result)
            {
                //Print(appID.ToString());
                //Print(name);
                //Print(fileSize.ToString());
                //Print(steamID.ToString());
            }

            //Print("GetUGCDetails Done");
        }


        private void CreateFile(string fileName)
        {
            byte[] fileData = GetFileData(fileName);
            if (!Cloud.Write(fileName, fileData))
            {
                Failed();
            }
        }

        private byte[] GetFileData(string customData)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string date = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            string wholeFile = String.Format("Written {0}:\n{1}", date, customData);

            return encoding.GetBytes(wholeFile);
        }

        private string GetStringData(byte[] fileData, int fileSize)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string fullFileString = encoding.GetString(fileData, 0, fileSize);
            int index = fullFileString.IndexOf('\n');
            return fullFileString.Substring(index + 1);
        }

        private void Failed()
        {
            Test.TestFailed();
        }
    }
}
