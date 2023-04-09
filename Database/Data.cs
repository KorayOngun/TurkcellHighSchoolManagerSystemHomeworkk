using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Database
{
    public static class Data
    {
        public static List<ClassRoom> Classrooms = new();
        public static List<Teacher> teachers = new();
        public static List<Student> students = new();

        public static void DemoDataAdd()
        {
            ClassRoom classRoom = new("11-A")
            {
                ClassId = 1
            };
            Classrooms.Add(classRoom);
            ClassRoom classRoom1 = new("12-A")
            {
                ClassId = 2
            };
            Classrooms.Add(classRoom1);
            Teacher teacher = new("ilber", "ortaylı", 1965, 1);
            teachers.Add(teacher);
            Teacher teacher1 = new("mukaddes", "gültekin", 342, 2);
            teachers.Add(teacher1);

            Student s1 = new("ali", "yılmaz", 32, 1);
            Student s2 = new("oya", "yılmaz", 53, 1);
            Student s3 = new("ersin", "destanoğlu", 65, 1);
            Student s4 = new("mine", "tugay", 34, 1);
            students.Add(s1); students.Add(s2); students.Add(s3); students.Add(s4);

            Student s5 = new("yılmaz", "ali", 432, 2);
            Student s6 = new("yılmaz", "oya", 123, 2);
            Student s7 = new("cenk", "tosun", 3245, 2);
            Student s8 = new("sergen", "yalçın", 7, 2);
            students.Add(s5); students.Add(s6); students.Add(s7); students.Add(s8);

        }
    }
}
