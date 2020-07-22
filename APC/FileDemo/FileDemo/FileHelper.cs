using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileDemo
{
    public class FileHelper
    {
        public static List<string> ReadFile(string filePath)
        {
            var data = new List<string>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                var line = string.Empty;
                int number = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    number += 1;
                    data.Add($"Line {number} : {line.ToUpper()}");
                }
            }
            return data;
        }

        public static void WriteFile(string filePath, List<string> data)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}
