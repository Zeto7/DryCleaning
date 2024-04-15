using System;
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
            else if (comboBox1.Text == "Анкета")

            {
                NoteAddForm addForm = new NoteAddForm(employee);
                addForm.Owner = this;
                addForm.ShowDialog();
            }
            else if (comboBox1.Text == "Услуги")
            {
                CompanyAddForm addForm = new CompanyAddForm(employee);
                addForm.Owner = this;
                addForm.ShowDialog();
            }
            ReloadTable(comboBox1.Text);
        }

        private void ReloadTable(string text)
        {
            switch (text)
            {
                case "Клиенты":
                    comboBox2.Visible = false;
                    var employees = context.Employees.ToList();
                    dataGridView1.DataSource = employees;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Имя";
                    dataGridView1.Columns[2].HeaderText = "Фамилия";
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[4].HeaderText = "Телефон";
                    dataGridView1.Columns[5].HeaderText = "Адрес";
                    break;
                case "Договора":
                    comboBox2.Visible = false;
                    var contracts = context.Contracts.ToList();
                    dataGridView1.DataSource= contracts;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Номер клиента";
                    dataGridView1.Columns[2].HeaderText = "Дата заключения";
                    dataGridView1.Columns[3].HeaderText = "Дата окончания";
                    break;
                case "Услуги":
                    comboBox2.Visible = false;
                    var services = context.Services.Join(context.Types, s => s.TypeId, t => t.Id, (s, t) => new { s.Name, TpeName = t.Name, s.Price }).ToList();
                    dataGridView1.DataSource = services;
                    dataGridView1.Columns[0].HeaderText = "Название";
                    dataGridView1.Columns[1].HeaderText = "Тип";
                    dataGridView1.Columns[2].HeaderText = "Стоимость";
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
                switch (comboBox1.Text)
                {
                    case "Клиенты":
                        int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        Employee employee = context.Employees.FirstOrDefault(e => e.Id == id);
                        context.Employees.Remove(employee);
                        break;
                }
                MessageBox.Show("Удаление завершено", "Успех", MessageBoxButtons.OK);
                
                else if (comboBox1.Text == "Анкета")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Note note = context.Notes.FirstOrDefault(n => n.Id == id);
                    Employee emp = context.Employees.FirstOrDefault(e => e.Id == note.Employee_id);
                    emp.In_Company = false;
                    context.Notes.Remove(note);
                    MessageBox.Show("Удаление завершено", "Успех", MessageBoxButtons.OK);
                }
                else if (comboBox1.Text == "Услуги")
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Company company = context.Companies.FirstOrDefault(e => e.Id == id);
                    context.Companies.Remove(company);
                    MessageBox.Show("Удаление завершено", "Успех", MessageBoxButtons.OK);
                }
                context.SaveChanges();
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
            if (comboBox1.Text == "Клиенты")
            {
                string text = textBox1.Text.ToLower();
                var result = context.Employees.Where(e => e.Fio.StartsWith(text) && e.In_Company == false).ToList();

                dataGridView1.DataSource = result.ToList();
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "ФИО";
                dataGridView1.Columns[3].HeaderText = "Ста";
                dataGridView1.Columns[4].Visible = false;
            }
            else if (comboBox1.Text == "Анкета")
            {
                string text = textBox1.Text.ToLower();
                var result = from n in context.Notes
                             join em in context.Employees on n.Employee_id equals em.Id
                             join c in context.Companies on n.Company_id equals c.Id

                             where n.User_Id == employee.Id && em.Fio.StartsWith(text)
                             select new
                             {
                                 Id = n.Id.ToString(),
                                 EFIO = em.Fio,
                                 CName = c.Name,
                                 EStazh = em.Stazh,
                                 NDate = n.Date.ToString()
                             };
                if (comboBox2.Text != "Все")
                    result = result.Where(r => r.CName == comboBox2.Text);
                dataGridView1.DataSource = result.ToList();
                
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[2].HeaderText = "Компания";
                dataGridView1.Columns[3].HeaderText = "Место жительства";
                dataGridView1.Columns[4].HeaderText = "Дата окончания";
            }
            else if (comboBox1.Text == "Услуги")
            {
                string text = textBox1.Text.ToLower();
                var result = from n in context.Companies
                             join c in context.Countries on n.Country_id equals c.Id
                             where n.Name.StartsWith(text)
                             select new
                             {
                                 Id = n.Id.ToString(),
                                 CName = n.Name,
                                 CSphere = n.Sphere,
                                 Countr = c.Name
                             };
                dataGridView1.DataSource = result.ToList();
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[2].HeaderText = "Цена";
                dataGridView1.Columns[3].HeaderText = "Страна";
            }
        }
    }
}