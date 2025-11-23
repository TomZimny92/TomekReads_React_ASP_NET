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
                    await _bookDbContext.SaveChangesAsync();
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
                await _bookDbContext.SaveChangesAsync();
                return addedBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public async Task UpdateBookAsync(Book book, string id)
        {
            try
            {
                var existingBook = await _bookDbContext.Books.FirstOrDefaultAsync((b) => b.Id == id);
                if (existingBook == null)
                {
                    throw new Exception($"{book.Title} does not exist and cannot be updated");
                }
                await _bookDbContext.Books
                    .Where(book => book.Id == id)
                    .ExecuteUpdateAsync(set => set
                        .SetProperty(b => b.Rating, book.Rating)
                        .SetProperty(b => b.Review, book.Review));

                //await _bookDbContext.SaveChangesAsync(); I don't think we need this with the Update API
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
            }
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            try
            {
                var existingBook = await _bookDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (existingBook == null)
                {
                    Console.WriteLine("The book you want to delete is not found");
                    return false;
                }
                await _bookDbContext.Books
                    .Where(book => book.Id == id)
                    .ExecuteDeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<string>?> DeleteBooksAsync(IEnumerable<string> ids)
        {
            try
            {
                var deletedBooks = new List<string>();
                foreach (string id in ids)
                {
                    var existingBook = await _bookDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
                    if (existingBook != null)
                    {
                        deletedBooks.Add(existingBook.Id);
                        await _bookDbContext.Books
                            .Where(book => book.Id == id)
                            .ExecuteDeleteAsync();
                    }
                }
                return deletedBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public string TestTest()
        {
            return "test";
        }
    }
}
