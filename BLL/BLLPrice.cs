using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Wbs.Entity;
using Wbs.DAL;

namespace Wbs.BLL
{
    public class BLLPrice
    {
        private DALPrice dal;

        public BLLPrice()
        {
            dal = new DALPrice();
        }

        public void Add(Price price)
        {
            dal.Add(price);
        }
        public IList<Price> Get()
        {
            return dal.Get();
        }

        public Price Get(string year, string mon)
        {
            return dal.Get(year, mon);
        }

        public void Update(Price price)
        {
            dal.Update(price);
        }
        public void Del(int id)
        {
            dal.Del(id);
        }

        public void Del(Price price)
        {
            dal.Del(price);
        }

        public bool IsExist(string year, string mon)
        {
            return dal.IsExist(year, mon);
        }

        public bool IsExistWhileUpdate(string year, string mon, string id)
        {
            return dal.IsExistWhileUpdate(year, mon, id);
        }

        public bool IsExistWhileUpdate(Price price)
        {
            return dal.IsExistWhileUpdate(price.YearValue, price.Mon, price.Id.ToString());
        }
    }
}
