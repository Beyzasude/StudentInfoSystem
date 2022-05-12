using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Lecture;
using ModelLayer.StudentLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentLectureBLL
    {
        public void Add(List<int> lectureIds, int studentId)
        {

            Context context = new Context();

           
            foreach (int item in lectureIds)
            {
                StudentLecture studentLecture = new StudentLecture();
                studentLecture.AcademicianLectureID = item;
                studentLecture.StudentID = studentId;
                studentLecture.Note1 = null;
                studentLecture.Note2 = null;
                context.StudentLectures.Add(studentLecture);
            }
            context.SaveChanges();          
        }

        public static void AddNote(List<StudentLectureInput> students)
        {
            Context context = new Context();

            foreach (StudentLectureInput item in students)
            {
                StudentLecture studentLecture = context.StudentLectures.Where(r => r.StudentLectureID == item.StudentLectureID).FirstOrDefault();
                studentLecture.Note1 = item.Note1;
                studentLecture.Note2 = item.Note2;
                //studentLecture.StudentID = item.StudentID;
                
                context.SaveChanges();
            }
        }

        public List<LectureResult> GetList(int id)
        {
            Context context = new Context();

            List<LectureResult> lectureList = context.Lectures.Where(s => s.DepartmentID == id).Select(s => new LectureResult()
            {
                LectureID = s.LectureID,
                LectureName = s.LectureName,
            }).ToList();

            return lectureList;
        }
      
    }
}
