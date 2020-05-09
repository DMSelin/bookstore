using Moq;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookStore.Tests
{
    public class BookServicesTests
    {   
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor (It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "") });


            var bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-54321";
            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, Book => Assert.Equal(1, Book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitle()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "") });


            var bookService = new BookService(bookRepositoryStub.Object);
            var invalidIsbn = "12345-54321";
            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, Book => Assert.Equal(2, Book.Id));
        }
    }
}
