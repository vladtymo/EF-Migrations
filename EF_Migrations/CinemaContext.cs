using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Migrations
{
    public class CinemaContext : DbContext
    {
        public CinemaContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-O0M8V28\SQLEXPRESS;Initial Catalog=CinemaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }

    public class Ticket
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public decimal Price { get; set; }
        [Required]
        public Session Session { get; set; }
    }

    public class Session
    {
        public int Id { get; set; }
        public int Places { get; set; }
        public bool Is3D { get; set; }
        public DateTime Time { get; set; }

        [Required]
        public Movie Movie { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }

    public class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            Sessions = new HashSet<Session>();
        }
        public int Id { get; set; }
        [Required, MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        public int Year { get; set; }
        //public TimeSpan Duration { get; set; }
        public float Rating { get; set; }

        public Genre Genre { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
