namespace WinFormsCTech
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
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            button3 = new Button();
            button4 = new Button();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1032, 29);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Выбрать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1032, 11);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
            label1.TabIndex = 1;
            label1.Text = "Файл по РКК не выбран";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1032, 79);
            label2.Name = "label2";
            label2.Size = new Size(190, 15);
            label2.TabIndex = 2;
            label2.Text = "Файл по обращениям не выбран";
            // 
            // button2
            // 
            button2.Location = new Point(1032, 97);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Выбрать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 9);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(924, 616);
            dataGridView1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            button3.Location = new Point(1032, 159);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "Очистить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1113, 159);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 6;
            button4.Text = "Сохранить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(1212, 615);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1, 1);
            richTextBox1.TabIndex = 7;
            richTextBox1.TabStop = false;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(942, 560);
            label3.Name = "label3";
            label3.Size = new Size(163, 15);
            label3.TabIndex = 8;
            label3.Text = "Время загрузки данных РКК:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(942, 586);
            label4.Name = "label4";
            label4.Size = new Size(232, 15);
            label4.TabIndex = 9;
            label4.Text = "Время загрузки данных по обращениям:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(941, 610);
            label5.Name = "label5";
            label5.Size = new Size(247, 15);
            label5.TabIndex = 10;
            label5.Text = "Время затраченое на отображение данных:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 637);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button button3;
        private Button button4;
        private RichTextBox richTextBox1;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}