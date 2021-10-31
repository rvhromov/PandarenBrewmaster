using System;
using System.Threading.Tasks;
using Beer.API.Dtos.Feedback;
using Beer.API.Services.Beer;
using Beer.API.Services.Feedback;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beer.API.Controllers
{
    [Route("api/beers/{id:length(24)}/feedbacks")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IBeerService _beerService;

        public FeedbacksController(
            IFeedbackService feedbackService, 
            IBeerService beerService)
        {
            _feedbackService = feedbackService 
                ?? throw new ArgumentNullException(nameof(feedbackService));
            _beerService = beerService 
                ?? throw new ArgumentNullException(nameof(beerService));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync([FromRoute] string id, [FromBody] CreateFeedbackDto createModel)
        {
            if (!await _beerService.IsExist(id))
                return NotFound("Entity not found");

            await _feedbackService.CreateAsync(id, createModel);

            await _beerService.RecountRatingAsync(id);
            
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}