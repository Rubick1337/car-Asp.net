namespace Car_oop.Models.Exception_custom
{
    public class ClientCollectionBadRequestExcaption : BadRequestException
    {
        public ClientCollectionBadRequestExcaption() : base("Collection client is null") { }
    }
}
