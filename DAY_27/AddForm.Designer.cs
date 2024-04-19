namespace DAY_27
{
    partial class AddForm
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
            textBox1 = new TextBox();
            this.textBox4 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox5 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 7);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 30);
            label1.TabIndex = 0;
            label1.Text = "Имя:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 241);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 30);
            label2.TabIndex = 1;
            label2.Text = "Адрес:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(21, 43);
            textBox1.Margin = new Padding(5, 6, 5, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(271, 35);
            textBox1.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Point(21, 277);
            this.textBox4.Margin = new Padding(5, 6, 5, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(271, 35);
            this.textBox4.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(21, 422);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(168, 84);
            button1.TabIndex = 4;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(21, 121);
            textBox2.Margin = new Padding(5, 6, 5, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(271, 35);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 85);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 5;
            label3.Text = "Фамилия:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(21, 200);
            textBox3.Margin = new Padding(5, 6, 5, 6);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(271, 35);
            textBox3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 164);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(108, 30);
            label4.TabIndex = 7;
            label4.Text = "Отчество:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(21, 360);
            textBox5.Margin = new Padding(5, 6, 5, 6);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(271, 35);
            textBox5.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 324);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(180, 30);
            label5.TabIndex = 9;
            label5.Text = "Номер телефона:";
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 522);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(this.textBox4);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox4;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox5;
        private Label label5;
    }
}