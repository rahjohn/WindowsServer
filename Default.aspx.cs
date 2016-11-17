using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;

public partial class Default : System.Web.UI.Page
{
    string fileName = string.Format(@"{0}meme.jpeg", Guid.NewGuid());
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
        if (Request.QueryString["email"] != null)
        {
            if (FileUpload1.HasFile)
            {
                //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        } else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have to authenticate in order to upload an image." + "');", true);
        }
    }
    protected void addText(object sender, EventArgs e)
    {
        TextBox top = (TextBox)TextBox4;
        string topText = top.Text;
        TextBox bot = (TextBox)TextBox5;
        string botText = bot.Text;

        PointF firstLocation = new PointF(10f, 10f);
        PointF secondLocation = new PointF(10f, 50f);

        string imageFilePath = Server.MapPath("~/Images/") + fileName; 
        Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(imageFilePath);//load the image file

        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            using (Font arialFont = new Font("Arial", 10))
            {
                graphics.DrawString(topText, arialFont, Brushes.Blue, firstLocation);
                graphics.DrawString(botText, arialFont, Brushes.Red, secondLocation);
            }
        }

        bitmap.Save(imageFilePath);//save the image file
    }
}