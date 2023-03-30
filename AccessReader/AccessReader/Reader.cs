using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessReader
{
    public partial class Reader : Form
    {
        public Access accessConnection { get; set; } = null; //宣告AccessConnection

        public Reader()
        {
            InitializeComponent();
        }

        //［視窗］開啟後事件
        private void Reader_Shown(object sender, EventArgs e)
        {
            this.execute.Enabled = false; //關閉［執行］按鈕
            this.filePath.Text = string.Empty; //清除filePath元件資料
            this.tableList.Items.Clear(); //清除tableList元件資料
            this.sqlScript.Text = string.Empty; //清除sqlScript元件資料
            this.table.DataSource = null; // 清空table資料來源
            this.table.Rows.Clear(); // 清空table所有列
            this.message.Text = string.Empty; //清除message元件資料
            this.tabControl.SelectedTab = this.resultTab; //顯示〔結果］頁籤
        }

        #region 元件事件
        //［執行］按鈕事件
        private void execute_Click(object sender, EventArgs e)
        {
            string SQL = this.sqlScript.Text.Trim(); //SQL語法
            string type = string.Empty; //執行類型
            int spaceIndex = 0; //半形空白位置

            if (accessConnection == null || !accessConnection.State) //如果資料庫未連接或資料庫連接失敗
            {
                MessageBox.Show("請連接資料庫！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning); //跳出提示視窗
                return;
            }
            if (SQL == "") //如果未輸入SQL語法
            {
                MessageBox.Show("請輸入SQL語法！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information); //跳出提示視窗
                return;
            }

            this.table.DataSource = null; // 清空table資料來源
            this.table.Rows.Clear(); // 清空table所有列 
            this.message.Text = string.Empty; //清除message元件資料

            SQL = SQL.Replace(Environment.NewLine, " "); //SQL語法(換行改半形空白)
            spaceIndex = SQL.IndexOf(" "); //半形空白位置

            if (spaceIndex >= 0) //如果半形空白存在
            {
                type = SQL.Substring(0, SQL.IndexOf(" ")).Trim().ToUpper(); //攫取SQL字串的第0~半形空白的字串
            }

            switch (type) //判斷執行類型
            {
                case "DELETE": //刪除
                case "UPDATE": //更新
                case "INSERT": //新增
                    string typeName = type == "DELETE" ? "刪除" : type == "UPDATE" ? "更新" : "新增"; //類型對應的名稱
                    DialogResult result = MessageBox.Show($"是否要執行{typeName}指令？", "確認訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question); //確認訊息
                    if (result == DialogResult.OK) //如果按下「確定」
                    {
                        string executeMessage = string.Empty; //執行訊息
                        if (accessConnection.Execute(SQL)) //執行SQL
                        {
                            executeMessage = $"執行Access資料庫語法：{SQL}"; //成功訊息
                        }
                        else
                        {
                            executeMessage = $"執行{type}語法時發生錯誤：\n{accessConnection.ExecuteException}"; //失敗訊息
                            accessConnection.ExecuteException = string.Empty; //清空AccessConnection執行錯誤訊息
                            MessageBox.Show(executeMessage, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error); //跳出錯誤訊息視窗  
                        }
                        this.message.Text = executeMessage; //將執行訊息顯示於message元件上
                        this.tabControl.SelectedTab = this.messageTab; //顯示〔訊息］頁籤
                    }
                    break;
                case "SELECT": //查詢
                    DataTable dataTable = accessConnection.Query(SQL); //查詢SQL
                    this.table.DataSource = dataTable; //將查詢到的資料放到table元件上
                    string queryMessage = string.Empty; //查詢訊息
                    if (accessConnection.QueryState) //判斷查詢狀態
                    {
                        queryMessage = $"執行Access資料庫語法：{SQL}";
                        this.tabControl.SelectedTab = this.resultTab; //顯示〔結果］頁籤
                    }
                    else
                    {
                        queryMessage = $"執行{type}語法時發生錯誤：\n{accessConnection.QueryException}";
                        accessConnection.QueryException = string.Empty;
                        MessageBox.Show(queryMessage, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error); //跳出提示視窗
                        this.tabControl.SelectedTab = this.messageTab; //顯示〔訊息］頁籤
                    }
                    this.message.Text = queryMessage;
                    break;
                default:
                    MessageBox.Show("功能開發中！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

        }

        //［瀏覽］按鈕事件
        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog(); //宣告開啟檔案視窗
            browser.Title = "開啟檔案"; //開啟檔案視窗-名稱設定
            browser.Filter = "所有檔案|*.*|Microsoft Access 檔案|*.accdb"; //開啟檔案視窗-過濾的檔名及副檔名
            DialogResult reslut = browser.ShowDialog(); //顯示開啟檔案視窗
            if (reslut == DialogResult.OK) //如果按下「確定」
            {
                string path = browser.FileName; //所選的檔案路徑字串

                this.Reader_Shown(null, null); //初始化UI資料

                this.accessConnection = new Access(path); //宣告Access連接檔案路徑
                
                if (this.accessConnection.State) //如果連接狀態「連接成功」
                {
                    this.execute.Enabled = true; //開啟［執行］按鈕
                    this.filePath.Text = path; //將路徑寫入filePath
                    this.tableList.Items.AddRange(this.accessConnection.Tables); //將連接到的Table放入tableList
                }
                else //如果連接狀態「連接失敗」
                {
                    MessageBox.Show($"Microsoft Access 資料庫連接失敗：\n{accessConnection.Exception}", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error); //跳出提示視窗
                    accessConnection = null; //Access連接指向null
                }
            }
        }

        //［Table列表］ListBox雙擊事件
        private void tableList_DoubleClick(object sender, EventArgs e)
        {
            if (this.tableList.SelectedItem != null) //如果有選取選項
            {
                string tableName = this.tableList.SelectedItem.ToString(); //取得選項名稱
                this.sqlScript.Text = $"SELECT TOP 1000 * FROM {tableName}"; //寫入sqlScript元件
            }
        }

        //［Table列表］ListBox滑鼠放開事件
        private void tableList_MouseUp(object sender, MouseEventArgs e)
        {
            int index = this.tableList.IndexFromPoint(e.Location); //點擊選項的Index，回傳-1則沒點到選項
            if (index == ListBox.NoMatches) //如果點擊的選項等於-1
            {
                this.tableList.ClearSelected(); //取消ListBox選取
            }
        }
        #endregion

        #region 函式庫

        #endregion
    }
}
