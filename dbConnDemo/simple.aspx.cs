using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using dbConnDemo.App_Code;


namespace dbConnDemo
{
    public partial class simple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // execute this code.
            // to keep it clean, make method calls
            if (!Page.IsPostBack)   // means when the page loads for the first time only execuate the code 
            {
                populateCountryCombo();
                populateGvCustomer();
            }
        }


        protected void populateGvCustomer()
        {

            CRUD myCrud = new CRUD();
            string mySql = "  select * from customer ";
            //Dictionary<string, object> myPara = new Dictionary<string, object>();
            //myPara.Add("", "");
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }
        protected void populateCountryCombo()
        {
            // connect to the db via CRUD class
            CRUD myCrud = new CRUD();
            string mySql = "  select countryId, country from country ";
            //Dictionary<string, object> myPara = new Dictionary<string, object>();
            //myPara.Add("", "");
            SqlDataReader dr=  myCrud.getDrPassSql(mySql);
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataTextField = "country";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            insertViaCmdParameter();
            //// capture values from inputform
            //string strCustomerName = txtCustomer.Text;
            //string conString = WebConfigurationManager.ConnectionStrings["conStrUniversity"].ConnectionString;
            //SqlConnection con = new SqlConnection(conString);

            //Dictionary<string, object> myPara = new Dictionary<string, object>();
            //myPara.Add("@newCustomer", strCustomerName);
            //string sqlCmd = " Insert customer (customer) values( @newCustomer)";
            //SqlCommand cmd = new SqlCommand(sqlCmd, con);
            //cmd.Parameters.Add()
            //con.Open();
            //cmd.ExecuteNonQuery();
            //////CRUD myCrud = new CRUD();
            //////string strCustomerName = txtCustomer.Text;
            //////string mySql = "insert into  customer (customer) values (@newCustomer)";
            //////Dictionary<string, object> myPara = new Dictionary<string, object>();
            //////myPara.Add("@newCustomer", strCustomerName);
            //////myCrud.InsertUpdateDelete(mySql, myPara);
        }

        protected void insertViaCmdParameter()
        {
          string myCustomer=   txtCustomerName.Text;
            CRUD myCrud = new CRUD();
            string mySql = "  insert into customer (customer,countryId) values (@customer,@countryId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customer", myCustomer);
            myPara.Add("@countryId", int.Parse(ddlCountry.SelectedValue));  // to be explained

            myCrud.InsertUpdateDelete(mySql, myPara);

            populateGvCustomer();
            //// conn and reader declared outside try
            //// block for visibility in finally block
            //SqlConnection conn = null;

            //string inputCustomer = txtCustomerName.Text;
            //try
            //{
            //    string conString = WebConfigurationManager.ConnectionStrings["conStrUniversity"].ConnectionString;
            //     conn = new SqlConnection(conString);
            //    // instantiate and open connection

            //    conn.Open();

            //    // don't ever do this
            //    // SqlCommand cmd = new SqlCommand(
            //    // "select * from Customers where city = '" + inputCity + "'";

            //    // 1. declare command object with parameter
            //    SqlCommand cmd = new SqlCommand(
            //        "insert into customer (customer) values @customer", conn);

            //    // 2. define parameters used in command object
            //    SqlParameter param = new SqlParameter();
            //    param.ParameterName = "@customer";
            //    param.Value = inputCustomer;

            //    cmd.ExecuteNonQuery();

            //}
            //finally
            //{
            //    // close connection
            //    if (conn != null)
            //    {
            //        conn.Close();
            //    }
            //}
        }
    
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string conString = WebConfigurationManager.ConnectionStrings["conStrUniversity"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sqlCmd = "  update customer where customerId = @customerId";
            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string conString = WebConfigurationManager.ConnectionStrings["conStrUniversity"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sqlCmd = "  delete customer where customerId  = @customerId";
            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        //protected void InsertUpdateDelete(string mySql)
        //{
        //    string conString = WebConfigurationManager.ConnectionStrings["conStrUniversity"].ConnectionString;
        //    SqlConnection con = new SqlConnection(conString);
        //    string sqlCmd = mySql;
        //    SqlCommand cmd = new SqlCommand(sqlCmd, con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //}


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            customer_select();
            solder_select();
            
        }


        protected void customer_select()
        {
            string conString = WebConfigurationManager.ConnectionStrings["conStrUniversity"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sqlCmd = " select * from customer";
            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            gvContact.DataSource = dr;
            gvContact.DataBind();
        }
        protected void solder_select()
        {
            string conString = WebConfigurationManager.ConnectionStrings["Army"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sqlCmd = " select * from solder";
            SqlCommand cmd = new SqlCommand(sqlCmd, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            gvSolder.DataSource = dr;
            gvSolder.DataBind();
        }

        protected void btnTestObject_Click(object sender, EventArgs e)
        {
            customer myCustomer = new customer();
            myCustomer.intCustomerId = 1;
            myCustomer.customerName = txtCustomerName.Text;

          //  lblOutput.Text = myCustomer.customerName;

            // write a method to give bonus to the customer 
            showCustomerName(myCustomer);
        }

        protected void showCustomerName(customer myObject)
        {
            // logic code is written here to give bonus
           int myClientId =  myObject.intCustomerId;
           string myClientName = myObject.customerName;
            lblOutput.Text = myClientId + "  " + myClientName;
        }
    }
}