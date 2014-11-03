using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace InteropDllFixer
{
    class Program
    {
        private const string TargetDllString = "DllImportAttribute(\"";
        private const string TargetClassString = " partial class Native";
        private const string ClassAttribute = "[System.CodeDom.Compiler.GeneratedCode(\"InteropSignatureToolkit\", \"\")]";


        static void Main(string[] args)
        {
            string targetFile = args[0];
            string targetDLLName = args[1];

            List<string> fileLines = new List<string>(File.ReadAllLines(targetFile));

            for (int i = 0; i < fileLines.Count; i++)
            {
                string line = fileLines[i];


                // Replace <Unknown> with the dll name
                int dllImportIndex = line.IndexOf(TargetDllString);
                if (dllImportIndex > 0)
                {
                    int startIndex = dllImportIndex + TargetDllString.Length;
                    int endIndex = line.IndexOf('"', startIndex);

                    string newLine = line.Substring(0, startIndex);
                    newLine += targetDLLName;
                    newLine += line.Substring(endIndex);

                    fileLines[i] = newLine;
                }

                int classStartIndex = line.IndexOf(TargetClassString);
                if (classStartIndex > 0)
                {
                    // Add the attribute on an extra line
                    fileLines.Insert(i, ClassAttribute);
                    ++i;
                }

                // Make all the exported native methods/types/delegates internal
                fileLines[i] = fileLines[i].Replace("public ", "internal ");
            }

            File.WriteAllLines(targetFile, fileLines);
            Console.WriteLine("Done");
        }
    }
}
