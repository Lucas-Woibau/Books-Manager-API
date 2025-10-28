using GerenciamentoBiblioteca.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BooksManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ILendingService, LendingService>();

            return services;
        }
    }
}
