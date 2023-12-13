using BookManagerProject;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;

namespace BookManager.Tests
{
    public class BookManagerTests
    {
        [Fact]
        public void AddGenre_AddScienceFictionGenre_GenreSetContainsShienceFiction()
        {
            // Arrange

            var sut = new BookManagerProject.BookManager();

            //Act

            sut.AddGenre("Science Fiction");
            //Assert

            Assert.Contains("Science Fiction", sut.GetGenres());
        }

        [Fact]
        public void RemoveGenre_AddGenreMysteryThenDeleteThem_GenresSetDoesntContainsMysteryGenre()
        {
            //Arrange
            var sut = new BookManagerProject.BookManager();

            //Act
            sut.AddGenre("Mystery");
            sut.RemoveGenre("Mystery");

            //Assert
            Assert.DoesNotContain("Mystery", sut.GetGenres());
        }

        [Fact]
        public void AddBook_AddABook_BookAddedToList()
        {
            //Arrange
            var sut = new BookManagerProject.BookManager();
            var book = new Book("The Hobbit", "J.R.R. Tolkien", "Fantasy");
            List<Book> expectedBooksList = new List<Book> { book };

            //Act
            sut.AddBook(book);
            List<Book> actualBooksList = sut.GetBooks();

            //Assert
            Assert.Equal(expectedBooksList, actualBooksList);
            Assert.Contains(book, sut.GetBooks());

        }


    }
    
}
