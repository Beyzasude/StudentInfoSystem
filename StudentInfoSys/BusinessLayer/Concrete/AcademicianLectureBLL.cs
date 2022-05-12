using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer;
using ModelLayer.StudentLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AcademicianLectureBLL
    {
        public List<AcademicianLectureResult> Get(int departmentId, int studentId)
        {
            
            Context context = new Context();

            List<int> lectureIds = context.StudentLectures.Where(r => r.StudentID == studentId).Select(s => s.AcademicianLecture.LectureID).ToList();

            var res= context.AcademicianLectures.Where(r => r.Academician.DepartmentID == departmentId && lectureIds.Contains(r.LectureID) == false).Select(s => new AcademicianLectureResult()
            {
                AcademicianLectureID = s.AcademicianLectureID,
                LectureID = s.LectureID,
                AcademicianName = s.Academician.Name,
                AcademicianSurname = s.Academician.Surname,
                LectureName = s.Lecture.LectureName
            }).ToList();
            
            return res;
        }


        //ders kayıt yaptıktan sonra seçilen derslerin gösdterileceği fonksiyon
        public List<AcademicianLectureResult> SelectedLectures(int studentID)
        {
            Context context = new Context();

            return (from studentLecture in context.StudentLectures
                    join academicianLecture in context.AcademicianLectures on studentLecture.AcademicianLectureID equals academicianLecture.AcademicianLectureID
                    where studentLecture.StudentID == studentID
                    select new AcademicianLectureResult()
                    {
                        AcademicianLectureID = academicianLecture.AcademicianLectureID,
                        AcademicianName = academicianLecture.Academician.Name,
                        AcademicianSurname = academicianLecture.Academician.Surname,
                        LectureID = academicianLecture.LectureID,
                        LectureName = academicianLecture.Lecture.LectureName
                    }).ToList();
        }
        public List<AcademicianLectureResult> AcademicianLectures(int academicianID)
        {
            Context context = new Context();

            List<AcademicianLectureResult> lectureList = context.AcademicianLectures.Where(s => s.AcademicianID == academicianID).Select(s => new AcademicianLectureResult()
            {
                AcademicianLectureID=s.AcademicianID,
                AcademicianName=s.Academician.Name,
                AcademicianSurname=s.Academician.Surname,
                LectureID=s.LectureID,
                LectureName=s.Lecture.LectureName
            }).ToList();

            return lectureList;


        }


    }
}
