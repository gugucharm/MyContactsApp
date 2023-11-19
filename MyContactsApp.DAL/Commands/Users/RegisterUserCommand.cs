using AutoMapper;
using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Exceptions;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Users
{
    // Here we define the MediatR's command and it's handler
    // for registering a user in the database
    public class RegisterUserCommand : IRequest<User>
    {
        public UserDTO UserDto { get; }

        public RegisterUserCommand(UserDTO userDto)
        {
            UserDto = userDto;
        }
    }

    // The handler leverages UserssRepository class and helper
    // methods to check the validity of both the email and the
    // password typed in by the client. It also uses the mapper
    // to convert UserDTO to a User and returns it after successful
    // operation
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
            if (!EmailUtility.IsValidEmail(request.UserDto.Email))
            {
                throw new InvalidEmailException("Email is not in a valid format.");
            }

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
