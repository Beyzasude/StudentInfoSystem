using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("AcademicianLecture")]
    public class AcademicianLecture
    {
        [Key]
        [Required]
        [Column("AcademicianLectureID", Order = 0, TypeName = "int")]
        public int AcademicianLectureID { get; set; }

        [Required]
        [Column("AcademicianID", Order = 1, TypeName = "int")]
        public int AcademicianID { get; set; }

        [Required]
        [Column("LectureID", Order = 2, TypeName = "int")]
        public int LectureID { get; set; }

        [ForeignKey("AcademicianID")]
        public virtual Academician Academician { get; set; }

        [ForeignKey("LectureID")]
        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<StudentLecture> StudentLectures { get; set; }
    }
}
