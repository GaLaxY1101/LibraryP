using BookManagerProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Tests
{
    public class BookTests
    {
        [Fact]
        public void Equals_InstanceWithTheSameFieldsAreEquals_ReturnTrue()
        {
            //Arrange 
            var sut = new Book("Harry Potter", "Joahn Rowling", "Fantasy");
            
            var expected = true;
            
            //Act

            var actual = sut.Equals(new Book("Harry Potter", "Joahn Rowling", 		"Fantasy"));

            //Arrange
            Assert.Equal(expected, actual);
        
        }

        [Fact]
        public void Equals_InstancesWithDifferentFieldsAreNotEquals_ReturnFalse()
        {
            //Arrange
            var sut = new Book("SomeTitle", "SomeAuthor", "Genre");

            var expected = false;

            //Act
            var actual = sut.Equals(new Book("Title", "Author", "Genre"));

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToString_CorrectToStringFormat()
        {
            //Arrange
            var sut = new Book("Harry Potter", "Joahn Rowling", "Fantasy");
            var expected = "Harry Potter by Joahn Rowling. Fantasy";
            
            //Act
            var actual = sut.ToString();

            //Assert 
            Assert.Equal(expected, actual);
        }
    }
}
