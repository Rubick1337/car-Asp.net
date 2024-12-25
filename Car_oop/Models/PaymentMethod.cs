using System.ComponentModel.DataAnnotations;

namespace Car_oop.Models
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string paymentMethod { get; set; }
        // связь 1 к м PaymentMethod --> Order
        public ICollection<Order> orders { get; set; }
    }
}
