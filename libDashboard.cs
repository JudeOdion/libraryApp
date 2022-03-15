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
    public partial class libDashboard : Form
    {
        public libDashboard()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)  // this code asks the user to CONFIRM if they want to close the application (from the menustrip)
        {
            if (MessageBox.Show("Are you sure you want to Exit the Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            
            Application.Exit();  //if user action is YES, this portion of the code closes the application
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)  
        {
            addBooks abs = new addBooks();  //This portion of the code JOINS the ADDBOOK form to the dashboard form
            abs.Show();
        }

        private void viewBookCatalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookCollection bc = new bookCollection();  //This portion of the code JOINS the BOOK COLLECTION  form to the dashboard form
            bc.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            SqlConnection con = new SqlConnection();   // the SqlConnection object con connects the local database to the application
            con.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\data5.mdf; Integrated Security = True; Connect Timeout = 30";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addBookTbl";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
        }

        private void newStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStudents ast = new addStudents();  //This portion of the code JOINS the ADDSTUDENT form to the dashboard form
            ast.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void graduatingStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stuRecord str = new stuRecord();   // This portion of the code JOINS the STURECORD form to the dashboard form
            str.Show();
        }

        private void exitBttn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit the Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                Application.Exit(); //this portion of the code allows the user exit the application
        }

        private void label1_Click(object sender, EventArgs e)
        {
            addBooks abs = new addBooks();  //This portion of the code JOINS the "Add New Book" option on the dashboard to the addBook form
            abs.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            bookCollection bc = new bookCollection();  //This portion of the code JOINS the "View book" option on the dashboard to the dashboard bookCollection form
            bc.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            addStudents ast = new addStudents();  //This portion of the code joins the "add student" option on the dashboard to the addstudent form
            ast.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            stuRecord str = new stuRecord();  //This portion of the code joins the "view student record" option on the dashboard to the stuRec form
            str.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;          //minimizes the window
        }

        private void maxButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;           //maximizes the window
        }

        private void closeButton_Click(object sender, EventArgs e)     
        {

            this.Close();                 //closes the window
           
        }
    }
}
