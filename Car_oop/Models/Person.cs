using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Car_oop.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public int experience { get; set; }

        public string name { get; set; }
        public string surname { get; set; }

        public double payday { get; set; }
        //связь 1 к 1 Post --> Person
        public int PostId {  get; set; }
        public Post post { get; set; } = null!;
        // связь 1 к м Person --> Order
        public ICollection<Order> orders { get; set; }
    }
}
