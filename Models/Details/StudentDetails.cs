using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Models.Details
{
    public class StudentDetails
    {
        public string Name { get; set; }    
        public string lastName { get; set; }

        public int Number { get; set; }   
        public int  ClassId { get; set; }
        public ClassRoom? ClassRoom { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
