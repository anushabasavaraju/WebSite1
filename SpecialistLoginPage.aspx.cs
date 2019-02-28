using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class SpecialistLoginPage : System.Web.UI.Page
{
     public string[] con_strs ={
          "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True",
          "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123;Allow User Variables=True" }; 
  //  public string strcon = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123";
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        NameLabel.Text = name.ToString();
        

        TextBox1.Text = Session["ResponseTime"].ToString();


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        string pswd = Session["pswd"].ToString();
        var watch = System.Diagnostics.Stopwatch.StartNew();
      /*   MySqlConnection con = new MySqlConnection(strcon);
         MySqlCommand com = new MySqlCommand(strcon,con);
         com.CommandText = "Update ModifyData set Ethnicity = 'African'";
         com.Connection = con;
         con.Open();
         MySqlDataReader AValid = com.ExecuteReader();
         while(AValid.Read())
         {

         }
         con.Close(); */

        var ATuple = check_database.Check_Adatabase(name, pswd);
        var GTuple = check_database.Check_Gdatabase(name, pswd);

        var r = ATuple.Item1;
        var t = GTuple.Item1;

        MySqlConnection Acon = new MySqlConnection(con_strs[0]);
        MySqlConnection Gcon = new MySqlConnection(con_strs[1]);
        MySqlCommand Acom = new MySqlCommand(con_strs[0], Acon);
        MySqlCommand Gcom = new MySqlCommand(con_strs[1], Gcon);
        Acom.Connection = Acon;
        Acon.Open();
        Acom.CommandText = "Update EhrMysqlDb.ModifyData set Ethnicity = 'Mangolian'";
        Gcom.Connection = Gcon;
        Gcon.Open();
        Gcom.CommandText = "Update ehrgoogledb.ModifyData set Ethnicity = 'Japanese'";
        MySqlDataReader AValid = Acom.ExecuteReader();
        MySqlDataReader GValid = Gcom.ExecuteReader();

        if (r == true)
        {
            if (AValid.Read())
            {
               
               
                
                Acon.Close();
            }
        }
        else if (t == true)
        {
            if (GValid.Read())
            {
               
                
            }
        } 
        
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        TextBox2.Text = elapsedMs.ToString(); 
    }
}