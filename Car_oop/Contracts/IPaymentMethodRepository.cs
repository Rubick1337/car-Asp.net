using Car_oop.DTO;

namespace Car_oop.Interface
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethodDto> GetAllPayments(bool trackChanges);
        PaymentMethodDto GetPayment(int id, bool trackChanges);

        PaymentMethodDto CreateMethod(PaymentMethodForCreationDto method);
        void DeleteMethod(int Id, bool trackChanges);
        void UpdateMethod(int id, bool trackChanges, PaymentForUpdateDto updateMethod);
    }
}
