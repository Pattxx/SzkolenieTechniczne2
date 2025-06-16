using FluentValidation.Results;

namespace SzkolenieTechniczne2.Cinema.Domain.Command
{
    public class Result
    {
        private Result(bool isSuccess, string message, IEnumerable<Error> errors)
        {
            IsSuccess = isSuccess;
            IsFailure = !isSuccess;
            Message = message;
            Errors = errors ?? Enumerable.Empty<Error>();
        }

        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public string Message { get; }
        public IEnumerable<Error> Errors { get; }

        public class Error
        {
            public Error(string propertyName, string message)
            {
                PropertyName = propertyName;
                Message = message;
            }

            public string PropertyName { get; }
            public string Message { get; }
        }

        public static Result Ok()
         => new(true, string.Empty, Enumerable.Empty<Error>());

        public static Result Fail(string message)
            => new(false, message, Enumerable.Empty<Error>());

        public static Result Fail(ValidationResult validationResult)
        {
            var errors = validationResult.Errors
                .Select(x => new Error(x.PropertyName, x.ErrorMessage));

            var message = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));

            return new Result(false, message, errors);
        }

    }
}
