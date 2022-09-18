
namespace LFSR_FORM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Process = new System.Windows.Forms.Button();
            this.PolTextBox = new System.Windows.Forms.TextBox();
            this.RegTextBox = new System.Windows.Forms.TextBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.CipherDecipher = new System.Windows.Forms.Button();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveToFile = new System.Windows.Forms.Button();
            this.ShowTable = new System.Windows.Forms.Button();
            this.SizeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите полином:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите начальное состояние регистра:";
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(408, 24);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(106, 60);
            this.Process.TabIndex = 2;
            this.Process.Text = "Ввод";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // PolTextBox
            // 
            this.PolTextBox.Location = new System.Drawing.Point(15, 25);
            this.PolTextBox.Name = "PolTextBox";
            this.PolTextBox.Size = new System.Drawing.Size(363, 20);
            this.PolTextBox.TabIndex = 3;
            this.PolTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PolTextBox_KeyDown);
            this.PolTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PolTextBox_KeyPress);
            // 
            // RegTextBox
            // 
            this.RegTextBox.Location = new System.Drawing.Point(15, 64);
            this.RegTextBox.MaxLength = 256;
            this.RegTextBox.Name = "RegTextBox";
            this.RegTextBox.Size = new System.Drawing.Size(363, 20);
            this.RegTextBox.TabIndex = 4;
            this.RegTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegTextBox_KeyDown);
            this.RegTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegTextBox_KeyPress);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(12, 122);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(85, 41);
            this.OpenFile.TabIndex = 5;
            this.OpenFile.Text = "Открыть файл";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // CipherDecipher
            // 
            this.CipherDecipher.Location = new System.Drawing.Point(126, 122);
            this.CipherDecipher.Name = "CipherDecipher";
            this.CipherDecipher.Size = new System.Drawing.Size(266, 41);
            this.CipherDecipher.TabIndex = 6;
            this.CipherDecipher.Text = "Шифрование/Дешифрование";
            this.CipherDecipher.UseVisualStyleBackColor = true;
            this.CipherDecipher.Click += new System.EventHandler(this.Cipher_Click);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyTextBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.KeyTextBox.Location = new System.Drawing.Point(342, 218);
            this.KeyTextBox.Multiline = true;
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.ReadOnly = true;
            this.KeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KeyTextBox.Size = new System.Drawing.Size(240, 286);
            this.KeyTextBox.TabIndex = 8;
            this.KeyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(338, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ключ:";
            // 
            // input
            // 
            this.input.AutoSize = true;
            this.input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input.Location = new System.Drawing.Point(8, 195);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(53, 20);
            this.input.TabIndex = 10;
            this.input.Text = "Ввод:";
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.output.Location = new System.Drawing.Point(594, 195);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(64, 20);
            this.output.TabIndex = 11;
            this.output.Text = "Вывод:";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(12, 218);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ReadOnly = true;
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(314, 286);
            this.inputTextBox.TabIndex = 12;
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputTextBox.Location = new System.Drawing.Point(598, 218);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(314, 286);
            this.outputTextBox.TabIndex = 13;
            this.outputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // SaveToFile
            // 
            this.SaveToFile.Location = new System.Drawing.Point(429, 122);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(85, 41);
            this.SaveToFile.TabIndex = 14;
            this.SaveToFile.Text = "Записать в файл";
            this.SaveToFile.UseVisualStyleBackColor = true;
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // ShowTable
            // 
            this.ShowTable.Location = new System.Drawing.Point(578, 25);
            this.ShowTable.Name = "ShowTable";
            this.ShowTable.Size = new System.Drawing.Size(152, 80);
            this.ShowTable.TabIndex = 15;
            this.ShowTable.Text = "Показать таблицу";
            this.ShowTable.UseVisualStyleBackColor = true;
            this.ShowTable.Click += new System.EventHandler(this.ShowTable_Click);
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.Location = new System.Drawing.Point(198, 183);
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SizeTextBox.TabIndex = 16;
            this.SizeTextBox.Text = "400";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Размер:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 516);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.ShowTable);
            this.Controls.Add(this.SaveToFile);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.CipherDecipher);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.RegTextBox);
            this.Controls.Add(this.PolTextBox);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "LFSR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.TextBox PolTextBox;
        private System.Windows.Forms.TextBox RegTextBox;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button CipherDecipher;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label input;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button SaveToFile;
        private System.Windows.Forms.Button ShowTable;
        private System.Windows.Forms.TextBox SizeTextBox;
        private System.Windows.Forms.Label label4;
    }
}

