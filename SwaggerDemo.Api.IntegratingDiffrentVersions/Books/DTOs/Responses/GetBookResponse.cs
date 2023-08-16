namespace SwaggerDemo.Api.Books.DTOs.Responses
{
    public class GetBookResponse
    {
        public Guid Id { get; set; }

        public AuthorResponse Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
