using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This program will take an input by the User of purchased packages, calculate the appropriate discount amount, display
//the discount amount, and display the total to the User.
namespace Project_1
{
    class Program
    {
        //Main Module where the main variables are delcared and where main modules are utilized.
        static void Main(string[] args)
        {
            //Main Module Variables
            int packages_Purchased = 0;
            double discount_Amount = 0;
            double package_Price = 99;

            //Program Modules (These will be explained above each module)
            opening_Message();
            packages_Purchased = number_Packages_Purchased();
            discount_Amount = calculate_Discount(packages_Purchased, package_Price);
            show_Discount(discount_Amount);
            calculate_Total(packages_Purchased, discount_Amount, package_Price);

        }
        //This Module will display the first opening Message to the User.
        static void opening_Message()
        {
            Console.WriteLine("A software company sells a package for $99 each. Quantity discounts are calculated by the number of packages sold.");
        }
        //This Module will take a User input of the number of packages purchased and either return the correct variable to be stored
        //or show an error message if the input is incorrect.
        static int number_Packages_Purchased()
        {
            int packages_Purchased = 0;

            Console.WriteLine("Please enter the number of packages purchased: ");
            while (!int.TryParse(Console.ReadLine(), out packages_Purchased) || packages_Purchased < 1)
                error();
            return packages_Purchased;
        }
        //This Module will calculate the total Discount amount depending on the User input and return the amount to a variable to 
        //be stored.
        static double calculate_Discount(int packages_Purchased, double package_Price)
        {
            double discount_Amount = 0;

            //This IF statement will calculate no discount.
            if (packages_Purchased < 10)
            {
                discount_Amount = 0;
            }
            //This IF statement will calculate a 20% discount.
            if (packages_Purchased > 9 && packages_Purchased < 20)
            {
                double discount_Percentage = 0.20;

                discount_Amount = (packages_Purchased * package_Price) * discount_Percentage;
            }
            //This IF statement will calculate a 30% discount.
            if (packages_Purchased > 19 && packages_Purchased < 50)
            {
                double discount_Percentage = 0.30;

                discount_Amount = (packages_Purchased * package_Price) * discount_Percentage;
            }
            //This IF statement will calculate a 40% discount.
            if (packages_Purchased > 49 && packages_Purchased < 100)
            {
                double discount_Percentage = 0.40;

                discount_Amount = (packages_Purchased * package_Price) * discount_Percentage;
            }
            //This IF statement will calculate a 50% discount.
            if (packages_Purchased > 99)
            {
                double discount_Percentage = 0.50;

                discount_Amount = (packages_Purchased * package_Price) * discount_Percentage;
            }

            return discount_Amount;
        }
        //This Module will take the returned discount_Amount variable and display a message for the Discount Total. 
        static void show_Discount(double discount_Amount)
        {
            Console.WriteLine("Discount Total: {0:C}", discount_Amount);
        }
        //This Module will take the returned packages_Purchased variable, returned discount_Amount variable, and package_Price variable,
        //calculate the total Amount, and display a message for the total Amount.
        static void calculate_Total(int packages_Purchased, double discount_Amount, double package_Price)
        {
            double total_Amount = (packages_Purchased * package_Price) + discount_Amount;
            Console.WriteLine("Total Amount: {0:C}", total_Amount);
        }
        //This Module will display an error if the User inputs an incorrect datatype.
        static void error()
        {
            Console.WriteLine("ERROR: Please enter a valid number! **Packages Purchased must be greater than 0**");
        }
    }
}
