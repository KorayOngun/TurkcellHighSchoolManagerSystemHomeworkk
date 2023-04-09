using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Database.Abstract;
using TurkcellHighSchoolManagerSystem.Models.Abstract;

namespace TurkcellHighSchoolManagerSystem.Database.Concrete
{
    public abstract class DalRepo<T> : IDalRepo<T> where T : class,IEntity
    {
        List<T> list;
        public DalRepo(List<T> _list)
        {
            list = _list;
        }
        public void Add(T item)
        {
            list.Add(item);
        }

        public  bool Delete(Func<T, bool> filter)
        {
            var item = list.FirstOrDefault(filter);
            return list.Remove(item);
            
        }

        public T Get(Func<T, bool> filter)
        {
            return list.FirstOrDefault(filter);
        }

        public List<T> GetAll()
        {
            return list;
        }

        public List<T> GetFilter(Func<T, bool> filter)
        {
            return list.Where(filter).ToList();
        }

        public bool ItemAny(Func<T, bool> filter)
        {
            return list.Any(filter);    
        }

        public abstract void Update(T item);
    }
}
