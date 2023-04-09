using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellHighSchoolManagerSystem.Results.Interfaces;

namespace TurkcellHighSchoolManagerSystem.Results.Classes
{
    public class Result : IResult
    {
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(bool ısSuccess, string messages) : this(ısSuccess)
        {
            Message = messages;
        }

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
