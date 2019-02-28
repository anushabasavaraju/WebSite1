using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


public partial class RegistrationPage : System.Web.UI.Page
{
  public string[] con_strs = {
        "Server=35.224.47.204;Port=3306;Database=ehrgoogledb;Uid=root;Pwd=admin123",
       "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123" }; 


    //  public string con_strs = "Server=ehrmysqldb.czolesibiz1g.us-west-2.rds.amazonaws.com;Port=3306;Database=EhrMysqlDb;Uid=admin;Pwd=admin123";

    string str;
    MySqlCommand com;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Random rnd = new Random();
        str = "insert into RegistrationDetails(FirstName,LastName,Age,Gender,Occupation,UserName,Password) values" +
            " ('" + this.TextBox4.Text + "','" + this.TextBox6.Text + "','" + this.TextBox5.Text + "','"+this.Gender.SelectedValue+"','"+this.DropDownList1.SelectedItem.Value+"','"+this.TextBox1.Text+"','" +this.TextBox2.Text+"');";

        string name = TextBox1.Text;
        string pass = TextBox2.Text;
       // str = "insert into data (username,password) values (AES_ENCRYPT(@name,'222'),AES_ENCRYPT(@pass,'222'))";


        MySqlConnection con = new MySqlConnection(con_strs[rnd.Next(con_strs.Length)]);
      //   MySqlConnection con = new MySqlConnection(con_strs);
        com = new MySqlCommand(str, con);
        com.Parameters.AddWithValue("@name", name);
        com.Parameters.AddWithValue("@pass", pass);

        MySqlDataReader MyReader2;
        con.Open();
        MyReader2 = com.ExecuteReader();
        while(MyReader2.Read())
        {

        }
        con.Close();

        Response.Redirect("Default.aspx");
    }
}