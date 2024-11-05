using Car_oop.Contracts;
using Car_oop.DTO;
using Car_oop.Interface;
using Car_oop.Models;

namespace Car_oop.Repository
{
    public class PaymentMethodRepository : RepositoryBase<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(RepositoryContext context) : base(context)
        {
        }
        public IEnumerable<PaymentMethodDto> GetAllPayments(bool trackChanges)
        {
            var payments = FindAll(trackChanges).OrderBy(x => x.Id).ToList();
            var paymentsDto = payments.Select(x => new PaymentMethodDto(x.Id, x.paymentMethod)).ToList();
            return paymentsDto;
        }

        public PaymentMethodDto GetPayment(int id, bool trackChanges)
        {
            var payments = FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();

            var paymentsDto = new PaymentMethodDto(payments.Id, payments.paymentMethod);
            return paymentsDto;
        }
    }
}
