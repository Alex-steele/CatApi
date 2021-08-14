using Cats.Logic.Wrappers.Enums;

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

        public Result Result { get; set; }

        public T Payload { get; set; }
    }
}
