namespace AccessReader
{
    partial class Reader
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
            this.browse = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.tableList = new System.Windows.Forms.ListBox();
            this.sqlScript = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.resultTab = new System.Windows.Forms.TabPage();
            this.messageTab = new System.Windows.Forms.TabPage();
            this.message = new System.Windows.Forms.TextBox();
            this.table = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.resultTab.SuspendLayout();
            this.messageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(13, 11);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(51, 23);
            this.browse.TabIndex = 0;
            this.browse.Text = "瀏覽...";
            this.browse.UseVisualStyleBackColor = true;
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(70, 12);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(124, 22);
            this.filePath.TabIndex = 1;
            // 
            // tableList
            // 
            this.tableList.FormattingEnabled = true;
            this.tableList.ItemHeight = 12;
            this.tableList.Location = new System.Drawing.Point(13, 43);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(181, 424);
            this.tableList.TabIndex = 2;
            // 
            // sqlScript
            // 
            this.sqlScript.Location = new System.Drawing.Point(200, 12);
            this.sqlScript.Multiline = true;
            this.sqlScript.Name = "sqlScript";
            this.sqlScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlScript.Size = new System.Drawing.Size(642, 214);
            this.sqlScript.TabIndex = 3;
            this.sqlScript.WordWrap = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.resultTab);
            this.tabControl.Controls.Add(this.messageTab);
            this.tabControl.Location = new System.Drawing.Point(200, 232);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(642, 236);
            this.tabControl.TabIndex = 4;
            // 
            // resultTab
            // 
            this.resultTab.Controls.Add(this.table);
            this.resultTab.Location = new System.Drawing.Point(4, 22);
            this.resultTab.Name = "resultTab";
            this.resultTab.Padding = new System.Windows.Forms.Padding(3);
            this.resultTab.Size = new System.Drawing.Size(634, 210);
            this.resultTab.TabIndex = 0;
            this.resultTab.Text = "結果";
            this.resultTab.UseVisualStyleBackColor = true;
            // 
            // messageTab
            // 
            this.messageTab.Controls.Add(this.message);
            this.messageTab.Location = new System.Drawing.Point(4, 22);
            this.messageTab.Name = "messageTab";
            this.messageTab.Padding = new System.Windows.Forms.Padding(3);
            this.messageTab.Size = new System.Drawing.Size(634, 210);
            this.messageTab.TabIndex = 1;
            this.messageTab.Text = "訊息";
            this.messageTab.UseVisualStyleBackColor = true;
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(6, 6);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.ReadOnly = true;
            this.message.Size = new System.Drawing.Size(622, 198);
            this.message.TabIndex = 0;
            // 
            // table
            // 
            this.table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table.Location = new System.Drawing.Point(6, 6);
            this.table.Name = "table";
            this.table.RowTemplate.Height = 24;
            this.table.Size = new System.Drawing.Size(622, 198);
            this.table.TabIndex = 0;
            // 
            // Reader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 480);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.sqlScript);
            this.Controls.Add(this.tableList);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.browse);
            this.Name = "Reader";
            this.Text = "AccessReader";
            this.tabControl.ResumeLayout(false);
            this.resultTab.ResumeLayout(false);
            this.messageTab.ResumeLayout(false);
            this.messageTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.ListBox tableList;
        private System.Windows.Forms.TextBox sqlScript;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage resultTab;
        private System.Windows.Forms.TabPage messageTab;
        private System.Windows.Forms.DataGridView table;
        private System.Windows.Forms.TextBox message;
    }
}

