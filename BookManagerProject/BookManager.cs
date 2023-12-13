using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerProject
{
    public class BookManager
    {
        private HashSet<string> genres = new HashSet<string>();
        private List<Book> books = new List<Book>();
        private HashSet<Book> favorites = new HashSet<Book>();

        public void AddGenre(string genre)
        {
            genres.Add(genre);
        }

        public HashSet<string> GetGenres() => new HashSet<string>(genres);

        public void RemoveGenre(string genre)
        {
            genres.Remove(genre);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(string title)
        {
            books.RemoveAll(book => book.Title == title);
        }

        public void AddToFavorites(string title)
        {
            if (books.Any(book => book.Title == title))
            {
                favorites.Add(books.Where(book => book.Title == title).FirstOrDefault());
            }
            else
            {
                throw new ArgumentException($"There is no book called {title} in the list.");
            }
        }

        public void RemoveFromFavorites(string title)
        {
            if (favorites.Any(book => book.Title == title))
            {
                favorites.Remove(favorites.Where(book => book.Title == title).FirstOrDefault());
            }
            else
            {
                throw new ArgumentException($"There is no book called {title} in the list.");
            }
        }

        public List<Book> GetBooks()
        {
            return new List<Book>(books);
        }

        public List<Book> GetFavorites()
        {
            return new List<Book>(favorites);
        }

        public List<Book> GetSortedFavorites()
        {
            return favorites.OrderByDescending(book => book.Title).ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            return books
                .Where(book => book.Genre == genre)
                .OrderByDescending(book => book.Title)
                .ToList();
        }
    }
}