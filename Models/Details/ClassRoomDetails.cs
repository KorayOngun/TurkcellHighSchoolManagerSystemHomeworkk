using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Models.Concrete;

namespace TurkcellHighSchoolManagerSystem.Models.Details
{
    public class ClassRoomDetails
    {

        public int ClassId { get; set; }
        public string Name { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student>? Students { get; set; }
    }
}
