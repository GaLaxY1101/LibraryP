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

        [Fact]
        public void RemoveBook_RemoveBookByTitle_BookWasRemovedFromBooksList()
        {
            //Arrange
            var sut = new BookManagerProject.BookManager();

            var book = new Book("The Hobbit", "J.R.R. Tolkien", "Fantasy");
            var book2 = new Book("Harry Potter", "Joahn Rowling", "Fantasy");

            //Act

            sut.AddBook(book);
            sut.AddBook(book2);

            sut.RemoveBook("The Hobbit");

            //Assert
            Assert.DoesNotContain(book, sut.GetBooks());

        }

        [Fact]
        public void AddToFavorites_AddBookWhichNotInBooksList_ThrowArgumentException()
        {
            //Arrange 
            var sut = new BookManagerProject.BookManager();

            var book = new Book("The Hobbit", "J.R.R. Tolkien", "Fantasy");
            var book2 = new Book("Harry Potter", "Joahn Rowling", "Fantasy");

            //Act 
            sut.AddBook(book);
            sut.AddBook(book2);

            //Assert
            Assert.Throws<ArgumentException>(() => sut.AddToFavorites("1984"));

        }

        [Fact]
        public void AddToFavorites_AddBookToFavorites_AddedSuccessfully()
        {
            //Arrange 
            var sut = new BookManagerProject.BookManager();

            var book = new Book("The Hobbit", "J.R.R. Tolkien", "Fantasy");
            var book2 = new Book("Harry Potter", "Joahn Rowling", "Fantasy");

            List<Book> expectedFavoritesList = new List<Book>() { book, book2 };

            //Act 
            sut.AddBook(book);
            sut.AddBook(book2);

            sut.AddToFavorites(book.Title);
            sut.AddToFavorites(book2.Title);

            var actualFavoritesList = sut.GetFavorites();

            //Assert
            Assert.Equal(expectedFavoritesList, actualFavoritesList);
        }



    }

}
