namespace BookAppAPI.Models;

public class Review
{
    public int ReviewId { get; set; }
    public string VoterName { get; set; }
    public int NumberOfStart { get; set; }
    public string Comment { get; set; }
    public int BookId { get; set; }
}