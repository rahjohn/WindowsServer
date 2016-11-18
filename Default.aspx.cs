using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Drawing;
using AForge.Imaging.Filters;

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
        if (Request.QueryString["email"] != null)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = string.Format(@"{0}meme.jpeg", Guid.NewGuid());
                //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                Response.Redirect(Request.Url.AbsoluteUri + "&filename=" + fileName);
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
        PointF secondLocation = new PointF(10f, 500f);
        string fileName = Request.QueryString["fileName"];
        string imageFilePath = Server.MapPath("~/Images/") + fileName;
        Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(imageFilePath);//load the image file
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            using (Font arialFont = new Font("Arial", 40))
            {
                graphics.DrawString(topText, arialFont, Brushes.Black, firstLocation);
                graphics.DrawString(botText, arialFont, Brushes.Black, secondLocation);
            }
        }
        Bitmap temp = bitmap;
        if (DropDownList1.SelectedItem.Text == "Grayscale")
        {
            // create grayscale filter (BT709)
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            // apply the filter
        temp = filter.Apply(bitmap);
        } else
        {
            // create filter
            Sepia filter = new Sepia();
            // apply the filter
            filter.ApplyInPlace(bitmap);
        }
        temp.Save(Server.MapPath("~/Images/edit/") + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);//save the image file
        try
        {
            string connectionString = "uid=guest;server=bryce-aws.duckdns.org;port=3307;database=it210b;password=guest;";
            MySqlConnection MyConn = new MySqlConnection(connectionString);
            MyConn.Open();
            string dataQuery = "SELECT userId FROM users WHERE email ='" + Request.QueryString["email"] + "'";
            MySqlCommand command = new MySqlCommand(dataQuery, MyConn);
            MySqlDataReader reader = command.ExecuteReader();
            string idnumber = "";
            while (reader.Read())
            {
                idnumber = reader.GetString(0);
            }
            MyConn.Close();
            MyConn.Open();
            dataQuery = "INSERT INTO images (imagePath,altText,userId) VALUES('/images/" + fileName + "','" + fileName + "'," + idnumber + ")";
            MySqlCommand MyCommand2 = new MySqlCommand(dataQuery, MyConn);
            MyCommand2.ExecuteNonQuery();
            MyConn.Close();
        }
        catch (MySqlException ex)
        {
            int errorcode = ex.Number;
            Label1.Text = ex.Message;
        }
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}
