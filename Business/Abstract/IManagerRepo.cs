using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Abstract;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Manager.Abstract
{
    public interface IManagerRepo<T> where T : class, IEntity
    {
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll();  
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(int id);
    }
}
