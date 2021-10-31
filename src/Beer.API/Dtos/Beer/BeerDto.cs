using Beer.API.Enums;

namespace Beer.API.Dtos.Beer
{
    public class BeerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public BeerType Type { get; set; }
        public double AverageRate { get; set; }
    }
}