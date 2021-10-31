using Beer.API.Enums;

namespace Beer.API.Dtos.Beer
{
    public class CreateBeerDto
    {
        public string Name { get; set; }
        public BeerType Type { get; set; }
    }
}