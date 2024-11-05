using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethodDto> GetAllPayments(bool trackChanges);
        PaymentMethodDto GetPayment(int id, bool trackChanges);
    }
}
