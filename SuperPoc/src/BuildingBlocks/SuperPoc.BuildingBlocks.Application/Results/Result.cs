namespace SuperPoc.BuildingBlocks.Application.Results
{
    public class Result
    {
        public bool Success { get; set; }
        public Error Error { get; set; }

        public Result(bool isSuccess, Error error)
        {
            Success = isSuccess;
            Error = error;
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new(value,true,Error.None);
        public static Result<T> Failure(Error error) => new(default!, false, Error.None);
    }
}
