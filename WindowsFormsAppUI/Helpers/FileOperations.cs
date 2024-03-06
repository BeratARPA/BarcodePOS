using System;
using System.IO;

namespace WindowsFormsAppUI.Helpers
{
    public class FileOperations<T>
    {
        private string _filePath;

        public FileOperations(string filePath)
        {
            _filePath = filePath;
        }

        public void CreateFile()
        {
            if (!File.Exists(_filePath))
            {
                using (StreamWriter sw = File.CreateText(_filePath))
                {
                    Console.WriteLine("File created.");
                }
            }
            else
            {
                Console.WriteLine("File already exists.");
            }
        }

        public void WriteToFile(T data, bool append = false)
        {
            if (!File.Exists(_filePath))
            {
                return;
            }

            if (IsDataExists(data))
            {
                Console.WriteLine("Data already exists in the file.");
                return;
            }

            using (StreamWriter sw = new StreamWriter(_filePath, append))
            {
                sw.WriteLine(data.ToString());
                Console.WriteLine("Data written to the file.");
            }
        }

        public string ReadFile()
        {
            if (!File.Exists(_filePath))
            {
                return "";
            }

            using (StreamReader sr = File.OpenText(_filePath))
            {
                string line = "";
                string text = "";
                while ((line = sr.ReadLine()) != null)
                {
                    text += line;
                }

                return text;
            }
        }

        public void DeleteFile()
        {
            if (!File.Exists(_filePath))
            {
                return;
            }

            File.Delete(_filePath);
            Console.WriteLine("File deleted.");
        }

        private bool IsDataExists(T data)
        {
            if (!File.Exists(_filePath))
            {
                return false;
            }

            using (StreamReader sr = new StreamReader(_filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim().Equals(data.ToString().Trim()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
