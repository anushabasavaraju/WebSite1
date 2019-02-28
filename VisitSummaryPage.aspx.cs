using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class VisitSummaryPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        Label mpLabel = (Label)Master.FindControl("NameLabel");
        mpLabel.Text = name.ToString();
    }
}