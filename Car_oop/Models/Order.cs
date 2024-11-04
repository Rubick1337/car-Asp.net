using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_oop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime orderDate { get; set; }
        public double price { get; set; }
        public string status { get; set; }
        //Связь 1 к м Person --> Order
        public int PersonId { get; set; }

        public Person person { get; set; } = null!;
        // связь 1 к 1..0 Car --> Order
        public int? CarId { get; set; }
        public Car? car { get; set; } = null!; 
        // связь 1 к м  Client --> Order
        public int ClientId { get; set; }

        public Client client { get; set; } = null!;
        //связь 1 к 1 PayementMethod --> Order
        [ForeignKey("paymentMethod")]
        public int PaymentMetgodId { get; set; }
        public PaymentMethod paymentMethod { get; set; } = null!;

    }
}
