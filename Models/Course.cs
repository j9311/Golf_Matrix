using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfMatrix.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int CourseLength { get; set; }

        public string TournamentName { get; set; }

        public string RelSGTLs { get; set; }

        public string Par { get; set; }

        public string GrassType { get; set; }

        public int Par5Count { get; set; }

        public int Par4Count { get; set; }

        public int Par3Count { get; set; }

        public string CourseNotes { get; set; }

        public string Date { get; set; }

        public string Outcomes { get; set; }

        public string CourseTop6 { get; set; }

        public string CourseMap { get; set; }

        public string WeatherConsiderations { get; set; }

        public string StatSheet { get; set; }

        public Course()
        {

        }

    }
}
