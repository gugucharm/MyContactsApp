using MediatR;
using Microsoft.Extensions.Configuration;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.JWT;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Users
{
    public class LoginUserCommand : IRequest<string>
    {
        public LoginDTO LoginDto { get; }

        public LoginUserCommand(LoginDTO loginDto)
        {
            LoginDto = loginDto;
        }
    }

    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IConfiguration _configuration;

        public LoginUserHandler(IUsersRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.LoginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.LoginDto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            return JwtTokenGenerator.GenerateJwtToken(user, _configuration);
        }
    }
}
