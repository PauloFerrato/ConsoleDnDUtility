using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleDnDUtility
{
    static class PersistenceHandler
    {

        public static List<string> ReadFile()
        {

            List<string> extractedFile = null;
            if (FilesExists())
            {
                extractedFile = new List<string>();
                if (FileExists(UtilsKeysNAdresses.MY_FILE_NAME))
                {
                    using (StreamReader sr = new StreamReader(UtilsKeysNAdresses.MY_FILE_NAME))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            extractedFile.Add(line);
                        }
                        sr.Close();
                    }
                }
            }
            return extractedFile;
        }

        public static void WriteFile(List<string> extractedFile)
        {
            extractedFile.Sort();

            if (FilesExists())
            {

                using (StreamWriter sw = new StreamWriter(UtilsKeysNAdresses.MY_FILE_NAME))
                {
                    foreach (string line in extractedFile)
                    {
                        sw.Write(line + "\n");
                    }
                    sw.Close();

                }
            }
        }

        private static bool FilesExists()
        {
            bool exists = true;
            if (!DirectoryExists(UtilsKeysNAdresses.MY_FOLDER_NAME))
            {
                Directory.CreateDirectory(UtilsKeysNAdresses.MY_FOLDER_NAME);
                exists = false;
            }

            if (!FileExists(UtilsKeysNAdresses.MY_FILE_NAME))
            {
                File.Create(UtilsKeysNAdresses.MY_FILE_NAME);
                exists = false;
            }
            return exists;
        }

        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
