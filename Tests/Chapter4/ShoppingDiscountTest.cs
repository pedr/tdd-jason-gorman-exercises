using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Base.Chapter4;
using Xunit;

namespace Tests.Chapter4
{
    /**
          Test-drive some code that will calculate the total net value of items
        in a shopping cart represented as a list of unit price and quantity –
        e.g., {{10.0, 5}, {25.5, 2}}, with the following discounts applied:
            1. If total gross value > £100, apply a 5% discount
            2. If total gross value > £200, apply a 10% discount
    */
    [Trait("Category","ShoppingDiscount")]
    public class ShoppingDiscountTest
    {
    
        [Fact]
        public void total_should_be_zero_if_list_is_empty()
        {
            var expected = 0;

            var itemList = new List<Item>();
            var shoppingPrice = new ShoppingDiscount(itemList);

            Assert.Equal(expected, shoppingPrice.Calculate());
        }

        [Theory, MemberData(nameof(total_from_one_item_should_be_equal_quantity_price_data))]
        public void total_from_one_item_should_be_equal_quantity_price_under_100(List<Item> items, double expected)
        {   
            var shoppingPrice = new ShoppingDiscount(items);

            Assert.Equal(expected, shoppingPrice.Calculate());
        }

        public static IEnumerable<object[]> total_from_one_item_should_be_equal_quantity_price_data
        {
            get
            {
                return new[]
                {
                    new object[] { new List<Item>() { new Item(1, 10) }, 10 },
                    new object[] { new List<Item>() { new Item(2, 10) }, 20 },
                    new object[] { new List<Item>() { new Item(3, 20) }, 60 },
                    new object[] { new List<Item>() { new Item(5, 5.5) }, 27.5 },
                };
            }
        }

        [Fact]
        public void total_over_100_should_have_five_percent_discount()
        {
            var expected = 118.75;
            var item = new Item(5, 25);
            var list = new List<Item> { item };
            var shopping = new ShoppingDiscount(list);

            Assert.Equal(expected, shopping.Calculate());
        }

        [Fact]
        public void total_over_200_shoul_have_ten_percent_discount()
        {
            var expected = 225;
            var item = new Item(10, 25);
            var list = new List<Item> { item };
            var shopping = new ShoppingDiscount(list);

            Assert.Equal(expected, shopping.Calculate());
        }
    }


    [Trait("Category","ShoppingDiscount")]
    public class ItemTest
    {
    
        [Fact]
        public void should_not_accept_less_than_one_quantity()
        {
            Assert.Throws<ArgumentException>(() => new Item(0, 100));
        }

        [Theory]
        [InlineData(5, 10, 50)]
        [InlineData(10, 20, 200)]
        [InlineData(5, 10.5, 52.5)]
        [InlineData(1, 27, 27)]
        public void total_should_be_quantity_multiplied_by_price(int quantity, double price, double expected)
        {
            var item = new Item(quantity, price);
         
            Assert.Equal(expected, item.Total());
        }
    }
}
