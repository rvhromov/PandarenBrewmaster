using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.API.Models.Users;
using User.BusinessLogic.Dtos.User;
using User.BusinessLogic.Services.Users;

namespace User.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper; 
        private readonly IUserService _userService;
        
        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
            _userService = userService 
                ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("")]
        public async Task<ActionResult<int>> SignUpAsync([FromBody] SignUpModel signUpRequest)
        {
            var signUpDto = _mapper.Map<SignUpDto>(signUpRequest);

            var userId = await _userService.SignUpAsync(signUpDto);

            return StatusCode(StatusCodes.Status201Created, userId);
        }
    }
}