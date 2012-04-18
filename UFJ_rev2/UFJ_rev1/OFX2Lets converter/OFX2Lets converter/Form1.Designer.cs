namespace OFX2LetsForm
{
    partial class OFX2Lets
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceFile = new System.Windows.Forms.TextBox();
            this.convertFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openbutton = new System.Windows.Forms.Button();
            this.savebutton = new System.Windows.Forms.Button();
            this.startbutton = new System.Windows.Forms.Button();
            this.closebutton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.convbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.convertTable = new System.Windows.Forms.TextBox();
            this.openconvertFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // sourceFile
            // 
            this.sourceFile.Location = new System.Drawing.Point(123, 42);
            this.sourceFile.Name = "sourceFile";
            this.sourceFile.Size = new System.Drawing.Size(391, 19);
            this.sourceFile.TabIndex = 0;
            // 
            // convertFile
            // 
            this.convertFile.Location = new System.Drawing.Point(123, 113);
            this.convertFile.Name = "convertFile";
            this.convertFile.Size = new System.Drawing.Size(391, 19);
            this.convertFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "変換元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(30, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "変換先";
            // 
            // openbutton
            // 
            this.openbutton.Location = new System.Drawing.Point(532, 42);
            this.openbutton.Name = "openbutton";
            this.openbutton.Size = new System.Drawing.Size(75, 23);
            this.openbutton.TabIndex = 4;
            this.openbutton.Text = "開く";
            this.openbutton.UseVisualStyleBackColor = true;
            this.openbutton.Click += new System.EventHandler(this.openbutton_Click);
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(532, 109);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 5;
            this.savebutton.Text = "開く";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // startbutton
            // 
            this.startbutton.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.startbutton.Location = new System.Drawing.Point(205, 259);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(182, 62);
            this.startbutton.TabIndex = 6;
            this.startbutton.Text = "変換";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // closebutton
            // 
            this.closebutton.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.closebutton.Location = new System.Drawing.Point(497, 269);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(101, 44);
            this.closebutton.TabIndex = 7;
            this.closebutton.Text = "終了";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "OFX Files (*.ofx)|*.ofx|CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All file" +
                "s (*.*)|*.*";
            this.openFileDialog.InitialDirectory = "C:\\Data\\HouseholdAccounts\\明細";
            // 
            // convbutton
            // 
            this.convbutton.Location = new System.Drawing.Point(532, 177);
            this.convbutton.Name = "convbutton";
            this.convbutton.Size = new System.Drawing.Size(75, 23);
            this.convbutton.TabIndex = 10;
            this.convbutton.Text = "開く";
            this.convbutton.UseVisualStyleBackColor = true;
            this.convbutton.Click += new System.EventHandler(this.convbutton_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(30, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "変換テーブル";
            // 
            // convertTable
            // 
            this.convertTable.Location = new System.Drawing.Point(123, 177);
            this.convertTable.Name = "convertTable";
            this.convertTable.Size = new System.Drawing.Size(391, 19);
            this.convertTable.TabIndex = 8;
            // 
            // openconvertFile
            // 
            this.openconvertFile.FileName = "openFileDialog1";
            this.openconvertFile.InitialDirectory = "C:\\Data\\HouseholdAccounts\\明細";
            // 
            // OFX2Lets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 333);
            this.Controls.Add(this.convbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.convertTable);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.openbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convertFile);
            this.Controls.Add(this.sourceFile);
            this.Name = "OFX2Lets";
            this.Text = "OFX2Let\'s家計簿コンバータ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sourceFile;
        private System.Windows.Forms.TextBox convertFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openbutton;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.Button startbutton;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button convbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox convertTable;
        private System.Windows.Forms.OpenFileDialog openconvertFile;
    }
}

