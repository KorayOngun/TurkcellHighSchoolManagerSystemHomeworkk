using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Business.Rules;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Manager.Rules
{
    public static class StudentRules
    {
 
        public static bool GetClass(int classId) => RulesDatabase.Classrooms.ItemAny(x => x.ClassId == classId);
        public static bool AddRules(Student student)
        {
            bool checkStudent = !RulesDatabase.students.ItemAny(x => x.Number == student.Number);
            bool checkClass = GetClass(student.ClassId);
            return checkStudent && checkClass;
        }

    }
}
