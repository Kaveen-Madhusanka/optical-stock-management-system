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
    public partial class Add_Items : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\optical.mdf;Integrated Security=True;Connect Timeout=30");
        int qnt;
        public Add_Items()
        {
            InitializeComponent();
            SqlDataAdapter adr = new SqlDataAdapter("select * from item ", con);
            DataTable dt = new DataTable();
            con.Open();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           
            this.ActiveControl = btnback;
 
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try 
            {
                SqlCommand com = new SqlCommand("select quntity from item where item_id='" + txtitemid.Text + "'", con);
                con.Open();
                qnt = Convert.ToInt32(com.ExecuteScalar());
                con.Close();


                qnt = qnt + Convert.ToInt32(txtquntity.Text);
                MessageBox.Show("items added", "Stock Status", MessageBoxButtons.OK, MessageBoxIcon.Information);


                SqlCommand cmd = new SqlCommand("update item set quntity=" + qnt + " where item_id='" + txtitemid.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                SqlDataAdapter adr = new SqlDataAdapter("select * from item ", con);
                DataTable dt = new DataTable();
                con.Open();
                adr.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void txtitemid_Leave(object sender, EventArgs e)
        {
            if (txtitemid.TextLength == 0)
            {

                MessageBox.Show("check item id", "can not blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // erpBlanck.Clear();
            }
        }

        private void txtquntity_Leave(object sender, EventArgs e)
        {
            if (txtquntity.Text.All(char.IsDigit) != true)
            {
                MessageBox.Show("check quntity", "Only positive Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtquntity.TextLength == 0)
            {

                MessageBox.Show("check quntity", "can not blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // erpBlanck.Clear();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            new Stock().Show();
            this.Hide();
        }
    }
}
