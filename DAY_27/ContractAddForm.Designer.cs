using System.Windows.Forms;

namespace DAY_27
{
    partial class ContractAddForm
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
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            listBox1 = new CheckedListBox();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 18);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(85, 30);
            label1.TabIndex = 0;
            label1.Text = "Клиент:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 109);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(81, 30);
            label2.TabIndex = 1;
            label2.Text = "Услуги:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(69, 54);
            comboBox1.Margin = new Padding(5, 6, 5, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 38);
            comboBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(69, 542);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(151, 68);
            button1.TabIndex = 4;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.Location = new Point(69, 142);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(242, 228);
            listBox1.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(69, 411);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(242, 35);
            dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 378);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(186, 30);
            label3.TabIndex = 7;
            label3.Text = "Дата заключения:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 453);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(174, 30);
            label4.TabIndex = 9;
            label4.Text = "Дата окончания:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(69, 486);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(242, 35);
            dateTimePicker2.TabIndex = 8;
            // 
            // ContractAddForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 625);
            Controls.Add(label4);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(dateTimePicker1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ContractAddForm";
            Text = "ContractAddForm";
            Load += NoteAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private Button button1;
        private CheckedListBox listBox1;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker2;
    }
}