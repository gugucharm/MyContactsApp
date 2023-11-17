using AutoMapper;
using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Exceptions;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Users
{
    public class RegisterUserCommand : IRequest<User>
    {
        public UserDTO UserDto { get; }

        public RegisterUserCommand(UserDTO userDto)
        {
            UserDto = userDto;
        }
    }

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUsersRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.UserDto.Email);
            if (existingUser != null)
            {
                throw new UserAlreadyExistsException("User already exists with the provided email.");
            }

            if (!PasswordUtility.IsPasswordSecure(request.UserDto.Password))
            {
                throw new InsecurePasswordException("Password does not meet security standards.");
            }

            var user = _mapper.Map<User>(request.UserDto);
            await _userRepository.AddUserAsync(user);

            return user;
        }
    }
}
