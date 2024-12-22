namespace Car_oop.DTO
{
    public record OrderDto (int Id, int CarId, int ClientId, int PaymentMetgodId, int PersonId, double price, string status, DateTime orderDate)
    {

    }
}
