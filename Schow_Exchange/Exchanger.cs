using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schow_Exchange
{
    static class Exchanger
    {
        public static float Converter(float value, string convertFrom, string convertTo)
        {
            // Sorting inputs, converting, and returning the converted value.
            value = Sorter(value, convertFrom, convertTo);
            return value;
        }

        private static float Sorter(float value, string convertFrom, string convertTo)
        {
            // Figuring out what the initial currency is and what it should be converted to,
            // and then calling the correct conversion method accordingly
            if (convertFrom.ToLower() == "usd" && convertTo.ToLower() == "gbp")
            {
                value = USD_GBP(value);
            } else if (convertFrom.ToLower() == "usd" && convertTo.ToLower() == "can")
            {
                value = USD_CAN(value);
            } else if (convertFrom.ToLower() == "usd" && convertTo.ToLower() == "eur")
            {
                value = USD_EUR(value);
            } else if (convertFrom.ToLower() == "gbp" && convertTo.ToLower() == "usd")
            {
                value = GBP_USD(value);
            } else if (convertFrom.ToLower() == "gbp" && convertTo.ToLower() == "can")
            {
                value = GBP_CAN(value);
            } else if (convertFrom.ToLower() == "gbp" && convertTo.ToLower() == "eur")
            {
                value = GBP_EUR(value);
            } else if (convertFrom.ToLower() == "can" && convertTo.ToLower() == "usd")
            {
                value = CAN_USD(value);
            } else if (convertFrom.ToLower() == "can" && convertTo.ToLower() == "gbp")
            {
                value = CAN_GBP(value);
            } else if (convertFrom.ToLower() == "can" && convertTo.ToLower() == "eur")
            {
                value = CAN_EUR(value);
            } else if (convertFrom.ToLower() == "eur" && convertTo.ToLower() == "usd")
            {
                value = EUR_USD(value);
            } else if (convertFrom.ToLower() == "eur" && convertTo.ToLower() == "gbp")
            {
                value = EUR_GBP(value);
            } else if (convertFrom.ToLower() == "eur" && convertTo.ToLower() == "can")
            {
                value = EUR_CAN(value);
            }
            return value;
        }

        // Conversion methods for each of the different combinations
        // Each one multiplies the input value by its conversion ratio
        // and then returns the new value
        private static float USD_GBP(float value)
        {
            value = value * 0.72523f;
            return value;
        }
        private static float USD_CAN(float value)
        {
            value = value * 1.25427f;
            return value;
        }
        private static float USD_EUR(float value)
        {
            value = value * 0.83572f;
            return value;
        }
        private static float GBP_USD(float value)
        {
            value = value * 1.37887f;
            return value;
        }
        private static float GBP_CAN(float value)
        {
            value = value * 1.72947f;
            return value;
        }
        private static float GBP_EUR(float value)
        {
            value = value * 1.15195f;
            return value;
        }
        private static float CAN_USD(float value)
        {
            value = value * 0.79728f;
            return value;
        }
        private static float CAN_GBP(float value)
        {
            value = value * 0.57848f;
            return value;
        }
        private static float CAN_EUR(float value)
        {
            value = value * 0.66645f;
            return value;
        }
        private static float EUR_USD(float value)
        {
            value = value * 1.19648f;
            return value;
        }
        private static float EUR_GBP(float value)
        {
            value = value * 0.86826f;
            return value;
        }
        private static float EUR_CAN(float value)
        {
            value = value * 1.50040f;
            return value;
        }
    }
}