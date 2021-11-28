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
using System.Data.Common;


namespace TPBinding
{
    public partial class ListBox : Form
    {
        public ListBox()
        {
            InitializeComponent();
        }

        BindingSource bds = new BindingSource();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlConnection ctn = new SqlConnection(@"Data Source=ELHAJUOJY-LAPTO\MEHDI;Initial Catalog=personneDb;Integrated Security=True");


        private void btnTri_Click(object sender, EventArgs e)
        {

            // sort kbir sghir katdir DESC  WEL3EKSS BELA MADIR OULA DIR ASC 
            ds.Tables["personne"].DefaultView.Sort = "age DESC";



        }

        private void ListBox_Load(object sender, EventArgs e)
        {


            SqlCommand cmd = new SqlCommand("select * from personne", ctn);

            da = new SqlDataAdapter(cmd);

            
            
            
         
            da.Fill(ds, "personne");

            
            bds.DataSource = ds.Tables["personne"];
            bindingNavigator1.BindingSource = bds;
            listBox1.DataSource = bds;
            listBox1.DisplayMember = "nom";
            listBox1.ValueMember = "nom";



            comboBox1.DataSource = ds.Tables["personne"];
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "nom";
        }

        private void btnFiltere_Click(object sender, EventArgs e)
        {
            ds.Tables["personne"].DefaultView.RowFilter = "age>22";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
