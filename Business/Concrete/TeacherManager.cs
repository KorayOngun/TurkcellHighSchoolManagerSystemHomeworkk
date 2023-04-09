using TurkcellHighSchoolManagerSystem.Business.Rules;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Rules;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Results.Classes;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Concrete
{
    public class TeacherManager : ITeacherManager
    {
        ITeacherDal teacherDal;
        public TeacherManager(ITeacherDal _teachers)
        {
            RulesDatabase.teachers = _teachers;
            teacherDal = _teachers;
        }

        public IDataResult<Teacher> GetById(int number)
        {
            var item = teacherDal.Get(x => x.Number == number);
            if (item != default) return new SuccessDataResult<Teacher>(item); return new ErrorDataResult<Teacher>();
        }

        public IDataResult<List<Teacher>> GetAll()
        {
            var data = teacherDal.GetAll();
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<Teacher>>(data);
            }
            return new ErrorDataResult<List<Teacher>>();
        }
        public IResult Add(Teacher teacher)
        {
            if (TeacherRules.AddRules(teacher))
            {
                teacherDal.Add(teacher);
                return new SuccessResult(Messages.AddTeacherSuccess);
            }
            return new ErrorResult(Messages.AddTeacherError);
        }

        public IResult Update(Teacher entity)
        {
            if (TeacherRules.UpdateRules(entity))
            {
                var item = GetById(entity.Number).Data;
                teacherDal.Update(item);
                return new SuccessResult(Messages.UpdateTeacherSuccess);
            }
            return new ErrorResult(Messages.UpdateTeacherError);
        }

        public IResult Delete(int id)
        {
            var item = GetById(id).Data;
            if (item != default)
            {
                teacherDal.Delete(x=>x.Number==id);
                return new SuccessResult(Messages.TeacherDeleteSuccess);
            }
            return new ErrorResult(Messages.TeacherDeleteError);
        }
        public IResult ReplaceTeacher(int id1, int id2)
        {
            var teacher1 = GetById(id1).Data;
            var teacher2 = GetById(id2).Data;
            if (teacher1 != default && teacher2 != default)
            {
                (teacher2.ClassId, teacher1.ClassId) = (teacher1.ClassId, teacher2.ClassId);
                return new SuccessResult(Messages.ReplaceTeacherSuccess);
            }
            return new ErrorResult(Messages.ReplaceTeacherError);
        }

    }
}
