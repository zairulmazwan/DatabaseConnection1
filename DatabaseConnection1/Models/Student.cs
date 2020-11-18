using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseConnection1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display (Name = "Student ID")]
        public string StudentID { get; set; }

        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Student Level")]
        public int StudentLevel { get; set; }

        [Display(Name = "Student Course")]
        public string StudentCourse { get; set; }



    }
}
