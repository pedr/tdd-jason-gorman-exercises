
using System;

namespace Base.Chapter7
{
    public class Review
    {
        public Review()
        {
            Author = "anonymous";
        }

        public Review(string title, Rating rating, string commentary)
        {
            if (!Enum.IsDefined(typeof(Rating), rating))
            {
                throw new ArgumentException("Rating is not a valid enum value");
            }

            Title = title;
            Rating = rating;
            Commentary = commentary;
        }

        public string Author { get; }
        public string Title { get; }
        public Rating Rating { get; }
        public string Commentary { get; }
    }
}