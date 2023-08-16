using SwaggerDemo.Api.Entities;
using SwaggerDemo.Api.Repositories;

namespace SwaggerDemo.Api.Services
{ 
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public void AddBook(Book bookToAdd)
        {
            _bookRepository.AddBook(bookToAdd);
        }

        public Task<Book> GetBookAsync(Guid authorId, Guid bookId)
        {
            return _bookRepository.GetBookAsync(authorId, bookId);
        }

        public Task<IEnumerable<Book>> GetBooksAsync(Guid authorId)
        {
            return _bookRepository.GetBooksAsync(authorId);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _bookRepository.SaveChangesAsync();
        }
    }
}
