
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Api.Books.DTOs.Responses;
using SwaggerDemo.Api.Books.Mappers;
using SwaggerDemo.Api.Entities;
using SwaggerDemo.Api.Services;
using Microsoft.AspNetCore.Http;
using SwaggerDemo.Api.Books.DTOs.Requests;

namespace SwaggerDemo.Api.Controllers;

[Route("api/authors/{authorId}/books")]
[ApiController]
[Produces("application/json")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    /// <summary>
    /// Adds a new book to the collection of books for a specific author.
    /// </summary>
    /// <remarks>
    /// Creates and adds a new book to the collection of books associated with the provided Author ID.
    /// The provided Author ID is used to associate the book with the correct author.
    /// <br/><br/>
    /// <b>Request Body:</b><br/>
    /// The request body should contain a JSON object with the following properties:
    /// <code>
    /// {
    ///   "Title": "The Title of the Book",
    ///   "Description": "The Description of the Book",
    ///   "AmountOfPages": 200
    /// }
    /// </code>
    /// </remarks>
    /// <param name="authorId">The ID of the author for whom the book is being added.</param>
    /// <param name="bookToAdd">The details of the new book to be added.</param>
    [HttpPost]
    [Consumes("application/json")]

    public IActionResult AddBook(Guid authorId, [FromBody] Book bookToAdd)
    {
        bookToAdd.AuthorId = authorId;
        _bookService.AddBook(bookToAdd);

        return CreatedAtAction(nameof(GetBook), new { authorId, bookId = bookToAdd.Id }, bookToAdd);
    }


    [HttpGet("{bookId}")]
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetBook(Guid authorId, Guid bookId)
    {
        var book = await _bookService.GetBookAsync(authorId, bookId);

        if (book == null)
        {
            return NotFound();
        }

        var response = book.ToResponse();
        return Ok(response);
    }

    /// <summary>
    /// Get an book by Author Id
    /// </summary>
    /// <param name="authorId"> The id of the author you want to get</param>
    /// <returns></returns>
    /// <response code="200"> Returns the requested book</response>
    [HttpGet]
    [ProducesResponseType(typeof(Book), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(GetBookResponse))]
    [ProducesResponseType(typeof(Book), StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GetBookResponse>> GetBooks(Guid authorId)
    {
        var books = await _bookService.GetBooksAsync(authorId);
        var response = books.ToResponse();
        return Ok(response);
    }


}
