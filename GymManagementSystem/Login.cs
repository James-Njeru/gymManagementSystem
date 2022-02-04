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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox1.Focus();

            }
            else if (TextBox2.Text == "")
            {
                MessageBox.Show("Ensure all fields are filled!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextBox2.Focus();

            }
            else
            {
                try
                {
                    conn connect = new conn();
                    string query = "SELECT * FROM  member WHERE  member_name='" + TextBox1.Text.ToString() + "' AND password='" + TextBox2.Text.ToString() + "' ";
                    //open connection
                    if (connect.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, connect.connection);
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        if (dataReader.Read())
                        {
                            Member das = new Member();
                            das.Visible = true;
                            this.Hide();
                        }
                        else
                        {
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            TextBox1.Focus();
                            MessageBox.Show("Password/Username Mismatch!");

                        }
                        connect.CloseConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
