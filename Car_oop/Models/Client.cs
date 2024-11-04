using System.ComponentModel.DataAnnotations;
namespace Car_oop.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string clientPhone { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string passport { get; set; }
        public string surname { get; set; }

        //связь 1 к м Client --> Order
        public ICollection<Order> orders { get; set; }
    }
}
