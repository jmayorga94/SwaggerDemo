using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync(Guid authorId);

        Task<Book> GetBookAsync(Guid authorId, Guid bookId);

        void AddBook(Book bookToAdd);

        Task<bool> SaveChangesAsync();
    }
}
