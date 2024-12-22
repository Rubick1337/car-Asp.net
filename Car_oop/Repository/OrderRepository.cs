using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Microsoft.EntityFrameworkCore;
namespace Car_oop.Repository
{

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly IMapper _mapper;
        public OrderRepository(RepositoryContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<OrderDto> GetAllOrders(bool trackChanges)
        {
            var orders = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            //var ordersDto = orders.Select(x => new OrderDto(x.Id,x.CarId,x.ClientId,x.PaymentMetgodId,x.PersonId,x.price,x.status,x.orderDate)).ToList();
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public OrderDto GetOrder(int id, bool trackChanges)
        {
            var orders = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
            if(orders == null)
            {
                throw new NotFound();
            }
            //var ordersDto = new OrderDto(orders.Id, orders.CarId, orders.ClientId, orders.PaymentMetgodId, orders.PersonId, orders.price, orders.status, orders.orderDate);
            var ordersDto = _mapper.Map<OrderDto>(orders);
            return ordersDto;
        }
        public OrderDto CreateOrder(OrderForCreationDto order, int PersonalId, int ClientId, int CarId, int MethodId, bool trackChanges)
        {
            var personalEntity = _context.Set<Person>()
                .Where(x => x.Id == PersonalId)
                .AsTracking()
                .SingleOrDefault();
            if (personalEntity == null)
            {
                throw new NotFound();
            }

            var clientEntity = _context.Set<Client>()
                .Where(x => x.Id == ClientId)
                .AsTracking()
                .SingleOrDefault();
            if (clientEntity == null)
            {
                throw new NotFound();
            }

            var carEntity = _context.Set<Car>()
                .Where(x => x.Id == CarId)
                .AsTracking()
                .SingleOrDefault();
            if (carEntity == null)
            {
                throw new NotFound();
            }

            var paymentMethodEntity = _context.Set<PaymentMethod>()
                .Where(x => x.Id == MethodId)
                .AsTracking()
                .SingleOrDefault();
            if (paymentMethodEntity == null)
            {
                throw new NotFound();
            }

            var orderEntity = _mapper.Map<Order>(order);
            orderEntity.PersonId = PersonalId;
            orderEntity.ClientId = ClientId;
            orderEntity.CarId = CarId;
            orderEntity.PaymentMetgodId = MethodId;

            Create(orderEntity);

            var orderReturn = _mapper.Map<OrderDto>(orderEntity);
            return orderReturn;
        }
        public void DeleteOrder(int Id, bool trackChanges)
        {
            var orderCheck = _context.Set<Order>()
                .Where(x => x.Id.Equals(Id))
                .AsNoTracking()
                .FirstOrDefault();
            if (orderCheck == null)
            {
                throw new NotFound();
            }

            Delete(orderCheck);
            _context.SaveChanges();
        }
        public void UpdateOrder(int Id, OrderForUpdateDto order, int? ClientId, int? PersonalId, int? PaymentMethodId, int? CarId, bool trackChanges)
        {
            var orderCheck = FindByCondition(x => x.Id.Equals(Id), trackChanges).SingleOrDefault();
            if (orderCheck == null)
            {
                throw new NotFound($"Order with ID {Id} not found.");
            }

            if (ClientId.HasValue)
            {
                var clientCheck = FindByCondition(x => x.Id.Equals(ClientId.Value), trackChanges).SingleOrDefault();
                if (clientCheck == null)
                {
                    throw new NotFound($"Client with ID {ClientId.Value} not found.");
                }
                orderCheck.ClientId = ClientId.Value;
            }

            if (PersonalId.HasValue)
            {
                var personCheck = FindByCondition(x => x.Id.Equals(PersonalId.Value), trackChanges).SingleOrDefault();
                if (personCheck == null)
                {
                    throw new NotFound($"Person with ID {PersonalId.Value} not found.");
                }
                orderCheck.PersonId = PersonalId.Value;
            }

            if (PaymentMethodId.HasValue)
            {
                var paymentMethodCheck = FindByCondition(x => x.Id.Equals(PaymentMethodId.Value), trackChanges).SingleOrDefault();
                if (paymentMethodCheck == null)
                {
                    throw new NotFound($"Payment Method with ID {PaymentMethodId.Value} not found.");
                }
                orderCheck.PaymentMetgodId = PaymentMethodId.Value;
            }

            if (CarId.HasValue)
            {
                var carCheck = FindByCondition(x => x.Id.Equals(CarId.Value), trackChanges).SingleOrDefault();
                if (carCheck == null)
                {
                    throw new NotFound($"Car with ID {CarId.Value} not found.");
                }
                orderCheck.CarId = CarId.Value;
            }

            _mapper.Map(order, orderCheck);

            _context.SaveChanges();
        }


    }
}
