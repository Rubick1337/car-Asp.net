namespace Car_oop.Models.Exception_custom
{
    public class IdBadRequestException : BadRequestException
    {
        public IdBadRequestException() : base("The provided ID is invalid or null.") { }

        public IdBadRequestException(string message) : base(message) { }

    }

}
