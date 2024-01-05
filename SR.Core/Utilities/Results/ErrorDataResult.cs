using Microsoft.AspNetCore.Http;

namespace SR.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message, int code) : base(data, false, message, code)
        {
        }

        public ErrorDataResult(T data, int code) : base(data, false, default, code)
        {
        }

        public ErrorDataResult(string message, int code) : base(default, false, message, code)
        {

        }

        public ErrorDataResult() : base(default, false, StatusCodes.Status500InternalServerError)
        {

        }
        public ErrorDataResult(T data) : base(data, false, default, StatusCodes.Status500InternalServerError)
        {
        }
    }
}
