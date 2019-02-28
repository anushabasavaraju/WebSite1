using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Security.Cryptography;

public partial class LoginPage : System.Web.UI.Page
{
    public string[] con_strs = {
        "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123",
         "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123" }; 

  //  public string constr = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True";

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string UName = Convert.ToString(TextBox1.Text);
        string Pswd = Convert.ToString(TextBox2.Text);
        
        Session["fname"] = TextBox1.Text;
        Session["pswd"] = TextBox2.Text;


        
        var watch = System.Diagnostics.Stopwatch.StartNew();

      /*  MySqlConnection Acon = new MySqlConnection(con_strs[1]);
        MySqlCommand Acom = new MySqlCommand(con_strs[1], Acon);
        Acom.CommandText = "Select * from EhrMysqlDb.RegistrationDetails where UserName = @UName and Password = @Pswd";
        Acom.Parameters.AddWithValue("@UName", UName);
        Acom.Parameters.AddWithValue("@Pswd", Pswd);
        Acom.Connection = Acon;
        Acon.Open();
        MySqlDataReader reader = Acom.ExecuteReader(); */

     /*   MySqlConnection con = new MySqlConnection(constr);
        MySqlCommand com = new MySqlCommand(constr, con);

        // com.CommandText = "Select * from AllData where UserName = @UName and Password = @Pswd"; //Case 1
        // com.CommandText = "Select * from AllData2 where UserName = @UName and Password = @Pswd"; //Case 2 
        com.CommandText = "Select * from RegistrationDetails where UserName = @UName and Password = @Pswd";  //Case 3 & Case 4

        com.Parameters.AddWithValue("@UName", UName);
        com.Parameters.AddWithValue("@Pswd", Pswd);
        com.Connection = con;
        con.Open();
        MySqlDataReader reader = com.ExecuteReader();  

        watch.Stop();    
        var elapsedMs = watch.ElapsedMilliseconds;
        Session["ResponseTime"] = elapsedMs;  */

        if (UName == "" || Pswd == "")
            Label1.Text = "Empty fields detected. Please fill up all the fields";

     /*  else if (reader.Read())
             { 
                 string occ = reader.GetString("Occupation");

            if (occ == "Doctor")
                Response.Redirect("DoctorLoginPage.aspx");
            else if (occ == "Patient")
                Response.Redirect("PatientLoginPage.aspx");
            else if (occ == "Specialist")
                Response.Redirect("SpecialistLoginPage.aspx");
            else if (occ == "Provider")
                Response.Redirect("ProviderLoginPage.aspx"); 
              }
        else
            Label1.Text = "Incorrect Credentials.Login Failed!";
        Acon.Close();  */


           else
               {
                  
                   var Atuple = check_database.Check_Adatabase(UName, Pswd);
                   var r = Atuple.Item1;
                   var Aocc = Atuple.Item2;
               
                   var Gtuple = check_database.Check_Gdatabase(UName, Pswd);
                   var t = Gtuple.Item1;
                   var Gocc = Gtuple.Item2;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Session["ResponseTime"] = elapsedMs;

            if (r == true)
                   {

                       if (Aocc == "Doctor")
                           Response.Redirect("DoctorLoginPage.aspx");
                       else if (Aocc == "Patient")
                           Response.Redirect("PatientLoginPage.aspx");
                       else if (Aocc == "Specialist")
                           Response.Redirect("SpecialistLoginPage.aspx");
                       else if (Aocc == "Provider")
                           Response.Redirect("ProviderLoginPage.aspx");

                   }


                    else if (t == true)
                    {
                   if (Gocc == "Doctor")
                        Response.Redirect("DoctorLoginPage.aspx");
                    else if (Gocc == "Patient")
                     Response.Redirect("PatientLoginPage.aspx");
                   else if (Gocc == "Specialist")
                     Response.Redirect("SpecialistLoginPage.aspx");
                     else if (Gocc == "Provider")
                     Response.Redirect("ProviderLoginPage.aspx");
                    } 
        else

            Label1.Text = "Incorrect Credentials.Login Failed!"; 
            
        } 

    }
}