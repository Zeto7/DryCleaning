using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAY_27.Tables;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;

namespace DAY_27
{
    public partial class MainForm : Form
    {
        Employee employee;
        Datab context = new Datab();

        public MainForm(Employee userData)
        {
            InitializeComponent();
            employee = userData;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Все");
            //var companies = context.;
            //foreach (var company in companies)
            //{
            //    comboBox2.Items.Add(company.Name);
            //}
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Клиенты")
            {
                AddForm addForm = new AddForm(employee);
                addForm.Owner = this;
                addForm.ShowDialog();
            }
            else if (comboBox1.Text == "Договора")
            {
                ContractAddForm addForm = new ContractAddForm(employee);
                addForm.Owner = this;
                addForm.ShowDialog();
            }
            else if (comboBox1.Text == "Услуги")
            {
                ServiceAddForm addForm = new ServiceAddForm(employee);
                addForm.Owner = this;
                addForm.ShowDialog();
            }
            ReloadTable(comboBox1.Text);
        }

        bool onContract = false;
        private void LoadTable(string label, object data)
        {
            onContract = false;
            switch (label)
            {
                case "Клиенты":
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = data;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Имя";
                    dataGridView1.Columns[2].HeaderText = "Фамилия";
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[4].HeaderText = "Телефон";
                    dataGridView1.Columns[5].HeaderText = "Адрес";
                    break;
                case "Договора":
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Columns[dataGridView1.Columns.Add("Id", "")].Visible = false;
                    dataGridView1.Columns.Add("Client", "Клиент");
                    dataGridView1.Columns.Add("StartDate", "Дата заключения");
                    dataGridView1.Columns.Add("CompletionDate", "Дата окончания");
                    dataGridView1.Columns.Add("Services", "Услуги");
                    foreach (var entry in (List<Contract>)data)
                    {
                        var row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = entry.Id });
                        row.Cells.Add(new DataGridViewLinkCell { Value = "@" });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = entry.StartDate.ToShortDateString() });
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = entry.CompletionDate?.ToShortDateString() });
                        var typesColumn = new DataGridViewTextBoxCell { Value = string.Join("\n", context.ContractServices.Where(cs => cs.ContractId == entry.Id).Join(context.Services, cs => cs.ServiceId, s => s.Id, (cs, s) => s.Name)) };
                        typesColumn.Style.WrapMode = DataGridViewTriState.True;
                        row.Cells.Add(typesColumn);
                        row.Height = row.GetPreferredHeight(dataGridView1.Rows.Add(row), DataGridViewAutoSizeRowMode.AllCells, false);
                    }
                    onContract = true;
                    break;
                case "Услуги":
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = data;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[2].HeaderText = "Тип";
                    dataGridView1.Columns[3].HeaderText = "Стоимость";
                    break;
            }
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (onContract && e.ColumnIndex == 1)
            {
                int contractId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                comboBox1.Text = "Клиенты";
                ReloadTable(comboBox1.Text);
                int clientId = context.Contracts.First(c => c.Id == contractId).ClientId;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    if (row.Cells[0].Value.ToString() == clientId.ToString())
                    {
                        row.Selected = true;
                        break;
                    }
            }
        }

        private void ReloadTable(string text)
        {
            switch (text)
            {
                case "Клиенты":
                    comboBox2.Visible = false;
                    var clients = context.Clients.ToList();
                    LoadTable(text, clients);
                    break;
                case "Договора":
                    comboBox2.Visible = false;
                    var contracts = context.Contracts.ToList();
                    LoadTable(text, contracts);
                    break;
                case "Услуги":
                    comboBox2.Visible = false;
                    var services = context.Services.Join(context.Types, s => s.TypeId, t => t.Id, (s, t) => new { s.Id, s.Name, TpeName = t.Name, s.Price }).ToList();
                    LoadTable(text, services);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Нет выделеных обьектов для удаления", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            else
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                switch (comboBox1.Text)
                {
                    case "Клиенты":
                        var client = context.Clients.First(c => c.Id == id);
                        var clientContracts = context.Contracts.Where(c => c.ClientId == client.Id).ToList(); 
                        if (clientContracts.Count() > 0 && MessageBox.Show("Удаление клиента повлечет за собой удаление одного или нескольких договоров, продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                            return;
                        foreach (var c in clientContracts)
                            context.ContractServices.RemoveRange(context.ContractServices.Where(cs => cs.ContractId == c.Id));
                        context.SaveChanges();
                        context.Contracts.RemoveRange(clientContracts);
                        context.SaveChanges();
                        context.Clients.Remove(client);
                        break;
                    case "Договора":
                        var contract = context.Contracts.First(c => c.Id == id);
                        context.ContractServices.RemoveRange(context.ContractServices.Where(cs => cs.ContractId == contract.Id));
                        context.SaveChanges();
                        context.Contracts.Remove(contract);
                        break;
                    case "Услуги":
                        var service = context.Services.First(c => c.Id == id);
                        var contractServices = context.ContractServices.Where(cs => cs.ServiceId == service.Id).ToList();
                        var emptyContracts = context.Contracts.GroupJoin(context.ContractServices, c => c.Id, cs => cs.ContractId, (c, cs) => new { Contract = c, Services = cs }).Where(c => c.Services.Any(s => s.ServiceId == service.Id) && c.Services.Count() == 1).Select(c => c.Contract).ToList();
                        if (emptyContracts.Count() > 0 && MessageBox.Show("Удаление услуги повлечет за собой удаление одного или нескольких договоров, продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                            return;
                        context.ContractServices.RemoveRange(contractServices);
                        context.SaveChanges();
                        context.Contracts.RemoveRange(emptyContracts);
                        context.SaveChanges();
                        context.Services.Remove(service);
                        break;
                }
                context.SaveChanges();
                MessageBox.Show("Удаление завершено", "Успех", MessageBoxButtons.OK);
            }
            ReloadTable(comboBox1.Text);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            ReloadTable(comboBox1.Text);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Все") ReloadTable(comboBox1.Text);
            //else
            //{
            //    string name = comboBox2.Text.ToLower();
            //    var result = from n in context.Notes
            //                 join em in context.Employees on n.Employee_id equals em.Id
            //                 join c in context.Companies on n.Company_id equals c.Id
            //                 where n.User_Id == employee.Id && c.Name.Equals(name)
            //                 select new
            //                 {
            //                     Id = n.Id.ToString(),
            //                     EFIO = em.Fio,
            //                     CName = c.Name,
            //                     EStazh = em.Stazh,
            //                     NDate = n.Date.ToString()
            //                 };
            //    dataGridView1.DataSource = result.ToList();
            //}
            //if (dataGridView1.Columns.Count > 0)
            //{
            //    dataGridView1.Columns[0].HeaderText = "№";
            //    dataGridView1.Columns[1].HeaderText = "ФИО";
            //    dataGridView1.Columns[2].HeaderText = "Услуга";
            //    dataGridView1.Columns[3].HeaderText = "Место жительства";
            //    dataGridView1.Columns[4].HeaderText = "Дата окончания";
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string table = comboBox1.Text;
            string text = textBox1.Text.ToLower();
            object result;
            switch (table)
            {
                case "Клиенты":
                    result = context.Clients.Where(c => c.Surname.StartsWith(text)).ToList();
                    break;
                case "Договора":
                    result = context.Contracts.Where(c => c.ClientId.ToString() == text).ToList();
                    break;
                case "Услуги":
                    result = context.Services.Where(s => s.Name.StartsWith(text)).ToList();
                    break;
                default:
                    return;
            }
            LoadTable(table, result);
        }
    }
}