using Store;
using System;
using Xunit;

namespace BookStore.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("   ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISB 123");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBn 12332-14321");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBn 12332-14321 132");

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnTrue()
        {
            bool actual = Book.IsIsbn("xxx ISBn 12332-14321 xxx");

            Assert.False(actual);
        }

    }
}
