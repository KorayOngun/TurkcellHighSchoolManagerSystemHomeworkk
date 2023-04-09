using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Business.Rules;
using TurkcellHighSchoolManagerSystem.Manager.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Manager.Rules
{
    public static class ClassRoomRules
    {

        public static bool AddRules(ClassRoom entity)
        {
            bool nameControl = !RulesDatabase.Classrooms.ItemAny(x => x.Name == entity.Name);
            bool lengthControl = entity.Name.Length > 2 && entity.Name.Length < 10;
            return nameControl && lengthControl;
        }
        public static bool DeleteRules(int id)
        {
            bool studentControl = !RulesDatabase.students.ItemAny(x => x.ClassId == id);
            bool teachrControl = !RulesDatabase.teachers.ItemAny(x => x.ClassId == id);
            bool classControl = RulesDatabase.Classrooms.ItemAny(x => x.ClassId == id);
            return classControl && teachrControl && studentControl;
        }
    }
}
