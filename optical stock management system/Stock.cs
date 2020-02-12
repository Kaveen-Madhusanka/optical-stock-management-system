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
    public partial class Stock : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\optical.mdf;Integrated Security=True;Connect Timeout=30");

        public void display()
        {
            SqlDataAdapter adr = new SqlDataAdapter("select * from item ", con);
            DataTable dt = new DataTable();
            con.Open();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
 
        }

        public void clear()
        {
            txtitem_id.Text="";
            txtquntity.Text = "";
            txtprice.Text = "";
            txtsupplyer_id.Text = "";

        }

        public Stock()
        {
            InitializeComponent();

            txtdate.Text = Convert.ToString(DateTime.Now);
            display();

           
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try 
            {
                txtdate.Text = Convert.ToString(DateTime.Now);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into item(item_id,supplyer_id,quntity,Supplyer_TP,date) values('" + txtitem_id.Text + "','" + txtsupplyer_id.Text + "','" + txtquntity.Text + "','" + txtprice.Text + "','" + txtdate.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("inserted");
                con.Close();
                clear();
                display();

                

               
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

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                txtdate.Text = Convert.ToString(DateTime.Now);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from item where item_id = '" + txtitem_id.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted");
                con.Close();
                clear();
                display();



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

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try 
            {
                txtdate.Text = Convert.ToString(DateTime.Now);
                SqlDataAdapter adr = new SqlDataAdapter("select * from item where item_id = '" + txtitem_id.Text + "'", con);
                DataTable dt = new DataTable();
                con.Open();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
 
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            txtdate.Text = Convert.ToString(DateTime.Now);
            clear();
            display();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                txtdate.Text = Convert.ToString(DateTime.Now);
                con.Open();
                SqlCommand cmd = new SqlCommand("update item set supplyer_id= '" + txtsupplyer_id.Text + "',quntity='" + txtquntity.Text + "',Supplyer_TP='" + txtprice.Text + "' where item_id = '" + txtitem_id.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("updated");
                con.Close();
                clear();
                display();
 
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

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Add_Items().Show();
            this.Hide();
        }

        private void issueItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new issue_items().Show();
            this.Hide();

        }

        private void txtitem_id_Leave(object sender, EventArgs e)
        {
            
            if (txtitem_id.TextLength == 0)
            {
               
                MessageBox.Show("check item id", "can not blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // erpBlanck.Clear();
            }
        }

        private void txtsupplyer_id_Leave(object sender, EventArgs e)
        {
             if (txtsupplyer_id.TextLength == 0)
            {

                MessageBox.Show("check Supplyer id", "can not blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // erpBlanck.Clear();
            }

        }

        private void txtquntity_Leave(object sender, EventArgs e)
        {
            int qun =Convert.ToInt32(txtquntity.Text);
            if (txtquntity.Text.All(char.IsDigit) != true)
            {
                MessageBox.Show("check quntity", "Only positive Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtquntity.TextLength == 0)
            {

                MessageBox.Show("check quntity", "can not blank or ", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            
        }

        private void txtprice_Leave(object sender, EventArgs e)
        {
            if (txtprice.Text.All(char.IsDigit) != true)
            {
                MessageBox.Show("check Telephone no", "Only Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtprice.TextLength != 10)
            {

                MessageBox.Show("check Telephone no", "Telephone NO should be 10 charactors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // erpBlanck.Clear();
            }

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();

        }
    }
}
