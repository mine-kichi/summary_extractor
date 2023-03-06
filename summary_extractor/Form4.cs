using System;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;

namespace summary_extractor
{
    public partial class Form4 : Form
    {
        //
        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader rd;
        //
        public Form4()
        {
            InitializeComponent();
        }

        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dBDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'dBDataSet.Table' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.tableTableAdapter.Fill(this.dBDataSet.Table);

        }

        private void tableBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dBDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cn.ConnectionString =
@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True;Connect Timeout=30";
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
/*            cmd.CommandText = "DELETE FROM [dbo].[Table]" + "WHERE Id='" + textBox1.Text + "'";
            rd = cmd.ExecuteReader();
            rd.Close();
            cn.Close();
*/

            // 日付取得
            DateTime dt = DateTime.Now;
            string fileName = dt.ToString("yyyyMMdd") + ".md";
            FileInfo fileInfo = new FileInfo(fileName);
            if (!File.Exists(fileName))
            {
                // ファイルを作成する
                FileStream fileStream = fileInfo.Create();
                fileStream.Close();
            }
            fileName = dt.ToString("yyyyMMdd") + ".md";

            // 中身を書き出していく
            // ファイルを開いて、、、文字を追記。それぞれごとに改行はすべきかな。
            using (var writer = new StreamWriter(fileName, true))
            {
                // 日付
                writer.WriteLine(dt.ToString("yyyyMMdd"));

                // type
/*                cmd.CommandText = "SELECT * FROM [dbo].[Table] where type = 'Others'";
                int id_cnt = (int)cmd.ExecuteScalar() + 1;
*/                writer.WriteLine("ToDo");
                // overview
                cmd.CommandText = "SELECT * FROM [dbo].[Table] where extract_check = 1 ";
//                cmd.CommandText = "SELECT * FROM [dbo].[Table]";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {

//                    SqlBoolean check = rd.GetSqlBoolean(5);
//                    writer.WriteLine(check);
                    int id = (int)rd.GetValue(0);
                    writer.WriteLine(id);
                    string date = rd.GetDateTime(1).ToString("yyyyMMdd");
                    writer.WriteLine(date);
                    string type = (string)rd.GetValue(2);
                    writer.WriteLine(type);
                    string text = (string)rd.GetValue(4);
                    writer.WriteLine(text);
                }
                rd.Close();
                cn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
