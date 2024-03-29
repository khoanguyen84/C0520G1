﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGymWeb.Models.Course
{
    public class SaveCourseReq
    {
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Course name")]
        public string CourseName { get; set; }
        [Display(Name = "Status")]
        public int Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
    }
}
