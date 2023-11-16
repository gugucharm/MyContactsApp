using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public UserDTO UserDto { get; }

        public CreateUserCommand(UserDTO contactDto)
        {
            UserDto = contactDto;
        }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUsersRepository _repository;

        public CreateUserHandler(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var contact = new User
            {
                FirstName = request.UserDto.FirstName,
                LastName = request.UserDto.LastName,
                Email = request.UserDto.Email,
            };

            return await _repository.AddUserAsync(contact);
        }
    }
}
