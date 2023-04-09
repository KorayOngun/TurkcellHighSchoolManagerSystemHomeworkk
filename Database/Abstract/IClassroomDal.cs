using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Database.Abstract
{
    public interface IClassroomDal : IDalRepo<ClassRoom>
    {
        ClassRoomDetails GetDetails(int i);
    }
}
