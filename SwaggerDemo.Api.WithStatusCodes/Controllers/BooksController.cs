
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Api.Books.DTOs.Responses;
using SwaggerDemo.Api.Books.Mappers;
using SwaggerDemo.Api.Entities;
using SwaggerDemo.Api.Services;

namespace SwaggerDemo.Api.Controllers;

[Route("api/authors/{authorId}/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    /// <summary>
    /// Retrieves information about a specific book from the library.
    /// </summary>
    /// <param name="authorId">The ID of the author.</param>
    /// <param name="bookId">The ID of the book.</param>
    /// <returns>Information about the book.</returns>
    [HttpGet("{bookId}")]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetBookResponse>> GetBook(Guid authorId, Guid bookId)
    {
        var book = await _bookService.GetBookAsync(authorId, bookId);

        if (book == null)
        {
            return NotFound();
        }

        var response = book.ToResponse();
        return Ok(response);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks(Guid authorId)
    {
        var books = await _bookService.GetBooksAsync(authorId);
        var response = books.ToResponse();
        return Ok(response);
    }
}
