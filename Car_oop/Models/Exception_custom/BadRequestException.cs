namespace Car_oop.Models.Exception_custom
{
    public abstract class BadRequestException : Exception
    {

        protected BadRequestException(string message) : base(message) { }
    }

}
