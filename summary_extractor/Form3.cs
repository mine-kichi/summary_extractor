using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace summary_extractor
{
    public partial class Form3 : Form
    {

        //
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader rd;
        private string cnstr =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True;Connect Timeout=30";
        //
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Table] where type = 'ToDo'";

            rd = cmd.ExecuteReader();
            while (rd.Read())
                listBox1.Items.Add(
                    String.Format("[{0}] {1} {2} {3} {4}",
                    rd["Id"], rd["date"], rd["type"], rd["title"], rd["overview"]));

            rd.Close();
            cn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Table] where type = 'Summary'";

            rd = cmd.ExecuteReader();
            while (rd.Read())
                listBox1.Items.Add(
                    String.Format("[{0}] {1} {2} {3} {4}",
                    rd["Id"], rd["date"], rd["type"], rd["title"], rd["overview"]));

            rd.Close();
            cn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Table] where type = 'Others'";

            rd = cmd.ExecuteReader();
            while (rd.Read())
                listBox1.Items.Add(
                    String.Format("[{0}] {1} {2} {3} {4}",
                    rd["Id"], rd["date"], rd["type"], rd["title"], rd["overview"]));

            rd.Close();
            cn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cn.ConnectionString = cnstr;
            cn.Open();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [dbo].[Table]";

            rd = cmd.ExecuteReader();
            while (rd.Read())
                listBox1.Items.Add(
                    String.Format("[{0}] {1} {2} {3} {4}",
                    rd["Id"], rd["date"], rd["type"], rd["title"], rd["overview"]));

            rd.Close();
            cn.Close();

        }
    }
}
