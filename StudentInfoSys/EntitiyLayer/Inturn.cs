using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Inturn")]
    public class Inturn
    {
        [Key]
        [Required]
        [Column("InturnID", Order = 0, TypeName = "int")]
        public int InturnID { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("InturnName", Order = 1)]
        
        public string InturnName { get; set; }

        [Required]
        [Column("TotatlTime", Order = 2, TypeName = "int")]
        public int TotatlTime { get; set; }

        [Required]
        [Column("StartTime", Order = 3)]
        public DateTime StartTime { get; set; }

        [Required]
        [Column("EndTime", Order = 4)]
        public DateTime EndTime { get; set; }

        [Required]
        [Column("Status", Order = 5, TypeName = "int")]
        public int Status { get; set; }

        [Required]
        [Column("StudentID", Order = 6, TypeName = "int")]
        public int StudentID { get; set; }

       [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}
