namespace SR.Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string message, int code) : base(true, message, code)
        {
        }
    }
}
