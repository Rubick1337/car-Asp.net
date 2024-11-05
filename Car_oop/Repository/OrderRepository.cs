using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;

namespace Car_oop.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<OrderDto> GetAllOrders(bool trackChanges)
        {
            var orders = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var ordersDto = orders.Select(x => new OrderDto(x.Id,x.CarId,x.ClientId,x.PaymentMetgodId,x.PersonId,x.price,x.status,x.orderDate)).ToList();
            return ordersDto;
        }

        public OrderDto GetOrder(int id, bool trackChanges)
        {
            var orders = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var ordersDto = new OrderDto(orders.Id, orders.CarId, orders.ClientId, orders.PaymentMetgodId, orders.PersonId, orders.price, orders.status, orders.orderDate);
            return ordersDto;
        }
    }
}
