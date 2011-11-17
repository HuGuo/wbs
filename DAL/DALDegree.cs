using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;

using Wbs.Entity;

namespace Wbs.DAL
{
    public class DALDegree
    {
        private string connStr;

        public DALDegree()
        {
            connStr = ConfigurationManager.ConnectionStrings["wbs"].ConnectionString;
        }

        public void Add(Degree degree)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                dbCom.CommandType = CommandType.Text;
                dbCom.Connection = dbConn;
                dbCom.CommandText = "insert into Degree(userId,priceId,degreevalue) values(?,?,?)";
                dbCom.Parameters.Add(new OleDbParameter("userId", degree.UserId));
                dbCom.Parameters.Add(new OleDbParameter("priceId", degree.PriceId));
                dbCom.Parameters.Add(new OleDbParameter("degreeValue", degree.DegreeValue));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public IList<Degree> Get()
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                StringBuilder sb = new StringBuilder();
                sb.Append("select a.id,a.userId,a.priceId,a.degreevalue,b.yearvalue,b.mon,b.priceValue ")
                    .Append("from Degree as a,prices as b,Degree c")
                    .Append("where a.priceId=b.id");
                dbCom.CommandText = sb.ToString();
                DataSet ds = new DataSet();
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                IDataReader dr = dbCom.ExecuteReader();
                IList<Degree> degrees = GetDegree(dr);
                dbConn.Close();

                return degrees;
            }
        }

        public Degree Get(int userId, string year, string mon)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                StringBuilder sb = new StringBuilder();
                sb.Append("select a.id,a.userId,a.priceId,a.degreevalue,b.yearvalue,b.mon,b.priceValue ")
                  .Append("from Degree as  a,prices as b ")
                  .Append("where a.priceId=b.id and a.userId=? and b.yearvalue=? and b.mon=?");
                dbCom.CommandText = sb.ToString();
                dbCom.Parameters.Add(new OleDbParameter("userId", userId));
                dbCom.Parameters.Add(new OleDbParameter("year", year));
                dbCom.Parameters.Add(new OleDbParameter("mon", mon));
                DataSet ds = new DataSet();
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                IDataReader dr = dbCom.ExecuteReader();
                Degree degree = null;
                IList<Degree> degrees = GetDegree(dr);
                if (degrees.Count > 0)
                    degree = degrees[0];
                dbConn.Close();
                return degree;
            }
        }

        public IList<Degree> Get(int userId)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                StringBuilder sb = new StringBuilder();
                sb.Append("select a.id,a.userId,a.priceId,a.degreevalue,b.yearvalue,b.mon,b.priceValue ")
                    .Append("from Degree as  a,prices as b ")
                    .Append("where a.priceId=b.id and a.userId=? ");
                dbCom.CommandText = sb.ToString();
                DataSet ds = new DataSet();
                dbCom.Parameters.Add(new OleDbParameter("userId", userId));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                IDataReader dr = dbCom.ExecuteReader();
                IList<Degree> degrees = GetDegree(dr);
                dbConn.Close();

                return degrees;
            }
        }
        private IList<Degree> GetDegree(IDataReader dr)
        {
            IList<Degree> degrees = new List<Degree>();
            while (dr.Read())
            {
                Degree degree = new Degree();
                degree.Id = int.Parse(dr["id"].ToString());
                degree.PriceId = int.Parse(dr["priceid"].ToString());
                degree.UserId = int.Parse(dr["userId"].ToString());
                degree.DegreeValue = dr["degreevalue"].ToString();
                Price price = new Price();
                price.Id = int.Parse(dr["priceid"].ToString());
                price.YearValue = dr["yearvalue"].ToString();
                price.Mon = dr["mon"].ToString();
                price.PriceValue = dr["pricevalue"].ToString();
                degree.Price = price;
                degrees.Add(degree);
            }

            return degrees;
        }

        public void Update(Degree degree)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                dbCom.CommandText = "update Degree set userId=?,priceId=?,degreevalue=? where id=?";
                dbCom.Parameters.Add(new OleDbParameter("userId", degree.Id));
                dbCom.Parameters.Add(new OleDbParameter("priceId", degree.PriceId));
                dbCom.Parameters.Add(new OleDbParameter("degreevalue", degree.DegreeValue));
                dbCom.Parameters.Add(new OleDbParameter("id", degree.Id));
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
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;

                dbCom.CommandText = "delete from Degree where id=?";
                dbCom.Parameters.Add(new OleDbParameter("id", id));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public void Del(User user)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;

                dbCom.CommandText = "delete from Degree where id=?";
                dbCom.Parameters.Add(new OleDbParameter("id", user.Id));
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
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;

                dbConn.Open();
                dbCom.CommandText = "select count(1) from Degree d,prices p where d.userid=p.id and  yearvalue =? and mon=?";
                dbCom.Parameters.Add(new OleDbParameter("year", year));
                dbCom.Parameters.Add(new OleDbParameter("mon", mon));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                bool result = int.Parse(dbCom.ExecuteScalar().ToString()) > 0;
                dbConn.Close();
                return result;
            }
        }

        public bool IsExistWhileUpdate(Price price)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                dbCom.CommandText = "select count(1) from price where year =? and mon=? and id<>?";
                dbCom.Parameters.Add(new OleDbParameter("year", price.YearValue));
                dbCom.Parameters.Add(new OleDbParameter("mon", price.Mon));
                dbCom.Parameters.Add(new OleDbParameter("id", price.Id));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                bool result = int.Parse(dbCom.ExecuteScalar().ToString()) > 0;
                dbConn.Close();
                return result;
            }
        }

        public bool IsExistWhileUpdate(string year, string mon, int id)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand();
                dbCom.Connection = dbConn;
                dbCom.CommandText = "select count(1) from price where year =? and mon=? and id<>?";
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
