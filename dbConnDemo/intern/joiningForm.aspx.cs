using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace dbConnDemo.intern

{
    public partial class joiningForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                populateInternMajorCombo();
                populateInternDepartmnetCombo();
                CalendarStartDate.Visible = false;
                CalendarEndDate.Visible = false;
            }
        }



        protected void populateForm2_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @" select  intern2Id,internFirstName,internMName, internFamilyName,internMajorId,TrainningDepartmnetId,TrainingStartDate,TrainingEndDate
                            from intern2  
                    where intern2Id=@intern2Id";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@intern2Id", PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtInternId.Text = dr["intern2Id"].ToString();
                        txtFirstName.Text = dr["internFirstName"].ToString();
                        txtMiddleName.Text = dr["internMName"].ToString();
                        txtLastName.Text = dr["internFamilyName"].ToString();
                        ddlInternMajor.SelectedValue = dr["internMajorId"].ToString();
                        ddlDepartmnetName.SelectedValue = dr["TrainningDepartmnetId"].ToString();
                        txtStartDate.Text = dr["TrainingStartDate"].ToString();
                        txtEndDate.Text = dr["TrainingEndDate"].ToString();
                        
                       




                    }
                    
                }
            }
        }


        protected void populateInternMajorCombo()
        {

            CRUD myCrud = new CRUD();
            string mySql = "  select internMajorId,internMajor from internMajor";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlInternMajor.DataValueField = "internMajorId";
            ddlInternMajor.DataTextField = "internMajor";
            ddlInternMajor.DataSource = dr;
            ddlInternMajor.DataBind();
        }

        protected void populateInternDepartmnetCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = "  select TrainningDepartmnetId,TrainningDepartmnetName from TrainningDepartmnet";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlDepartmnetName.DataValueField = "TrainningDepartmnetId";
            ddlDepartmnetName.DataTextField = "TrainningDepartmnetName";
            ddlDepartmnetName.DataSource = dr;
            ddlDepartmnetName.DataBind();
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your First Name";
                txtFirstName.Focus();
                return;
            }
            if (txtMiddleName.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Middle Name";
                txtMiddleName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Last Name";
                txtLastName.Focus();
                return;
            }


            if (txtStartDate.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Training Start Date";
                txtStartDate.Focus();
                return;
            }
            if (txtEndDate.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Training End Date";
                txtEndDate.Focus();
                return;
            }
            if (Page.IsValid)
            {
                lblMessage.ForeColor = System.Drawing.Color.DeepPink;
                lblMessage.Text = "Data inserted successfuly";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Validation Falied";
            }
            

            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO intern2 (internFirstName,internMName,internFamilyName,internMajorId,TrainningDepartmnetId, TrainingStartDate, TrainingEndDate)" +
           "VALUES (@internFirstName, @internMName, @internFamilyName,@internMajorId, @TrainningDepartmnetId,@TrainingStartDate,@TrainingEndDate)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internFirstName", txtFirstName.Text);
            myPara.Add("@internMName", txtMiddleName.Text);
            myPara.Add("@internFamilyName", txtLastName.Text);
            myPara.Add("@internMajorId", int.Parse(ddlInternMajor.SelectedValue.ToString()));
            myPara.Add("@TrainningDepartmnetId", int.Parse(ddlDepartmnetName.SelectedValue.ToString()));
            myPara.Add("@TrainingStartDate", txtStartDate.Text);
            myPara.Add("@TrainingEndDate", txtEndDate.Text);
            myCrud.InsertUpdateDelete(mySql, myPara);
            
            showGvIntern();


        }

        protected void ImageBtnStartDate_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarStartDate.Visible)
            {
                CalendarStartDate.Visible = false;
            }
            else
            {
                CalendarStartDate.Visible = true;
            }
        }

        protected void ImageBtnEndDate_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarEndDate.Visible)
            {
                CalendarEndDate.Visible = false;
            }
            else
            {
                CalendarEndDate.Visible = true;
            }
        }

        protected void CalendarStartDate_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = CalendarStartDate.SelectedDate.ToShortDateString();
            CalendarStartDate.Visible = false;
        }

        protected void CalendarEndDate_SelectionChanged(object sender, EventArgs e)
        {
            txtEndDate.Text = CalendarEndDate.SelectedDate.ToShortDateString();
            CalendarEndDate.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            ddlDepartmnetName.SelectedIndex = 0;
            ddlInternMajor.SelectedIndex = 0;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            txtInternId.Text = "";
            lblMessage.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtInternId.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your id to update your information";
                txtInternId.Focus();
                return;
            }
            if (txtFirstName.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your First Name";
                txtFirstName.Focus();
                return;
            }
            if (txtMiddleName.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Middle Name";
                txtMiddleName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Last Name";
                txtLastName.Focus();
                return;
            }


            if (txtStartDate.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Training Start Date";
                txtStartDate.Focus();
                return;
            }
            if (txtEndDate.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Training End Date";
                txtEndDate.Focus();
                return;
            }
            if (Page.IsValid)
            {
                lblMessage.ForeColor = System.Drawing.Color.DeepPink;
                lblMessage.Text = "Data displyed successfuly";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Validation Falied";
            }

            CRUD myCrud = new CRUD();
            string mySql = @"Update intern2 set internFirstName =@internFirstName, internMName =@internMName, internFamilyName =@internFamilyName,
            internMajorId =@internMajorId ,TrainningDepartmnetId =@TrainningDepartmnetId,TrainingStartDate = @TrainingStartDate,
            TrainingEndDate = @TrainingEndDate
                                where intern2Id = @intern2Id";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@intern2Id", txtInternId.Text);
            myPara.Add("@internFirstName", txtFirstName.Text);
            myPara.Add("@internMName", txtMiddleName.Text);
            myPara.Add("@internFamilyName", txtLastName.Text);
            myPara.Add("@internMajorId", int.Parse(ddlInternMajor.SelectedValue.ToString()));
            myPara.Add("@TrainningDepartmnetId", int.Parse(ddlDepartmnetName.SelectedValue.ToString()));
            myPara.Add("@TrainingStartDate", txtStartDate.Text);
            myPara.Add("@TrainingEndDate", txtEndDate.Text);
            myCrud.InsertUpdateDelete(mySql, myPara);
            showGvIntern();


        }
        protected void showGvIntern()
        {
            string mySql = @"select  i.intern2Id,internFirstName,internMName, internFamilyName,TrainningDepartmnetName,internMajor,TrainingStartDate,TrainingEndDate
                            from intern2 i inner join TrainningDepartmnet t on i.TrainningDepartmnetId = t.TrainningDepartmnetId
							inner join internMajor m on i.internMajorId = m.internMajorId ";
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvIntern2.DataSource = dr;
            gvIntern2.DataBind();
        }


        protected void btnShowData_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                lblMessage.ForeColor = System.Drawing.Color.DeepPink;
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Validation Falied";
            }
            showGvIntern();
            //     string mySql = @"select  i.intern2Id,internFirstName,internMName, internFamilyName,TrainningDepartmnetName,internMajor,TrainingStartDate,TrainingEndDate
            //                     from intern2 i inner join TrainningDepartmnet t on i.TrainningDepartmnetId = t.TrainningDepartmnetId
            //inner join internMajor m on i.internMajorId = m.internMajorId ";
            //     CRUD myCrud = new CRUD();
            //     SqlDataReader dr = myCrud.getDrPassSql(mySql);
            //     gvIntern2.DataSource = dr;
            //     gvIntern2.DataBind(); create a showGvIntern method to call it in other methods

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtInternId.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your Id to delete your request";
                txtInternId.Focus();
                return;
            }
            if (Page.IsValid)
            {
                lblMessage.ForeColor = System.Drawing.Color.DeepPink;
                lblMessage.Text = "Data deleted successfuly";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Validation Falied";



            }

            string mySql = "delete intern2 where intern2Id = @internId ";   //
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", int.Parse(txtInternId.Text));  // demo for conversion 
            CRUD myCrud = new CRUD();
            myCrud.InsertUpdateDelete(mySql, myPara);
            showGvIntern();
        }


        protected void showInternById(int intern)
        {

            string mySql = @"select  i.intern2Id,internFirstName,internMName, internFamilyName,TrainningDepartmnetName,internMajor,TrainingStartDate,TrainingEndDate
                            from intern2 i inner join TrainningDepartmnet t on i.TrainningDepartmnetId = t.TrainningDepartmnetId
							inner join internMajor m on i.internMajorId = m.internMajorId 
                                where i.intern2Id = @intern2Id";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@intern2Id", intern);  // demo for conversion 
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvViewIntern2.DataSource = dr;
            gvViewIntern2.DataBind();
        }
        protected void btnShowIntern2Data_Click(object sender, EventArgs e)
        {
            if (txtInternId.Text == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please Enter Your id to show your information";
                txtInternId.Focus();
                return;
            }
            if (Page.IsValid)
            {
                lblMessage.ForeColor = System.Drawing.Color.DeepPink;
                lblMessage.Text = "Data updated successfuly";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Validation Falied";
            }
            int myIntern2Id = int.Parse(txtInternId.Text);
            showInternById(myIntern2Id);
        }

       
    }
}