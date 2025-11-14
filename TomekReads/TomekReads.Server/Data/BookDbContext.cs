using Microsoft.EntityFrameworkCore;
using TomekReads.Server.Data.Models;

namespace TomekReads.Server.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
