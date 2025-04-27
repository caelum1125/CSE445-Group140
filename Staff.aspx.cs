using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace StaffWebApp
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddStaff_Click(object sender, EventArgs e)
        {
            //retrieve username and password from text
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblResult.Text = "Username and Password cannot be empty.";
                return;
            }

            string encryptedPassword = password; //replace later

            //defines path to xml file
            string path = Server.MapPath("~/Staff.xml");

            XDocument doc;

            //check if staff.xml exists
            if (File.Exists(path))
            {
                doc = XDocument.Load(path);
            }
            else
            {
                doc = new XDocument(new XElement("StaffMembers"));
            }

            //adds a new <Staff> entry
            doc.Root.Add(
                new XElement("Staff",
                    new XElement("Username", username),
                    new XElement("Password", encryptedPassword)
                )
            );

            //saves changes
            doc.Save(path);

            lblResult.Text = "Staff added successfully!";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected void btnViewStaff_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Staff.xml");
            if (File.Exists(path))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(path);
                GridViewStaff.DataSource = ds.Tables[0];
                GridViewStaff.DataBind();
            }
        }
    }
}
