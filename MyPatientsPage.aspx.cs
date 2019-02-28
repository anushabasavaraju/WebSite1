using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


public partial class MyPatientsPage : System.Web.UI.Page
{
     public string[] con_strs ={
           "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True",
           "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123;Allow User Variables=True"}; 
  //  public string constr = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        NameLabel.Text = name.ToString();
        string pswd = Session["pswd"].ToString();

    } 

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("DoctorLoginPage.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyPatientsPage.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    

}