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
    public partial class ServiceAddForm : Form
    {
        Employee user;

        public ServiceAddForm(Employee userData)
        {
            InitializeComponent();
            user = userData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text, priceStr = textBox2.Text, type = comboBox1.Text;
                if (name.Length == 0 || priceStr.Length == 0 || type.Length == 0)
                {
                    throw new Exception("Заполните все поля");
                }
                decimal price;
                if (!Decimal.TryParse(priceStr, out price))
                    throw new Exception("Стоимость имеет некорректное значение");
                using (var context = new Datab())
                {
                    var service = new Service(name, context.Types.First(s => s.Name == type).Id, price);
                    var com = context.Services.FirstOrDefault(s => s.Name == service.Name && s.TypeId == service.TypeId && s.Price == service.Price);
                    if (com == null)
                    {
                        context.Services.Add(service);
                        context.SaveChanges();
                        MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButtons.OK);
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
                foreach (var type in context.Types)
                {
                    comboBox1.Items.Add(type.Name);
                }
            }
        }
    }
}
