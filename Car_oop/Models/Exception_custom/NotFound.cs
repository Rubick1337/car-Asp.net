namespace Car_oop.Models.Exception_custom
{
    public class NotFound : Exception
    {
        public NotFound() : base("This Id not found") { }

        public NotFound(string message) : base(message) { }
    }
}
