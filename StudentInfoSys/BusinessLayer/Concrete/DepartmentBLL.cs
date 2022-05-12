using DataAccessLayer.Concrete;
using ModelLayer.Academician;
using ModelLayer.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DepartmentBLL
    {
        public List<DepartmentResult> GetList()
        {
            Context context = new Context();

            List<DepartmentResult> DepartmentList = context.Departments.OrderBy(o => o.DepartmentName).Select(s => new DepartmentResult()
            {
                DepartmentID=s.DepartmentID,
                DepartmentName = s.DepartmentName

            }).ToList();

            return DepartmentList;
        }
    }
}
