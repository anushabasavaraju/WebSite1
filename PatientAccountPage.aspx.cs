using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class PatientAccountPage : System.Web.UI.Page
{
    public string[] con_strs =
       { "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123",
       "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123"}; 
    public string constr = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        Label mpLabel = (Label)Master.FindControl("NameLabel");
        mpLabel.Text = name.ToString();
    }
    
}
