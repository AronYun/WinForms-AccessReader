namespace Access
{
    partial class Form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.textBox_DB = new System.Windows.Forms.TextBox();
            this.textBox_SQL = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(12, 299);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(702, 60);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // textBox_DB
            // 
            this.textBox_DB.Location = new System.Drawing.Point(12, 12);
            this.textBox_DB.Name = "textBox_DB";
            this.textBox_DB.Size = new System.Drawing.Size(702, 22);
            this.textBox_DB.TabIndex = 1;
            // 
            // textBox_SQL
            // 
            this.textBox_SQL.Location = new System.Drawing.Point(12, 40);
            this.textBox_SQL.Multiline = true;
            this.textBox_SQL.Name = "textBox_SQL";
            this.textBox_SQL.Size = new System.Drawing.Size(702, 224);
            this.textBox_SQL.TabIndex = 2;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(12, 270);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(702, 23);
            this.button.TabIndex = 3;
            this.button.Text = "執行";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 365);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(702, 225);
            this.dataGridView.TabIndex = 4;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 602);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox_SQL);
            this.Controls.Add(this.textBox_DB);
            this.Controls.Add(this.richTextBox);
            this.Name = "Form";
            this.Text = "Access";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.TextBox textBox_DB;
        private System.Windows.Forms.TextBox textBox_SQL;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}

