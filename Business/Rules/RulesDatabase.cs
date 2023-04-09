using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Business.Rules
{
    public static class RulesDatabase
    {
        public static IClassroomDal Classrooms;
        public static IStudentDal students;
        public static ITeacherDal teachers;
    }
}
