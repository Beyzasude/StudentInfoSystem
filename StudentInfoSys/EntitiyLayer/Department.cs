using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Department")]
    public class Department
    {
        public Department()
        {
            //this.Lectures = new HashSet<Lecture>();
           //this.Academicians = new HashSet<Academician>();
          // this.Students = new HashSet<Student>();
        }


        [Key]
        [Required]
        [Column("DepartmentID", Order = 0, TypeName = "int")]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("DepartmentName", Order = 1)]
        public string DepartmentName { get; set; }

        [Required]
        [Column("SemesterCount", Order = 2, TypeName = "int")]
        public int SemesterCount { get; set; }

        [Required]
        [Column("InturnCount", Order = 3, TypeName = "int")]
        public int InturnCount { get; set; }

        [Required]
        [Column("FacultyID", Order = 4, TypeName = "int")]
        public int FacultyID { get; set; }


        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }


        public virtual ICollection<Academician> Academicians { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

