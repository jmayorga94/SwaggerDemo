﻿
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

    [HttpPost]
    public IActionResult AddBook(Guid authorId, [FromBody] Book bookToAdd)
    {
        bookToAdd.AuthorId = authorId;
        _bookService.AddBook(bookToAdd);

        return CreatedAtAction(nameof(GetBook), new { authorId, bookId = bookToAdd.Id }, bookToAdd);
    }


    [HttpGet("{bookId}")]
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
