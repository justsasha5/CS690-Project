using System;
using System.IO;

namespace FinalPr
{
    public class FileSaver
    {
        private readonly string _filePath;

        public FileSaver(string filePath)
        {
            _filePath = filePath;
        }

        public void AppendLine(string line)
        {
            File.AppendAllText(_filePath, line + Environment.NewLine);
        }
    }
}
