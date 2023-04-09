﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Database.Concrete
{
    public class ClassroomDal : DalRepo<ClassRoom>, IClassroomDal
    {
        public static List<ClassRoom> list = Data.Classrooms;
        public ClassroomDal():base(list)
        {
            
        }

        public ClassRoomDetails GetDetails(int i)
        {
            var teacher = Data.teachers;
            var student = Data.students;
            var item = list.FirstOrDefault(x=>x.ClassId == i);
            if (item != default)
            {
                ClassRoomDetails details = new ClassRoomDetails
                {
                    ClassId = i,
                    Name = item.Name,
                    Students = student.Where(x=>x.ClassId==i).ToList(),
                    Teacher = teacher.FirstOrDefault(x => x.ClassId==i),
                };
                return details;   
            }
            return default;
        }

        public override void Update(ClassRoom item)
        {
            var data = list.FirstOrDefault(x=>x.ClassId==item.ClassId); 
            data.Name = item.Name;  
        }
    }
}
