namespace _8._Delegates_and_LINQ
{
    public class Movie(string title = "", string description = "", List<string>? genres = null, int year = 0, float rating = 0)
    {

        public string Title { get; set; } = title;

        public string Description { get; set; } = description;

        public List<string>? Genres { get; set; } = genres ?? [];

        public int Year { get; set; } = year;

        public float Rating { get; set; } = rating;

        public override string ToString() => $"{{\nTitle: {Title}\nDescription: {Description}\nGenres: {string.Join(", ", Genres)}\nYear: {Year}\nRating: {Rating}\n}}\n";
    }
}
