using System;


namespace Assign5Mem3
{
    public partial class RSTryIt : System.Web.UI.Page
    {
        //event handler for reverse button
        protected void btnReverse_Click(object sender, EventArgs e)
        {
            //creates new instance of service
            var service = new MyUtilityService();
            //reverese method and display result
            lblResult.Text = service.ReverseString(txtInput.Text);
        }

        //event handler for set session button
        protected void btnSetSession_Click(object sender, EventArgs e)
        {
            //sets sample user session
            SessionManager.SetUserSession("TestUser");
            Response.Redirect(Request.RawUrl);
        }
    }
}