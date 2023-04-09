using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Abstract;

namespace TurkcellHighSchoolManagerSystem.Entity
{
    public abstract class Person
    {
        public Person(string firstname,string lastName,short number,int classId)
        {
            FirstName = firstname;
            LastName = lastName;
            Number = number;
            ClassId = classId;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public int ClassId { get; set; } 
        
    }
}
