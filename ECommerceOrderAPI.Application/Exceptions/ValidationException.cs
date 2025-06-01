using FluentValidation.Results;

namespace Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; }

        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new List<ValidationFailure>();
        }

        public ValidationException(List<ValidationFailure> errors)
            : this()
        {
            Errors = errors;
        }

        public ValidationException(string? message)
            : base(message)
        {
            Errors = new List<ValidationFailure>();
        }

        public ValidationException(string? message, Exception? innerException)
            : base(message, innerException)
        {
            Errors = new List<ValidationFailure>();
        }
        public IEnumerable<string> ErrorMessages => Errors.Select(e => e.ErrorMessage);
    }
}