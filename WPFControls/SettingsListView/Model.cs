using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsListView
{
    public class FileInfo
    {
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileDate { get; set; }
        public string OpenDate { get; set; }
        public FileInfo() { }
        public FileInfo(string fileName, string fileSize, string fileDate, string openDate)
        {
            FileName = fileName;
            FileSize = fileSize;
            FileDate = fileDate;
            FileDate = openDate;
        }

    }
}
