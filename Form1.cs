using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace summary_extractor
{
    public partial class Form1 : Form
    {

        private SqlConnection cn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataReader rd;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 日々書き込んでいくファイル作成関数。
        /// フォルダ指定機能作成予定
        /// ファイル名も日付にする予定
        /// </summary>
        private void makeFileBtn(object sender, EventArgs e)
        {

            // 日付取得
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString("yyyy/MM/dd"));
            string path = dt.ToString("yyyyMMdd") + ".md";
            // FileInfoのインスタンスを生成する
            FileInfo fileInfo = new FileInfo(path);
            if (File.Exists(path))
            {
                MessageBox.Show("日付ファイルはすでに存在します");
            }
            else
            {
                // ファイルを作成する
                FileStream fileStream = fileInfo.Create();
                fileStream.Close();
            }

        }

        /// <summary>
        /// 抽出ボタン実行部/DBへ追加
        /// </summary>
        private void extractBtn(object sender, EventArgs e)
        {

            int flg = 0; //
            string type = null; //
                                //            List<string> list = new List<string>();
            string text = null;
            string fileName;
            string fileNameWithOutExtension;

            if (String.IsNullOrEmpty(textBox2.Text))
            {

                // 日付取得
                DateTime dt = DateTime.Now;
                Console.WriteLine(dt.ToString("yyyy/MM/dd"));
                fileName = dt.ToString("yyyyMMdd") + ".md";
                FileInfo fileInfo = new FileInfo(fileName);
                if (!File.Exists(fileName))
                {
                    // ファイルを作成する
                    FileStream fileStream = fileInfo.Create();
                    fileStream.Close();
                }
                fileName = dt.ToString("yyyyMMdd") + ".md";
                fileNameWithOutExtension = Path.GetFileNameWithoutExtension(fileName);
            }
            else
            {
                fileName = @textBox2.Text;
                fileNameWithOutExtension = Path.GetFileNameWithoutExtension(fileName);

            }

            // ファイルを一行ずつ読み込み
            foreach (string line in System.IO.File.ReadLines(fileName))
            {
                Debug.Print(line);
                if (flg == 0)
                {
                    //<Todo/>開始
                    //</Todo>終わり
                    if (line == "<ToDo/>")
                    {
                        flg = 1;
                        type = "ToDo";
                    }
                    else if (line == "<QA/>")
                    {
                        flg = 1;
                        type = "QA";
                    }
                    else if (line == "<Others/>")
                    {
                        flg = 1;
                        type = "Others";
                    }

                }
                else
                {
                    if (line == "</ToDo>" || line == "</QA>" || line == "</Others>")
                    {
                        //                        additionSentence(type, fileNameWithOutExtension, list);
                        additionSentence(type, fileNameWithOutExtension, text);
                        //初期化
                        flg = 0;
                        type = null;
                        text = null;
                        //                        list = new List<string>();
                        continue;
                    }
                    text += line + "\n";
                    //                    list.Add(line);
                }
            }
        }

        /// <summary>
        /// ファイル/DBに抽出事項を追記する関数
        /// </summary>
//        private void additionSentence(string type, string fileNameWithOutExtension, List<string> S)
        private void additionSentence(string type, string fileNameWithOutExtension, string S)
        {
            // ここでDBに追記していけばいいのかな
            cn.ConnectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB.mdf;Integrated Security=True;Connect Timeout=30";
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            // 現在のレコード数を検索
            cmd.CommandText = "select count(*) from [dbo].[Table]";
            int id_cnt = (int)cmd.ExecuteScalar() + 1;
            //            foreach(string s in S)
            //            {
            //                Debug.Print(S);
            //            }
            // 日付取得
            // fileNameWithOutExtensionが日付のはず
            // type
            // そのまま
            // overview
            // id,date,type,title,overview
            // タイトル？え？あったっけ？後で追加って感じかぁ。。。文章書きながらタイトル一行目をタイトルにするか、、、後で。
            // テキストから抽出しDBへ追加
            cmd.CommandText = "INSERT INTO [dbo].[Table] VALUES( " +
                                "'" + id_cnt + "'," + // id
                                "N'" + fileNameWithOutExtension + "'," + // date
                                "N'" + type + "'," + // type
                                "N'" + "" + "'," + // title
                                "N'" + S + "')"; // overview
            rd = cmd.ExecuteReader();
            rd.Close();
            cn.Close();

        }


        private void closeBtn(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string openFileName;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog2.FileName;
            }
            else
            {
                return;
            }

            textBox2.Clear();
            textBox2.Text = openFileName;

        }

        /// <summary>
        /// close
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string openFileName;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            textBox1.Clear();
            textBox1.Text = openFileName;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.FileName = "code";
            pInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pInfo.Arguments = textBox1.Text;
            Process.Start(pInfo);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //            Form3 frm = new Form3();
            Form4 frm = new Form4();
            frm.ShowDialog();

        }
    }
}
