using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace YahooHit
{

    public class DB_Access
    {
        private string path;
        private OleDbConnection myCon;
        private OleDbCommand myCom;

        public DB_Access()
        {
            String strCon = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
            strCon += "YahooHit.mdb";
            myCon = new OleDbConnection(strCon);
            myCon.Open();
            myCom = new OleDbCommand();
            myCom.Connection = myCon;
        }

        public DB_Access(string strPath)
        {
            this.path = strPath;
            String strCon = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
            strCon += this.path;
            myCon = new OleDbConnection(strCon);
            myCon.Open();
            myCom = new OleDbCommand();
            myCom.Connection = myCon;
        }

        public OleDbCommand GetCommand()
        {
            return myCom;
        }

        public int Execute(string sql)
        {
            myCom.CommandText = sql;
            return myCom.ExecuteNonQuery();
        }

        public int InsertKeywords(string Keywords, string urls)
        {
            myCom = new OleDbCommand("insert into Keywords(Keywords,urls) values (@Keywords,@urls)", myCon);
            myCom.Parameters.AddWithValue("@Keywords", Keywords);
            myCom.Parameters.AddWithValue("@urls", urls);
            return myCom.ExecuteNonQuery();
        }

        public int UpdateKeywords(int id, string Keywords, string urls)
        {
            myCom = new OleDbCommand("update Keywords set Keywords=@Keywords,urls=@urls where id=@id", myCon);
            myCom.Parameters.AddWithValue("@Keywords", Keywords);
            myCom.Parameters.AddWithValue("@urls", urls);
            myCom.Parameters.AddWithValue("@id", id);
            return myCom.ExecuteNonQuery();
        }

        public int UpdateADSL(string EntryName,string userName,string pwd)
        {
            myCom = new OleDbCommand("update ADSL set EntryName=@EntryName,UserName=@UserName,pwd=@pwd", myCon);
            myCom.Parameters.AddWithValue("@EntryName", EntryName);
            myCom.Parameters.AddWithValue("@UserName", userName);
            myCom.Parameters.AddWithValue("@pwd", pwd);
            return myCom.ExecuteNonQuery();
        }

        public DataTable Query(string sql)
        {
            myCom.CommandText = sql;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCom;
            DataTable Dt = new DataTable();
            adapter.Fill(Dt);
            return Dt;
        }

        public void Close()
        {
            myCon.Close();
        }

    }
}
