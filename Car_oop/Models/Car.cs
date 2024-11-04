using System.ComponentModel.DataAnnotations;
namespace Car_oop.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
  
 
        //связь ModelCar --> Сar 1 к 1
        public int ModelCarId { get; set; }
        public ModelCar modelCar { get; set; } = null!;

        //связь 1 к 1 Car --> Order
        public Order order { get; set; }



    }
}
