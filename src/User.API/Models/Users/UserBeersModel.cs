using System.Collections.Generic;
using User.API.Models.Beers;

namespace User.API.Models.Users
{
    public class UserBeersModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<BeerModel> Beers { get; set; }
    }
}