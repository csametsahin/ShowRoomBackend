namespace SR.Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message, int code) : base(success, message, code)
        {
            Data = data;
        }
        public DataResult(T data, bool success, int code) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
