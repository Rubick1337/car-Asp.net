using Car_oop.Models;

namespace Car_oop.DTO
{
    public class ModelCarForUpdateDto
    {
        public string? bodyType { get; set; }
        public string? brand { get; set; }
        public string? color { get; set; }
        public int? count { get; set; } 
        public string? driveType { get; set; }
        public string?  firm { get; set; }
        public string? fuelType { get; set; }
        public string? model { get; set; }
        public double? price { get; set; }
        public string? transmissionType { get; set; }
        public int? yearRealse { get; set; } 

        //связь ModelCar --> Сar 1 к М
        public IEnumerable<CarCreationWithIdDto> cars {  get; init; }
    }
}
