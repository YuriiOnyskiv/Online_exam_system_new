using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Admin_examDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string eid = Request.QueryString["eid"];
        if (!IsPostBack)
        {

            if (eid == null)
            {
                Response.Redirect("~/admin/exam.aspx");
            }

            getexam_details(Convert.ToInt32(eid));
        }
    }
    /// <summary>
    /// Method for exam details
    /// </summary>
    /// <param name="id">Id is used as parametr</param>
    public void getexam_details(int id)
    {
        string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("spExamListDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@exam_id", id);
            try
            {
                con.Open();
                exam_details.DataSource = cmd.ExecuteReader();
                exam_details.DataBind();
            }
            catch (Exception ex)
            {
                panel_examdetails_warning.Visible = true;
                lbl_examdetailswarning.Text = "Something went wrong. Pleas contact your provider </br>" + ex.Message;
            }

        }
    }
}