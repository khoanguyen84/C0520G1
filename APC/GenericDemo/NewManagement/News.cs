using System;
using System.Collections.Generic;
using System.Text;

namespace NewManagement
{
    class News : INews
    {
        private int id;
        private string title;
        private string publishDate;
        private string author;
        private string content;
        private float averageRate;

        public int Id  { get => id; set => id = value;}
        public string Title { get => title; set => title = value; }
        public string PublishDate { get => publishDate; set => publishDate = value; }
        public string Author { get => author; set => author = value; }
        public string Content { get => content; set => content = value; }
        public float AverageRate { get => averageRate; }
        public int[] RateList = new int[3];
        
        public void Display()
        {
            Console.WriteLine($"{id}\t{title}\t{publishDate}\t{author}\t{content}\t{averageRate}");
        }

        public void Calculate()
        {
            float total = 0;
            foreach(var item in RateList)
            {
                total += item;
            }
            averageRate = total / RateList.Length;
        }
    }
}
