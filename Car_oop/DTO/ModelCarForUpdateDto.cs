using Car_oop.Models;

namespace Car_oop.DTO
{
    public class ModelCarForUpdateDto
    {
        public string bodyType { get; init; }
        public string brand { get; init; }
        public string color { get; init; }
        public int count { get; init; }
        public string driveType { get; init; }
        public string firm { get; init; }
        public string fuelType { get; init; }
        public string model { get; init; }
        public double price { get; init; }
        public string transmissionType { get; init; }
        public int yearRealse { get; init; }

        //связь ModelCar --> Сar 1 к М
        public IEnumerable<CarCreationWithIdDto> cars {  get; init; }
    }
}
