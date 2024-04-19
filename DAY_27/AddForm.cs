using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAY_27.Tables;

namespace DAY_27
{
    public partial class AddForm : Form
    {
        Employee user;

        public AddForm(Employee userData)
        {
            InitializeComponent();
            user = userData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            if (client.Name.Length == 0 || 
                client.Surname.Length == 0 ||
                client.Fathername.Length == 0 ||
                client.Adress.Length == 0 ||
                client.Phone.Length == 0)
            {
                throw new Exception("Заполните все поля");
            }
            else
            {
                using (var context = new Datab())
                {
                    try
                    {                        
                        if (context.Clients.FirstOrDefault(c => 
                            c.Name == client.Name &&
                            c.Surname == client.Surname &&
                            c.Fathername == client.Fathername &&
                            c.Adress == client.Adress &&
                            c.Phone == client.Phone
                        ) == null)
                        {
                            context.Clients.Add(client);
                            MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Клиент уже есть в БД", "Ошибка", MessageBoxButtons.OK);
                        }
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
