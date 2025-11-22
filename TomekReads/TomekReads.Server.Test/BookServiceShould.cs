using TomekReads.Server.Data;
using TomekReads.Server.Data.Services;

namespace TomekReads.Server.Test
{
    [TestFixture]
    public class BookServiceShould
    {
        private readonly IBookService _bookService;
        private readonly BookDbContext _booDbContext;
        private BookService _service;

        public BookServiceShould(IBookService bookService, BookDbContext bookDbContext)
        {
            _bookService = bookService;
            _booDbContext = bookDbContext;
        }

        [SetUp]
        public void Setup()
        {            
            _service = new BookService(_booDbContext);
        }

        [Test]
        public async Task GetAllBooksShould()
        {
            var books = await _service.GetAllBooksAsync();
            Assert.Equals(books.Leng, true);
        }

        [Test]
        public void Test2()
        {
            Assert.Fail();
        }
    }
}
