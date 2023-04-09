using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Abstract
{
    public interface IClassManager : IManagerRepo<ClassRoom>
    {
        IDataResult<ClassRoomDetails> GetDetails(int i);
    }
}
