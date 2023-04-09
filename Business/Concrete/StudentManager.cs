using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Business.Rules;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Abstract;
using TurkcellHighSchoolManagerSystem.Manager.Rules;
using TurkcellHighSchoolManagerSystem.Models.Concrete;
using TurkcellHighSchoolManagerSystem.Models.Details;
using TurkcellHighSchoolManagerSystem.Results.Classes;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Concrete
{
    public class StudentManager : IStudentManager
    {
        IStudentDal studentDal;

        public StudentManager(IStudentDal _students)
        {
            RulesDatabase.students = _students;
            studentDal = _students;
        }

        public IDataResult<Student> GetById(int id)
        {
            var item = studentDal.Get(x=>x.Number==id);
            if (item != default) return new SuccessDataResult<Student>(item); return new ErrorDataResult<Student>();
        }

        public IDataResult<List<Student>> GetAll()
        {
            var data = studentDal.GetAll();
            if (data.Count>0)
            {
                return new SuccessDataResult<List<Student>>(data);
            }
            return new ErrorDataResult<List<Student>>();
        }

        public IResult Add(Student student)
        {
            if (StudentRules.AddRules(student))
            {
                studentDal.Add(student);
                return new SuccessResult(Messages.AddStudentSuccess);
            }
            return new ErrorResult(Messages.AddStudentError);
        }

        public IResult Update(Student entity)
        {
            var item = GetById(entity.Number);
            if (item.IsSuccess)
            {
                studentDal.Update(entity);
                return new SuccessResult(Messages.UpdateStudentSuccess);
            }
            return new ErrorResult(Messages.UpdateStudentError);
        }

        public IResult Delete(int id)
        {
            bool result = studentDal.Delete(x=>x.Number==id);
            return new Result(result);
        }

        public IResult AddHomework(int classId)
        {
            var data = studentDal.GetFilter(x => x.ClassId == classId);
            int c = 0;
            foreach (var item in data)
            {
                item.Homework = true;
                c++;
            }
            return new SuccessResult(Messages.AddHomeworkSuccess.Insert(0,c.ToString()));
        }

        public IResult DoHomework(int number)
        {
            var item = GetById(number).Data;
            bool condition = item != default ? item.Homework : false;
            if (condition)
            {
                GetById(number).Data.Homework = false;
                return new SuccessResult(Messages.StudentHomeworkSuccess);
            }
            return new ErrorResult(Messages.StudentHomeworkError);
        }


        /// <param name="data">isim veya numara giriniz</param>
        /// <returns></returns>
        public IDataResult<List<StudentDetails>> StudentDetailsSearch(string data)
        {
            return StudentDetailsSearch(x => data.Contains(x.FirstName) || data.Contains(x.LastName));
        }

 
        public IDataResult<List<StudentDetails>> StudentDetailsSearch(int data)
        {
            return StudentDetailsSearch(x=>x.Number == data);
        }
        private IDataResult<List<StudentDetails>> StudentDetailsSearch(Func<Student, bool> filter)
        {
            var data = studentDal.studentDetails(filter);
            if (data.Count > 0)
            {
                return new SuccessDataResult<List<StudentDetails>>(data);
            }
            return new ErrorDataResult<List<StudentDetails>>();
        }
    }
}
