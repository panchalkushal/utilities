using System;
using System.Collections.Generic;
using System.IO;

namespace Services
{
    public static class Utility
    {
        /// <summary>
        /// Get all files present in the directory, traverses through subdirectories too
        /// </summary>
        public static string[] GetFileNames(string dirPath)
        {
            string[] files = Directory.GetFiles(dirPath);
            List<string> fileNames = new List<string>();

            foreach (string file in files)
            {
                fileNames.Add(file);
                //to add only file names use Path.GetFileName(file) 
            }

            //get sub directories files
            DirSearch(dirPath, ref fileNames);

            return fileNames.ToArray();
        }

        /// <summary>
        /// Copy all files mentioned in the text file from designPath to dirPath
        /// </summary>
        public static bool CopyFilesFromFileList(string designPath, string destPath, string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string fileName = line.Replace(designPath, "");                
                System.IO.FileInfo file = new System.IO.FileInfo(destPath + fileName);
                file.Directory.Create();

                if (!line.Contains(designPath))
                {
                    File.Copy(designPath + line, destPath + fileName, true);
                }
                else
                {
                    File.Copy(line, destPath + fileName, true);
                }

                Console.WriteLine($"{fileName} copied to {destPath}");
            }

            return true;
        }

        /// <summary>
        /// Search CSV file row wise and return rows where string match was found
        /// </summary>
        public static string[] GetMatchingLines(string filePath, string ss)
        {
            char[] delimiters = new char[] { ',' };
            int i = 0;
            List<string> n = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    string[] parts = line.Split(delimiters);
                    if (Array.FindIndex(parts, p => p.Equals(ss, StringComparison.CurrentCultureIgnoreCase)) > -1)
                    {
                        n.Add(line);
                    }

                    i++;
                }
            }            
            
            return n.ToArray();
        }

        #region "Helper Functions"
        static void DirSearch(string sDir, ref List<string> fileNames)
        {
            try
            {                
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        fileNames.Add(f);
                    }

                    //recursively get sub directories files
                    DirSearch(d, ref fileNames);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        #endregion
    }
}
