using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Academician;
using ModelLayer.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AcademicianBLL
    {
        public void AcademicianAdd(AcademicianAddInput academicianAddInput , string imageName)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            Context context = new Context();
            Academician academician = new Academician();
            academician.Name = academicianAddInput.Name;
            academician.Surname = academicianAddInput.Surname;
            academician.Email = academicianAddInput.Email;
            academician.Phone = academicianAddInput.Phone;
            academician.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(academicianAddInput.Password)));
            academician.DepartmentID = academicianAddInput.DepartmentID;
            academician.SyllabusID = academicianAddInput.SyllabusID;
            academician.ImageName = imageName;

            context.Academicians.Add(academician);
            context.SaveChanges();

        }
        public AcademicianResult GetAcademician(int id)
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.
            return context.Academicians.Where(s => s.AcademicianID == id).Select(s => new AcademicianResult()
            {
                Id = s.AcademicianID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                DepartmentID = s.DepartmentID,
                DepartmentName = s.Department.DepartmentName,


            }).FirstOrDefault();

        }

        public AcademicianResult Login(string email, string password)
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.
            return context.Academicians.Where(s => s.Email == email && s.Password == password).Select(s => new AcademicianResult()
            {
                Id = s.AcademicianID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                DepartmentID = s.DepartmentID,
                ImageName = s.ImageName,
                DepartmentName = s.Department.DepartmentName,
                Lectures = s.AcademicianLectures.ToList()

            }).FirstOrDefault();
        }

        public void UpdatePassword(PasswordInput password, int id)
        {
            if (password.NewPassword == password.ConfigPassword)
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                Context context = new Context();
                AcademicianBLL studentBll = new AcademicianBLL();

                Academician academician = context.Academicians.Where(r => r.AcademicianID == id).FirstOrDefault();
                if (Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password.OldPassword))) == academician.Password)
                {

                    academician.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password.NewPassword)));
                    context.SaveChanges();
                }
                else
                    throw new Exception("Eski Şifre Yanlış ");
            }
            else
                throw new Exception("Girilen Şifreler Eşleşmiyor ");
        }

        public void AcademicianDelete(int id)
        {
            Context context = new Context();
            Academician academician = context.Academicians.Where(s => s.AcademicianID == id).SingleOrDefault();
            context.Academicians.Remove(academician);
            context.SaveChanges();
        }

        public void AcademicianUpdate(AcademicianResult academicianResult)
        {
            Context context = new Context();
            Academician academician = context.Academicians.Where(s => s.AcademicianID == academicianResult.Id).FirstOrDefault();


            academician.Name = academicianResult.Name;
            academician.Surname = academicianResult.Surname;
            academician.Email = academicianResult.Email;
            academician.Phone = academicianResult.Phone;
            academician.DepartmentID = academicianResult.DepartmentID;

            context.SaveChanges();

        }

        public void ImageUpdate(string imageName, int id)
        {
            Context context = new Context();
            Academician academician = context.Academicians.Where(s => s.AcademicianID == id).FirstOrDefault();
            academician.ImageName = imageName;
            context.SaveChanges();
        }
        public Student GetByIdStudent(int id)
        {
            return null;
        }

        public List<AcademicianResult> GetList()
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.
            //List<StudentResult> studentLıst = context.Students.Where(s=>s.StudentID==10).OrderBy(o => o.Surname).Select(s => new StudentResult()

            List<AcademicianResult> AcademicianList = context.Academicians.OrderBy(o => o.Surname).Select(s => new AcademicianResult()
            {
                Id = s.AcademicianID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                DepartmentID = s.DepartmentID,
                DepartmentName = s.Department.DepartmentName,

            }).ToList();



            //  var x = (from q in context.Students
            //  where q.AcademicianID == 10
            //  select new StudentResult()
            //  {
            //      AcademicianID = q.AcademicianID,
            //      AcademicianName = q.Academician.Name
            //  }.ToList()
            return AcademicianList;
        }

        public List<AcademicianResult> Get(int departmentId)
        {
            Context context = new Context();

            return context.Academicians.Where(r => r.DepartmentID == departmentId).OrderBy(o => o.Surname).Select(s => new AcademicianResult()
            {
                Id = s.AcademicianID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                DepartmentID = s.DepartmentID,
                DepartmentName = s.Department.DepartmentName,

            }).ToList();
        }
    }
}
