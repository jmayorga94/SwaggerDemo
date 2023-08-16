using SwaggerDemo.Api.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("BooksAndAuthorsSpecification", new()
    {
        //Title = "Books and Authors API",
        //Version = "1",
        //Description = "Through this API you can access authors and books",
        //Contact = new()
        //{
        //    Email = "escribe tu email",
        //    Name = "escribe tu nombre",
        //    Url = new Uri("https://www.twitter/user")
        //}


    });
    //var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    //setup.IncludeXmlComments(xmlCommentsFullPath);
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/BooksAndAuthorsSpecification/swagger.json", "Library API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
