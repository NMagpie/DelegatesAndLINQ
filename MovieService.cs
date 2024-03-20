using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8._Delegates_and_LINQ
{
    public delegate void ShareOption(Movie movie);

    public class MovieService
    {

        public void ShareMovie(Movie movie, ShareOption shareOption)
        {
            Console.WriteLine($"Sharing movie: {movie.Title}");
            shareOption(movie);
        }

        public void ShareMovieUsingAction(Movie movie, Action<Movie> shareOption) 
        {
            Console.WriteLine($"Sharing movie via Action: {movie.Title}");
            shareOption(movie);
        }
    }
}
