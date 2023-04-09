using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Abstract;

namespace TurkcellHighSchoolManagerSystem.Models.Concrete
{
    public class ClassRoom : IEntity
    {

        /// <param name="name">sınıf adı</param>
        public ClassRoom(string name)
        {
            Name = name;
        }
        public int ClassId { get; set; }
        public string Name { get; set; }
    }
}
