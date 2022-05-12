using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Password;
using ModelLayer.Personnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonnelBLL
    {
        public PersonnelResult Login(string email, string password)
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.
            return context.Personnels.Where(s => s.Email == email && s.Password == password).Select(s => new PersonnelResult()
            {
                Id = s.PersonnelID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,
                
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

                Personnel personnel = context.Personnels.Where(r => r.PersonnelID == id).FirstOrDefault(); //burada student result yapamazsın update yapmak istiyorsan gerçek entitiyi vermen lazım 
                if (Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password.OldPassword))) == personnel.Password)
                {

                    personnel.Password = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password.NewPassword)));
                    context.SaveChanges();
                }
                else
                    throw new Exception("Eski Şifre Yanlış"); //bu koyulan throwlar hata varsa kendilerine en yakın bir önceki catche gidip orada hata fırlatırlar . 
            }
            else
                throw new Exception("Girilen şifreler eşleşmiyor ");
        }


        public PersonnelResult GetPersonnel(int id)
        {
            Context context = new Context();

            return context.Personnels.Where(s => s.PersonnelID == id).Select(s => new PersonnelResult()
            {
                Id = s.PersonnelID,
                Name = s.Name,
                Surname = s.Surname,
                Email = s.Email,
                Phone = s.Phone,

            }).FirstOrDefault();
        }
    }
}
