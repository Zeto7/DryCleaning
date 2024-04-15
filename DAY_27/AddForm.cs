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
            string name = textBox1.Text, stazh = textBox2.Text;
            if (name.Length == 0 || stazh.Length == 0)
            {
                throw new Exception("Заполните все поля");
            }
            else
            {
                using (var context = new Datab())
                {
                    try
                    {
                        Employee employee = new Employee(user.Id, name, stazh, false);
                        var co = context.Employees.FirstOrDefault(em => em.Fio == employee.Fio);
                    
                        if(co == null)
                        {
                            context.Employees.Add(employee);
                            MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Сотрудник уже есть в БД", "Ошибка", MessageBoxButtons.OK);
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
