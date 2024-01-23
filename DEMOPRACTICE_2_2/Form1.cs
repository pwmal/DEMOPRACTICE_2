using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Npgsql;

namespace DEMOPRACTICE_2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection connString = new NpgsqlConnection("Host=localhost;Port=5432;Database=shop;Username=postgres;Password=1234");
                connString.Open();
                connString.Close();
                label1.Text = "Всё замечательно!";
                label1.ForeColor = Color.Green;
                label1.Visible = true;
            }
            catch
            {
                MessageBox.Show("Строка подключения содержит ошибку!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var trimmedEmail = textBox2.Text.Trim();
                if (trimmedEmail.EndsWith("."))
                {
                    throw new Exception();
                }
                var addr = new System.Net.Mail.MailAddress(textBox2.Text);
                if (addr.Address == trimmedEmail)
                {
                    label2.ForeColor = Color.Green;
                    label2.Visible = true;
                    label2.Text = "Всё верно!";
                }
            }
            catch
            {
                MessageBox.Show("Почта введена неправильно");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string str = maskedTextBox1.Text.Trim();
                if (str.Length == 15)
                {
                    label3.Visible = true;
                    label3.Text = "Всё отлично!";
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Телефон введён неправильно!");
            }
        }
    }
}