namespace SR.Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message, int code) : this(success)
        {
            Message = message;
            Code = code;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
