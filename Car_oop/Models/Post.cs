using System.ComponentModel.DataAnnotations;

namespace Car_oop.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string namePost { get; set; }
        //связь 1 к 1 Post --> Person
        public Person person { get; set; } = null!;
    }
}
