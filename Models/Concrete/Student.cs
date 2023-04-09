using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Entity;
using TurkcellHighSchoolManagerSystem.Models.Abstract;

namespace TurkcellHighSchoolManagerSystem.Models.Concrete
{
    public class Student : Person, IEntity
    {
        /// <summary>
        /// öğrenci sınıfı 'sınıf' tablosunda olmak zorunda 
        /// </summary>
        /// <param name="firstname">öğrenci adı string </param>
        /// <param name="lastName">öğrenci soyadı string</param>
        /// <param name="number">öğrenci numarası primary key </param>
        /// <param name="classId">sınıf id Foreing key</param>
        public Student(string firstname, string lastName, short number, int classId) : base(firstname, lastName, number, classId) { }
        public bool Homework { get; set; } = false;
    }
}
