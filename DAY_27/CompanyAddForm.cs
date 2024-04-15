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
    public partial class CompanyAddForm : Form
    {
        Employee user;

        public CompanyAddForm(Employee userData)
        {
            InitializeComponent();
            user = userData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text, sphere = textBox2.Text, date = dateTimePicker1.Text;
                if (name.Length == 0 || sphere.Length == 0 || date.Length == 0)
                {
                    throw new Exception("Заполните все поля");
                }
                using (var context = new Datab())
                {
                    var com = context.Companies.FirstOrDefault(c => c.Name == name);
                    if (com == null)
                    {
                        var country = context.Countries.FirstOrDefault(c => c.Name == date);

                        Company company = new Company(textBox1.Text, textBox2.Text, country.Id);
                        context.Companies.Add(company);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Данная компания уже есть в базе данных");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void CompanyAddForm_Load(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                var countries = context.Countries;
                foreach (var country in countries)
                {
                    //comboBox1.Items.Add(country.Name);
                }
            }
        }
    }
}
