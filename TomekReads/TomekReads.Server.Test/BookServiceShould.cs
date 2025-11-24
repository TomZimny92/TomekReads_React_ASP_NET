using TomekReads.Server.Data;
using TomekReads.Server.Data.Services;
using Moq;
using TomekReads.Server.Data.Models;

namespace TomekReads.Server.Test
{
    [TestFixture(typeof(IBookService), typeof(BookDbContext))]
    public class BookServiceShould
    {
        private Mock<BookDbContext> _bookDbContext;
        private Mock<BookService> _service;

        [SetUp]
        public void Setup()
        {
            _bookDbContext = new Mock<BookDbContext>();
            _service = new Mock<BookService>(_bookDbContext.Object);
        }

        [Test]
        public async Task GetAllBooksShould()
        {
            //var books = await _service.GetAllBooksAsync();
            //Assert.That(books, Is.Null);
            List<Book>? books = [];

            await _service
                .Setup(b => b.GetAllBooksAsync())
                .Returns(books);
                
        }

        [Test]
        public void TestTestShould()
        {
            var test = "rest";
            var testResult = _service.TestTest();
            Assert.That(test, Is.EqualTo(testResult));
        }

    }
}
