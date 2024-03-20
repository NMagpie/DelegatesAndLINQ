using _8._Delegates_and_LINQ;
using Newtonsoft.Json;

var textFile = "D:\\AM\\C#\\8. Delegates and LINQ\\movies.json";

string text = File.Exists(textFile) ? File.ReadAllText(textFile) : "";


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// 1. Create a collecation

List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(text) ?? [];

var movieService = new MovieService();


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// 2. Manipulate collection via delegates

movieService.ShareMovie(movies[1], (movie) => Console.WriteLine($"Movie {movie.Title} was copied as URL!\n"));

// urlShare(movies[1]);


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// 3. Rewrite using anonymous functions

ShareOption messengerShare = delegate (Movie movie)
{
    Console.WriteLine($"Movie {movie.Title} was shared via Messenger!\n");
};

movieService.ShareMovie(movies[15], messengerShare);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// 4. Rewrite using lambda expression


ShareOption emailShare = (movie) => Console.WriteLine($"Movie {movie.Title} was shared via Email!\n");

//emailShare(movies[26]);

movieService.ShareMovie(movies[26], emailShare);

// Using action (just to check)

Action<Movie> facebookShare = (movie) => Console.WriteLine($"Movie {movie.Title} was shared via Facebook!\n");

movieService.ShareMovieUsingAction(movies[5], facebookShare);

//facebookShare(movies[13]);

// Gives error - type mismatch (ShareOption delegate type and Action)

// movieService.ShareMovieUsingAction(movies[5], emailShare);


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// 5. Using extention methods on the collection

Console.WriteLine(movies[18].MovieAsJson());

Console.WriteLine();


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// 6. Using Select/Where operators on the collection

var selectedMovies = movies.Where(movie => movie.Genres.Contains("Action"))
      .OrderBy(movie => movie.Genres.Count)
      .Select(movie => new { movie.Title, movie.Genres });

foreach (var movie in selectedMovies)
{
    Console.WriteLine(movie.Title + ": " + string.Join(", ", movie.Genres));
}

Console.WriteLine();

var allGenres = movies.SelectMany(movie => movie.Genres)
    .Distinct()
    .OrderBy(genre => genre);

foreach (var genre in allGenres)
{
    Console.WriteLine(genre);
}


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Example of query syntax

var moviesWithHighRating = from movie in movies
                           where movie.Rating > 7
                           select movie.Title;