using Data;
using Microsoft.EntityFrameworkCore;

public class BookUtility
{
    public static void ListAll()
    {
        using (var db  = new AppDbContext())
        {
            foreach (var book in db.Books.AsNoTracking()    // AsNoTraking() => indicates that this access is read-only.
                                         .Include(book => book.Author))   
            {
                var webUrl = book.Author.WebURL == null ? "- no web URL given" : book.Author.WebURL;

                Console.WriteLine($"{book.Title} by {book.Author.Name}");
                Console.WriteLine($"Published On: {book.PublishedOn:dd-MMM-yyyy}");
                Console.WriteLine($"URL: {webUrl}");
            }
        }
    }

    public static void ChangeWebURL()
    {
        Console.WriteLine("New Quantum Networking WebURL > ");
        var newWebURL = Console.ReadLine();

        using(var db = new AppDbContext())
        {
            var singleBook = db.Books.Include(book => book.Author)                              // Include() => allow us to load the author info with the book
                                     .Single(book => book.Title == "Quantum Networking");       // Single() => Select only one book with given condition.
            
            singleBook.Author.WebURL = newWebURL;
            db.SaveChanges();           // SaveChanges() => tells the EF Core to check for any changes in data that has been read in and write out those changes to the DB.
        }

        ListAll();      // to list books again after edit.
    }
}