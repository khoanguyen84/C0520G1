﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Course
{
    public class CourseView
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public string StartDateStr { get; set; }
        public DateTime EndDate { get; set; }
        public string EndDateStr { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateStr { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateStr { get; set; }
        public int ModifiedBy { get; set; }
    }
}
