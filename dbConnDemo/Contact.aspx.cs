using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dbConnDemo
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateDropDownList();
            }
        }

        protected void populateDropDownList()
        {
            //     here I create the code to access the database
                 CRUD myCrud = new CRUD();
                string mySql = (@" select contactId,firstname from contact");
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                ddlContact.DataTextField = "firstname";
                ddlContact.DataValueField = "contactId";
                ddlContact.DataSource = dr;
                ddlContact.DataBind();
            
        }
    }
}