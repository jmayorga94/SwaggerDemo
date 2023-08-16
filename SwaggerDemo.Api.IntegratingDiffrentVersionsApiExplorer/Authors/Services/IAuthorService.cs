using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Authors.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();

        Task<Author> GetAuthorAsync(Guid authorId);

    }
}
