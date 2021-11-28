using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace TPBinding
{
    public partial class TestDataBinding : Form
    {
        public TestDataBinding()
        {
            InitializeComponent();
        }
        SqlConnection ctn = new SqlConnection(@"Data Source=ELHAJUOJY-LAPTO\MEHDI;Initial Catalog=personneDb;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        private void TestDataBinding_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from personne ",ctn);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "personne");
            BindingSource tbinding = new BindingSource();
            tbinding.DataSource = ds.Tables["personne"];


            bindingNavigator1.BindingSource = tbinding;

           
            textBox1.DataBindings.Add(new Binding("Text", tbinding, "cin"));
            textBox2.DataBindings.Add(new Binding("Text", tbinding, "nom"));
            textBox3.DataBindings.Add(new Binding("Text", tbinding, "prenom"));
            textBox4.DataBindings.Add(new Binding("Text", tbinding, "age"));




        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
        public void Afficher(int pos)
        {
           
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
           


        }
        int pos = 0;
        
        private void btnRecherche_Click(object sender, EventArgs e)
        {

            for( int i =0; i< ds.Tables["personne"].Rows.Count; i++)
            {
                if( textBox1.Text == ds.Tables["personne"].Rows[i][0].ToString())
                {
                    pos = i;
                    break;
                }
               
            }
            textBox1.Text = ds.Tables["personne"].Rows[pos][0].ToString();
            textBox2.Text= ds.Tables["personne"].Rows[pos][1].ToString();
            textBox3.Text= ds.Tables["personne"].Rows[pos][2].ToString();
            textBox4.Text= ds.Tables["personne"].Rows[pos][3].ToString();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ds.Tables["personne"].Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            MessageBox.Show("ajoutee effected");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder bd = new SqlCommandBuilder(da);
            bd.GetUpdateCommand();
            da.Update(ds.Tables["personne"]);
            
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            for(int i =0;i< ds.Tables["personne"].Rows.Count ; i++)
            {
                if( textBox1.Text == ds.Tables["personne"].Rows[i][0].ToString())
                {
                    pos = i;
                    break;
                }
            }
            ds.Tables["personne"].Rows[pos][0] = textBox1.Text;
            ds.Tables["personne"].Rows[pos][1] = textBox2.Text;
            ds.Tables["personne"].Rows[pos][2] = textBox3.Text;
            ds.Tables["personne"].Rows[pos][3] = textBox4.Text;
            MessageBox.Show("modification effected");
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables["personne"].Rows.Count; i++)
            {
                if (textBox1.Text == ds.Tables["personne"].Rows[i][0].ToString())
                {
                    pos = i;
                    break;
                }
            }
            ds.Tables["personne"].Rows[pos].Delete();
            MessageBox.Show("delete effected");
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
