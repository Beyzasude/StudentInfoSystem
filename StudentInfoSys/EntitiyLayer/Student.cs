using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Student")]
    public class Student
    {
        //public Student()
        //{
        //    this.Inturns = new HashSet<Inturn>();
        //    this.StudentLectures = new HashSet<StudentLecture>();
        //}



        [Key]
        [Required]
        [Column("StudentID", Order = 0, TypeName = "int")]
        public int StudentID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Name", Order = 1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Surname", Order = 2)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Column("Email", Order = 3)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Phone", Order = 4)]
        public string  Phone { get; set; }


        [Required]
        [MaxLength(255)]
        [Column("Address", Order = 5)] 
        public string Address { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Tc", Order = 6)]
        public string Tc { get; set; }


        [Required]
        [MaxLength(255)]
        [Column("Password", Order = 7)]
        public string Password { get; set; }

        [Required]
        [Column("Semester", Order = 8, TypeName = "int")]
        public int Semester { get; set; }

        [Required]
        [Column("AcademicianID", Order = 9, TypeName = "int")]
        public int AcademicianID { get; set; }

        [Required]
        [Column("DepartmentID", Order = 10, TypeName = "int")]
        public int DepartmentID { get; set; }

        [Required]
        [Column("SyllabusID", Order = 11, TypeName = "int")]
        public int SyllabusID { get; set; }


        [Column("ImagName", Order = 12)]
        public string ImageName { get; set; }


        [ForeignKey("AcademicianID")]
        public virtual Academician Academician { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [ForeignKey("SyllabusID")]
        public virtual Syllabus Syllabus { get; set; }

        public virtual ICollection<Inturn> Inturns { get; set; }
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}
