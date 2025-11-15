using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TomekReads.Server.Data.Models;

namespace TomekReads.Server.Data.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _bookDbContext;

        public BookService(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<IEnumerable<Book>?> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookDbContext.Books.ToListAsync<Book>();
                if (books == null)
                {
                    return null;
                }
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public async Task<Book?> GetBookAsync(string id)
        {
            try
            {
                var foundBook = await _bookDbContext.Books.FirstOrDefaultAsync<Book>((book) => book.Id == id);
                if (foundBook == null)
                {
                    return null;
                }
                return foundBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Mesasge: {ex.Message}");
                return null;
            }
        }

        public async Task<Book?> AddBookAsync(Book book)
        {
            try
            {
                var newBookExists = await _bookDbContext.Books.FirstOrDefaultAsync((dbBook) => dbBook.Id == book.Id);
                if (newBookExists == null)
                {
                    await _bookDbContext.Books.AddAsync(book);
                    var newBook = await GetBookAsync(book.Id);
                    if (newBook == null)
                    {
                        return null;
                    }
                    return newBook;
                }
                else
                {
                    Console.WriteLine("Book already exists");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Book>?> AddBooksAsync(IEnumerable<Book> books)
        {
            try
            {
                foreach(var book in books)
                {
                    await _bookDbContext.Books.AddAsync(book);
                }
                var addedBooks = new List<Book>();
                foreach (var book in books)
                {
                    var newBook = await _bookDbContext.Books.FirstOrDefaultAsync((b) => b.Id == book.Id);
                    if (newBook != null)
                    {
                        addedBooks.Add(newBook);
                    }
                }
                return addedBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public async Task<ActionResult> UpdateBookAsync(Book book, string id)
        {
            // update to db
        }

        public async Task<ActionResult> DeleteBookAsync(string id)
        {

        }

        public async Task<ActionResult> DeleteBooksAsync(IEnumerable<string> ids)
        {

        }

    }
}
