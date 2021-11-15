
using System.Collections.Generic;
using System.Linq;
using Base.Chapter7;
using Xunit;

namespace Tests.Chapter7
{
    /**
      Test-drive code to leave reviews for movies, with:
        - A rating from 1-5
        - The name of the reviewer (defaulted to “Anonymous” if not supplied)
        - The text of the review
      It should calculate an average rating for a movie, and also report
        the number of reviews for each rating.
     */
    [Trait("Category","MovieReviewReport")]
    public class MovieReviewReportTest
    {

        [Fact]
        public void should_be_able_to_create_review_report()
        {
            var expectedTitle = "The Shinning";

            var movieReviewReport = new MovieReviewReport(expectedTitle);

            Assert.NotNull(movieReviewReport);
            Assert.Equal(expectedTitle, movieReviewReport.Title);
        }

        [Fact]
        public void should_be_able_to_add_reviews()
        { 
            var anonymousReview = new Review();
            var movieReviewReport = new MovieReviewReport("The Matrix"); 
            
            movieReviewReport.AddReview(anonymousReview);

            Assert.Contains(anonymousReview, movieReviewReport.Reviews);
        }

        [Theory, MemberData(nameof(should_be_able_to_calculate_avg_rating_data))]
        public void should_be_able_to_calculate_avg_rating(List<Review> reviews, double expectedAverageRating)
        {
            var movieReviewReport = new MovieReviewReport("The Matrix"); 
            
            movieReviewReport.AddReview(reviews);

            Assert.Equal(expectedAverageRating, movieReviewReport.AvgRating(), 3);
        }

        public static IEnumerable<object[]> should_be_able_to_calculate_avg_rating_data 
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new List<Review> {
                            new Review("The Matrix", Rating.FourStars, ""),
                            new Review("The Matrix", Rating.FiveStars, "Neo is cool"),
                            new Review("The Matrix", Rating.FiveStars, ""),
                        },
                        4.667
                    },
                    new object[] {
                        new List<Review> {
                            new Review("The Matrix", Rating.OneStar, ""),
                            new Review("The Matrix", Rating.OneStar, "Neo is cool"),
                            new Review("The Matrix", Rating.FourStars, ""),
                        },
                        2.0
                    },
                };
            }
        }

        [Fact]
        public void should_display_reviews_counts_by_rating()
        {
            var expected = new Dictionary<Rating, int>()
            {
                { Rating.OneStar, 0 },
                { Rating.TwoStars, 0 },
                { Rating.ThreeStars, 0 },
                { Rating.FourStars, 2 },
                { Rating.FiveStars, 3 },
            };

            var reviewsDistribution = new List<Rating>()
            {
                Rating.FiveStars,
                Rating.FiveStars,
                Rating.FiveStars,
                Rating.FourStars,
                Rating.FourStars,
            };

            var movieReviewReport = new MovieReviewReport("Stalker");
            var reviews = reviewsDistribution.Select(rating => new Review("Stalker", rating, ""));
            movieReviewReport.AddReview(reviews.ToList());

            Assert.Equal(expected, movieReviewReport.ReviewsByRating());
        }
    }
}