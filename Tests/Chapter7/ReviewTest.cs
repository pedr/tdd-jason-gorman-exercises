using Base.Chapter7;
using Xunit;

namespace Tests.Chapter7
{
    [Trait("Category", "MovieReviewReport")]
    public class ReviewTest
    {
        [Fact]
        public void should_be_able_to_create_anonymous_review()
        {
            var expected = "anonymous";

            var review = new Review();

            Assert.Equal(expected, review.Author);
        }

        [Fact]
        public void should_be_able_to_give_rating()
        {
            
            Rating rating = new Rating();

            var review = new Review(
                title: "DragonBall Evolution",
                rating: Rating.OneStar, 
                commentary: "Not really good, not enough action");

            Assert.NotNull(review.Rating);
            Assert.NotEqual(rating, review.Rating);
        }
    }
}