using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;

namespace TurkcellHighSchoolManagerSystem.Database.Concrete
{
    public class StudentDal : DalRepo<Student>, IStudentDal
    {
        public static List<Student> list = Data.students;
        public StudentDal():base(list)
        {
            
        }
  

        public List<StudentDetails> studentDetails(Func<Student, bool> filter)
        {
            var teacherList = Data.teachers;
            var classList = Data.Classrooms;
            var data = list.Where(filter)
                                 .Select(p =>

                                     new StudentDetails
                                     {
                                        Name = p.FirstName,
                                        lastName = p.LastName,
                                        Number = p.Number,  
                                        ClassId = p.ClassId,
                                        ClassRoom = classList.FirstOrDefault(x => x.ClassId == p.ClassId),
                                        Teacher = teacherList.FirstOrDefault(x => x.ClassId == p.ClassId),
                                     }
                                 ).ToList();
            return data;
        }

        public override void Update(Student student)
        {
            var item = list.FirstOrDefault(x => x.Number == student.Number);
            item.FirstName = student.FirstName;
            item.LastName = student.LastName;
            item.ClassId = student.ClassId;
        }
    }
}
