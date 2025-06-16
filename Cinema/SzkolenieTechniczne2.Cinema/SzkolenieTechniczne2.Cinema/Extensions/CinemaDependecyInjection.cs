﻿using SzkolenieTechniczne2.Cinema.Common.Repositories;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Create;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Delete;
using SzkolenieTechniczne2.Cinema.Domain.Command.Movie.Update;
using SzkolenieTechniczne2.Cinema.Domain.Command.Seances;
using SzkolenieTechniczne2.Cinema.Domain.Command.Tickets;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetAllMoviesQuery;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieCategories;
using SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetMovieQuery;
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
                cfg.RegisterServicesFromAssembly(typeof(GetMovieCategoriesQuery).Assembly);
            });

            return services;
        }
    }
}
