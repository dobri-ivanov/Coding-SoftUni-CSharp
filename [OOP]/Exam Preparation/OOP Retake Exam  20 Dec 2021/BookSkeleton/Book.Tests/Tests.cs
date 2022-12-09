namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        private Book book;
        private string name = "MyTestBook";
        private string author = "TestAuthor";
        [SetUp]
        public void SetUp()
        {
            book = new Book(name, author);
        }

        [Test]
        public void Constructor()
        {
            Assert.AreEqual(name, book.BookName);
        }
        [Test]
        public void Constructor2()
        {
            Assert.AreEqual(author, book.Author);
        }
        [Test]
        public void Constructor3()
        {
            book = new Book(name, author);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Name(string testName)
        {
            Assert.Catch<ArgumentException>(() => book = new Book(testName, author));
        }
        [TestCase("Name")]
        public void Name2(string testName)
        {
            book = new Book(testName, author);
            Assert.Pass();
        }
        [TestCase(null)]
        [TestCase("")]
        public void Author(string testAuthor)
        {
            Assert.Catch<ArgumentException>(() => book = new Book(name, testAuthor));
        }
        [TestCase("Author")]
        public void Author2(string testAuthor)
        {
            book = new Book(testAuthor, testAuthor);
            Assert.Pass();

        }
        [TestCase(35, "Text")]
        public void Add(int number, string text)
        {
            book.AddFootnote(number, text);
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [TestCase(35, "Text")]
        public void Add2(int number, string text)
        {
            book.AddFootnote(number, text);
            Assert.Catch<InvalidOperationException>(() => book.AddFootnote(number, "Text"));
        }
        [TestCase(35, "Text")]
        public void Add3(int number, string text)
        {
            book.AddFootnote(number, "Text");
            string output = book.FindFootnote(number);
            Assert.IsTrue(output != null);
        }
        [TestCase(35, "Text")]
        public void Find(int number, string text)
        {
            book.AddFootnote(number, "Text");
            string output = book.FindFootnote(number);
            string expected = $"Footnote #{number}: {text}";
            Assert.AreEqual(expected, output);
        }
        [TestCase(35, "Text")]
        public void Find2(int number, string text)
        {
            Assert.Catch<InvalidOperationException>(() => book.FindFootnote(number));
        }
        [TestCase(35, "Text")]
        public void Alter(int number, string text)
        {
            Assert.Catch<InvalidOperationException>(() => book.AlterFootnote(number, text));
        }
    }
}