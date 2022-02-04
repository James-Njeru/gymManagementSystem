using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GymManagementSystem
{
    public partial class Member : Form
    {
        String query;
        DataTable dt;
        int index = 0;

        public Member()
        {
            InitializeComponent();
        }

        public void showData(int position)
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM member";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                MySqlDataAdapter da;
                dt = new DataTable();
                da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                DataGridView1.DataSource = dt;

                //Read the data and store them in the list
                TextBox1.Text = dt.Rows[position]["member_id"].ToString();
                TextBox2.Text = dt.Rows[position]["member_name"].ToString();
                TextBox3.Text = dt.Rows[position]["contact_number"].ToString();
                TextBox4.Text = dt.Rows[position]["member_address"].ToString();
                TextBox5.Text = dt.Rows[position]["checkin"].ToString();
                TextBox6.Text = dt.Rows[position]["checkout"].ToString();
                TextBox7.Text = dt.Rows[position]["password"].ToString();

                connect.CloseConnection();
            }
        }

        private void Member_Load(object sender, EventArgs e)
        {
            
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            conn connect = new conn();
            if (connect.OpenConnection() == true)
            {
                query = "SELECT * FROM member";
                MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                if (dataReader.Read())
                {
                    this.TextBox1.Text = dataReader["member_id"].ToString();
                    this.TextBox2.Text = dataReader["member_name"].ToString();
                    this.TextBox3.Text = dataReader["contact_number"].ToString();
                    this.TextBox4.Text = dataReader["member_address"].ToString();
                    this.TextBox5.Text = dataReader["checkin"].ToString();
                    this.TextBox6.Text = dataReader["checkout"].ToString();
                    this.TextBox7.Text = dataReader["password"].ToString();
                }
                connect.CloseConnection();
            }
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            index = dt.Rows.Count - 1;
            showData(index);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            showData(index);
            index = dt.Rows.Count + 1;
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            index -= 1;
            showData(index);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "insert into member values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();
                    MessageBox.Show("Record Successfully saved!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "update member set member_id='" + TextBox1.Text + "', member_name='" + TextBox2.Text + "', contact_number='" + TextBox3.Text + "', member_address='" + TextBox4.Text + "', checkin='" + TextBox5.Text + "', checkout='" + TextBox6.Text + "', password='" + TextBox7.Text + "' where member_id='" + TextBox1.Text + "' ";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();
                    MessageBox.Show("Record updated Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn connect = new conn();
                string query = "delete from member where member_id='" + TextBox1.Text + "' ";

                if (connect.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                    cmd.ExecuteNonQuery();
                    connect.CloseConnection();

                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    MessageBox.Show("Record deleted Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
