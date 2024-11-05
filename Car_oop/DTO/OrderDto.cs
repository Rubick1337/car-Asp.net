namespace Car_oop.DTO
{
    public record OrderDto (int id, int CarId, int ClientId, int MethodId, int PersonalId,double price, string status, DateTime orderTime)
    {

    }
}
