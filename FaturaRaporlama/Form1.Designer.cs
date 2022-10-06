namespace FaturaRaporlama
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.DigerDataGridView = new System.Windows.Forms.DataGridView();
            this.SanayiDataGridView = new System.Windows.Forms.DataGridView();
            this.MeskenDataGridView = new System.Windows.Forms.DataGridView();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.PeriodComboBox = new System.Windows.Forms.ComboBox();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DigerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SanayiDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeskenDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DigerDataGridView
            // 
            this.DigerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DigerDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DigerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DigerDataGridView.Location = new System.Drawing.Point(923, 170);
            this.DigerDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.DigerDataGridView.Name = "DigerDataGridView";
            this.DigerDataGridView.RowHeadersWidth = 75;
            this.DigerDataGridView.Size = new System.Drawing.Size(434, 328);
            this.DigerDataGridView.TabIndex = 15;
            // 
            // SanayiDataGridView
            // 
            this.SanayiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SanayiDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.SanayiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SanayiDataGridView.Location = new System.Drawing.Point(470, 170);
            this.SanayiDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.SanayiDataGridView.Name = "SanayiDataGridView";
            this.SanayiDataGridView.RowHeadersWidth = 75;
            this.SanayiDataGridView.Size = new System.Drawing.Size(435, 328);
            this.SanayiDataGridView.TabIndex = 14;
            // 
            // MeskenDataGridView
            // 
            this.MeskenDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MeskenDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MeskenDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MeskenDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MeskenDataGridView.Location = new System.Drawing.Point(16, 170);
            this.MeskenDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.MeskenDataGridView.Name = "MeskenDataGridView";
            this.MeskenDataGridView.RowHeadersWidth = 75;
            this.MeskenDataGridView.Size = new System.Drawing.Size(436, 328);
            this.MeskenDataGridView.TabIndex = 13;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(451, 86);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(4);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(158, 32);
            this.SubmitButton.TabIndex = 12;
            this.SubmitButton.Text = "Rapor Göster";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PeriodComboBox
            // 
            this.PeriodComboBox.FormattingEnabled = true;
            this.PeriodComboBox.Items.AddRange(new object[] {
            "1. Dönem",
            "2. Dönem"});
            this.PeriodComboBox.Location = new System.Drawing.Point(156, 86);
            this.PeriodComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PeriodComboBox.Name = "PeriodComboBox";
            this.PeriodComboBox.Size = new System.Drawing.Size(180, 26);
            this.PeriodComboBox.TabIndex = 11;
            // 
            // YearComboBox
            // 
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022"});
            this.YearComboBox.Location = new System.Drawing.Point(156, 31);
            this.YearComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(180, 26);
            this.YearComboBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 42);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dönem :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Yıl :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1370, 588);
            this.Controls.Add(this.DigerDataGridView);
            this.Controls.Add(this.SanayiDataGridView);
            this.Controls.Add(this.MeskenDataGridView);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.PeriodComboBox);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DigerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SanayiDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeskenDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DigerDataGridView;
        private System.Windows.Forms.DataGridView SanayiDataGridView;
        private System.Windows.Forms.DataGridView MeskenDataGridView;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ComboBox PeriodComboBox;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

