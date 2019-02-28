using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

public partial class DoctorLoginPage : System.Web.UI.Page
{
    public string[] con_strs ={
         "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True",
         "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123;Allow User Variables=True"}; 

  // public string constr = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables = True";

    public void Page_Load(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        NameLabel.Text = name.ToString();
        string pswd = Session["pswd"].ToString();
        TextBox2.Text = Session["ResponseTime"].ToString();

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

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        string pswd = Session["pswd"].ToString();

       /* MySqlConnection con = new MySqlConnection(constr);
        MySqlCommand com = new MySqlCommand(constr, con);
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // com.CommandText = "Select FirstName from AllData"; //Case1
        //com.CommandText = "Select FirstName from AllData2"; //Case 2
        com.CommandText = "Select FirstName from PatientDetails"; //Case 3 & Case 4

        con.Open();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(com);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind(); */
        MySqlConnection Acon = new MySqlConnection(con_strs[0]);
        MySqlConnection Gcon = new MySqlConnection(con_strs[1]);
        MySqlCommand Acom = new MySqlCommand(con_strs[0], Acon);
        MySqlCommand Gcom = new MySqlCommand(con_strs[1], Gcon);
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Acom.CommandText = "Select FirstName from EhrMysqlDb.PatientDetails";
        Gcom.CommandText = "Select FirstName from ehrgoogledb.PatientDetails";
        Acon.Open();
        Gcon.Open();
        DataTable dt = new DataTable();

        DataSet ds = new DataSet();
        MySqlDataAdapter da = new MySqlDataAdapter(Acom);
        MySqlDataAdapter dg = new MySqlDataAdapter(Gcom);


        var Atuple = check_database.Check_Adatabase(name, pswd);
        var r = Atuple.Item1;

        var Gtuple = check_database.Check_Gdatabase(name, pswd);
        var t = Gtuple.Item1;

        if (r == true)
            da.Fill(dt);
        else if (t == true)
            dg.Fill(dt);


        GridView1.DataSource = dt;
        GridView1.DataBind(); 

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        TextBox1.Text = elapsedMs.ToString();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
       // Label1.Text = "You selected " + row.Cells[1].Text + ".";
        Response.Redirect("MyPatientsPage.aspx");
    }
}