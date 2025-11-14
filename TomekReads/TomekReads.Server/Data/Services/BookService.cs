using Microsoft.AspNetCore.Mvc;
using TomekReads.Server.Data.Models;

namespace TomekReads.Server.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IBookService _bookService;

        public BookService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksAsync()
        {
            // read database to get all items
            
        }

        public async Task<ActionResult<Book>> GetBookAsync(string id)
        {
            // use id to query db
        }

        public async Task<ActionResult> AddBookAsync(Book book)
        {
            // 
        }

        public async Task<ActionResult> AddBooksAsync(IEnumerable<Book> books)
        {
            // do the thing
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
