using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;

namespace TurkcellHighSchoolManagerSystem.Database.Abstract
{
    public interface IStudentDal : IDalRepo<Student>
    {
        List<StudentDetails> studentDetails(Func<Student, bool> filter);
    }
}
