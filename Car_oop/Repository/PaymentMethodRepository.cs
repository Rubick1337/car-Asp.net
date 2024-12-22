using AutoMapper;
using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;
using Car_oop.Models.Exception_custom;
using Microsoft.EntityFrameworkCore;
namespace Car_oop.Repository
{
    public class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        private readonly IMapper _mapper;
        public PaymentMethodRepository(RepositoryContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public IEnumerable<PaymentMethodDto> GetAllPayments(bool trackChanges)
        {
            var payments = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            //var paymentsDto = payments.Select(x => new PaymentMethodDto(x.Id, x.paymentMethod)).ToList();
            var paymentsDto = _mapper.Map<IEnumerable <PaymentMethodDto>>(payments);  
            return paymentsDto;
        }

        public PaymentMethodDto GetPayment(int id, bool trackChanges)
        {
            var payments = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
            if(payments == null)
            {
                throw new NotFound();
            }
            //var paymentsDto = new PaymentMethodDto(payments.Id, payments.paymentMethod);
            var paymentsDto = _mapper.Map<PaymentMethodDto>(payments);
            return paymentsDto;
        }
        public PaymentMethodDto CreateMethod(PaymentMethodForCreationDto method)
        {
            var paymentEntity = _mapper.Map<PaymentMethod>(method);
            Create(paymentEntity);
            var paymentReturn = _mapper.Map<PaymentMethodDto>(paymentEntity);
            return paymentReturn;
        }
        public void DeleteMethod(int Id, bool trackChanges)
        {
            var methodCheck = _context.Set<PaymentMethod>()
                .Where(x => x.Id.Equals(Id))
                .AsNoTracking()
                .FirstOrDefault();
            if (methodCheck == null)
            {
                throw new NotFound();
            }

            Delete(methodCheck);
            _context.SaveChanges();
        }
        public void UpdateMethod(int id, bool trackChanges, PaymentForUpdateDto updateMethod)
        {
            var methodEntity = FindByCondition(cl => cl.Id.Equals(id), trackChanges)
                .SingleOrDefault();

            if (methodEntity == null)
            {
                throw new NotFound();
            }

            _mapper.Map(updateMethod, methodEntity);

            _context.SaveChanges();
        }
    }
}
