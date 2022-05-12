using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Academician")]
    public class Academician
    {
        [Required]
        [Key]
        [Column("AcademicianID", Order = 0, TypeName = "int")]
        public int AcademicianID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Name", Order = 1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Surname", Order = 2)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        [Column("Email", Order = 3)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Phone", Order = 4)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Password", Order = 5)]
        public string Password { get; set; }

        [Column("SyllabusID", Order = 6)]
        public int SyllabusID { get; set; }

        [Column("DepartmentID", Order = 7, TypeName = "int")]
        public int DepartmentID { get; set; }

        [Column("ImagName", Order = 8)]
        public string ImageName { get; set; }


        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [ForeignKey("SyllabusID")]
        public virtual Syllabus Syllabus { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<AcademicianLecture> AcademicianLectures { get; set; }
    }
}
