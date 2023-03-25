using System;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace AccessReader
{
    class Access
    {
        public bool State { get; set; }                  //連接狀態
        public bool QueryState { get; set; }             //查詢狀態
        public string Exception { get; set; }            //連接錯誤訊息
        public string QueryException { get; set; }       //查詢錯誤訊息
        public string ExecuteException { get; set; }     //執行錯誤訊息
        public List<string> Tables { get; set; }         //連接DB的所有Table名稱
        private OleDbConnection Connection { get; set; } //連接物件

        //Access資料庫：連接
        public Access(string Source)
        {
            string connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Source};Persist Security Info=False;";

            try
            {
                using (this.Connection = new OleDbConnection(connectionString))
                {
                    if (this.Connection.State != ConnectionState.Open) { this.Connection.Open(); }
                    this.Tables = Connection.GetSchema("Tables").AsEnumerable().Select(r => r.Field<string>("TABLE_NAME")).ToList();
                }
                this.State = true;
            }
            catch (Exception e)
            {
                this.State = false;
                this.Exception = e.ToString();
            }
        }

        //Access資料庫：查詢
        public DataTable Query(string SQL)
        {
            DataTable Table = new DataTable();
            DataSet DataSet = new DataSet();

            try
            {
                if (this.Connection.State != ConnectionState.Open) { this.Connection.Open(); }

                OleDbDataAdapter Adapter = new OleDbDataAdapter(SQL, this.Connection);
                DataSet.Clear();
                Adapter.Fill(DataSet);
                Table = DataSet.Tables[0];

                DataSet.Dispose();
                Adapter.Dispose();

                this.QueryState = true;
            }
            catch (Exception e)
            {
                Table = new DataTable();
                this.QueryState = false;
                this.QueryException = e.ToString();
            }

            return Table;
        }

        //Access資料庫：執行語法
        public bool Execute(string SQL)
        {
            bool Result = false;

            try
            {
                if (this.Connection.State != ConnectionState.Open) { this.Connection.Open(); }

                OleDbCommand Cmd = new OleDbCommand(SQL, this.Connection);
                Cmd.ExecuteNonQuery();

                Cmd.Dispose();

                Result = true;
            }
            catch (Exception e)
            {
                Result = false;
                this.ExecuteException = e.ToString();
            }

            return Result;
        }
    }
}
