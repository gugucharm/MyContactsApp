using AutoMapper;
using MediatR;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories;
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
        private readonly IMapper _mapper;

        public CreateUserHandler(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserDto);
            return await _repository.AddUserAsync(user);
        }
    }
}
