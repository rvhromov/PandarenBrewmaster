using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.API.Models.Users;
using User.BusinessLogic.Services.Users;

namespace User.API.Controllers
{
    [Route("api/users/{id:int}/beers")]
    public class BeersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public BeersController(
            IMapper mapper, 
            IUserService userService)
        {
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService 
                ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("")]
        public async Task<ActionResult<UserBeersModel>> GetAllAsync([FromRoute] int id)
        {
            var beers = await _userService.GetUserBeersAsync(id);

            return Ok(_mapper.Map<UserBeersModel>(beers));
        }
    }
}