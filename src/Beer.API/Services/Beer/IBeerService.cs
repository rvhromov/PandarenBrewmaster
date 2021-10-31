using System.Collections.Generic;
using System.Threading.Tasks;
using Beer.API.Dtos.Beer;

namespace Beer.API.Services.Beer
{
    public interface IBeerService
    {
        Task<bool> IsExist(string id);
        
        Task<List<BeerDto>> GetAsync();

        Task<string> CreateAsync(CreateBeerDto createDto);

        Task<bool> RecountRatingAsync(string id);

        Task RemoveAsync(string id);
    }
}