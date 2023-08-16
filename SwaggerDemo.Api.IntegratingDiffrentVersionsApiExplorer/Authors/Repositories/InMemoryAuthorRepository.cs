using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Authors.Repositories
{
    public class InMemoryAuthorRepository : IAuthorRepository
    {
        public Task<Author> GetAuthorAsync(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
