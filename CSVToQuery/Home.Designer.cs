namespace CSVToQuery
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            btnStart = new Button();
            dataGridWithCheckbox = new DataGridView();
            btnConvertTable = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridWithCheckbox).BeginInit();
            SuspendLayout();
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(24, 35);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(621, 27);
            txtFilePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(656, 35);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Green;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(24, 86);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(496, 29);
            btnStart.TabIndex = 2;
            btnStart.Text = "(1) Read To File";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // dataGridWithCheckbox
            // 
            dataGridWithCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridWithCheckbox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridWithCheckbox.Location = new Point(24, 121);
            dataGridWithCheckbox.Name = "dataGridWithCheckbox";
            dataGridWithCheckbox.RowHeadersWidth = 51;
            dataGridWithCheckbox.RowTemplate.Height = 29;
            dataGridWithCheckbox.Size = new Size(992, 360);
            dataGridWithCheckbox.TabIndex = 3;
            // 
            // btnConvertTable
            // 
            btnConvertTable.BackColor = Color.FromArgb(255, 128, 0);
            btnConvertTable.FlatStyle = FlatStyle.Flat;
            btnConvertTable.ForeColor = Color.White;
            btnConvertTable.Location = new Point(526, 86);
            btnConvertTable.Name = "btnConvertTable";
            btnConvertTable.Size = new Size(490, 29);
            btnConvertTable.TabIndex = 4;
            btnConvertTable.Text = "(2) Convert Data Table";
            btnConvertTable.UseVisualStyleBackColor = false;
            btnConvertTable.Click += btnConvertTable_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 493);
            Controls.Add(btnConvertTable);
            Controls.Add(dataGridWithCheckbox);
            Controls.Add(btnStart);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Name = "Home";
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)dataGridWithCheckbox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFilePath;
        private Button btnBrowse;
        private Button btnStart;
        private DataGridView dataGridWithCheckbox;
        private Button btnConvertTable;
    }
}