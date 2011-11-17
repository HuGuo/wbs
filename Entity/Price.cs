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

        private string yearValue;
        public string YearValue
        {
            get { return yearValue; }
            set { yearValue = value; }
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

        private string remark;
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
