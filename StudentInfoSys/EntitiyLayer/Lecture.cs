using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Lecture")]
    public class Lecture
    {
        //public Lecture()
        //{
        //    this.AcademicianLectures = new HashSet<AcademicianLecture>();
        //    this.StudentLectures = new HashSet<StudentLecture>();
        //    this.LectureSyllabuses = new HashSet<LectureSyllabus>();
        //}


        [Key]
        [Required]
        [Column("LectureID", Order = 0, TypeName = "int")]
        public int LectureID { get; set; }


        [Required]
        [MaxLength(255)]
        [Column("LectureName", Order = 1)]
        public string LectureName { get; set; }

        [Required]
        [Column("Semester", Order = 2, TypeName = "int")]
        public int Semester { get; set; }

        [Required]
        [Column("DepartmentID", Order = 3, TypeName = "int")]
        public int DepartmentID { get; set; }

        //Ders programı için gün ve saat kolonu açılması lazım sql veritabanında 
        //[Required]
        //[Column("Day", Order = 4)]
        //public DateTime Day { get; set; }

        //[Required]
        //[Column("Hour", Order = 5)]
        //public DateTime Hour { get; set; }


        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        public virtual ICollection<AcademicianLecture> AcademicianLectures { get; set; }
        public virtual ICollection<LectureSyllabus> LectureSyllabuses { get; set; }
    }
}
