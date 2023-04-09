using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Database.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Database.Abstract
{
    public interface ITeacherDal : IDalRepo<Teacher>
    {
        
    }
}
