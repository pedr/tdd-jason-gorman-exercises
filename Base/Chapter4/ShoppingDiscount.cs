using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Base.Chapter4
{
    public class ShoppingDiscount
    {
        private readonly List<DiscountRule> discountRules = new List<DiscountRule>()
        {
            new DiscountRule(200, 0.1),
            new DiscountRule(100, 0.05)
        };
        private List<Item> items { get; set; }

        public ShoppingDiscount(List<Item> items)
        {
            this.items = items;
        }

        public double Calculate()
        {
            if (items.Count == 0)
            {
                return 0.0;
            }

            var totalGross = ItemsTotalGross();

            return ApplyDiscount(totalGross);
        }

        private double ItemsTotalGross()
        {
            return items.Aggregate(0.0, (acc, item) => acc + item.Total());
        }

        private double ApplyDiscount(double total)
        {
            foreach (var rule in discountRules.OrderByDescending(d => d.Threshold))
            {
                if (rule.IsApplicable(total))
                {
                    return rule.Apply(total); 
                }
            }

            return total;
        }
    }

    class DiscountRule
    {
        public double Threshold { get; private set; }
        private double Discount { get; set; }

        public DiscountRule(double threshold, double disccount)
        {
            Threshold = threshold;
            Discount = disccount;
        }

        public bool IsApplicable(double totalGross)
        {
            return totalGross > Threshold;
        }

        public double Apply(double totalGross)
        {
            return totalGross - totalGross * Discount;
        }
    }

    public class Item
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Item(int quantity, double price)
        {
            if (quantity < 1)
            {
                throw new ArgumentException("Quantity must be equal or bigger than one");
            }
            Quantity = quantity;
            Price = price;
        }

        public double Total() => Quantity * Price;
    }
}
