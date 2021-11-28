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
    public partial class DatagridView : Form
    {
        public DatagridView()
        {
            InitializeComponent();
        }


        BindingSource bds = new BindingSource();
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlConnection ctn = new SqlConnection(@"Data Source=ELHAJUOJY-LAPTO\MEHDI;Initial Catalog=personneDb;Integrated Security=True");
        private void DatagridView_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from personne", ctn);

            da = new SqlDataAdapter(cmd);





            da.Fill(ds, "personne");

            bds.DataSource = ds.Tables["personne"];
            bindingNavigator1.BindingSource = bds;
            dataGridView1.DataSource = bds;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {

        }

        private void btnEnergistrer_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder bldr = new SqlCommandBuilder(da);
            bldr.GetUpdateCommand();
            da.Update(ds.Tables["personne"]);
        }

        private void btnPreimer_Click(object sender, EventArgs e)
        {

        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {

        }

        private void btnPrecedant_Click(object sender, EventArgs e)
        {

        }

        private void btnDerrier_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
