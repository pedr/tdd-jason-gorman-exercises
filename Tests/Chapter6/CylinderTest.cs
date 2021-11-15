using System;
using Base.Chapter6;
using Xunit;

namespace Tests.Chapter4
{
    /**
          Writing the assertions first and working backwards to the set-up,
        test-drive some code to calculate how much water will be needed
        to fill the following
        - Cylinder
     */
    [Trait("Category","CalculateArea")]
    public class CylinderTest
    {
        [Fact]
        public void should_not_create_empty_cube()
        {
            Assert.Throws<ArgumentException>(() => new Cylinder(1, 0));
            Assert.Throws<ArgumentException>(() => new Cylinder(0, 1));
            Assert.Throws<ArgumentException>(() => new Cylinder(0, 0));
        }

        [Theory]
        [InlineData(1, 1, 3.14)]
        [InlineData(2, 2, 25.12)]
        [InlineData(2, 3, 37.68)]
        [InlineData(1, 10, 31.4)]
        public void cylinder_volume_is_height_versus_radius_cube_versus_pi(double radius, double height, double expectedVolume)
        {
            var cylinder = new Cylinder(radius, height);

            var result = cylinder.CalculateVolume();

            Assert.Equal(expectedVolume, result, 1);
        }
   }
}