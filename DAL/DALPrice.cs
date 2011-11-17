using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;

using Wbs.Entity;
using System.Data.Common;

namespace Wbs.DAL
{
    public class DALPrice
    {
        private string connStr;

        public DALPrice()
        {
            connStr = ConfigurationManager.ConnectionStrings["wbs"].ConnectionString;
        }

        public void Add(Price price)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                dbCom.CommandType = CommandType.Text;
                dbCom.Connection = dbConn;
                dbCom.CommandText = "insert into prices(yearValue,mon,priceValue,remark) values(?,?,?,?)";
                dbCom.Parameters.Add(new OleDbParameter("yearValue", price.YearValue));
                dbCom.Parameters.Add(new OleDbParameter("mon", price.Mon));
                dbCom.Parameters.Add(new OleDbParameter("priceValue", price.PriceValue));
                dbCom.Parameters.Add(new OleDbParameter("remark", price.Remark));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public IList<Price> Get()
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                dbCom.CommandText = "select id,yearValue,mon,priceValue,remark from prices";
                DataSet ds = new DataSet();
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                IDataReader dr = dbCom.ExecuteReader();
                IList<Price> prices = GetPriceFromDataReader(dr);
                dbConn.Close();

                return prices;
            }
        }

        public Price Get(string year, string mon)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;

                dbCom.CommandText = "select id,yearValue,mon,priceValue,remark from prices where yearValue=? and mon=?";
                dbCom.Parameters.Add(new OleDbParameter("yearValue", year));
                dbCom.Parameters.Add(new OleDbParameter("mon", mon));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                IDataReader dr = dbCom.ExecuteReader();

                Price price = null;
                IList<Price> prices = GetPriceFromDataReader(dr);
                if (prices.Count > 0)
                    price = prices[0];
                dbConn.Close();
                return price;
            }
        }

        private IList<Price> GetPriceFromDataReader(IDataReader dr)
        {
            IList<Price> prices = new List<Price>();
            while (dr.Read())
            {
                Price price = new Price();
                price.Id = int.Parse(dr["id"].ToString());
                price.YearValue = dr["yearvalue"].ToString();
                price.Mon = dr["mon"].ToString();
                price.PriceValue = dr["pricevalue"].ToString();
                price.Remark = dr["remark"].ToString();
                prices.Add(price);
            }
            return prices;
        }

        public void Update(Price price)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;

                dbCom.CommandText = "update prices set yearValue=?,mon=?,priceValue=?,remark=? where id=?";
                dbCom.Parameters.Add(new OleDbParameter("yearValue", price.YearValue));
                dbCom.Parameters.Add(new OleDbParameter("mon", price.Mon));
                dbCom.Parameters.Add(new OleDbParameter("priceValue", price.PriceValue));
                dbCom.Parameters.Add(new OleDbParameter("remark", price.Remark));
                dbCom.Parameters.Add(new OleDbParameter("id", price.Id));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public void Del(int id)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;

                dbCom.CommandText = "delete from prices where id=?";
                dbCom.Parameters.Add(new OleDbParameter("id", id));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public void Del(Price price)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;

                dbCom.CommandText = "delete from prices where id=?";
                dbCom.Parameters.Add(new OleDbParameter("id", price.Id));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }



        public bool IsExist(string year, string mon)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = "select count(1) from prices where yearValue =? and mon=?";
                dbCom.Parameters.Add(new OleDbParameter("code", year));
                dbCom.Parameters.Add(new OleDbParameter("code", mon));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                bool result = int.Parse(dbCom.ExecuteScalar().ToString()) > 0;
                dbConn.Close();
                return result;
            }
        }

        public bool IsExistWhileUpdate(string year, string mon, string id)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); 
                dbCom.Connection = dbConn;
                dbCom.CommandText = "select count(1) from prices where yearValue =? and mon=? and id<>?";
                dbCom.Parameters.Add(new OleDbParameter("year", year));
                dbCom.Parameters.Add(new OleDbParameter("mon", mon));
                dbCom.Parameters.Add(new OleDbParameter("id", id));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                bool result = int.Parse(dbCom.ExecuteScalar().ToString()) > 0;
                dbConn.Close();
                return result;
            }
        }
    }
}
