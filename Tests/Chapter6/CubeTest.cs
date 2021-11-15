using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Base.Chapter4;
using Base.Chapter6;
using Xunit;

namespace Tests.Chapter4
{
    /**
          Writing the assertions first and working backwards to the set-up,
        test-drive some code to calculate how much water will be needed
        to fill the following
        - Cube
     */
    [Trait("Category","CalculateArea")]
    public class CubeTest
    {
        [Fact]
        public void should_not_create_empty_cube()
        {
            Assert.Throws<ArgumentException>(() => new Cube(0, 0, 0));
        }

        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(2, 2, 2, 8)]
        [InlineData(2, 3, 2.5, 15)]
        [InlineData(1, 1, 10, 10)]
        public void cube_area_is_side_versus_side_versus_side(double x, double y, double z, double totalArea)
        {
            var expected = totalArea;
            var cube = new Cube(x, y, z);

            var result = cube.CalculateArea();

            Assert.Equal(expected, result);
        }
   }
}