using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Database.Concrete
{
    public class TeacherDal : DalRepo<Teacher>, ITeacherDal
    {
        public static List<Teacher> list;
        public TeacherDal(List<Teacher> _list):base(_list) 
        {
            list = _list;
        }

        public override void Update(Teacher item)
        {
            var data = list.FirstOrDefault(x=>x.Number==item.Number);
            data.FirstName = item.FirstName;
            data.LastName = item.LastName;
            data.ClassId = item.ClassId;
        }
    }
}
