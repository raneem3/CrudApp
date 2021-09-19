using System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dbConnDemo
{
    public partial class curdOps : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateCountryDropDownList();
                populateDepDropDownList();
                populateGvContact();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void populateCountryDropDownList()
        {
            //     here I create the code to access the database
            CRUD myCrud = new CRUD();
            string mySql = (@" select countryId,country from country");
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCountry.DataTextField = "country";
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();

        }
        protected void populateDepDropDownList()
        {
            //     here I create the code to access the database
            CRUD myCrud = new CRUD();
            string mySql = (@" select departmentid,department from department");
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlDepartment.DataTextField = "department";
            ddlDepartment.DataValueField = "departmentid";
            ddlDepartment.DataSource = dr;
            ddlDepartment.DataBind();

        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            populateGvContact();
        }


        protected void populateGvContact()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT contactId, name,cell,country,department
                          FROM contact c ,country co,department d
                          where c.countryid = co.countryid  
                          and c.departmentId = d.departmentid
                        ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = "delete contact where contactid = @contactId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@contactId", txtContactId.Text);
            int rtn =myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Success";
                lblOutput.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOutput.Text = "Failed";
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }

            populateGvContact();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO [dbo].[contact]
           ([name] ,[cell],[countryId],[departmentId])VALUES (@name,@cell,@countId,@departmentId)";
 
            Dictionary<string, Object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", (txtName.Text));
            myPara.Add("@cell", (txtCell.Text));
            myPara.Add("@countId", ddlCountry.SelectedValue );
            myPara.Add("@departmentId", ddlDepartment.SelectedValue);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Success";
                lblOutput.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblOutput.Text = "Failed";
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }

            populateGvContact();
        }
    }
}