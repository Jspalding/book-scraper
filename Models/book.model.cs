public class Book
{
    public string Title { get; set; }
    public string AuthorFullName { get; set; }
    public string Published { get; set; }
    public string Url { get; set; }
    public string? Summary { get; set; }
    public List<string>? Genres { get; set; }
    public int? PageCount { get; set; }

    public int? TotalRatings { get; set; }
    public int? TotalReviews { get; set; }
    public int? AverageRating { get; set; }

}