using System;
using System.Collections.Generic;
using System.IO;

namespace FileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var path = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Data\Request";
            //var path = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Data";
            //Directory.CreateDirectory(path);
            //Directory.Delete(path);

            //var fileName = "input.txt";

            //using (StreamWriter sw = File.CreateText($@"{path}\{fileName}"))
            //{
            //    sw.WriteLine("CodeGym Hue");
            //    sw.WriteLine("C0520G1");
            //    sw.WriteLine("Hello world");
            //}

            //List<string> data = new List<string>();
            //using (StreamReader sr = File.OpenText($@"{path}\{fileName}"))
            //{
            //    //Console.WriteLine(sr.ReadToEnd());
            //    var line = string.Empty;
            //    int number = 0;
            //    while((line = sr.ReadLine()) != null)
            //    {
            //        number += 1;
            //        //Console.WriteLine($"Line {number} : {line.ToUpper()}");
            //        data.Add($"Line {number} : {line.ToUpper()}");
            //    }
            //}
            //data = FileHelper.ReadFile($@"{path}\{fileName}");

            //var outputFileName = "output.txt";
            //using (StreamWriter sw = File.CreateText($@"{path}\{outputFileName}"))
            //{
            //    foreach(var item in data)
            //    {
            //        sw.WriteLine(item);
            //    }
            //}

            //FileHelper.WriteFile($@"{path}\{outputFileName}", data);

            //var logPath = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Logs";
            //Directory.CreateDirectory(logPath);
            //var logFileName = $"Log_{DateTime.Now.ToString("ddMMyyyyhhmm")}.txt";
            //try
            //{
            //    int a = 10;
            //    int b = 0;
            //    Console.WriteLine($"{a}/{b} = {a / b}");
            //}
            //catch (Exception e)
            //{
            //    using (StreamWriter sw = File.AppendText($@"{logPath}\{logFileName}"))
            //    {
            //        sw.WriteLine($"Error {DateTime.Now.ToString("dd/MM/yyyy hh:mm: ")}{e.Message}");
            //    }
            //}

            //var inputFN = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Logs\Log_220720200231.txt";
            //var outputFN = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Logs\Update_Log_220720200231.txt";
            //var log = new List<string>();
            //log = FileHelper.ReadFile(inputFN);
            //FileHelper.WriteFile(outputFN, log);

            var arrayInput = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Data\ArrayInput.txt";
            var arrayOutput = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\FileDemo\Data\ArrayOutput.txt";

            
            int[] array = new int[0];
            using (StreamReader sr = File.OpenText(arrayInput))
            {
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');
                    array = new int[data.Length];
                    for(int i=0; i< data.Length; i++)
                    {
                        array[i] = int.Parse(data[i]);
                    }
                }
            }
            using (StreamWriter sw = File.CreateText(arrayOutput))
            {
                for(int i=0; i < array.Length; i++)
                {
                    array[i] *= 2;
                }
                var data = string.Join(' ', array);
                sw.WriteLine(data);
            }
        }
    }
}
