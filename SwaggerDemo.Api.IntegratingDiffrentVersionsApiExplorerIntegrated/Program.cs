using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SwaggerDemo.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApi();

builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(setup =>
//{
//    setup.SwaggerDoc("BooksAndAuthorsSpecification", new()
//    {
//        Title = "Library Books and Authors API",
//        Version = "1",
//        Description = "Through this API you can access authors and books",
//        Contact = new()
//        {
//            Email = "javiermay",
//            Name = " Javier Mayorga",
//            Url = new Uri("https://www.twitter/javiermay")
//        }


//    });

//    //setup.SwaggerDoc("LibrarySpecificationAuthors", new()
//    //{
//    //    Title = "Library API (Authors)",
//    //    Version = "1",
//    //    Description = "Through this API you can access authors",
//    //    Contact = new()
//    //    {
//    //        Email = "javiermay",
//    //        Name = " Javier Mayorga",
//    //        Url = new Uri("https://www.twitter/javiermay")
//    //    }


//    //});

//    //setup.SwaggerDoc("LibrarySpecificationBooks", new()
//    //{
//    //    Title = "Library API (Books)",
//    //    Version = "1",
//    //    Description = "Through this API you can access books",
//    //    Contact = new()
//    //    {
//    //        Email = "javiermay",
//    //        Name = " Javier Mayorga",
//    //        Url = new Uri("https://www.twitter/javiermay")
//    //    }


//    //});
//    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

//    setup.IncludeXmlComments(xmlCommentsFullPath);
//});


var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
var env = app.Services.GetRequiredService<IWebHostEnvironment>();


app.UseSwagger();

app.UseSwaggerUI(options =>
{
    //foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    //{
    //    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $" Library Api {env.EnvironmentName}  {description.GroupName.ToUpperInvariant()}"
    //   );
    //}

    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
    options.SwaggerEndpoint($"/swagger/v1/swagger.json", $" Library Api {env.EnvironmentName} V1"
       );
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
