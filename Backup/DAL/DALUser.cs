using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;

using Wbs.Entity;

namespace Wbs.DAL
{
    public class DALUser
    {
        OleDbConnection dbConn;
        OleDbCommand dbCom;

        public DALUser()
        {
            dbConn = new OleDbConnection();
            dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["wbs"].ConnectionString;
            dbCom = new OleDbCommand();
            dbCom.CommandType = CommandType.Text;
            dbCom.Connection = dbConn;
        }

        public void Add(User user)
        {
            dbConn.Open();

            dbCom.CommandText = "insert into users(code,name) values(?,?)";
            dbCom.Parameters.Add(new OleDbParameter("code", user.Code));
            dbCom.Parameters.Add(new OleDbParameter("name", user.Name));
            dbCom.ExecuteNonQuery();

            dbConn.Close();
        }

        public DataSet Get()
        {
            dbConn.Open();

            dbCom.CommandText = "select id,code,name from users";
            DataSet ds = new DataSet();
            OleDbDataAdapter dap = new OleDbDataAdapter(dbCom);
            dap.Fill(ds);
            dbCom.ExecuteReader();
            dbConn.Close();

            return ds;
        }

        public void Update(User user)
        {
            dbConn.Open();

            dbCom.CommandText = "update users set code=?,name=? where id=?";
            dbCom.Parameters.Add(new OleDbParameter("code", user.Code));
            dbCom.Parameters.Add(new OleDbParameter("name", user.Name));
            dbCom.Parameters.Add(new OleDbParameter("id", user.Id));
            dbCom.ExecuteNonQuery();

            dbConn.Close();
        }

        public void Del(int id)
        {
            dbConn.Open();

            dbCom.CommandText = "delete from users where id=?";
            dbCom.Parameters.Add(new OleDbParameter("id", id));
            dbCom.ExecuteNonQuery();

            dbConn.Close();
        }

        public void Del(User user)
        {
            dbConn.Open();

            dbCom.CommandText = "delete from users where id=?";
            dbCom.Parameters.Add(new OleDbParameter("id", user.Id));
            dbCom.ExecuteNonQuery();

            dbConn.Close();
        }

        public DataSet GetById(int id)
        {
            dbConn.Open();

            dbCom.CommandText = "select id,code,name from users where id=?";
            dbCom.Parameters.Add(new OleDbParameter("id", id));
            DataSet ds = new DataSet();
            OleDbDataAdapter dap = new OleDbDataAdapter(dbCom);
            dap.Fill(ds);
            dbCom.ExecuteReader();
            dbConn.Close();

            return ds;
        }

        public DataSet GetByName(string name)
        {
            dbConn.Open();
            dbCom.CommandText = string.Format("select id,code,name from users where name like '%{0}%'", name);
            DataSet ds = new DataSet();
            OleDbDataAdapter dap = new OleDbDataAdapter(dbCom);
            dap.Fill(ds);
            dbCom.ExecuteReader();
            dbConn.Close();

            return ds;
        }

        public DataSet GetByCode(string code)
        {
            dbConn.Open();

            dbCom.CommandText = "select id,code,name from users where code=?";
            dbCom.Parameters.Add(new OleDbParameter("code", code));
            DataSet ds = new DataSet();
            OleDbDataAdapter dap = new OleDbDataAdapter(dbCom);
            dap.Fill(ds);
            dbCom.ExecuteReader();
            dbConn.Close();

            return ds;
        }
    }
}
