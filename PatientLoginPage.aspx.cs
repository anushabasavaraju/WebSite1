using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class PatientLoginPage : System.Web.UI.Page
{
    public string[] con_strs = {
        "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123",
       "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123" }; 
   // public string strcon = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123";
    public string str;
    public MySqlCommand com;
    public MySqlConnection con;

   
        
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string a = Session["fname"].ToString();
        Label2.Text = a.ToString();
        TextBox1.Text = Session["ResponseTime"].ToString();

      /*  con = new MySqlConnection(strcon);
        com = new MySqlCommand(str, con);
        com.CommandText = "Select FirstName  from RegistrationDetails where UserName = Label2.Text";
        com.Connection = con;
        con.Open();

        con.Close(); */

        



    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("PatientLoginPage.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PatientAccountPage.aspx");
    }
}