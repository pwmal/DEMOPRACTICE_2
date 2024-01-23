using Npgsql;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DEMOPRACTICE_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SQLtoDB("SELECT * FROM products ORDER BY id");
            comboBox1.Items.AddRange(new string[] { "А -> Я", "Я -> А" });
            comboBox2.Items.AddRange(new string[] { "Мин -> Макс", "Макс -> Мин" });
        }

        NpgsqlConnection connString = new NpgsqlConnection("Host=localhost;Port=5432;Database=shop;Username=postgres;Password=1234");
        private DataSet informationFromDB = new DataSet();
        private DataTable infTable = new DataTable();

        public void SQLtoDB(string sql)
        {
            connString.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, connString);
            NpgsqlDataAdapter dataAd = new NpgsqlDataAdapter(sql, connString);
            informationFromDB.Reset();
            dataAd.Fill(informationFromDB);
            infTable = informationFromDB.Tables[0];
            dataGridView1.DataSource = infTable;
            connString.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    SQLtoDB($"SELECT * FROM products WHERE name LIKE '%{textBox1.Text}%'");
                    button2.Visible = true;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLtoDB("SELECT * FROM products ORDER BY id");
            textBox1.Text = "";
            button2.Visible = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SQLtoDB("SELECT * FROM products ORDER BY name ASC");
                comboBox2.SelectedIndex = -1;
                button3.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                SQLtoDB("SELECT * FROM products ORDER BY name DESC");
                comboBox2.SelectedIndex = -1;
                button3.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                SQLtoDB("SELECT * FROM products ORDER BY price ASC");
                comboBox1.SelectedIndex = -1;
                button3.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                SQLtoDB("SELECT * FROM products ORDER BY price DESC");
                comboBox1.SelectedIndex = -1;
                button3.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLtoDB("SELECT * FROM products ORDER BY id");
            button3.Visible = false;
            textBox1.Enabled = true;
            button1.Enabled = true;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
    }
}