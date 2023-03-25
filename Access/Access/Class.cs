using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Access
{
    class Class
    {
        //richTextBox：檢查執行緒
        delegate void PrintHandler(RichTextBox Box, string Text);
        public static void Print(RichTextBox Box, string Text)
        {
            if (Box.InvokeRequired)
            {
                PrintHandler Handler = new PrintHandler(Print);
                Box.Invoke(Handler, Box, Text);
            }
            else
            {
                Box.Text += DateTime.Now.ToString() + "\t" + Text + Environment.NewLine;
            }
        }

        //Access資料庫：查詢
        public static DataTable Access_Query(string Database, string SQL)
        {
            DataTable Table = new DataTable();
            OleDbConnection Connection = new OleDbConnection();
            DataSet DataSet = new DataSet();
            try
            {
                Connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Database;
                if (Connection.State != ConnectionState.Open) { Connection.Open(); }
                OleDbDataAdapter Adapter = new OleDbDataAdapter(SQL, Connection);
                DataSet.Clear();
                Adapter.Fill(DataSet);
                Table = DataSet.Tables[0];

                DataSet.Dispose();
                Adapter.Dispose();
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }

                Print(Class.RichTextBox, "查詢Access資料庫：" + SQL);
                return Table;
            }
            catch (Exception e)
            {
                Print(Class.RichTextBox, e.Message);
                return new DataTable();
            }
        }

        //Access資料庫：執行語法
        public static void Access_Execute(string Database, string SQL)
        {
            OleDbConnection Connection = new OleDbConnection();
            try
            {
                Connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Database;
                if (Connection.State != ConnectionState.Open) { Connection.Open(); }
                OleDbCommand Cmd = new OleDbCommand(SQL, Connection);
                Cmd.ExecuteNonQuery();

                Cmd.Dispose();
                if (Connection.State == ConnectionState.Open) { Connection.Close(); }

                Print(Class.RichTextBox, "執行Access資料庫語法：" + SQL);
            }
            catch (Exception e)
            {
                Print(Class.RichTextBox, e.Message + "錯誤代碼：執行Access資料庫語法失敗");
            }
        }

        public static RichTextBox RichTextBox { get; set; }
    }
}
