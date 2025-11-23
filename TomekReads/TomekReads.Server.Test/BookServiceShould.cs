using TomekReads.Server.Data;
using TomekReads.Server.Data.Services;

namespace TomekReads.Server.Test
{
    [TestFixture(typeof(IBookService), typeof(BookDbContext))]
    public class BookServiceShould
    {
        private readonly IBookService _bookService;
        private readonly BookDbContext _bookDbContext;
        private BookService _service;

        public BookServiceShould()
        {

            _bookDbContext = new BookDbContext();
            _service = new BookService(_booDbContext);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllBooksShould()
        {
            var books = await _service.GetAllBooksAsync();
            //Assert.Equals(books.Leng, true);
        }

        [Test]
        public void TestTestShould()
        {
            var test = "test";
            var testResult = _service.TestTest();
            Assert.Equals(test, testResult);
        }
    }
}
