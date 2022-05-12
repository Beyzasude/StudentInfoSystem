using EntitiyLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Academician
{
    public class AcademicianResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string ImageName { get; set; }
        public List<AcademicianLecture> Lectures { get; set; }
    }
}
