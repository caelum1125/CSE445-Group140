using System;
using System.Data;
using FinalProject_WebApp.AuthServiceRef;
using System.Web;
using FinalProject_WebApp;
using System.Web.UI;
using System.Web.UI.HtmlControls;



namespace FinalProject_WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // populate dropdown from cookie
                ddlTheme.SelectedValue = CookieHelper.GetTheme(Request);

                // build Service Directory once
                BuildDirectoryTable();
            }
        }

        private void BuildDirectoryTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Provider");
            dt.Columns.Add("Component Type");
            dt.Columns.Add("Name / Link");
            dt.Columns.Add("Inputs");
            dt.Columns.Add("Outputs");
            dt.Columns.Add("Description");

            dt.Rows.Add("Member A", "Global.asax", "Hit‑counter", "—", "—",
                "Application_Start & Session_Start increment visitor count");
            dt.Rows.Add("Member A", "Cookie Helper", "ThemeColor cookie", "color(string)",
                "none", "Stores selected theme 14 days");
            dt.Rows.Add("Member A", "Web Service", $"<a href='https://webstrar.../AuthUtilityService/AuthUtilityService.asmx?op=CheckStrength' target='_blank'>CheckStrength</a>",
                "password(string)", "score(int)", "Returns 0‑4 strength");

            // TODO: Rows for Member B & C later
            tblDirectory.InnerHtml = ToHtml(dt);
        }

        private static string ToHtml(DataTable dt)
        {
            string html = "<tr>";
            foreach (DataColumn col in dt.Columns) html += $"<th>{col.ColumnName}</th>";
            html += "</tr>";
            foreach (DataRow r in dt.Rows)
            {
                html += "<tr>";
                foreach (var item in r.ItemArray) html += $"<td>{item}</td>";
                html += "</tr>";
            }
            return html;
        }

        /*** Try‑It handlers ***/
        protected void BtnCheck_Click(object sender, EventArgs e)
        {
            var svc = new AuthUtilityService();
            int score = svc.CheckStrength(txtPwd.Text);
            lblScore.Text = $"Strength = {score}";
        }

        protected void BtnSaveTheme_Click(object sender, EventArgs e)
        {
            CookieHelper.SetTheme(Response, ddlTheme.SelectedValue);
            lblThemeMsg.Text = "Cookie saved. Refresh to see it persist.";
        }
    }
}