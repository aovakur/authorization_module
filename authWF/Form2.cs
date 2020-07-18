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

namespace authWF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Users.Name = textBox1.Text;
            Users.Surname = textBox2.Text;
            Users.Patronymic = textBox3.Text;
            Users.Date = textBox11.Text;
            Users.Position = textBox4.Text;
            Users.Mail = textBox5.Text;
            Users.Login = textBox8.Text;
            Users.Views = textBox7.Text;
            Users.Accesses = textBox6.Text;


            if (textBox9.Text != textBox10.Text)
            {
                textBox9.BackColor = Color.Red;
                textBox10.BackColor = Color.Red;
                label9.Visible = true;
                label13.Visible = true;
                label9.Text = "Пароли не равны или не введены";
                label13.Text = "Пароли не равны или не введены";
            }
            else
            {
                label9.Visible = false;
                label13.Visible = false;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                Users.Password = Base64Encode(textBox9.Text);
                Users.PasswordRepeat = Base64Encode(textBox10.Text);
               // string login = Form1.login;
                string BD = Form1.BD;

                WriteToBD(BD,Users.Name, Users.Surname, Users.Patronymic, Users.Date, Users.Position, Users.Mail, Users.Login, Users.Views, Users.Accesses, Users.Password);
            }
        }

        private void WriteToBD(string BD, string name, string surname, string patronymic, string date, string position, string mail, string login, string views, string accesses, string password)
        {
            try
            {
                SqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = $"INSERT INTO {BD}(Name,Surname,Patronymic,Date,Login,Password,Mail,Accesses,Views,Position) VALUES ('{name}','{surname}','{patronymic}','{date}','{login}','{password}','{mail}','{accesses}','{views}','{position}')";
                sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch { }
            finally
            {
                textBox1.Enabled=false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox11.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;


            }
        }

        
        public static string Base64Encode(string password)
        {
            var passwordinbase64 = System.Text.Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(passwordinbase64);
        }

        public void Form2_Load(object sender, EventArgs e)
        {
         
           
        }

        

        private void редактированиеПрофиляToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытыеСчетаКомпанииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void редактированиеПрофиляToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = $"Select * FROM {Form1.BD} WHERE Login='{Form1.login}'";
            var reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader.GetValue(1).ToString();
                textBox2.Text = reader.GetValue(2).ToString();
                textBox3.Text = reader.GetValue(3).ToString();
                textBox11.Text = reader.GetValue(4).ToString();

                textBox4.Text = reader.GetValue(10).ToString();

                textBox5.Text = reader.GetValue(7).ToString();
                textBox8.Text = reader.GetValue(5).ToString();


                textBox6.Text = reader.GetValue(8).ToString();
                textBox7.Text = reader.GetValue(9).ToString();
                
                textBox9.Text = reader.GetValue(6).ToString();
            
            }
            conn.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
