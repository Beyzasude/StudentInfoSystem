using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Lecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LectureBLL
    {

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




        //public void LectureAdd(LectureAddInput lectureAddInput)
        //{

        //    Context context = new Context();
        //    Lecture lecture = new Lecture();


        //    lecture.LectureID = lectureAddInput.LectureID;
        //    //lecture.LectureName = lectureAddInput.LectureName;
        //    //lecture.Semester = lectureAddInput.Semester;
        //    //lecture.DepartmentID = lectureAddInput.DepartmentID;

        //    context.Lectures.Add(lecture);
        //    context.SaveChanges();

        //}
    }
}
