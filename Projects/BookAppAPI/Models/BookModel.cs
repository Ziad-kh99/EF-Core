namespace BookAppAPI.Models;

public class Book
{
    public int BookId { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
    public string ImageURL { get; set; }

    public PriceOffer Promotion { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<BookAuthor> AuthorsLink { get; set; }
}