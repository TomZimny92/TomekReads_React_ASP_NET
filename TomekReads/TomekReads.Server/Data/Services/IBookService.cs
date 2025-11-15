using Microsoft.AspNetCore.Mvc;
using TomekReads.Server.Data.Models;

namespace TomekReads.Server.Data.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>?> GetAllBooksAsync();
        Task<Book?> GetBookAsync(string id);
        Task<Book?> AddBookAsync(Book book);
        Task<IEnumerable<Book>?> AddBooksAsync(IEnumerable<Book> books);
        Task UpdateBookAsync(Book book, string id);
        Task<bool> DeleteBookAsync(string id);
        Task<IEnumerable<string>?> DeleteBooksAsync(IEnumerable<string> ids);
    }
}
