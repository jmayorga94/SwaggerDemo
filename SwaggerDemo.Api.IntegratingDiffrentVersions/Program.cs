using SwaggerDemo.Api.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    //setup.SwaggerDoc("BooksAndAuthorsSpecification", new()
    //{
    //    Title = "Books and Authors API With Status Codes",
    //    Version = "1",
    //    Description="Through this API you can access authors and books",
    //    Contact = new()
    //    {
    //     Email="javiermay",
    //     Name =" Javier Mayorga",
    //     Url = new Uri("https://www.twitter/javiermay")
    //    }


    //});

    setup.SwaggerDoc("LibrarySpecificationAuthors", new()
    {
        Title = "Library API (Authors)",
        Version = "1",
        Description = "Through this API you can access authors",
        Contact = new()
        {
            Email = "escribe tu email",
            Name = "escribe tu nombre",
            Url = new Uri("https://www.twitter/user")
        }


    });

    setup.SwaggerDoc("LibrarySpecificationBooks", new()
    {
        Title = "Library API (Books)",
        Version = "1",
        Description = "Through this API you can access books",
        Contact = new()
        {
            Email = "escribe tu email",
            Name = "escribe tu nombre",
            Url = new Uri("https://www.twitter/user")
        }


    });
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    setup.IncludeXmlComments(xmlCommentsFullPath);
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    //c.SwaggerEndpoint("/swagger/BooksAndAuthorsSpecification/swagger.json", "WeatherForecast API");
    c.SwaggerEndpoint("/swagger/LibrarySpecificationAuthors/swagger.json", "Library Authors API");
    c.SwaggerEndpoint("/swagger/LibrarySpecificationBooks/swagger.json", "Library Books API");


});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
