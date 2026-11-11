using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace GymApp
{
    public partial class Plans : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["GymDBConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Plans", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvPlans.DataSource = dt;
                    gvPlans.DataBind();
                }
            }
        }

        protected void gvPlans_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChoosePlan")
            {
                string[] data = e.CommandArgument.ToString().Split(';');
                Session["PlanID"] = data[0];
                Session["PlanName"] = data[1];
                Session["Duration"] = data[2];
                Session["Fee"] = data[3];
                Response.Redirect("Enroll.aspx");
            }
        }
    }
}