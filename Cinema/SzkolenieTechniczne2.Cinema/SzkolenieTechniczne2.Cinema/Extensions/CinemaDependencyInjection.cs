using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Infrastructure;
using SzkolenieTechniczne2.Cinema.Infrastructure.Repository;

namespace SzkolenieTechniczne2.Cinema.Extensions
{
    public static class CinemaDependecyInjection
    {
        public static IServiceCollection CinemaAddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddDbContext<CinemaTicketDbContext, CinemaTicketDbContext>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateMovieCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteMovieCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateMovieCommand).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(RegisterSeanceCommand).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(BuyTicketCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllMoviesQuery).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(GetMovieQuery).Assembly);
                //cfg.RegisterServicesFromAssembly(typeof(GetMovieCategoriesQueryHandler).Assembly);
            });

            return services;
        }
    }

}
