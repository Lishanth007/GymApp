using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GymApp
{
    public partial class PaymentHistory : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["GymDBConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    string sql = @"SELECT p.PaymentID, m.FullName AS [Member Name], pl.PlanName AS [Plan], 
                      p.StartDate AS [Start Date], p.EndDate AS [End Date], 
                      p.TotalPaid AS [Fee Paid (Rs)], p.PaymentMode AS [Payment Mode], 
                      p.PaymentStatus AS [Status], p.PaymentDate AS [Paid On]
               FROM FeePayments p
               JOIN Plans pl ON p.PlanID = pl.PlanID
               JOIN Members m ON p.MemberID = m.MemberID
               ORDER BY p.PaymentID DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvHistory.DataSource = dt;
                    gvHistory.DataBind();
                }
            }
        }
    }
}