using System;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using User.BusinessLogic.Dtos.User;
using User.Infrastructure.Repositories;

namespace User.BusinessLogic.Services.Users
{
    public sealed class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.User> _repository;

        private const string Salt = "94kJQ^rOZo^Jljn!qkjAHenG*Ggenia2%eN%zzg6y2";

        public UserService(
            IMapper mapper,
            IRepository<Domain.Entities.User> repository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<int> SignUpAsync(SignUpDto signUpModel)
        {
            var userAlreadyExist = await _repository.IsExistAsync(u => u.UserName == signUpModel.UserName);

            if (userAlreadyExist)
                throw new DuplicateNameException($"User with username {signUpModel.UserName} already exists");

            var newUser = _mapper.Map<Domain.Entities.User>(signUpModel);
            newUser.PasswordHash = HashHelper.Create(signUpModel.Password, Salt);

            await _repository.CreateAsync(newUser);

            return newUser.Id;
        }

        public async Task<UserBeersDto> GetUserBeersAsync(int userId) =>
            await _repository
                .GetAll()
                .AsNoTracking()
                .ProjectTo<UserBeersDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(u => u.Id == userId);
    }
}