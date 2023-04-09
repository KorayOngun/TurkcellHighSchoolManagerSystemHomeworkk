using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellHighSchoolManagerSystem.Results.Classes
{
    public class ErrorDataResult<T> : DataResult<T>
    {
    
        #pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
        public ErrorDataResult(string message) : base(false,default,message)
        {

        }
        public ErrorDataResult(): base(false, default)
        {
            
        }
    }
}
