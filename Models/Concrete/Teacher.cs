using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Entity;
using TurkcellHighSchoolManagerSystem.Models.Abstract;

namespace TurkcellHighSchoolManagerSystem.Models.Concrete
{
    public class Teacher : Person, IEntity
    {
        /// <param name="firstname">öğretmen adı</param>
        /// <param name="lastName">öğretmen soyadı</param>
        /// <param name="number">öğretmen numarası Primary Key</param>
        /// <param name="classId">sınıf id'si Foreign key ve Unique key</param>
        public Teacher(string firstname, string lastName, short number, int classId) : base(firstname, lastName, number, classId) { }
    }
}
