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
    public partial class bookCollection : Form
    {
        public bookCollection()
        {
            InitializeComponent();
        }

        private void bookCollection_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addBookTbl";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            dataGridView1.DataSource = ds.Tables[0];

        }
        int BID;  // I define a global variable for book id (bid)
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                BID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells["bName"].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from addBookTbl where BID = " + BID + " ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());  //parsing the row id
            
            txtbookName.Text = ds.Tables[0].Rows[0]["bName"].ToString();
            txtBookPrice.Text = ds.Tables[0].Rows[0]["bPrice"].ToString();
            txtBQuantity.Text = ds.Tables[0].Rows[0]["bQuan"].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0]["bAuthor"].ToString();
            txtBEdition.Text = ds.Tables[0].Rows[0]["bEdition"].ToString();






            //txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            //txtBEdition.Text = ds.Tables[0].Rows[0][3].ToString();
            //txtBookPrice.Text = ds.Tables[0].Rows[0][4].ToString();
            //txtBQuantity.Text = ds.Tables[0].Rows[0][5].ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (onlineStore.Text != " ")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addBookTbl where bName LIKE '" + onlineStore.Text + "%'"; ;
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

                cmd.CommandText = "select * from addBookTbl";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void onlineRefresh_Click(object sender, EventArgs e)
        {
            onlineStore.Clear();
            panel2.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your Data will be updated! Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtbookName.Text;
                string bauthor = txtAuthor.Text;
                Int64 price = Int64.Parse(txtBookPrice.Text);
                string bedition = txtBEdition.Text;
                Int64 quan = Int64.Parse(txtBQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update addBookTbl set bName = '" + bname + "' , bAuthor = '" + bauthor + "', bPrice = " + price + ", BEdition = '" + bedition + "', BQuan = " + quan + " where BID = "+rowid+" ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }


        }

        private void deleteBttn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your Data will be deleted! Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)   //deletes all selected rows in the dataGridView
                {
                    dataGridView1.Rows.RemoveAt(item.Index);              // Removes items
                }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from addBookTbl where BID = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
                }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close(); //closes the window(form)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;       // Maximizes the window
        }

        private void minButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;    // minimizes the window
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Your Data will be deleted! Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from addBookTbl where BID = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
