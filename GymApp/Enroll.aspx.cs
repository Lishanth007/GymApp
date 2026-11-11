using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GymApp
{
    public partial class Enroll : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["GymDBConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                using (SqlConnection con = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT PlanID, PlanName FROM Plans", con);
                    con.Open();
                    ddlPlans.DataSource = cmd.ExecuteReader();
                    ddlPlans.DataTextField = "PlanName";
                    ddlPlans.DataValueField = "PlanID";
                    ddlPlans.DataBind();
                }

                if (Session["PlanID"] != null)
                {
                    ddlPlans.SelectedValue = Session["PlanID"].ToString();
                }

                UpdatePlanDetails();
            }
        }

        protected void ddlPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlanDetails();
        }

        void UpdatePlanDetails()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT DurationMonths, FeeAmount FROM Plans WHERE PlanID = @id", con);
                cmd.Parameters.AddWithValue("@id", ddlPlans.SelectedValue);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblDuration.Text = reader["DurationMonths"].ToString();
                    lblFee.Text = reader["FeeAmount"].ToString();
                }
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            // Store the input name into Session
            Session["Cart_MemberName"] = string.IsNullOrWhiteSpace(txtName.Text) ? "Guest Member" : txtName.Text.Trim();

            Session["Cart_PlanID"] = ddlPlans.SelectedValue;
            Session["Cart_PlanName"] = ddlPlans.SelectedItem.Text;
            Session["Cart_StartDate"] = txtStartDate.Text;
            Session["Cart_Duration"] = lblDuration.Text;
            Session["Cart_Fee"] = lblFee.Text;

            Response.Redirect("FeeSummary.aspx");
        }
    }
}