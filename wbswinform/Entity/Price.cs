using System;
using System.Collections.Generic;
using System.Text;

namespace Wbs.Entity
{
    public class Price
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string year;
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        private string mon;
        public string Mon
        {
            get { return mon; }
            set { mon = value; }
        }

        private string priceValue;
        public string PriceValue
        {
            get { return priceValue; }
            set { priceValue = value; }
        }
    }
}
