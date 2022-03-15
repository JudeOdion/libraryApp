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
    public partial class stuRecord : Form
    {
        public stuRecord()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)  //warning to exit or no
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != " ")
            {
                // stuLogLabel.Visible = false;
                //// Image img = Image.FromFile("C:/Users/Dell Latitude/OneDrive - MNSCU/Desktop");
                // searchPicBox.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from astTbl where enroll LIKE '" + txtSearch.Text + "%'  ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from astTbl";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
                //    stuLogLabel.Visible = true;
                //    Image img = Image.FromFile("C:/Users/Dell Latitude/OneDrive - MNSCU/Desktop");
                //    searchPicBox.Image = img;

                // }




                // { 

                //if (txtSearch.Text != " ") // if the search textbox is not empty, 
                //{
                //    SqlConnection con = new SqlConnection();  //connecting the local database to the application
                //    con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.Connection = con;

                //    cmd.CommandText = "select * from astTbl where sname LIKE '" + txtSearch.Text + "%'"; ;
                //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);


                //    dataGridView1.DataSource = ds.Tables[0];

                //}
                //else
                //{
                //    SqlConnection con = new SqlConnection();
                //    con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.Connection = con;

                //    cmd.CommandText = "select * from astTbl";
                //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);


                //    dataGridView1.DataSource = ds.Tables[0];

                //}
            }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //exiting from the menuStrip
        {
            if (MessageBox.Show("Are you sure you want to Exit this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != " ")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from astTbl where enroll LIKE '" + txtSearch.Text + "%'"; ;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from astTbl";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0];
            }

            }

        private void refButton_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();                     // this code refreshes the dataGridView
            dataGridView1.Visible = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void stuRecord_Load(object sender, EventArgs e)
        {
            //dataGridView1.Visible = false;
            //panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from astTbl";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }
        
        private void panel2_Click(object sender, EventArgs e)
        {
           
        }
        int BID;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                BID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from astTbl where stid = '"+BID+"' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

        }

        private void enterStudentsEnrollmentIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != " ")
            {
                // stuLogLabel.Visible = false;
                //// Image img = Image.FromFile("C:/Users/Dell Latitude/OneDrive - MNSCU/Desktop");
                // searchPicBox.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from astTbl where enroll LIKE '" + txtSearch.Text + "%'  ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from astTbl";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            }

        private void button3_Click(object sender, EventArgs e)     
        {
            if (MessageBox.Show("Are you sure you want to Exit this form?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();  //closes the windows(form)

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;     //minimizes the windows
        }

        private void maxBttn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;  //Maximizes the windows
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }
    }
}
