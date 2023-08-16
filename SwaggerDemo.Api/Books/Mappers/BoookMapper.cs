using SwaggerDemo.Api.Books.DTOs.Responses;
using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Books.Mappers;

public static class BookMapper
{
    public static GetBookResponse ToResponse(this Book book)
    {
        if (book == null)
        {
            return null;
        }

        return new GetBookResponse
        {
            Id = book.Id,
            Author = new AuthorResponse
            {
                FirstName = book.Author.FirstName,
                LastName = book.Author.LastName
            },
            Title = book.Title,
            Description = book.Description
        };
    }
    public static IEnumerable<GetBookResponse> ToResponse(this IEnumerable<Book> books) => books.Select(book => book.ToResponse()).ToList();
  
}