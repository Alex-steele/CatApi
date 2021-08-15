using Cats.Logic.Wrappers.Enums;
using FluentValidation.Results;

namespace Cats.Logic.Wrappers
{
    public class ResultWrapper<T>
    {
        private ResultWrapper(Result result)
        {
            Result = result;
        }

        private ResultWrapper(T payload)
        {
            Payload = payload;
            Result = Result.Success;
        }

        private ResultWrapper(ValidationResult validation)
        {
            Validation = validation;
            Result = Result.ValidationError;
        }

        /// <summary>
        /// Create a new ResultWrapper as success
        /// </summary>
        /// <param name="payload">Payload of query</param>
        /// <returns></returns>
        public static ResultWrapper<T> Success(T payload) => new ResultWrapper<T>(payload);

        /// <summary>
        /// Create a new ResultWrapper as NotFound
        /// </summary>
        public static ResultWrapper<T> NotFound => new ResultWrapper<T>(Result.NotFound);

        /// <summary>
        /// Create a new ResultWrapper as ValidationError
        /// </summary>
        /// <param name="validation">Validation result containing validation errors</param>
        /// <returns></returns>
        public static ResultWrapper<T> ValidationError(ValidationResult validation) => new ResultWrapper<T>(validation);

        public Result Result { get; }
        public T Payload { get; }
        public ValidationResult Validation { get; }
    }
}
