using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beer.API.Dtos.Beer;
using Beer.API.Services.Beer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beer.API.Controllers
{
    [Route("api/beers")]
    public class BeersController : ControllerBase
    {
        private readonly IBeerService _beerService;

        public BeersController(IBeerService beerService)
        {
            _beerService = beerService 
                ?? throw new ArgumentNullException(nameof(beerService));
        }
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BeerDto>>> GetAsync() =>
            Ok(await _beerService.GetAsync());

        [HttpPost("")]
        public async Task<ActionResult<string>> CreateAsync([FromBody] CreateBeerDto createModel)
        {
            var beerId = await _beerService.CreateAsync(createModel);

            if (beerId is null)
                return BadRequest("Creation failed");

            return StatusCode(StatusCodes.Status201Created, beerId);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            if (!await _beerService.IsExist(id))
                return NotFound("Entity not found");

            await _beerService.RemoveAsync(id);

            return NoContent();
        }
    }
}