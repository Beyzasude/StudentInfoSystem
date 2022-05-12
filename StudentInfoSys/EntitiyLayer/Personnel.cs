using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer
{
    [Table("Personnel")]
    public class Personnel
    {
        [Required]
        [Key]
        [Column("PersonnelID", Order = 0, TypeName = "int")]
        public int PersonnelID { get; set; }

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

        [Required]
        [Column("ImagName", Order = 6)]
        public string ImageName { get; set; }
    }
}
