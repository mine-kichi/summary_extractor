using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace summary_extractor
{
    public partial class Form2 : Form
    {
        //
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader rd;
        //
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.ConnectionString =
    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True;Connect Timeout=30";
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM [dbo].[Table]" + "WHERE Id='" + textBox1.Text + "'";
            rd = cmd.ExecuteReader();
            rd.Close();
            cn.Close();
            this.Close();

        }
    }
}
