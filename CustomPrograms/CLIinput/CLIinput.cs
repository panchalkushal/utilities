using System;
using System.IO;

/// <summary>
/// Get input for file copy function
/// </summary>
namespace CLIinput
{
    public static class UserInput
    {
        public static void GetFileCopyParams(ref string designPath, ref string dirPath, ref string filePath)
        {
            Console.Write("Enter source loc:");
            designPath = Console.ReadLine();

            Console.Write("Enter destination to:");
            dirPath = Console.ReadLine();

            Console.Write("Text file which has list:");
            filePath = Console.ReadLine();
        }

        public static string GetFileNameParams(string dirPath)
        {
            Console.Write("Enter dir loc:");
            dirPath = Console.ReadLine();
            return dirPath;
        }

        public static void GetMatchingLinesParams(ref string filePath, ref string ss)
        {
            Console.Write("Enter the file path:");
            filePath = Console.ReadLine();

            Console.Write("Enter the search string:");
            ss = Console.ReadLine();
        }

        // Write an array of strings to a file.
        public static void WriteToFile(string filePath, string[] lines)
        {
            System.IO.File.WriteAllLines(filePath, lines);
        }        
    }
}
