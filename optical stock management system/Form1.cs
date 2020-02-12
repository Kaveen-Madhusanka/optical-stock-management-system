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

namespace optical_stock_management_system
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\optical.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string dbpass;
            try 
            {
                SqlCommand cmd = new SqlCommand("select password from login where uname='" + txtuname.Text + "'", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    dbpass = rdr.GetString(0);
                    //MessageBox.Show(dbpass);
                    if (txtpassword.Text == dbpass)
                    {
                        //MessageBox.Show("login ok", "CAPTION ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                         new Stock().Show();
                         this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("check password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("check password and user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
           

            

        }
    }
}
