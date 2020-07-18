using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace authWF
{
    public partial class Form1 : Form
    {
        public static string BD{ get; set; }
        public static string login { get; set; }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            BD = "Users";
            string password = textBox2.Text;
            if (CheckPswd() == password)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }

            else
            {
                label3.Visible = true;
            }

        }

        private string CheckPswd()
            {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = $"Select Password FROM {BD} WHERE Login='{login}'";
            string passfrombase = Base64Decode(Convert.ToString(sqlCmd.ExecuteScalar()));
            conn.Close();
            return passfrombase;
            
            }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
