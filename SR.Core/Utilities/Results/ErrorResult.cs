namespace SR.Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, int code) : base(false, message, code)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}
