using DataAccessLayer.Concrete;
using ModelLayer.Inturn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class InturnBLL
    {
        public List<InturnResult> GetInturn(int id)
        {
            Context context = new Context();

            //böyle yaparsan id si 10 olan öğrenci için getirir.

            List<InturnResult> inturns = context.Inturns.Where(s => s.StudentID == id)
                .Select(s => new InturnResult
                {
                    InturnID = s.InturnID,
                    InturnName = s.InturnName,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    TotalTime = s.TotatlTime,
                    Status = s.Status,

                }).ToList();
            return inturns;
        }
    }
}
