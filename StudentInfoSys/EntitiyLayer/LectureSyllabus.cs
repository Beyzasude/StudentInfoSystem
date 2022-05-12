using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("LectureSyllabus")]
    public class LectureSyllabus
    {

        [Key]
        [Required]
        [Column("LectureSyllabusID", Order = 0, TypeName = "int")]
        public int LectureSyllabusID { get; set; }

        [Required]
        [Column("LectureID", Order = 1, TypeName = "int")]
        public int LectureID { get; set; }

        [Required]
        [Column("SyllabusID", Order = 2, TypeName = "int")]
        public int SyllabusID { get; set; }

       [ForeignKey("LectureID")]
        public virtual Lecture Lecture { get; set; }

        [ForeignKey("SyllabusID")]
        public virtual Syllabus Syllabus { get; set; }

    }
}
