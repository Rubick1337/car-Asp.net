using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDto> GetAllOrders(bool trackChanges);
        OrderDto GetOrder(int id, bool trackChanges);

        OrderDto CreateOrder(OrderForCreationDto order, int PersonalId,int ClinetId,int CarId,int MethodId, bool trackChanges);
        void DeleteOrder(int Id, bool trackChanges);
        void UpdateOrder(int Id, OrderForUpdateDto order, int? ClientId, int? PersonalId, int? PaymentMethodId, int? CarId, bool trackChanges);
    }
}
