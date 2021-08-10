using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie> {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
                new Movie("The Martian", "Matt Damon", 8, 2015),
            };

            List<Actor> actors = new List<Actor> {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            Movie selectedMovie = movies.FirstOrDefault(m => m.LeadActor == "Leonardo DiCaprio");
            // Console.WriteLine(selectedMovie);

            Movie oldestMovie = movies.FirstOrDefault(m => m.Year == movies.Min(mov => mov.Year));
            Console.WriteLine(oldestMovie);

            IEnumerable<Movie> alphabeticalMovies = movies.OrderBy(m => m.Title);
            PrintEach(alphabeticalMovies, "Alphabetical Movies:");

            List<Movie> leoMovies = movies.Where(m => m.LeadActor == "Leonardo DiCaprio").ToList();
            PrintEach(leoMovies, "leoMovies:");

            List<Movie> leoMoviesAbove8 = movies.Where(m => m.LeadActor == "Leonardo DiCaprio" && m.Rating > 8).ToList();
            PrintEach(leoMoviesAbove8, "leoMoviesAbove8:");

            IEnumerable<Movie> theMovies = movies.Where(m => m.Title.StartsWith("The"));
            PrintEach(theMovies, "theMovies:");

            // .Select and Distinct IS NOT ON EXAM
            List<string> highCloutActors = movies
                .Where(m => m.Rating >= 8.2)
                .OrderByDescending(m => m.Rating)
                .Select(m => m.LeadActor)
                .Distinct<string>() // removes duplicates
                .ToList();

            PrintEach(highCloutActors, "highCloutActors:");

            // NOT ON EXAM
            var moviesAndActor = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie, actor } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
                .ToList();

            PrintEach(moviesAndActor);
            Console.WriteLine(moviesAndActor[0].actor.Age);
        }

        public static void PrintEach(IEnumerable<dynamic> items, string msg = "msg")
        {
            Console.WriteLine("\n" + msg);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
