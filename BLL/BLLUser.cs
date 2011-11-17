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

        public void Del(User user)
        {
            dal.Del(user);
        }

        public DataTable Get()
        {
            return dal.Get();
        }

        public User GetById(int id)
        {
            return dal.GetById(id);
        }

        public IList<User> GetByName(string name)
        {
            return dal.GetByName(name);
        }

        public User GetByCode(string code)
        {
            return dal.GetByCode(code);
        }

        public bool IsExistWhileUpdate(string oldCode, string newCode)
        {
            return dal.IsExistWhileUpdate(oldCode, newCode);
        }

        public bool IsExist(string code)
        {
            return dal.IsExist(code);
        }

        public DataTable GetUserDegreePrice(string year, string mon)
        {
            return dal.GetUserDegreePrice(year, mon);
        }

        public DataTable GetUserDegree(string year, string mon)
        {
            return dal.GetUserDegree(year, mon);
        }

        public DataTable GetUserDegree(string year)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("name"));
            for (int i = 1; i <= 12; i++)
                dt.Columns.Add(new DataColumn("mon" + i.ToString()));
            for (int i = 1; i <= 12; i++)
            {
                DataTable dataTable = GetUserDegree(year, i.ToString());

                if (dataTable != null && dataTable.Rows.Count > 0)
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        if (i == 1)
                            dt.Rows.Add(dataTable.Rows[j]["name"], "", "", "", "", "", "", "", "", "", "", "", "");
                        dt.Rows[j][i] = dataTable.Rows[j]["degreevalue"];
                    }
            }
            return dt;
        }

        public DataTable GetUserMonthPayfor(string year)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("name"));
            for (int i = 1; i <= 12; i++)
                dt.Columns.Add(new DataColumn("mon" + i.ToString()));
            List<DataTable> listTb = new List<DataTable>();
            for (int i = 1; i <= 12; i++)
            {
                DataTable dataTable = GetUserDegree(year, i.ToString());
                listTb.Add(dataTable);
                DateTime dateTime = new DateTime(int.Parse(year), i, 1).AddMonths(-1);
                BLLPrice bll = new BLLPrice();
                DataTable lastYearDecDegree = null;
                if (i == 1)
                    lastYearDecDegree = GetUserDegree(dateTime.Year.ToString(), dateTime.Month.ToString());
                Price price = bll.Get(year, i.ToString());
                if (dataTable != null && dataTable.Rows.Count > 0)
                    for (int j = 0; j < dataTable.Rows.Count; j++)
                    {
                        if (i == 1)
                        {
                            dt.Rows.Add(dataTable.Rows[j]["name"], "", "", "", "", "", "", "", "", "", "", "", "");
                            if (dataTable.Rows[j]["degreevalue"] != DBNull.Value)
                                dt.Rows[j][i] = Math.Round((double.Parse(dataTable.Rows[j]["degreevalue"].ToString())
                                    - double.Parse(lastYearDecDegree.Rows[j]["degreevalue"].ToString())) * double.Parse(price.PriceValue), 2);
                        }
                        else
                        {
                            if (dataTable.Rows[j]["degreevalue"] != DBNull.Value && !string.IsNullOrEmpty(listTb[i - 2].Rows[j]["degreevalue"].ToString()))
                                dt.Rows[j][i] = Math.Round((double.Parse(dataTable.Rows[j]["degreevalue"].ToString())
                                    - double.Parse(listTb[i - 2].Rows[j]["degreevalue"].ToString())) * double.Parse(price.PriceValue), 2);
                        }
                    }
            }
            return dt;
        }
    }
}
