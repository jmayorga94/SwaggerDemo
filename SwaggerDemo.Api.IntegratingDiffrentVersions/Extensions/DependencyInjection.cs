using SwaggerDemo.Api.Books.Repositories;
using SwaggerDemo.Api.Books.Services;

namespace SwaggerDemo.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, InMemoryBookRepository>();

            services.AddControllers();

            return services;
        }
    }
}
