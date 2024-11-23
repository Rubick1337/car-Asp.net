using Car_oop.Models;

namespace Car_oop.DTO
{
    public record PersonalForUpdateDto
    {
        public int experience { get; set; }

        public string name { get; set; }
        public string surname { get; set; }

        public double payday { get; set; }

    }
}
