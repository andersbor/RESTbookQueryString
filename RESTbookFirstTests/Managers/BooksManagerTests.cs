using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTbookQueryString.Models;

namespace RESTbookQueryString.Managers.Tests
{
    [TestClass]
    public class BooksManagerTests
    {
        [TestMethod]
        public void TestItAll()
        // We cannot control the execution order of test methods.
        // unless we have only one test method ...
        {
            BooksManager manager = new BooksManager();

            List<Book> allBooks = manager.GetAll();
            Assert.AreEqual(3, allBooks.Count);

            Book book = manager.GetById(1);
            Assert.AreEqual("C# is nice", book.Title);

            Assert.IsNull(manager.GetById(100));

            Book newBook = new Book { Title = "Android Programing", Price = 17.85 };
            Book addedBook = manager.Add(newBook);
            Assert.AreEqual(4, addedBook.Id);
            Assert.AreEqual(4, manager.GetAll().Count);

            Book updates = new Book { Title = "Android Programming", Price = 18.1 };
            Book updatedBook = manager.Update(3, updates);
            Assert.AreEqual("Android Programming", updatedBook.Title);

            Assert.IsNull(manager.Update(100, updates));

            Book deletedBook = manager.Delete(3);
            Assert.AreEqual("Android Programming", deletedBook.Title);
            Assert.AreEqual(3, manager.GetAll().Count);

            Assert.IsNull(manager.Delete(100));
        }

        [TestMethod]
        public void QueryStringTest()
        {
            BooksManager manager = new BooksManager();

            List<Book> Cbooks = manager.GetAll(title: "C");
            Assert.AreEqual(2, Cbooks.Count);

            List<Book> noBooks = manager.GetAll(title: "None");
            Assert.AreEqual(0, noBooks.Count);

            List<Book> sortTitle = manager.GetAll(sortBy: "title");
            Assert.AreEqual("ABC for beginners", sortTitle[0].Title);

            List<Book> sortPrice = manager.GetAll(sortBy: "Price");
            Assert.AreEqual("C# is nice", sortPrice[0].Title);
        }
    }
}