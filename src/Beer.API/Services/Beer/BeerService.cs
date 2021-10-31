using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Beer.API.Data;
using Beer.API.Dtos.Beer;
using MongoDB.Driver;

namespace Beer.API.Services.Beer
{
    public class BeerService : IBeerService
    {
        private readonly MongoDbContext _dbContext;
        private readonly IMapper _mapper;

        public BeerService(
            MongoDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> IsExist(string id) =>
            await _dbContext.Beers
                .Find(b => b.Id == id)
                .AnyAsync();

        public async Task<List<BeerDto>> GetAsync()
        {
            var beers = await _dbContext.Beers
                .Find(b => true)
                .ToListAsync();

            return _mapper.Map<List<BeerDto>>(beers);
        }

        public async Task<string> CreateAsync(CreateBeerDto createDto)
        {
            var newBeer = _mapper.Map<Entities.Beer>(createDto);

            await _dbContext.Beers.InsertOneAsync(newBeer);

            return newBeer.Id;
        }

        public async Task<bool> RecountRatingAsync(string id)
        {
            var beer = await _dbContext.Beers
                .Find(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (beer is null)
                return false;

            var feedbacks = beer.Feedbacks?.ToList();

            if (feedbacks is not null && feedbacks.Any())
            {
                beer.AverageRate = (double) feedbacks.Sum(f => f.Rate) / feedbacks.Count;
            }

            await _dbContext.Beers.ReplaceOneAsync(b => b.Id == id, beer);

            return true;
        }

        public async Task RemoveAsync(string id) =>
            await _dbContext.Beers.DeleteOneAsync(b => b.Id == id);
    }
}