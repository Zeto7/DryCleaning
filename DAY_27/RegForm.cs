using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAY_27.Tables;

namespace DAY_27
{
    public partial class RegForm : Form
    {
        Datab context = new Datab();

        public RegForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm lf = new LoginForm();
            this.Hide();
            lf.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text, login = textBox1.Text, password = textBox2.Text;
            try
            {
                if (name.Length == 0 || login.Length == 0 || password.Length == 0)
                {
                    throw new Exception("Заполните все поля");
                }
                else
                {
                    Employee user = new Employee(login, Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password))));
                    var us = context.Users.FirstOrDefault(u => u.Login == user.Login);

                    if (us == null)
                    {
                        context.Users.Add(user);
                        MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK);
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }

        }
    }
}
