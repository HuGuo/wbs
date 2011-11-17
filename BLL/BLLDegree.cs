using System;
using System.Collections.Generic;
using System.Text;

using Wbs.DAL;
using Wbs.Entity;

namespace Wbs.BLL
{
    public class BLLDegree
    {
        public DALDegree dal;

        public BLLDegree()
        {
            dal = new DALDegree();
        }

        public void Add(Degree degree)
        {
             dal.Add(degree);
        }

        public IList<Degree> Get()
        {
            return dal.Get();
        }

        public IList<Degree> Get(int userId)
        {
            return dal.Get(userId);
        }

        public void Update(Degree degree)
        {
            dal.Update(degree);
        }

        public void Del(int id)
        {
            dal.Del(id);
        }

        public void Del(User user)
        {
            dal.Del(user);
        }

        public bool IsExist(string year, string mon)
        {
            return dal.IsExist(year, mon);
        }

        public bool IsExistWhileUpdate(Price price)
        {
            return dal.IsExistWhileUpdate(price);
        }

        public bool IsExistWhileUpdate(string year, string mon, int id)
        {
            return dal.IsExistWhileUpdate(year, mon, id);
        }

        public Degree Get(int userId, string year, string mon)
        {
            return dal.Get(userId, year, mon);
        }

    }
}
