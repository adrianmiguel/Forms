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
using System.Data.OleDb;

namespace Example_4_1_SQLTester
{
    public partial class FrmSQLTester : Form
    {
        SqlConnection conection;
        public FrmSQLTester()
        {
            InitializeComponent();
        }

        private void FrmSQLTester_Load(object sender, EventArgs e)
        {
            try
            {
                conection = new SqlConnection("server=MI-PC;database=DiplomadoAzure;user=SA;password=adrian9110;");

                conection.Open();
                string conexion;
                conexion = conection.State.ToString();

                //conection.Close();
                //conection.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            

        }

        private void FrmSQLTester_FormClosed(object sender, FormClosedEventArgs e)
        {
            conection.Close();
            conection.Dispose();
        }

        private void btbTest_Click(object sender, EventArgs e)
        {
            //SqlConnection SalesConnection;
            //SqlCommand myCommand;
            //SalesConnection = new SqlConnection("server=MI-PC;database=AdventureWorks2016CTP3;User Id=SA; Password=adrian9110");
            ////open the connection

            //SalesConnection.Open();

            ////display state
            ////lblState.Text = SalesConnection.State.ToString();

            //string MyQuery = "SELECT top 10 * FROM Sales.SalesOrder_json";
            //myCommand = new SqlCommand(MyQuery, SalesConnection);
            //SqlDataAdapter myAdapter;
            //myAdapter = new SqlDataAdapter();

            //myAdapter.SelectCommand = myCommand;

            ////SqlCommandBuilder myCommandBuilder = new SqlCommandBuilder(myAdapter);
            //DataTable titlesTable;
            //titlesTable = new DataTable();
            //myAdapter.Fill(titlesTable);

            //grdSQLTester.DataSource = titlesTable;

            //SalesConnection.Close();
            ////display state
            ////lblState.Text += SalesConnection.State.ToString();
            ////dispose of the connection object
            //SalesConnection.Dispose();
            //myAdapter.Dispose();
            //titlesTable.Dispose();
            SqlCommand resultsCommand = null;
            SqlDataAdapter resultAdapter = new SqlDataAdapter();

            DataTable resultsTable = new DataTable();

            try
            {
                string Query;
                if (!String.IsNullOrEmpty(txtSQLTester.SelectedText))
                {
                    Query = txtSQLTester.SelectedText;
                }
                else
                {
                    Query = txtSQLTester.Text;
                }
                
                resultsCommand = new SqlCommand(Query, conection);

                resultAdapter.SelectCommand = resultsCommand;
                resultAdapter.Fill(resultsTable);

                grdSQLTester.DataSource = resultsTable;

                lblRecords.Text = resultsTable.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Processing SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            resultsCommand.Dispose();
            resultAdapter.Dispose();
            resultsTable.Dispose();
        }
    }
}
