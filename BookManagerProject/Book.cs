using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerProject
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public Book() { }

        public Book(string title, string author, string genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} by {Author}. {Genre}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Book) { return false; }

            return ((Title.Equals(((Book)obj).Title)) && (Author.Equals(((Book)obj).Author)) && (Genre.Equals(((Book)obj).Genre)));
        }
    }
}