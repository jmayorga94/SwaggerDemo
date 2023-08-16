using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Api.Authors.Services;
using SwaggerDemo.Api.Entities;

namespace SwaggerDemo.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// Get an author by his/her id V2
        /// </summary>
        /// <param name="authorId">The id of the author you want to get</param>
        /// <returns>An ActionResult of type Author</returns>
        [HttpGet("{authorId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Author>> GetAuthor(
            Guid authorId)
        {
            var authorFromService = await _authorService.GetAuthorAsync(authorId);

            if (authorFromService == null)
            {
                return NotFound();
            }

            return Ok(authorFromService);
        }
    }
}
