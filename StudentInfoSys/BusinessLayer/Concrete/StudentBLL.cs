using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Academician;
using ModelLayer.Inturn;
using ModelLayer.Lecture;
using ModelLayer.Password;
using ModelLayer.Student;
using ModelLayer.StudentLecture;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StudentBLL
    {
        public void StudentAdd(StudentAddInput studentAddInput, string imageName)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            Context context = new Context();
            Student student = new Student();
            student.Name = studentAddInput.Name;
            student.Surname = studentAddInput.Surname;
            student.Email = studentAddInput.Email;
            student.Phone = studentAddInput.Phone;
            student.Address = studentAddInput.Address;
            student.ImageName = imageName;
            student.Tc = studentAddInput.Tc;
            student.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(studentAddInput.Password)));
            student.Semester = studentAddInput.Semester;
            student.AcademicianID = studentAddInput.AcademicianID;
            student.DepartmentID = studentAddInput.DepartmentID;
            student.SyllabusID = studentAddInput.SyllabusID;


            context.Students.Add(student);
            context.SaveChanges();

        }

        public void StudentDelete(int id)
        {
            Context context = new Context();
            Student student = context.Students.Where(s => s.StudentID == id).SingleOrDefault();
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void StudentUpdate(StudentResult studentResult)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            Context context = new Context();
            Student student = context.Students.Where(s => s.StudentID == studentResult.Id).FirstOrDefault();


            student.Name = studentResult.Name;
            student.Surname = studentResult.Surname;
            student.Email = studentResult.Email;
            student.Phone = studentResult.Phone;
            student.Address = studentResult.Address;
            student.Tc = studentResult.Tc;
            student.Semester = studentResult.Semester;
            student.AcademicianID = studentResult.AcademicianID;
            student.DepartmentID = studentResult.DepartmentID;
            context.SaveChanges();

        }

        public void ImageUpdate(string imageName, int id)
        {
            Context context = new Context();
            Student student = context.Students.Where(s => s.StudentID == id).FirstOrDefault();
            student.ImageName = imageName;
            context.SaveChanges();
        }


        public StudentResult GetStudent(int id) //bir öğrenciyi getirir.
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.
            return context.Students.Where(s => s.StudentID == id).Select(s => new StudentResult()
            {
                Id = s.StudentID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                AcademicianID = s.AcademicianID,
                AcademicianName = s.Academician.Name,
                DepartmentID = s.DepartmentID,
                Address = s.Address,
                DepartmentName = s.Department.DepartmentName,
                Semester = s.Semester,
                Tc = s.Tc,


            }).FirstOrDefault();

        }


        public StudentResult Login(string email, string password) //student login 
        {
            Context context = new Context();

            return context.Students.Where(s => s.Email == email && s.Password == password).Select(s => new StudentResult()
            {
                Id = s.StudentID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                AcademicianID = s.AcademicianID,
                AcademicianName = s.Academician.Name,
                DepartmentID = s.DepartmentID,
                Address = s.Address,
                DepartmentName = s.Department.DepartmentName,
                Semester = s.Semester,
                Tc = s.Tc,
                ImageName = s.ImageName

            }).FirstOrDefault();
        }

        public void UpdatePassword(PasswordInput password, int id) //student login 
        {
            if (password.NewPassword == password.ConfigPassword)
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                Context context = new Context();
                StudentBLL studentBll = new StudentBLL();
                //var std = studentBll.GetStudent(id);

                Student student = context.Students.Where(r => r.StudentID == id).FirstOrDefault(); //burada student result yapamazsın update yapmak istiyorsan gerçek entitiyi vermen lazım 
                if (Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password.OldPassword))) == student.Password)
                {
                    student.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password.NewPassword)));
                    context.SaveChanges();
                }
                else
                    throw new Exception("Eski Şifre Yanlış"); //bu koyulan throwlar hata varsa kendilerine en yakın bir önceki catche gidip orada hata fırlatırlar . 
            }
            else
                throw new Exception("Girilen şifreler eşleşmiyor ");
        }



        public List<StudentResult> GetList() // bütün öğrencileri getirir.
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.
            //List<StudentResult> studentLıst = context.Students.Where(s=>s.StudentID==10).OrderBy(o => o.Surname).Select(s => new StudentResult()

            List<StudentResult> studentList = context.Students.OrderBy(o => o.Surname).Select(s => new StudentResult()
            {
                Id = s.StudentID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                AcademicianID = s.AcademicianID,
                AcademicianName = s.Academician.Name,
                DepartmentID = s.DepartmentID,
                Address = s.Address,
                DepartmentName = s.Department.DepartmentName,
                Semester = s.Semester,
                Tc = s.Tc,


            }).ToList();

            return studentList;
        }
        public List<StudentLectureResult> GetListStudents(int id, int lectureID)  //Akademisyenden ders alan öğencileri getirir.
        {
            Context context = new Context();

            var studentResult = from academicianLecture in context.AcademicianLectures
                                join studentLecture in context.StudentLectures on academicianLecture.AcademicianLectureID equals studentLecture.AcademicianLectureID
                                where studentLecture.AcademicianLecture.LectureID == lectureID && studentLecture.AcademicianLecture.AcademicianID == id
                                select new StudentLectureResult()
                                {
                                    StudentLectureID = studentLecture.StudentLectureID,
                                    StudentID = studentLecture.StudentID,
                                    LectureID = academicianLecture.LectureID,
                                    StudentName = studentLecture.Student.Name,
                                    StudentSurname = studentLecture.Student.Surname,
                                    LectureName = academicianLecture.Lecture.LectureName,
                                    Note1 = studentLecture.Note1,
                                    Note2 = studentLecture.Note2
                                };

            return studentResult.ToList();

        }

        public List<StudentLectureResult> GetStudentNotes(int id)
        {
            Context context = new Context();

            return (from s in context.Students
                    join sl in context.StudentLectures on s.StudentID equals sl.StudentID
                    join al in context.AcademicianLectures on sl.AcademicianLectureID equals al.AcademicianLectureID
                    where s.StudentID == id
                    select new StudentLectureResult()
                    {
                        StudentID = s.StudentID,
                        LectureID = sl.StudentLectureID,
                        StudentName = s.Name,
                        StudentSurname = s.Surname,
                        LectureName = al.Lecture.LectureName,
                        Note1 = sl.Note1,
                        Note2 = sl.Note2
                    }).ToList();

        }
    }
}
