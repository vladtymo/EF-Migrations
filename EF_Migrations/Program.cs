using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            CinemaContext context = new CinemaContext();

            ShowMovies(context.Movies.Include("Genre").Include("Actors"));
            //ShowMovies(context.Movies.Where(m => m.Rating >= 7).OrderByDescending(m => m.Rating));
            //ShowMovies(context.Movies.Where(m => m.Year >= DateTime.Now.Year - 5));
        }
        static void ShowMovies(IEnumerable<Movie> movies)
        {
            foreach (var m in movies)
            {
                Console.WriteLine($"-=-=-=-=-=- {m.Title} {m.Year} -=-=-=-=-=-\n" +
                    $"Genres: {m.Genre.Name}\n" +
                    $"Rating: {m.Rating}\n" +
                    $"Actors: {m.Actors.Count}");
            }
        }
    }
}
