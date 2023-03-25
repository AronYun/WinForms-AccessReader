using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Access
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            Class.RichTextBox = this.richTextBox;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (this.textBox_DB.Text.Trim() == "")
            {
                MessageBox.Show("請輸入資料庫路徑！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.textBox_SQL.Text.Trim() == "")
            {
                MessageBox.Show("請輸入SQL語法！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string DB = this.textBox_DB.Text.Trim();
            string SQL = this.textBox_SQL.Text.Trim() + " ";
            string Status = SQL.Substring(0, SQL.IndexOf(" "));
            switch (Status.ToUpper())
            {
                case "DELETE":
                    DialogResult Result = MessageBox.Show("是否要執行刪除指令？", "確認訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (Result == DialogResult.OK) { Class.Access_Execute(DB, SQL); }
                    break;
                case "UPDATE":
                case "INSERT":
                    Class.Access_Execute(DB, SQL);
                    break;
                case "SELECT":
                    DataTable Table = Class.Access_Query(DB, SQL);
                    this.dataGridView.DataSource = Table;
                    break;
                default:
                    MessageBox.Show("功能開發中！", "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            this.richTextBox.SelectionStart = this.richTextBox.TextLength;
            this.richTextBox.ScrollToCaret();
        }
    }
}
