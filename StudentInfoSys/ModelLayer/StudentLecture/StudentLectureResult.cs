using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.StudentLecture
{
    public class StudentLectureResult
    {
        public int StudentLectureID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public int LectureID { get; set; }
        public string LectureName { get; set; }
        public int? Note1 { get; set; }
        public int? Note2 { get; set; }
    }
}
