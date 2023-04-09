using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Business.Rules;
using TurkcellHighSchoolManagerSystem.Models.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Manager.Rules
{
    public static class TeacherRules
    {        
        private static bool IsTeacherInClasses(int classId) => RulesDatabase.teachers.ItemAny(x => x.ClassId == classId);
        private static bool IsTeacherInTeachers(int number) => RulesDatabase.teachers.ItemAny(t => t.Number == number);
        private static bool RoomListAny(int classId) => RulesDatabase.Classrooms.ItemAny(x => x.ClassId == classId);
        private static Teacher? TeacherCheck(int number) => RulesDatabase.teachers.Get(x => x.Number == number);
        public static bool AddRules(Teacher teacher)
        {
            bool checkRoom = RoomListAny(teacher.ClassId);
            bool isTeacherInClasses = !IsTeacherInClasses(teacher.ClassId);
            bool isTeacherInTeachers = !IsTeacherInTeachers(teacher.Number);
            return checkRoom && isTeacherInClasses && isTeacherInTeachers;
        }
        public static bool UpdateRules(Teacher teacher)
        {
            var item = TeacherCheck(teacher.Number);
            if (item != default)
            {
                bool checkClassRoom = RoomListAny(item.ClassId);
                bool isThereTeacherInClass = !IsTeacherInClasses(item.ClassId);
                return item != default && checkClassRoom && isThereTeacherInClass;
            }
            return false;
        }

    }
}
