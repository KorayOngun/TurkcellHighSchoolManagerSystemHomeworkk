using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Abstract
{
    public interface ITeacherManager : IManagerRepo<Teacher>
    {
        IResult ReplaceTeacher(int id1, int id2);

    }
}
