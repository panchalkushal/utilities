using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CLIinput;
using Services;

namespace CustomPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            bool procStop = false;
            while(true)
            {
                if (procStop) break;

                string readString;
                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Copy files");
                Console.WriteLine("2. Get file Names");
                Console.WriteLine("3. Get line numbers for string match");
                Console.WriteLine("**** **** **** ****");
                Console.Write("Enter your choice:");
                readString = Console.ReadLine();

                string devPath = "", dirPath = "", filePath = "", ss = "";

                switch (readString)
                {
                    case "1":
                        UserInput.GetFileCopyParams(ref devPath, ref dirPath, ref filePath);
                        if (Utility.CopyFilesFromFileList(devPath, dirPath, filePath))
                        {
                            Console.WriteLine("Files copied");
                        }    
                        break;
                    case "2":
                        dirPath = UserInput.GetFileNameParams(dirPath);
                        
                        // move up by one directory level
                        string newPath = Path.GetFullPath(Path.Combine(dirPath, @"..\"));
                        // list of file names will be exported here
                        filePath = string.Concat(newPath, "filelist.txt");

                        // export
                        UserInput.WriteToFile(filePath, Utility.GetFileNames(dirPath));

                        Console.WriteLine("File created");
                        break;
                    case "3":
                        UserInput.GetMatchingLinesParams(ref filePath, ref ss);
                        
                        var result = Utility.GetMatchingLines(filePath, ss);
                        
                        Console.WriteLine("Search complete. Found {0} lines.", result.Length);

                        // move up by one directory level
                        newPath = Path.GetFullPath(Path.Combine(filePath, @"..\"));
                        // all the matching rows will be exported here
                        filePath = string.Concat(newPath, "filelist.txt");

                        // export
                        UserInput.WriteToFile(filePath, result.ToArray());
                        
                        break;
                    default:
                        procStop = true;
                        break;
                }                
                continue;
            }            
        }        

        
    }
}
