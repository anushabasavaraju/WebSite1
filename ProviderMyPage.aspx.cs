using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class ProviderMyPage : System.Web.UI.Page
{
    public string AID;
    public string[] con_strs ={
          "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True",
          "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123;Allow User Variables=True" }; 

  // public string constr = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123;Allow User Variables=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string name = Session["fname"].ToString();
        string pswd = Session["pswd"].ToString();
        NameLabel.Text = name.ToString();
        string selection = Server.UrlDecode(Request.QueryString["selection"]);
        var watch = System.Diagnostics.Stopwatch.StartNew();

        /* MySqlConnection con = new MySqlConnection(constr);
        MySqlCommand com = new MySqlCommand(constr, con); */

        // com.CommandText = "Select * from AllData where FirstName = @Selection"; //Case 1
        //com.CommandText = "Select * from AllData2 where FirstName = @Selection"; //Case 2
        /*  com.CommandText = "Select * from EhrMysqlDb.PatientDetails where FirstName = @Selection"; // 
          com.Parameters.AddWithValue("@Selection", selection);
          com.Connection = con;
          con.Open();
          MySqlDataReader reader = com.ExecuteReader();
          while(reader.Read())
          {
              TextBox1.Text = reader.GetString("SSN");
              TextBox2.Text = reader.GetString("CreditCardNumber");
              TextBox3.Text = reader.GetString("CVV");
              TextBox4.Text = reader.GetString("ExpiryDate");
              TextBox5.Text = reader.GetString("NameonCard");
              TextBox6.Text = reader.GetString("PersonalID");
          }
          con.Close(); */

      /*  Acom.CommandText = "Select * from EhrMysqlDb.PatientDetails where FirstName = @Selection";
        Acom.Parameters.AddWithValue("@Selection", selection);
        Acom.Connection = Acon;
        Acon.Open();
        MySqlDataReader AValid = Acom.ExecuteReader(); 
         while (AValid.Read())
         {
             AID = AValid.GetString("ID");

         } 

         Gcom.CommandText = "Select AES_DECRYPT(SSN,'222'),AES_DECRYPT(CreditCardNumber,'222'),AES_DECRYPT(CVV,'222'),AES_DECRYPT(ExpiryDate,'222'),AES_DECRYPT(NameonCard,'222'),AES_DECRYPT(PersonalID,'222') from ehrgoogledb.SensitiveData where ID=@aid";
         Gcom.Parameters.AddWithValue("@aid", AID);
         Gcom.Connection = Gcon;
         Gcon.Open();
         MySqlDataReader GValid = Gcom.ExecuteReader();
         while (GValid.Read()) 
         {

                 TextBox1.Text = GValid.GetString("AES_DECRYPT(SSN,'222')");
                 TextBox2.Text = GValid.GetString("AES_DECRYPT(CreditCardNumber,'222')");
                 TextBox3.Text = GValid.GetString("AES_DECRYPT(CVV,'222')");
                 TextBox4.Text = GValid.GetString("AES_DECRYPT(ExpiryDate,'222')");
                 TextBox5.Text = GValid.GetString("AES_DECRYPT(NameonCard,'222')");
                 TextBox6.Text = GValid.GetString("AES_DECRYPT(PersonalID,'222')");


         }
         Acon.Close();
         Gcon.Close(); */

        //Case 3
     /*   com.CommandText = "Select * from EhrMysqlDb.SensitiveData2 s inner join EhrMysqlDb.PatientDetails p on s.ID= p.ID where p.FirstName = @Selection";
        com.Parameters.AddWithValue("@Selection", selection);
        com.Connection = con;
        con.Open();
        MySqlDataReader reader = com.ExecuteReader();
        while(reader.Read())
        {
            TextBox1.Text = reader.GetString("SSN");
            TextBox2.Text = reader.GetString("CreditCardNumber");
            TextBox3.Text = reader.GetString("CVV");
            TextBox4.Text = reader.GetString("ExpiryDate");
            TextBox5.Text = reader.GetString("NameonCard");
            TextBox6.Text = reader.GetString("PersonalID");
            con.Close(); 
        } */

          var ATuple = check_database.Check_Adatabase(name, pswd);
          var GTuple = check_database.Check_Gdatabase(name, pswd);

          var r = ATuple.Item1;
          var t = GTuple.Item1;

          MySqlConnection Acon = new MySqlConnection(con_strs[0]);
          MySqlConnection Gcon = new MySqlConnection(con_strs[1]);
          MySqlCommand Acom = new MySqlCommand(con_strs[0], Acon);
          MySqlCommand Gcom = new MySqlCommand(con_strs[1], Gcon);

          Acom.CommandText = "Select AES_DECRYPT(SSN,'222'),AES_DECRYPT(CreditCardNumber,'222'),AES_DECRYPT(CVV,'222'),AES_DECRYPT(ExpiryDate,'222'),AES_DECRYPT(NameonCard,'222'),AES_DECRYPT(PersonalID,'222') from EhrMysqlDb.SensitiveData s inner join EhrMysqlDb.PatientDetails p on s.ID= p.ID where p.FirstName = @Selection";
          Gcom.CommandText = "Select AES_DECRYPT(SSN,'222'),AES_DECRYPT(CreditCardNumber,'222'),AES_DECRYPT(CVV,'222'),AES_DECRYPT(ExpiryDate,'222'),AES_DECRYPT(NameonCard,'222'),AES_DECRYPT(PersonalID,'222') from ehrgoogledb.SensitiveData s inner join ehrgoogledb.PatientDetails p on s.ID=p.ID where p.FirstName = @Selection";
          Acom.Parameters.AddWithValue("@Selection", selection);
          Gcom.Parameters.AddWithValue("@Selection", selection);
          Acom.Connection = Acon;
          Gcom.Connection = Gcon;
          Acon.Open();
          Gcon.Open();

          MySqlDataReader AValid = Acom.ExecuteReader();
          MySqlDataReader GValid = Gcom.ExecuteReader();

          if (r == true)
          {
              if (AValid.Read())
              {
                TextBox1.Text = AValid.GetString("AES_DECRYPT(SSN,'222')");
                TextBox2.Text = AValid.GetString("AES_DECRYPT(CreditCardNumber,'222')");
                TextBox3.Text = AValid.GetString("AES_DECRYPT(CVV,'222')");
                TextBox4.Text = AValid.GetString("AES_DECRYPT(ExpiryDate,'222')");
                TextBox5.Text = AValid.GetString("AES_DECRYPT(NameonCard,'222')");
                TextBox6.Text = AValid.GetString("AES_DECRYPT(PersonalID,'222')"); 
                  Acon.Close();
              }
          }
          else if (t == true)
          {
              if (GValid.Read())
              {

                TextBox1.Text = GValid.GetString("AES_DECRYPT(SSN,'222')");
                TextBox2.Text = GValid.GetString("AES_DECRYPT(CreditCardNumber,'222')");
                TextBox3.Text = GValid.GetString("AES_DECRYPT(CVV,'222')");
                TextBox4.Text = GValid.GetString("AES_DECRYPT(ExpiryDate,'222')");
                TextBox5.Text = GValid.GetString("AES_DECRYPT(NameonCard,'222')");
                TextBox6.Text = GValid.GetString("AES_DECRYPT(PersonalID,'222')");
                Gcon.Close();
              }
          } 
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        TextBox7.Text = elapsedMs.ToString();
    }

    protected void HomeButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProviderLoginPage.aspx");
    }

    protected void MyPageButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProviderMyPage.apx");
    }

    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}