using Microsoft.AspNetCore.Mvc;
using TomekReads.Server.Data.Models;

namespace TomekReads.Server.Data.Services
{
    public interface IBookService
    {
        public Task<ActionResult<IEnumerable<Book>>> GetAllBooksAsync();
        public Task<ActionResult<Book>> GetBookAsync(string id);
        public Task<ActionResult> AddBookAsync(Book book);
        public Task<ActionResult> AddBooksAsync(IEnumerable<Book> books);
        public Task<ActionResult> UpdateBookAsync(Book book, string id);
        public Task<ActionResult<Book>> DeleteBookAsync(string id);
        public Task<ActionResult<IEnumerable<Book>>> DeleteBooksAsync(IEnumerable<string> ids);
    }
}
