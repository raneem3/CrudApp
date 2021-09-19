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
    public partial class intern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)  // show intern the effectivness of this code and how it trick them if they do not use it correctly
            {
                populateCountryCombo();
                populatecblHobby();
                CalendarDateOfBirth.Visible = false;
            }
        }
        protected void populateCountryCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select countryId, country from country";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataTextField = "country";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();
        }
        protected void populatecblHobby()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select hobbyId, hobby from hobby";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            cblHobbies.DataValueField = "hobbyId";
            cblHobbies.DataTextField = "hobby";
            cblHobbies.DataSource = dr;
            cblHobbies.DataBind();
        }

        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @" select internId,fNameEn, fNameAr,countryId,salary,active,dateOfBirth from intern 
                    where internId=@internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtInternId.Text = dr["internId"].ToString();
                        txtFnameEn.Text = dr["fNameEn"].ToString();
                        txtFnameAr.Text = dr["fNameAr"].ToString();
                        ddlCountry.SelectedValue = dr["countryId"].ToString();
                        txtSalary.Text = dr["salary"].ToString();
                        txtDateOfBirth.Text = dr["dateOfBirth"].ToString();
                        string active = dr["active"].ToString();

                        if (rblActive.Items[0].Selected == true || rblActive.Items[1].Selected == true)
                        {

                            foreach (ListItem ls in rblActive.Items)
                            {
                                ls.Selected = false;
                            }

                        }

                        if (active == "True")
                        { rblActive.Items.FindByValue("1").Selected = true; }
                        else { rblActive.Items.FindByValue("0").Selected = true; }




                    }
                    populateFormHobby(PK);
                }
            }
        }
                protected void populateFormHobby(int PK)
                {
                    cblHobbies.ClearSelection();  // to clear  the list for each intern selection 
                    string mySql = @"select internHobbyId, ih.hobbyId , hobby
                            from internHobby ih inner join hobby h on ih.hobbyId = h.hobbyId
                            WHERE internId=  @internId";
                    Dictionary<string, object> myPara = new Dictionary<string, object>();
                    myPara.Add("@internId", PK);  // demo for conversion 
                    CRUD myCrud = new CRUD();
                    List<string> mySelectedHobbies = new List<string>();


                    // this pull the intern hobbies from the database
                    using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                mySelectedHobbies.Add(dr["hobbyId"].ToString());
                            }
                        }
                    }

                    // this will iterate through
                    foreach (ListItem item in cblHobbies.Items)
                    {
                        foreach (string x in mySelectedHobbies)
                        {
                            if (item.Value == x)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
            

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            if (txtFnameEn.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your First Name";
                txtFnameEn.Focus();
                return;
            }
            if (txtFnameAr.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your First Name";
                txtFnameAr.Focus();
                return;
            }
            if (txtSalary.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your Salary";
                txtSalary.Focus();
                return;
            }
            if (txtDateOfBirth.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your date of birth";
                txtDateOfBirth.Focus();
                return;
            }
            if (Page.IsValid)
            {
                lblOutput.ForeColor = System.Drawing.Color.DeepPink;
                lblOutput.Text = "Data inserted successfuly";
            }
            else
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Validation Falied";
            }
            int intInternId = 0;
            // I need to insert a new data to the database
            string mySql = "insert into intern (fNameEn,fNameAr,countryId,salary,active,dateOfBirth) " +
                "           values (@fNameEn,@fNameAr,@countryId,@salary,@active,@dateOfBirth)" +
                                                     "SELECT CAST(scope_identity() AS int)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@fNameEn", txtFnameEn.Text);
            myPara.Add("@fNameAr", txtFnameAr.Text);
            myPara.Add("@countryId", int.Parse(ddlCountry.SelectedValue.ToString()));
            myPara.Add("@salary", decimal.Parse(txtSalary.Text));
            myPara.Add("@dateOfBirth", txtDateOfBirth.Text);
            int intActive = 0;
            if (rblActive.SelectedValue == "0")
            {
                intActive = 0;
            }
            else
            {
                intActive = 1;
            }
            myPara.Add("@active", intActive);
            CRUD myCrud = new CRUD();
            intInternId = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);
            //   iterate cbl collection and capture the selected values
            List<int> mySelectedHobbies = new List<int>();
            foreach (ListItem item in cblHobbies.Items)
            {
                if (item.Selected)
                {
                    mySelectedHobbies.Add(int.Parse(item.Value));
                }
            }
            registerHobby(intInternId, mySelectedHobbies); 
            showGvIntern(intInternId);
            showInternHobby(intInternId);
            if (intInternId >= 1)// sent message ok 
            { lblOutput.Text = "Thanks for registering !"; }
            else
            { lblOutput.Text = "Failed !"; }

            //  showAllInterns();



        }
        protected void registerHobby(int myInternId, List<int> mySelectedHobbies)
        {
            foreach (int item in mySelectedHobbies) // Loop through List with foreach
            {
                string mySql = @"INSERT INTO internHobby  (internId ,HobbyId)
                                       VALUES    (@internId,@HobbyId)";
                CRUD myCrud = new CRUD();
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@internId", myInternId);
                myPara.Add("@HobbyId", item);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            }
        }
        protected void registerHobbyUp(int myInternId)
        {
            CRUD myCrud = new CRUD();
            string mySql = "delete internHobby WHERE internId=@internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", myInternId);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFnameAr.Text = "";
            txtFnameEn.Text = "";
            txtInternId.Text = "";
            txtSalary.Text = "";
            ddlCountry.SelectedIndex = 0;
            lblOutput.Text = "";
            rblActive.SelectedValue = "0";
            cblHobbies.SelectedValue = null;
            txtDateOfBirth.Text = "";

          

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtInternId.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your id";
                txtInternId.Focus();
                return;
            }
            if (txtFnameEn.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your First Name";
                txtFnameEn.Focus();
                return;
            }
            if (txtFnameAr.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your First Name";
                txtFnameAr.Focus();
                return;
            }
            if (txtSalary.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your Salary";
                txtSalary.Focus();
                return;
            }
            if (txtDateOfBirth.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your date of birth";
                txtDateOfBirth.Focus();
                return;
            }
            // I need to insert a new data to the database
            string mySql = @"Update intern set fNameEn =@fNameEn, fNameAr =@fNameAr, countryId =@countryId, salary =@salary ,active =@active,dateOfBirth=@dateOfBirth
                                where internId = @internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", txtInternId.Text);
            myPara.Add("@fNameEn", txtFnameEn.Text);
            myPara.Add("@fNameAr", txtFnameAr.Text);
            myPara.Add("@countryId", int.Parse(ddlCountry.SelectedValue.ToString()));
            myPara.Add("@salary", decimal.Parse(txtSalary.Text));
            myPara.Add("@dateOfBirth", txtDateOfBirth.Text);
            int intActive = 0;
            if (rblActive.SelectedValue == "0")
            {
                intActive = 0;
            }
            else
            {
                intActive = 1;
            }
            myPara.Add("@active", intActive);
            CRUD myCrud = new CRUD();
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            //   iterate cbl collection and capture the selected values
            List<int> mySelectedHobbies = new List<int>();
            foreach (ListItem item in cblHobbies.Items)
            {
                if (item.Selected)
                {
                    mySelectedHobbies.Add(int.Parse(item.Value));
                }
            }
            int InternId = int.Parse(txtInternId.Text);
            registerHobbyUp(InternId); // to read more about it ... This what we need to talk about
            registerHobby(InternId, mySelectedHobbies);
            showGvIntern(InternId);
            showInternHobby(InternId);

            if (rtn >= 1)// sent message ok 
            {
                lblOutput.Text = "Thanks for Updata !";
                lblOutput.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblOutput.Text = "Failed !";
                lblOutput.ForeColor = System.Drawing.Color.Black;
            }
            showGvIntern();

        }
        // call to populate the gv 






        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtInternId.Text == "")
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Please Enter Your id";
                txtInternId.Focus();
                return;
            }
            // I need to insert a new data to the database
            string mySql = "delete intern where internId = @internId ";   //
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", int.Parse(txtInternId.Text));  // demo for conversion 
            CRUD myCrud = new CRUD();
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            registerHobbyUp(int.Parse(txtInternId.Text));
            if (rtn >= 1)
            { lblOutput.Text = "Success !"; }
            else
            { lblOutput.Text = "Failed !"; }
            // call to populate the gv 
            showGvIntern();

          
        

            if (Page.IsValid)
            {
                lblOutput.ForeColor = System.Drawing.Color.DeepPink;
                lblOutput.Text = "Data has been deleted";
            }
            else
            {
                lblOutput.ForeColor = System.Drawing.Color.Red;
                lblOutput.Text = "Enter your Id";
                txtInternId.Focus();
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {

            lblOutput.Text = "";
            showGvIntern();
            showInternHobby();

            
        }
        protected void showGvIntern()
        {
            string mySql = @"select  i.internId,fNameEn,fNameAr,country,salary,active,dateOfBirth 
                            from intern i inner join country c on i.countryId = c.countryId";
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvIntern.DataSource = dr;
            gvIntern.DataBind();
            showInternHobby();
        }
        protected void showGvIntern(int intInternId)
        {
            string mySql = @"select  i.internId,fNameEn,fNameAr,i.countryId,country,salary,active,dateOfBirth 
                            from intern i inner join country c on i.countryId = c.countryId
                                where i.internId = @internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", intInternId);  // demo for conversion 
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvIntern.DataSource = dr;
            gvIntern.DataBind();
        }
        protected void btnShowIntern_Click(object sender, EventArgs e)
        {
            lblOutput.Text = "";
            if (txtInternId.Text == "")
            {

                lblOutput.Text = " Please enter intern Id !";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                return;
            }
            int myInternId = int.Parse(txtInternId.Text);
            showGvIntern(myInternId);
            showInternHobby(myInternId);
        }
        protected void showInternHobby()
        {
            string mySql = @"  select i.internId,fnameen ,ih.hobbyId,hobby
                   from intern i inner join internHobby ih on i.internid = ih.internId inner join hobby h on ih.hobbyId = h.hobbyId ";
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvInternHobby.DataSource = dr;
            gvInternHobby.DataBind();
        }
        protected void showInternHobby(int intInternId)
        {
            string mySql = @"  select i.internId,fnameen ,ih.hobbyId,hobby
                   from intern i inner join internHobby ih on i.internid = ih.internId inner join hobby h on ih.hobbyId = h.hobbyId
                        where i.internId = @InternId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@InternId", intInternId);
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvInternHobby.DataSource = dr;
            gvInternHobby.DataBind();
        }

        protected void CalendarDateOfBirth_SelectionChanged(object sender, EventArgs e)
        {
            txtDateOfBirth.Text = CalendarDateOfBirth.SelectedDate.ToShortDateString();
            CalendarDateOfBirth.Visible = false;
        }

        protected void ImageBDateOfBirth_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarDateOfBirth.Visible)
            {
                CalendarDateOfBirth.Visible = false;
            }
            else
            {
                CalendarDateOfBirth.Visible = true;
            }
        }

        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (FileUpdate.HasFile)
            {
                //get file extention
                string fileExtention = System.IO.Path.GetExtension(FileUpdate.FileName);
                if (fileExtention.ToLower() != ".pdf")
                {

                    lblOutput.Text = "only pdf files are allowed to upload";
                    lblOutput.ForeColor = System.Drawing.Color.Red;
                }
                else
                {



                    //using fileUpdate button to save file 
                    // Server.MapPath to map physical path to virtual pyth 
                    FileUpdate.SaveAs(Server.MapPath("~/uploaded file/" + FileUpdate.FileName));
                    lblOutput.Text = "the file has been uploaded";
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                lblOutput.Text = "no file has been uploaded , please update file";
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

   
    
}//class 
 //NS