using SwaggerDemo.Api.Entities;
using System.Text.Json;

namespace SwaggerDemo.Api.Books.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly Dictionary<Guid, List<Book>> _booksByAuthor;
        private readonly Dictionary<Guid, Author> _authors;

        public InMemoryBookRepository()
        {
            _booksByAuthor = new Dictionary<Guid, List<Book>>();
            _authors = new Dictionary<Guid, Author>();
            SeedInitialDataFromJson();
        }


        public void AddBook(Book bookToAdd)
        {
            if (!_booksByAuthor.ContainsKey(bookToAdd.AuthorId))
            {
                _booksByAuthor[bookToAdd.AuthorId] = new List<Book>();
            }

            _booksByAuthor[bookToAdd.AuthorId].Add(bookToAdd);
        }

        public async Task<Book> GetBookAsync(Guid authorId, Guid bookId)
        {
            return await Task.Run(() =>
            {
                if (_booksByAuthor.ContainsKey(authorId))
                {
                    return _booksByAuthor[authorId].FirstOrDefault(book => book.Id == bookId);
                }

                return null;
            });
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(Guid authorId)
        {
            return await Task.Run(() =>
            {
                if (_booksByAuthor.ContainsKey(authorId))
                {
                    return _booksByAuthor[authorId];
                }

                return Enumerable.Empty<Book>();
            });
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Task.Run(() =>
            {
                return true;
            });
        }

        private void SeedInitialDataFromJson()
        {
            var jsonString = File.ReadAllText("initialData.json");
            var initialData = JsonSerializer.Deserialize<InitialData>(jsonString);

            foreach (var initialAuthor in initialData.Authors)
            {
                _authors[initialAuthor.Id] = initialAuthor;
            }

            foreach (var initialBookData in initialData.Books)
            {
                var book = new Book
                {
                    Id = initialBookData.Id,
                    AuthorId = initialBookData.AuthorId,
                    Title = initialBookData.Title,
                    Description = initialBookData.Description,
                    AmountOfPages = initialBookData.AmountOfPages,
                    Author = _authors[initialBookData.AuthorId]
                };

                AddBook(book);
            }
        }

        private class InitialData
        {
            public List<Author> Authors { get; set; }
            public List<InitialBookData> Books { get; set; }
        }

        private class InitialBookData
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int? AmountOfPages { get; set; }
            public Guid AuthorId { get; set; }
        }
    }
}
