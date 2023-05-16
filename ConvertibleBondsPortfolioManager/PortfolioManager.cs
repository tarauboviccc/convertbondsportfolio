using System;
using System.Collections.Generic;

namespace ConvertibleBondsPortfolioManager
{
    public class PortfolioManager
    {
        private List<Bond> holdings;

        public PortfolioManager()
        {
            holdings = new List<Bond>();
        }

        public void AddBond(string name, int quantity, double currentPrice, double conversionRatio)
        {
            Bond bond = new Bond(name, quantity, currentPrice, conversionRatio);
            holdings.Add(bond);
        }

        public void SellBond(string name, int quantity)
        {
            Bond bond = FindBondByName(name);
            if (bond != null)
            {
                if (quantity <= bond.Quantity)
                {
                    bond.Quantity -= quantity;
                    if (bond.Quantity == 0)
                        holdings.Remove(bond);
                }
                else
                {
                    Console.WriteLine("Error: Insufficient quantity to sell.");
                }
            }
            else
            {
                Console.WriteLine("Error: Bond not found.");
            }
        }

        public double CalculatePortfolioValue()
        {
            double totalValue = 0;
            foreach (Bond bond in holdings)
            {
                totalValue += bond.CurrentPrice * bond.Quantity;
            }
            return totalValue;
        }

        private Bond FindBondByName(string name)
        {
            foreach (Bond bond in holdings)
            {
                if (bond.Name == name)
                    return bond;
            }
            return null;
        }
    }

    public class Bond
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double CurrentPrice { get; set; }
        public double ConversionRatio { get; set; }

        public Bond(string name, int quantity, double currentPrice, double conversionRatio)
        {
            Name = name;
            Quantity = quantity;
            CurrentPrice = currentPrice;
            ConversionRatio = conversionRatio;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PortfolioManager portfolioManager = new PortfolioManager();

            // Sample usage
            portfolioManager.AddBond("Bond A", 100, 50.0, 0.9);
            portfolioManager.AddBond("Bond B", 50, 75.0, 0.8);
            portfolioManager.SellBond("Bond A", 50);

            double portfolioValue = portfolioManager.CalculatePortfolioValue();
            Console.WriteLine("Portfolio Value: $" + portfolioValue);
        }
    }
}
