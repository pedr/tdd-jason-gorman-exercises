 using System.Linq;
using System.Collections.Generic;
using System;

namespace Base.Chapter7
{
    public class MovieReviewReport
    {
        public string Title { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();

        public MovieReviewReport(string title)
        {
            Title = title;
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }

        public double AvgRating()
        {
            return Reviews.Average(r => (int)r.Rating);
        }

        public void AddReview(List<Review> reviews)
        {
            reviews.ForEach(r => AddReview(r));
        }

        public Dictionary<Rating, int> ReviewsByRating()
        {
            var dictionary = new Dictionary<Rating, int>()
            {
                { Rating.OneStar, 0 },
                { Rating.TwoStars, 0 },
                { Rating.ThreeStars, 0 },
                { Rating.FourStars, 0 },
                { Rating.FiveStars, 0 },
            };

            foreach (var review in Reviews) 
            {
                dictionary[review.Rating] = dictionary[review.Rating] + 1; 
            }

            return dictionary;
        }
    }
}