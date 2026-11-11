using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GymApp
{
    public partial class FeeSummary : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["GymDBConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart_PlanID"] == null)
                {
                    Response.Redirect("Plans.aspx");
                    return;
                }

                DateTime startDate = Convert.ToDateTime(Session["Cart_StartDate"].ToString());
                int months = Convert.ToInt32(Session["Cart_Duration"].ToString());
                DateTime endDate = startDate.AddMonths(months);

                Session["Cart_EndDate"] = endDate.ToString("yyyy-MM-dd");

                lblMemberName.Text = Session["Cart_MemberName"].ToString();
                lblPlan.Text = Session["Cart_PlanName"].ToString();
                lblStart.Text = startDate.ToString("dd-MMM-yyyy");
                lblEnd.Text = endDate.ToString("dd-MMM-yyyy");
                lblTotal.Text = Session["Cart_Fee"].ToString();
            }
        }

        protected void btnPayFee_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                // 1. Insert member name and get the new generated MemberID
                string insertMemberSql = "INSERT INTO Members (FullName, Email, Phone) OUTPUT INSERTED.MemberID VALUES (@name, 'member@gym.com', '0000000000')";
                int newMemberId;
                using (SqlCommand memberCmd = new SqlCommand(insertMemberSql, con))
                {
                    memberCmd.Parameters.AddWithValue("@name", Session["Cart_MemberName"].ToString());
                    newMemberId = (int)memberCmd.ExecuteScalar();
                }

                // 2. Insert the fee payment linked to the new MemberID
                string sql = @"INSERT INTO FeePayments (MemberID, PlanID, StartDate, EndDate, TotalPaid, PaymentMode, PaymentStatus) 
                               VALUES (@mid, @pid, @sdate, @edate, @amt, @pmode, 'Paid')";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@mid", newMemberId);
                    cmd.Parameters.AddWithValue("@pid", Session["Cart_PlanID"].ToString());
                    cmd.Parameters.AddWithValue("@sdate", Session["Cart_StartDate"].ToString());
                    cmd.Parameters.AddWithValue("@edate", Session["Cart_EndDate"].ToString());
                    cmd.Parameters.AddWithValue("@amt", Session["Cart_Fee"].ToString());
                    cmd.Parameters.AddWithValue("@pmode", ddlPayMode.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
            }

            Session.Clear();
            Response.Redirect("PaymentHistory.aspx");
        }
    }
}