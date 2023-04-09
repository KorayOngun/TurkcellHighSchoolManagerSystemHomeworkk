using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Abstract
{
    public interface IStudentManager : IManagerRepo<Student>
    {
        IResult DoHomework(int number);
        IResult AddHomework(int classId);
        IDataResult<List<StudentDetails>> StudentDetailsSearch(string data);
        IDataResult<List<StudentDetails>> StudentDetailsSearch(int data);
    }
}
