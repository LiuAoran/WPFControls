using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperTools
{ 
    public enum FileDialogType
    {
        Open,
        Save
    }

    public static class FileHelper
    {
        /// <summary>
        /// Returns the file size based on the specified file path, with the smallest unit being bytes (B).
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>
        /// The calculated file size, with units in bytes (B), kilobytes (KB), megabytes (MB), or gigabytes (GB).
        /// </returns>
        public static string GetFileSize(string filePath)
        {
            try
            {
                long fileSize = new FileInfo(filePath).Length;
                string[] sizes = { "B", "KB", "MB", "GB" };
                int order = 0;

                while (fileSize >= 1024 && order < sizes.Length - 1)
                {
                    fileSize /= 1024;
                    order++;
                }

                return $"{fileSize} {sizes[order]}";
            }
            catch
            {
                return "0B";
            }
        }


        public static string GetFilePathOrEmpty(FileDialogType dialogType, string filter = "")
        {
            string selectedFilePath = string.Empty;
            FileDialog fileDialog = dialogType switch
            {
                FileDialogType.Open => new OpenFileDialog(),
                FileDialogType.Save => new SaveFileDialog(),
                _ => throw new ArgumentOutOfRangeException(nameof(dialogType), "Invalid dialog type."),
            };
            fileDialog.Filter = filter;

            if (fileDialog.ShowDialog() == true)
            {
                selectedFilePath = fileDialog.FileName;
            }

            return selectedFilePath;
        }
    }
}
