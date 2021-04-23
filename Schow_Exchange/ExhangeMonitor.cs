using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schow_Exchange
{
    class ExhangeMonitor
    {
        int _counter = 0;
        float _total = 0;

        public void Monitor(float value, string currencyType)
        {
            // Converting all values to USD
            value = Convert2USD(value, currencyType);
            // Updating the total amount converted
            UpdateTotal(value);
            // Updating the conversion counter
            UpdateCounter();
        }

        private float Convert2USD(float value, string currencyType) 
        {
            // Checking to see if the value is currently in USD, and converting it if it's not
            if (currencyType.ToLower() != "usd")
            {
                value = Exchanger.Converter(value, currencyType, "usd");
            }
            return value;
        }

        private void UpdateTotal(float value)
        {
            // Adding the newly converted value to the total converted.
            _total += value;
        }

        public float GetTotal()
        {
            // Returning the total converted
            return _total;
        }

        private void UpdateCounter()
        {
            // Adding one to the conversion counter
            _counter++;
        }

        public int GetCounter()
        {
            // returning the conversion counter
            return _counter;
        }
    }
}