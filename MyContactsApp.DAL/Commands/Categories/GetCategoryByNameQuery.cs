using MediatR;
using MyContactsApp.DAL.Models;
using MyContactsApp.DAL.Repositories.Interfaces;

namespace MyContactsApp.DAL.Commands.Categories
{
    public class GetCategoryByNameQuery : IRequest<Category>
    {
        public string Name { get; }

        public GetCategoryByNameQuery(string name)
        {
            Name = name;
        }
    }

    public class GetCategoryByNameHandler : IRequestHandler<GetCategoryByNameQuery, Category>
    {
        private readonly ICategoriesRepository _repository;

        public GetCategoryByNameHandler(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCategoryByNameAsync(request.Name);
        }
    }
}
