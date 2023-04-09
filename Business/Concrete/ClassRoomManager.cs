using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurkcellHighSchoolManagerSystem.Business.Rules;
using TurkcellHighSchoolManagerSystem.Database;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Rules;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Classes;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Concrete
{
    public class ClassRoomManager : IClassManager
    {
        IClassroomDal classroomDal;

        int id;
        public ClassRoomManager(IClassroomDal _classRooms)
        {
            RulesDatabase.Classrooms = _classRooms;
            classroomDal = _classRooms;
            id = classroomDal.GetAll().Count + 1;
        }
        public IResult Add(ClassRoom entity)
        {
            if (ClassRoomRules.AddRules(entity))
            {
                entity.ClassId = id++;
                classroomDal.Add(entity);
                return new SuccessResult(Messages.AddClassSuccess);
            }
            return new ErrorResult(Messages.AddClassError);
        }
        public IResult Delete(int id)
        {
            if (ClassRoomRules.DeleteRules(id))
            {
                classroomDal.Delete(x=>x.ClassId==id);
                return new SuccessResult(Messages.ClassDeleteSuccess);
            }
            return new ErrorResult(Messages.ClassDeleteError);
        }
        public IDataResult<List<ClassRoom>> GetAll()
        {
            var data = classroomDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<ClassRoom>>(data);
            }
            return new ErrorDataResult<List<ClassRoom>>();
        }

        public IDataResult<ClassRoom> GetById(int id)
        {
            var item = classroomDal.Get(x=>x.ClassId==id);
            if (item != default) return new SuccessDataResult<ClassRoom>(item); return new ErrorDataResult<ClassRoom>();
        }

        public IResult Update(ClassRoom entity)
        {
            var data = GetById(entity.ClassId);
            if (data.IsSuccess && ClassRoomRules.AddRules(entity))
            {
                var item = data.Data;
                classroomDal.Update(item);
                return new SuccessResult(Messages.UpdateClassSuccess);
            }
            return new ErrorResult(Messages.UpdateClassError); 
        }

        public IDataResult<ClassRoomDetails> GetDetails(int i)
        {
             var data = classroomDal.GetDetails(i);
            if (data != default)
            {
                return new SuccessDataResult<ClassRoomDetails>(data);
            }
            return new ErrorDataResult<ClassRoomDetails>();
        }

    }
}
