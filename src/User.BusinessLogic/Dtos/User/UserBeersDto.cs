using System.Collections.Generic;
using User.BusinessLogic.Dtos.Beer;

namespace User.BusinessLogic.Dtos.User
{
    public class UserBeersDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<BeerDto> Beers { get; set; }
    }
}