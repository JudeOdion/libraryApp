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

namespace libraryApp
{
    public partial class loginPage : Form
    {
        public loginPage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void enterButton_Click(object sender, EventArgs e)     // This portion of the code pulls the username of the user from the libTab database to authenticate the user
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\data5.mdf;Integrated Security=True");
            string query = "Select * from libTab Where Username = '" + txtUser.Text.Trim() + "' and Password = '" + txtPass.Text.Trim() + " ' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);


            if(dtbl.Rows.Count == 1) //if the input from the Row and Column == true, allow and hide
            {
                this.Hide();
                libDashboard da = new libDashboard();
                da.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  //Display warning when the wrong username/password combination is used

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)    //Closes this login form with a dialog box to confirm action.
        {
           
        }

        private void clearBttn_Click(object sender, EventArgs e)       //Clears the content of the username and password fields
        {
            txtUser.Clear();
            txtPass.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                this.Close(); //if user action is YES, then close this form
            }
        }
    }
}
