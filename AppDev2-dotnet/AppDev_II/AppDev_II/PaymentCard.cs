using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev_II
{
    public class PaymentCard
    {
        // Instance
        private double balance;

        // Constructor
        public PaymentCard (double openingBalance)
        {
            this.balance = openingBalance;
        }

        // Override Method
        public override string ToString()
        {
            return $"The card has a balance of {balance} euros";
        }

        // Eat Lunch Method
        public void EatLunch()
        {
            if (balance >= 10.60) balance -= 10.60;
            else Console.WriteLine("Insuffecient Funds");
        }

        // Drink Coffee Method
        public void DrinkCoffee()
        {
            if (balance >= 2) balance -= 2;
            else Console.WriteLine("Insuffecient Funds");
        }

        // Adding Money
        public void AddMoney(double amount)
        {
            if (amount > 0)
            {
                if (balance + amount <= 150)
                {
                    balance += amount;
                }
            }
            else balance = 150;
        }
    }
}
