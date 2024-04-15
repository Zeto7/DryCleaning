using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace DAY_27
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm rf = new RegForm();
            this.Hide();
            rf.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text, password = textBox2.Text;
            using (var context = new Datab())
            {
                try
                {
                    if (login.Length == 0 || password.Length == 0)
                    {
                        throw new Exception("Заполните поля");
                    }
                    else
                    {
                        var user = context.Employees.FirstOrDefault(e => e.Lo == login && SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual(Convert.FromHexString(e.Password)));
                        if(user != null && user.Login == login)
                        {
                            MainForm mf = new MainForm(user);
                            this.Hide();
                            Application.Run(mf);
                            
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль неверный", "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }
    }
}
