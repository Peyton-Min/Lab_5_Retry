using Lab_5_Attempt_2.Data;
using Lab_5_Attempt_2;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lab_5_Attempt_2.Services
{
    public class BookServices
    {
        public List<Book> books { get; set; } = new List<Book>();

        /// <summary>
        /// Retrieves all of the books from the Books.csv file
        /// </summary>
        public void ReadBooks()
        {
            try
            {
                foreach (var line in File.ReadLines("./Data/Books.csv"))
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 4)
                    {
                        var book = new Book
                        {
                            Id = int.Parse(fields[0].Trim()),
                            Title = fields[1].Trim(),
                            Author = fields[2].Trim(),
                            ISBN = fields[3].Trim()
                        };

                        books.Add(book);
                    }
                }
                Console.WriteLine($"Books successfully read. Count:{books.Count} books: {books}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Allows a user to add another Book to the Books.csv
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="isbn"></param>
        public void AddBook(string title, string author, string isbn)
        {
            int id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            var newBook = new Book { Id = id, Title = title, Author = author, ISBN = isbn };
            
            books.Add(newBook);
            
            // Append the new book to the CSV file
            using (StreamWriter writer = File.AppendText("./Data/Books.csv"))
            {
                writer.WriteLine($"{id},{title},{author},{isbn}");
            }
        }

        /// <summary>
        /// Allows a user to edit a previously made Book saved within Books.csv
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTitle"></param>
        /// <param name="newAuthor"></param>
        /// <param name="newISBN"></param>
        public void EditBook(int id, string newTitle, string newAuthor, string newISBN)
        {
            // Find the book with the specified ID
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                // Update the book properties
                book.Title = newTitle;
                book.Author = newAuthor;
                book.ISBN = newISBN;

                // Rewrite the CSV file with the updated book list
                using (StreamWriter writer = new StreamWriter("./Data/Books.csv"))
                {
                    foreach (var b in books)
                    {
                        writer.WriteLine($"{b.Id},{b.Title},{b.Author},{b.ISBN}");
                    }
                }
            }
        }

        /// <summary>
        /// Allows a user to delete a previously made Book within the Books.csv
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);

                using (StreamWriter writer = new StreamWriter("./Data/Books.csv"))
                {
                    foreach (var b in books)
                    {
                        writer.WriteLine($"{b.Id},{b.Title},{b.Author},{b.ISBN}");
                    }
                }
                Console.WriteLine($"Book with ID {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No book found with ID {id}.");
            }
        }

        /// <summary>
        /// Returns an IEnumerable containing every Book in the Books.csv, organizaed by their Id.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<dynamic> ListBooks()
        {
            Console.WriteLine("\nAvailable Books:");

            var bookGroups = books.GroupBy(b => b.Id).Select(bookGroup => new { Book = bookGroup.First(), Count = bookGroup.Count() });

            return bookGroups;
        }
    }
}
