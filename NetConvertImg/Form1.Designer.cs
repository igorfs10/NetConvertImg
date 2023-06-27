namespace NetConvertImg
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridViewFiles = new DataGridView();
            FilePath = new DataGridViewTextBoxColumn();
            FileSize = new DataGridViewTextBoxColumn();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label1 = new Label();
            txtPastaSaida = new TextBox();
            cbbExtensao = new ComboBox();
            label2 = new Label();
            button3 = new Button();
            txtAltura = new NumericUpDown();
            txtLargura = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAltura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLargura).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(578, 12);
            button1.Name = "button1";
            button1.Size = new Size(148, 23);
            button1.TabIndex = 1;
            button1.Text = "Adicionar Arquivos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // dataGridViewFiles
            // 
            dataGridViewFiles.AllowUserToAddRows = false;
            dataGridViewFiles.AllowUserToResizeRows = false;
            dataGridViewFiles.BackgroundColor = Color.White;
            dataGridViewFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFiles.Columns.AddRange(new DataGridViewColumn[] { FilePath, FileSize });
            dataGridViewFiles.Location = new Point(12, 12);
            dataGridViewFiles.Name = "dataGridViewFiles";
            dataGridViewFiles.ReadOnly = true;
            dataGridViewFiles.RowHeadersVisible = false;
            dataGridViewFiles.RowTemplate.Height = 25;
            dataGridViewFiles.Size = new Size(560, 243);
            dataGridViewFiles.TabIndex = 2;
            // 
            // FilePath
            // 
            FilePath.DataPropertyName = "FilePath";
            FilePath.HeaderText = "Path";
            FilePath.Name = "FilePath";
            FilePath.ReadOnly = true;
            FilePath.Resizable = DataGridViewTriState.False;
            FilePath.Width = 415;
            // 
            // FileSize
            // 
            FileSize.DataPropertyName = "FileSize";
            FileSize.HeaderText = "Size";
            FileSize.Name = "FileSize";
            FileSize.ReadOnly = true;
            FileSize.Resizable = DataGridViewTriState.False;
            FileSize.Width = 140;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Multiselect = true;
            // 
            // button2
            // 
            button2.Location = new Point(594, 232);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Converter";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 268);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Pasta Destino:";
            // 
            // txtPastaSaida
            // 
            txtPastaSaida.Location = new Point(12, 286);
            txtPastaSaida.Name = "txtPastaSaida";
            txtPastaSaida.Size = new Size(329, 23);
            txtPastaSaida.TabIndex = 5;
            // 
            // cbbExtensao
            // 
            cbbExtensao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbExtensao.FormattingEnabled = true;
            cbbExtensao.Location = new Point(451, 286);
            cbbExtensao.Name = "cbbExtensao";
            cbbExtensao.Size = new Size(189, 23);
            cbbExtensao.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(451, 268);
            label2.Name = "label2";
            label2.Size = new Size(163, 15);
            label2.TabIndex = 7;
            label2.Text = "Extensão do arquivo de saída:";
            // 
            // button3
            // 
            button3.Location = new Point(347, 286);
            button3.Name = "button3";
            button3.Size = new Size(22, 23);
            button3.TabIndex = 8;
            button3.Text = "...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // txtAltura
            // 
            txtAltura.Location = new Point(12, 351);
            txtAltura.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(120, 23);
            txtAltura.TabIndex = 9;
            // 
            // txtLargura
            // 
            txtLargura.Location = new Point(249, 351);
            txtLargura.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            txtLargura.Name = "txtLargura";
            txtLargura.Size = new Size(120, 23);
            txtLargura.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 333);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 11;
            label3.Text = "Altura:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(249, 333);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 12;
            label4.Text = "Comprimento:";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 438);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtLargura);
            Controls.Add(txtAltura);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(cbbExtensao);
            Controls.Add(txtPastaSaida);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(dataGridViewFiles);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Net Convert Img";
            DragDrop += Form1_DragDrop;
            DragEnter += Form1_DragEnter;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFiles).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAltura).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLargura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DataGridView dataGridViewFiles;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private DataGridViewTextBoxColumn FilePath;
        private DataGridViewTextBoxColumn FileSize;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private TextBox txtPastaSaida;
        private ComboBox cbbExtensao;
        private Label label2;
        private Button button3;
        private NumericUpDown txtAltura;
        private NumericUpDown txtLargura;
        private Label label3;
        private Label label4;
    }
}