using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Authors.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();

        Task<Author> GetAuthorAsync(Guid authorId);

    }
}
