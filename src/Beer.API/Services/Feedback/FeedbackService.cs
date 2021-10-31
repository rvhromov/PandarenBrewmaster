using System.Threading.Tasks;
using AutoMapper;
using Beer.API.Data;
using Beer.API.Dtos.Feedback;
using MongoDB.Driver;

namespace Beer.API.Services.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly MongoDbContext _dbContext;
        private readonly IMapper _mapper;

        public FeedbackService(
            MongoDbContext dbContext, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(string beerId, CreateFeedbackDto createDto)
        {
            var feedback = _mapper.Map<Entities.Feedback>(createDto);

            var beer = await _dbContext.Beers
                .Find(b => b.Id == beerId)
                .FirstOrDefaultAsync();

            beer.Feedbacks.Add(feedback);

            await _dbContext.Beers.ReplaceOneAsync(b => b.Id == beerId, beer);
        } 
    }
}