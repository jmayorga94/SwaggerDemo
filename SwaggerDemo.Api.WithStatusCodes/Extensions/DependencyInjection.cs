using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Api.Repositories;
using SwaggerDemo.Api.Services;

namespace SwaggerDemo.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, InMemoryBookRepository>();

            services.AddControllers(setupAction =>
            {
                //setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                //setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                //setupAction.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                //setupAction.Filters.Add(new ProducesDefaultResponseTypeAttribute());
            });

            return services;
        }
    }
}
