using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDnDUtility
{
    static class UtilsKeysNAdresses
    {
        public static string MY_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DnDNames\NamesFile.txt";
        public static string MY_FOLDER_NAME = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DnDNames";
        
        public static char SETLEMENT_NAME_KEY = '&';
        public static char SETLEMENT_TYPE_KEY = '#';
    }
}
