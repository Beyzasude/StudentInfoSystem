using BusinessLayer.Concrete;
using ModelLayer.Lecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfoSys.Models
{
    public class AcademicianLectureViewModel
    {
        public List<LectureResult> lectureResults { get; set; }
        public StudentLectureBLL studentLectureBLL{ get; set; }
    }
} 