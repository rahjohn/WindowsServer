using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request.QueryString["name"];
        string email = Request.QueryString["email"];
        Label1.Text = name + " " + email;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = "uid=guest;server=192.168.12.122;port=3306;database=it210b;password=guest;";
            string Query = "INSERT INTO images (imagePath,altText,userId) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ")";
            MySqlConnection MyConn2 = new MySqlConnection(connectionString);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MyConn2.Open();
            MySqlCommand command = new MySqlCommand(Query, MyConn2);
            command.ExecuteNonQuery();
            MyConn2.Close();
        }
        catch (MySqlException ex)
        {
            int errorcode = ex.Number;
            Label1.Text = ex.Message;
        }
    }
    protected void Upload(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string fileName = string.Format(@"{0}meme.jpeg", Guid.NewGuid());
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}