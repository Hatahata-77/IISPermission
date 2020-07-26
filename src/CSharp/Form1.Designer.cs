namespace WindowsFormsApp20
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.AppPoolUserText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AppPoolText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AppsCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SitesCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AppPoolUserText
            // 
            this.AppPoolUserText.BackColor = System.Drawing.Color.White;
            this.AppPoolUserText.Location = new System.Drawing.Point(12, 284);
            this.AppPoolUserText.Name = "AppPoolUserText";
            this.AppPoolUserText.ReadOnly = true;
            this.AppPoolUserText.Size = new System.Drawing.Size(348, 30);
            this.AppPoolUserText.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 258);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 24;
            this.label4.Text = "実行ユーザー";
            // 
            // AppPoolText
            // 
            this.AppPoolText.BackColor = System.Drawing.Color.White;
            this.AppPoolText.Location = new System.Drawing.Point(12, 202);
            this.AppPoolText.Name = "AppPoolText";
            this.AppPoolText.ReadOnly = true;
            this.AppPoolText.Size = new System.Drawing.Size(348, 30);
            this.AppPoolText.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "アプリケーションプール名";
            // 
            // AppsCombo
            // 
            this.AppsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AppsCombo.FormattingEnabled = true;
            this.AppsCombo.Location = new System.Drawing.Point(12, 110);
            this.AppsCombo.Name = "AppsCombo";
            this.AppsCombo.Size = new System.Drawing.Size(348, 31);
            this.AppsCombo.TabIndex = 21;
            this.AppsCombo.SelectedIndexChanged += new System.EventHandler(this.AppsCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "アプリケーション名";
            // 
            // SitesCombo
            // 
            this.SitesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SitesCombo.FormattingEnabled = true;
            this.SitesCombo.Location = new System.Drawing.Point(12, 34);
            this.SitesCombo.Name = "SitesCombo";
            this.SitesCombo.Size = new System.Drawing.Size(292, 31);
            this.SitesCombo.TabIndex = 19;
            this.SitesCombo.SelectedIndexChanged += new System.EventHandler(this.SitesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "サイト名";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 364);
            this.Controls.Add(this.AppPoolUserText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AppPoolText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AppsCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SitesCombo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AppPoolUserText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AppPoolText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AppsCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SitesCombo;
        private System.Windows.Forms.Label label1;
    }
}

