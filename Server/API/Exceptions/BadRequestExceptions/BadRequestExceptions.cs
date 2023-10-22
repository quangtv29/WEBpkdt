namespace API.Exceptions.BadRequestExceptions
{
    public abstract class BadRequestExceptions : Exception
    {
        public BadRequestExceptions(string? message) : base(message)
        {

        }
    }
}
