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
    public partial class NoteAddForm : Form
    {
        Employee user;

        public NoteAddForm(Employee userData)
        {
            InitializeComponent();
            user = userData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string empName = comboBox1.Text, compName = comboBox2.Text;
            if (empName.Length == 0 || compName.Length == 0)
            {
                throw new Exception("Заполните все поля");
            }
            else
            {
                using (var context = new Datab())
                {
                    try
                    {
                        var company = context.Companies.FirstOrDefault(c => c.Name == compName);
                        var emp = context.Employees.FirstOrDefault(em => em.Fio == empName);
                        Note note = new Note(user.Id, emp.Id, company.Id, DateTime.Now.ToShortDateString());

                        emp.In_Company = true;
                        context.Notes.Add(note);
                        MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButtons.OK);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }

        }

        private void NoteAddForm_Load(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var elements1 = context.Employees.ToList();
                foreach(var employee in elements1)
                {
                    comboBox1.Items.Add(employee.Fio);
                }

                var elements2 = context.Companies.ToList();
                foreach (var company in elements2)
                {
                    comboBox2.Items.Add(company.Name);
                }
            }
        }
    }
}
