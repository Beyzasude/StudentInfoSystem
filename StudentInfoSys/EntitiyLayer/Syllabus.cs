using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Syllabus")]
    public class Syllabus
    {
        //public Syllabus()
        //{
        //    this.Academicians = new HashSet<Academician>();
        //    this.Students = new HashSet<Student>();
        //    this.LectureSyllabuses = new HashSet<LectureSyllabus>();
        //}


        [Key]
        [Required]
        [Column("SyllabusID", Order = 0, TypeName = "int")]
        public int SyllabusID { get; set; }

        [Required]
        [Column("StartTime", Order = 1, TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column("EndTime", Order = 2, TypeName = "datetime")]
        public DateTime EndTime { get; set; }

       public virtual ICollection<Academician> Academicians { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<LectureSyllabus> LectureSyllabuses { get; set; }
    }
}
