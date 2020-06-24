using System;

namespace BaseApplication.Domain
{
    public class CommandResult<T>
    {
        public T Result { get; set; }
        public Exception Exception { get; }
        public bool IsSuccess { get; }
        
        public CommandResult(T result)
        {
            IsSuccess = true;
            Exception = null;
            Result = result;
        }

        public CommandResult(Exception exception)
        {
            Exception = exception;
            IsSuccess = false;
            Result = default;
        }
    }
}