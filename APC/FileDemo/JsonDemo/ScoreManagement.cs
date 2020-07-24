using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JsonDemo
{
    class ScoreManagement
    {
        public static void Main()
        {
            var filePath = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\JsonDemo\Data\score.json";
            var outFilePath = @"C:\CodeGym\Class\C0520G1\C0520G1\APC\FileDemo\JsonDemo\Data\process_score.json";
            var result = new Payload();
            using (StreamReader sr = File.OpenText(filePath))
            {
                var data = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<Payload>(data);
            }

            Console.WriteLine($"Name\t\tAge\t\tGender\t\tMath\t\tPhysical\t\tChemistry\t\tAverage Score");
            foreach(var student in result.students)
            {
                Console.WriteLine(student.ToString());
            }

            //preparation for output
            var response = new Response()
            {
                students = new List<ResStudent>()
            };

            //mapping Student to ResStudent
            foreach(var std in result.students)
            {
                response.students.Add(new ResStudent()
                {
                    age = std.age,
                    average = std.AverageScore(),
                    gender = std.gender,
                    name = std.name,
                    scores = std.scores
                });
            }

            using (StreamWriter sw = File.CreateText(outFilePath))
            {
                var data = JsonConvert.SerializeObject(response);
                sw.Write(data);
            }
        }
    }

    class Payload
    {
        public List<Student> students { get; set; }
    }
    public class Student
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public List<Score> scores { get; set; }

        public float AverageScore()
        {
            float total = 0;
            foreach(var item in scores)
            {
                if(item.name == "Toan")
                {
                    total += item.score*2;
                }
                else
                {
                    total += item.score;
                }
                
            }
            return total / (scores.Count+1);
        }

        public override string ToString()
        {
            return $"{name}\t\t{age}\t\t{gender}\t\t{scores[0].score}\t\t{scores[1].score}\t\t{scores[2].score}\t\t{AverageScore()}";
        }
    }
    public class Score
    {
        public string name { get; set; }
        public float score { get; set; }
    }

    public class Response
    {
        public List<ResStudent> students { get; set; }
    }

    public class ResStudent : Student
    {
        public float average { get; set; }
        public string rank => Rank();

        private string Rank()
        {
            if(average >= 9)
            {
                return "Xuat sac";
            }
            if (average >= 8)
            {
                return "Gioi";
            }
            if (average >= 7)
            {
                return "Kha";
            }
            if (average >= 5)
            {
                return "TB";
            }
            return "Yeu";
        }
    }
}
