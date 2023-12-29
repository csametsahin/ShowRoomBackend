using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, int code) : base(data, true, code)
        {
        }

        public SuccessDataResult(T data, string message, int code) : base(data, true, message, code)
        {
        }

        public SuccessDataResult() : base(default,true,default,StatusCodes.Status200OK)
        {

        }
        public SuccessDataResult(string message, int code) : base(default, true, message, code)
        {

        }
        public SuccessDataResult(T data) : base(data, true, default, StatusCodes.Status200OK)
        {

        }
    }
}
