using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("StudentLecture")]
    public class StudentLecture
    { 
        [Key]
        [Required]
        [Column("StudentLectureID", Order = 0, TypeName = "int")]
        public int StudentLectureID { get; set; }

        [Required]
        [Column("StudentID", Order = 1, TypeName = "int")]
        public int StudentID { get; set; }

        [Required]
        [Column("AcademicianLectureID", Order = 2, TypeName = "int")]
        public int AcademicianLectureID { get; set; }

        [Column("Note1", Order = 3, TypeName = "int")]
        public int? Note1 { get; set; }

        [Column("Note2", Order = 4, TypeName = "int")]
        public int? Note2 { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }

       [ForeignKey("AcademicianLectureID")]
        public virtual AcademicianLecture AcademicianLecture { get; set; }
    }
}
