using System;
using System.Collections.Generic;
using System.Text;

namespace Wbs.Entity
{
    public class Degree
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int userId;
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int priceId;
        public int PriceId
        {
            get { return priceId; }
            set { priceId = value; }
        }

        private string degreeValue;
        public string DegreeValue
        {
            get { return degreeValue; }
            set { degreeValue = value; }
        }


        private Price price;
        public Price Price
        {
            get { return price; }
            set { price = value; }
        }

        private Degree previousDegree;
        public Degree PreviousDegree
        {
            get { return previousDegree; }
            set { previousDegree = value; }
        }
    }
}
