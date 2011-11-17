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
    public class DALUser
    {
        private string connStr;
        public DALUser()
        {
            connStr = ConfigurationManager.ConnectionStrings["wbs"].ConnectionString;
        }

        public void Add(User user)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); 
                dbCom.Connection = dbConn;
                dbCom.CommandType = CommandType.Text;
                dbCom.CommandText = "insert into users(code,name,address) values(?,?,?)";
                dbCom.Parameters.Add(new OleDbParameter("code", user.Code));
                dbCom.Parameters.Add(new OleDbParameter("name", user.Name));
                dbCom.Parameters.Add(new OleDbParameter("address", user.Address));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public DataTable Get()
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); 
                dbCom.Connection = dbConn;
                dbCom.CommandText = "select id,code,name,address from users order by id";
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                dbCom.ExecuteReader();
                dbConn.Close();
                return ds.Tables[0];
            }
        }

        public DataTable GetUserDegreePrice(string year, string mon)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = @"select u.*,a.degreevalue,b.degreevalue as lastdegreevalue,a.remark,a.pricevalue from (users u left join 
                        (select * from prices p inner join degree d on p.id=d.priceid where p.yearvalue=? and p.mon=?) a  on  u.id=a.userid) 
                        left join (select * from prices p inner join degree d on p.id=d.priceid where p.yearvalue=? and p.mon=?) b on b.userid=u.id";
                DateTime datatime = new DateTime(int.Parse(year), int.Parse(mon), 1).AddMonths(-1);
                dbCom.Parameters.Add(new OleDbParameter("yearvalue", year));
                dbCom.Parameters.Add(new OleDbParameter("mon", mon));
                dbCom.Parameters.Add(new OleDbParameter("lastyearvalue", datatime.Year.ToString()));
                dbCom.Parameters.Add(new OleDbParameter("lastmon", datatime.Month.ToString()));
                DataSet ds = new DataSet();
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                dbCom.ExecuteReader();
                dbConn.Close();
                return ds.Tables[0];
            }
        }

        public DataTable GetUserDegree(string year, string mon)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandType = CommandType.Text;
                dbCom.Connection = dbConn;
                dbCom.CommandText = @"select u.*,a.degreevalue ,a.remark  from users u left join 
                        (select * from prices p inner join degree d on p.id=d.priceid where p.yearvalue=? and p.mon=?) a  on  u.id=a.userid";
                dbCom.Parameters.Add(new OleDbParameter("yearvalue", year));
                dbCom.Parameters.Add(new OleDbParameter("mon", mon));
                DataSet ds = new DataSet();
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                dbCom.ExecuteReader();
                dbConn.Close();
                return ds.Tables[0];
            }
        }

        public void Update(User user)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = "update users set code=?,name=?,address=? where id=?";
                dbCom.Parameters.Add(new OleDbParameter("code", user.Code));
                dbCom.Parameters.Add(new OleDbParameter("name", user.Name));
                dbCom.Parameters.Add(new OleDbParameter("address", user.Address));
                dbCom.Parameters.Add(new OleDbParameter("id", user.Id));
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
                dbCom.CommandText = "delete from users where id=?";
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
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = "delete from users where id=?";
                dbCom.Parameters.Add(new OleDbParameter("id", user.Id));
                dbCom.ExecuteNonQuery();

                dbConn.Close();
            }
        }

        public User GetById(int id)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;

                dbCom.CommandText = "select id,code,name,address from users where id=? order by id";
                dbCom.Parameters.Add(new OleDbParameter("id", id));
                DataSet ds = new DataSet();
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                dap.Fill(ds);
                User user = GetEntity(dbCom.ExecuteReader())[0];
                dbConn.Close();

                return user;
            }
        }

        public IList<User> GetByName(string name)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();

                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); 
                dbCom.Connection = dbConn;
                dbCom.CommandText = string.Format("select id,code,name,address from users where name like '%{0}%' order by id", name);
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                IDataReader dataReader = dbCom.ExecuteReader();
                IList<User> users = GetEntity(dataReader);
                dbConn.Close();
                return users;
            }
        }

        public User GetByCode(string code)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();

                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = string.Format("select id,code,name,address from users where code like '%{0}%' order by id", code);
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                User user = GetEntity(dbCom.ExecuteReader())[0];
                dbConn.Close();

                return user;
            }
        }

        public bool IsExist(string code)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = "select count(1) from users where code =?";
                dbCom.Parameters.Add(new OleDbParameter("code", code));
                bool result = int.Parse(dbCom.ExecuteScalar().ToString()) > 0;
                dbConn.Close();
                return result;
            }
        }

        public bool IsExistWhileUpdate(string code, string id)
        {
            using (IDbConnection dbConn = OleDbFactory.Instance.CreateConnection())
            {
                dbConn.ConnectionString = connStr;
                dbConn.Open();
                IDbCommand dbCom = OleDbFactory.Instance.CreateCommand(); dbCom.Connection = dbConn;
                dbCom.CommandText = "select count(1) from users where code =? and id<>?";
                dbCom.Parameters.Add(new OleDbParameter("code", code));
                dbCom.Parameters.Add(new OleDbParameter("id", id));
                IDbDataAdapter dap = OleDbFactory.Instance.CreateDataAdapter();
                dap.SelectCommand = dbCom;
                bool result = int.Parse(dbCom.ExecuteScalar().ToString()) > 0;
                dbConn.Close();
                return result;
            }
        }

        private IList<User> GetEntity(IDataReader oledbr)
        {
            IList<User> users = new List<User>();
            while (oledbr.Read())
            {
                User user = new User();
                if (oledbr["id"] != DBNull.Value)
                    user.Id = int.Parse(oledbr["id"].ToString());
                if (oledbr["code"] != DBNull.Value)
                    user.Code = oledbr["code"].ToString();
                if (oledbr["name"] != DBNull.Value)
                    user.Name = oledbr["name"].ToString();
                if (oledbr["address"] != DBNull.Value)
                    user.Address = oledbr["address"].ToString();
                users.Add(user);
            }
            return users;
        }
    }
}
