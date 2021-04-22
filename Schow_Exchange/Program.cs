using System;
using System.Globalization;

namespace Schow_Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            string initC;
            string newC;
            float currencyValue;
            float convertedValue;
            bool cont = false;
            ExhangeMonitor em = new ExhangeMonitor();
            
            do
            {
                // Getting the initial currency
                initC = InitCurrency();
                // Getting the initial value
                currencyValue = InitValue(initC);
                // Getting the currency to convert to
                newC = ConvertTo();
                // Converting the value to the new currency
                convertedValue = Exchanger.Converter(currencyValue, initC, newC);
                // Updating everything in ExchangeMonitor
                em.Monitor(convertedValue, newC);
                // Presenting the converted currency amount
                PresentConversion(currencyValue, convertedValue, initC, newC);
                // Asking if the user would like to continue or not
                cont = Quit();
            } while (cont == true);
            // Reporting # of conversions and total converted in USD
            Report(em);
        }

        static string InitCurrency()
        {
            string firstCurrency;
            bool successful;
            do
            {
                // Asking what the user would like to convert from and receiving response
                Console.WriteLine("What currency would you like to convert from?" +
                    "\n- USD - GBP - CAN - EUR - " +
                    "\nEnter one of the above:");
                firstCurrency = Console.ReadLine();
                // Checking response and assigning selected currency
                successful = CurrencyChecker(ref firstCurrency);
            } while (successful == false);
            Console.Clear();
            return firstCurrency;
        }

        static string ConvertTo()
        {
            string secondCurrency;
            bool successful;
            do
            {
                // Asking what the user would like to convert to and receiving response
                Console.WriteLine("What currency would you like to convert to?" +
                    "\n- USD - GBP - CAN - EUR - " +
                    "\nEnter one of the above:");
                secondCurrency = Console.ReadLine();
                // Checking response and assigning selected currency
                successful = CurrencyChecker(ref secondCurrency);
            } while (successful == false);
            Console.Clear();
            return secondCurrency;
        }
        static bool CurrencyChecker(ref string currencyType)
        {
            bool success;
            
            // checking to see if response is correct,
            // and assigning it to a culture keyword if it is
            if (currencyType.ToLower() == "usd")
            {
                currencyType = "en-US";
                success = true;               
            }
            else if (currencyType.ToLower() == "gbp")
            {
                
                currencyType = "en-GB";
                success = true;
            }
            else if (currencyType.ToLower() == "can")
            {
                currencyType = "en-CA";
                success = true;
            }
            else if (currencyType.ToLower() == "eur")
            {
                currencyType = "en-FR";
                success = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Please try again.");
                Console.WriteLine();
                success = false;
            }
            return success;
        }

        static float InitValue(string CurrencyType)
        {
            bool correctInput;
            string userInput;
            float firstValue;
            do
            {
                // Getting the value the user wants converted, and checking to see that it is valid
                Console.WriteLine("Enter the amount being converted:");
                userInput = Console.ReadLine();
                correctInput = float.TryParse(userInput, out firstValue);
                if (correctInput == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input. Please try again.");
                    Console.WriteLine();
                }
            } while (correctInput == false);
            Console.Clear();
            return firstValue;
        }

        static void PresentConversion(float startVal, float endVal, string startCur, string endCur)
        {
            // Presenting how much their initial value is worth in the converted currency,
            // using CultureInfo to determine how the currency should be formatted

            // DISCLAIMER: From what I've read, certain Visual Studio settings make the Euro symbol look like a question mark.
            // I'm trying to debug this on my end, but it might be a settings thing, not a code thing.
            CultureInfo startCul = new CultureInfo(startCur);
            CultureInfo endCul = new CultureInfo(endCur);
            Console.WriteLine("Your initial value of " + startVal.ToString("C", startCul) + " converts to " + endVal.ToString("C", endCul) + ".");
            Console.WriteLine();
        }

        static bool Quit()
        {
            bool cont = false;
            bool valid;
            string response;

            do
            {
                // Asking the user if they would like to continue or not, and verifying their response
                Console.WriteLine("Would you like to continue? Y/N");
                response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    cont = true;
                    valid = true;
                }
                else if (response.ToLower() == "n")
                {
                    cont = false;
                    valid = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please try again.");
                    Console.WriteLine();
                    valid = false;
                }
            } while (valid == false);
            Console.Clear();
            return cont;
        }

        static void Report(ExhangeMonitor em)
        {
            int totalConversions;
            float totalUS;
            
            // Gathering data from ExchangeMonitor
            totalConversions = em.GetCounter();
            totalUS = em.GetTotal();

            // Presenting ExchangeMonitor data
            Console.Clear();
            Console.WriteLine("Total Conversions: " + totalConversions);
            Console.WriteLine(String.Format("Total Converted (in USD): {0:C2}", totalUS));
            Console.WriteLine();
            Console.WriteLine("Have a nice day.");
        }
    }
}