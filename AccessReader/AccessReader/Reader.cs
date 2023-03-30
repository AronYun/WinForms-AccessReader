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
        public Access accessConnection { get; set; } //宣告Access連接

        public Reader()
        {
            InitializeComponent();
        }

        #region 元件事件
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

                this.filePath.Text = string.Empty; //清除filePath

                this.accessConnection = new Access(path); //宣告Access連接檔案路徑
                this.tableList.Items.Clear(); //清除tableList
                if (this.accessConnection.State) //如果連接狀態「連接成功」
                {
                    this.filePath.Text = path; //將路徑寫入filePath
                    this.tableList.Items.AddRange(this.accessConnection.Tables); //將連接到的Table放入tableList
                }
                else //如果連接狀態「連接失敗」
                {
                    MessageBox.Show("Microsoft Access 資料庫連接失敗", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error); //跳出提示視窗
                }
            }
        }

        //［Table列表］ListBox雙擊事件
        private void tableList_DoubleClick(object sender, EventArgs e)
        {
            if (this.tableList.SelectedItem != null) //如果有選取選項
            {
                string tableName = this.tableList.SelectedItem.ToString(); //取得選項名稱
                this.sqlScript.Text = $"SELECT TOP(1000) * FROM {tableName}"; //寫入sqlScript元件
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
    }
}
