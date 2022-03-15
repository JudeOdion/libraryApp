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
    public partial class addStudents : Form
    {
        public addStudents()
        {
            InitializeComponent();
        }

        private void exitBttn_Click(object sender, EventArgs e)   // exits the form
        {
            
            if (MessageBox.Show("Are you sure you want to Exit this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void refreshBttn_Click(object sender, EventArgs e)
        {
            txtDept.Clear();             // this portion of the code clears input on the fields
            txtEmail.Clear();
            txtEnrol.Clear();
            txtSemester.Clear();
            txtStdName.Clear();
            txtTech.Clear();
        }

        private void saveBttn_Click(object sender, EventArgs e)
        {
            string name = txtStdName.Text;                         //defining variables to receive student information
            string dept = txtDept.Text;
            string email = txtEmail.Text;
            Int64 tech = Int64.Parse(txtTech.Text);
            string enroll = txtEnrol.Text;
            string sem = txtSemester.Text;

            SqlConnection con = new SqlConnection(); // the sqlconnection object connects local database to the application
            con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();   //inputs data from the input fields into the database
            cmd.CommandText = "insert into astTbl (sname, enroll, dept, sem, email, techid) values ('" + name + "', '" + enroll + "','" + dept + "','" + sem + "','" +email + "', " + tech + ")";
            cmd.ExecuteNonQuery();
            con.Close();

            {   // warning to save or no.
                if (MessageBox.Show("Information saved here can not be deleted from this page You will have to contact Husky Teck for support. Do you still want to add Student Info?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                }
             
                { 
                    //if (MessageBox.Show("Are you sure you want to Exit this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                }

                 //MessageBox.Show("Student Info Saved Successfully.");
                //}

                //txtSemester.Clear();
                //txtDept.Clear();
                //txtEmail.Clear();
                //txtEnrol.Clear();
                //txtTech.Clear();
                //txtStdName.Clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); //this code closes/exits the form
        }
    }
}
