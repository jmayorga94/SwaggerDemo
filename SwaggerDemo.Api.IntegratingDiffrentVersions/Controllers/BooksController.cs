﻿
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Api.Books.DTOs.Responses;
using SwaggerDemo.Api.Books.Mappers;
using SwaggerDemo.Api.Books.Services;
using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Controllers;

[Route("api/authors/{authorId}/books")]
[ApiController]
[ApiExplorerSettings(GroupName = "LibrarySpecificationBooks")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    [HttpGet("{bookId}")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status400BadRequest)]
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Book), StatusCodes.Status404NotFound)]

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
