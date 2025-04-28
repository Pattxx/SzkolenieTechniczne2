using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SzkolenieTechniczne2.Cinema.Domain.Entities;
namespace SzkolenieTechniczne2.Infrastructure;
public class CinemaTicketDbContext : DbContext
{
    public CinemaTicketDbContext(DbContextOptions<CinemaTicketDbContext> options) : base(options)
    {
    }
    public DbSet<Movie> Movies { get; set; } //dodawanie tabeli
    public DbSet<Seance> Seances { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<MovieCategory> MovieCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=cinema;Trusted_Connection=True;",
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Cinema"));
    }
}