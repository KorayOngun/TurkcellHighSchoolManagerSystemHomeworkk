using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Abstract;

namespace TurkcellHighSchoolManagerSystem.Database.Abstract
{
    public interface IDalRepo<T> 
    {
        void Add(T item);
        bool Delete(Func<T,bool> filter);
        void Update(T item);

        T Get(Func<T,bool> filter);

        List<T> GetAll();

        List<T> GetFilter(Func<T,bool> filter);

        bool ItemAny(Func<T,bool> filter);  
    }
}
