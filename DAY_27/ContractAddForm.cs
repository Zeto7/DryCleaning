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
    public partial class ContractAddForm : Form
    {
        Employee user;

        public ContractAddForm(Employee userData)
        {
            InitializeComponent();
            user = userData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Client? client = (Client?)comboBox1.SelectedItem;
                var services = listBox1.CheckedItems;
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;
                if (client == null)
                    throw new Exception("Клиент не выбран");
                else if (services.Count == 0)
                    throw new Exception("Не выбрана ни одна услуга");
                else
                {
                    using (var context = new Datab())
                    {
                        var contract = new Contract(client.Id, startDate, endDate);
                        context.Contracts.Add(contract);
                        context.SaveChanges();
                        foreach (Service service in services)
                            context.ContractServices.Add(new(contract.Id, service.Id));
                        context.SaveChanges();
                        MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void NoteAddForm_Load(object sender, EventArgs e)
        {
            using (var context = new Datab())
            {
                foreach (var client in context.Clients)
                    comboBox1.Items.Add(client);
                foreach (var service in context.Services)
                    listBox1.Items.Add(service);
            }
        }
    }
}
