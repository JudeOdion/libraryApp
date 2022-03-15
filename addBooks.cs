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
    public partial class addBooks : Form
    {
        public addBooks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (txtBookName.Text != "" && txtBookPrice.Text != "" && txtBookQuan.Text != "" && txtAuthor.Text != "")
            {


                string addBk = txtBookName.Text;                 //the following codes creates the variables to receive inputs about the books
                string bPDate = dateTimePicker1.Text;
                Int64 bPrice = Int64.Parse(txtBookPrice.Text);
                Int64 bQuan = Int64.Parse(txtBookQuan.Text);
                string bAuth = txtAuthor.Text;
                string BEdition = txtEdition.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into addBookTbl (bName, bPDate, bPrice, bQuan, bAuthor, BEdition) values ('" + addBk + "', '" + bPDate + "'," + bPrice + "," + bQuan + ",'" + bAuth + "', '" + BEdition + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

                

            }
               else
            {
                MessageBox.Show("Empty Fields NOT Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }

          }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will clear your data!", "Do you still want to close this?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // this code clears the input on the fields
                txtBookName.Clear();
                txtBookPrice.Clear();
                txtBookQuan.Clear();
                txtAuthor.Clear();
                txtEdition.Clear();
            }
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();          // this code closes the form
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;  // this Maximizes the Window

        }

        private void button1_Click_1(object sender, EventArgs e)

        {
            this.WindowState = FormWindowState.Minimized; // this Minimizes the Window
        }
    }
      }
