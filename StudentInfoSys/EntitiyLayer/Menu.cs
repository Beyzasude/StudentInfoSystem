using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    public class Menu
    {
        [Required]
        [Key]
        [Column("Status", Order = 0, TypeName = "int")]
        public int Status { get; set; }

        [Required]
        [Column("Links", Order = 0, TypeName = "int")]
        public int Links { get; set; }

        [Required]
        [Column("ProcessName", Order = 0, TypeName = "int")]
        public int ProcessName { get; set; }

        [Required]
        [Column("ProcessName", Order = 0, TypeName = "int")]
        public int ProcessNam { get; set; }

    }
}
