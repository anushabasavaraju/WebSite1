using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


 


public partial class MyProfilePage : System.Web.UI.Page
{
     public string[] con_strs ={
         "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True",
         "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123;Allow User Variables=True"}; 

   // public string constr = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True";
    

    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["fname"].ToString();
        Label mpLabel = (Label)Master.FindControl("NameLabel");
        mpLabel.Text = name.ToString();

        var watch = System.Diagnostics.Stopwatch.StartNew();

     /*    MySqlConnection con = new MySqlConnection(constr);
         MySqlCommand com = new MySqlCommand(constr, con);
         com.CommandText = "Select * from PatientDetails P inner join RegistrationDetails R on R.ID= P.ID where R.UserName = @UName"; //Case 3 & Case 4
        //com.CommandText = "Select * from AllData where UserName = @UName"; //Case 1
        //com.CommandText = "Select * from AllData2 where UserName = @UName"; //Case 2
         com.Parameters.AddWithValue("@UName", name);
         com.Connection = con;
         con.Open();
         MySqlDataReader reader = com.ExecuteReader();
         while(reader.Read())
         {
             TextBox1.Text = reader.GetString("FirstName");
             TextBox2.Text = reader.GetString("Gender");
             TextBox3.Text = reader.GetString("Birthday");
             TextBox4.Text = reader.GetString("Race");
             TextBox5.Text = reader.GetString("Ethnicity");
             TextBox6.Text = reader.GetString("Smoking");
             TextBox7.Text = reader.GetString("Language");
         }
         con.Close(); */

         MySqlConnection Acon = new MySqlConnection(con_strs[0]);
         MySqlCommand Acom = new MySqlCommand(con_strs[0], Acon);
         MySqlConnection Gcon = new MySqlConnection(con_strs[1]);
         MySqlCommand Gcom = new MySqlCommand(con_strs[1], Gcon);
         Acom.CommandText = "Select * from EhrMysqlDb.PatientDetails P inner join EhrMysqlDb.RegistrationDetails R on R.ID= P.ID where R.UserName = @UName";
         Gcom.CommandText = "Select * from ehrgoogledb.PatientDetails P inner join ehrgoogledb.RegistrationDetails R on R.ID=P.ID where R.UserName = @UName";
         Acom.Parameters.AddWithValue("@UName", name);
         Gcom.Parameters.AddWithValue("@UName", name);
         Acom.Connection = Acon;
         Acon.Open();
         Gcom.Connection = Gcon;
         Gcon.Open();
         MySqlDataReader AValid = Acom.ExecuteReader();
         MySqlDataReader GValid = Gcom.ExecuteReader(); 

        
         if (AValid.Read())
             {

                 TextBox1.Text = AValid.GetString("FirstName");
                 TextBox2.Text = AValid.GetString("Gender");
                 TextBox3.Text = AValid.GetString("Birthday");
                 TextBox4.Text = AValid.GetString("Race");
                 TextBox5.Text = AValid.GetString("Ethnicity");
                 TextBox6.Text = AValid.GetString("Smoking");
                 TextBox7.Text = AValid.GetString("Language");
                 Acon.Close();
             }


            else if(GValid.Read())
             {

                 TextBox1.Text = GValid.GetString("FirstName");
                 TextBox2.Text = GValid.GetString("Gender");
                 TextBox3.Text = GValid.GetString("Birthday");
                 TextBox4.Text = GValid.GetString("Race");
                 TextBox5.Text = GValid.GetString("Ethnicity");
                 TextBox6.Text = GValid.GetString("Smoking");
                 TextBox7.Text = GValid.GetString("Language");
                 Gcon.Close();
             } 
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        TextBox8.Text = elapsedMs.ToString();
        Console.Write("elapseMs");

    }

}
