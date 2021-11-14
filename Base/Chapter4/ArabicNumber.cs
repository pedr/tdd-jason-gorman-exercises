using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Chapter4
{
    public class ArabicNumber
    {
        public static string ToRoman(int numberToBeConverted)
        {
            if (numberToBeConverted < 1)
            {
                throw new ArgumentException("value must be between 1 and 4000");
            }

            var list = new List<RomanConvertRule>
            {
                new RomanConvertRule(1000, "M"),
                new RomanConvertRule(900, "CM"),
                new RomanConvertRule(500, "D"),
                new RomanConvertRule(400, "CD"),
                new RomanConvertRule(100, "C"),
                new RomanConvertRule(90, "XC"),
                new RomanConvertRule(50, "L"),
                new RomanConvertRule(40, "XL"),
                new RomanConvertRule(10, "X"),
                new RomanConvertRule(9, "IX"),
                new RomanConvertRule(5, "V"),
                new RomanConvertRule(4, "IV"),
                new RomanConvertRule(1, "I"),    
            };

            var romanSymbol = new StringBuilder();

            foreach (var rule in list)
            {
                var result = rule.Reduce(numberToBeConverted);

                numberToBeConverted = result.ArabicValueLeft;
                romanSymbol.Append(result.RomanSymbol);
            }

            return romanSymbol.ToString();
        }

    }

    class RomanConvertRule
    {
        public RomanConvertRule(int equivalent, string symbol)
        {
            this.equivalent = equivalent;
            this.symbol = symbol;
        }

        private int equivalent { get; set; }

        private string symbol { get; set; }

        public RomanConvertResult Reduce(int valueToBeConverted)
        {
            var str = "";
            for (; valueToBeConverted >= equivalent; valueToBeConverted -= equivalent)
            {
                str += symbol;
            }

            return new RomanConvertResult(valueToBeConverted, str);
        }
        
    }

    class RomanConvertResult
    {
        public RomanConvertResult(int rest, string roman)
        {
            ArabicValueLeft = rest;
            RomanSymbol = roman;
        }

        public int ArabicValueLeft { get; set; }

        public string RomanSymbol { get; set; }
    }
}
