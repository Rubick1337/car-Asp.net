using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDto> GetAllOrders(bool trackChanges);
        OrderDto GetOrder(int id, bool trackChanges);
    }
}
