namespace MovieAPI.Models;

public partial class CiniMovie
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Genre { get; set; }

    public DateTime ReleaseYear { get; set; }
}
