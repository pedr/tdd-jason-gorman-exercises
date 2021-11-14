using System;
using System.ComponentModel;
using Base.Chapter4;
using Xunit;

namespace Tests.Chapter4
{
    /**
        Test-drive some code that will convert integers from 1 to
        4,000 into Roman Numerals
    */
    [Category("ArabicNumber")]
    public class ArabicNumberTest
    {
        [Fact]
        public void should_not_convert_zero()
        {
            Assert.Throws<ArgumentException>(() => ArabicNumber.ToRoman(0));
        }

        [Theory]
        [InlineData(15, "XV")]
        [InlineData(16, "XVI")]
        [InlineData(18, "XVIII")]
        public void number_over_fifteen_should_include_X_and_other_symbols(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(10, "X")]
        [InlineData(19, "XIX")]
        [InlineData(20, "XX")]
        [InlineData(26, "XXVI")]
        [InlineData(38, "XXXVIII")]
        [InlineData(39, "XXXIX")]
        public void number_over_ten_and_under_forty_should_include_X(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(15, "XV")]
        [InlineData(17, "XVII")]
        [InlineData(28, "XXVIII")]
        public void number_over_five_and_under_nine_should_include_V(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]
        public void rest_of_number_is_less_than_three_should_include_I(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(14, "XIV")]
        [InlineData(24, "XXIV")]
        public void rest_of_number_is_four_should_include_IV(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(9, "IX")]
        [InlineData(19, "XIX")]
        [InlineData(29, "XXIX")]
        public void rest_of_number_is_NINE_should_include_IX(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(40, "XL")]
        [InlineData(43, "XLIII")]
        [InlineData(50, "L")]
        [InlineData(80, "LXXX")]
        [InlineData(89, "LXXXIX")]
        public void number_over_40_and_under_90_should_include_L(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(90, "XC")]
        [InlineData(112, "CXII")]
        [InlineData(200, "CC")]
        [InlineData(280, "CCLXXX")]
        public void number_over_90_should_include_C(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }


        [Theory]
        [InlineData(400, "CD")]
        [InlineData(414, "CDXIV")]
        public void number_over_400_should_include_CD(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(500, "D")]
        [InlineData(550, "DL")]
        [InlineData(888, "DCCCLXXXVIII")]
        public void number_over_500_should_include_D(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(900, "CM")]
        [InlineData(909, "CMIX")]
        [InlineData(999, "CMXCIX")]
        public void number_over_900_should_include_CM(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }

        [Theory]
        [InlineData(1000, "M")]
        [InlineData(1600, "MDC")]
        [InlineData(2720, "MMDCCXX")]
        [InlineData(3999, "MMMCMXCIX")]
        public void number_over_1000_should_include_M(int arabic, string roman)
        {
            var result = ArabicNumber.ToRoman(arabic);

            Assert.Equal(roman, result);
        }
    }
}
