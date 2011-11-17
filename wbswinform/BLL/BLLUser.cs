using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Wbs.Entity;
using Wbs.DAL;

namespace Wbs.BLL
{
    public class BLLUser
    {
        private DALUser dal;

        public BLLUser()
        {
            dal = new DALUser();
        }

        public void Add(User user)
        {
            dal.Add(user);
        }

        public void Update(User user)
        {
            dal.Update(user);
        }

        public void Del(int id)
        {
            dal.Del(id);
        }

        public DataSet Get()
        {
            return dal.Get();
        }

        public DataSet GetById(int id)
        {
            return dal.GetById(id);
        }

        public DataSet GetByName(string name)
        {
            return dal.GetByName(name);
        }

        public DataSet GetByCode(string code)
        {
            return dal.GetByCode(code);
        }
    }
}
