using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Faculty")]
    public class Faculty
    {
        public Faculty()
        {
            this.Departments = new HashSet<Department>();
        }

        [Key]
        [Required]
        [Column("FacultyID", Order = 0, TypeName = "int")]
        public int FacultyID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("FacultyName", Order = 1)]
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
