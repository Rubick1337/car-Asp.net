namespace Car_oop.Models.Exception_custom
{
    public class IdMisMatchRequest : BadRequestException
    {
        public IdMisMatchRequest() : base("Collection count mismatch compared to ids") { }

        public IdMisMatchRequest(string message) : base(message) { }

    }
}
