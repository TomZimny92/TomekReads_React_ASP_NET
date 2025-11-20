using TomekReads.Server.Data.Services;

namespace TomekReads.Server.Test
{
    public class BookServiceShould
    {
        private BookService _bookService;

        [SetUp]
        public void Setup()
        {
            _bookService = new BookService();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.Fail();
        }
    }
}
