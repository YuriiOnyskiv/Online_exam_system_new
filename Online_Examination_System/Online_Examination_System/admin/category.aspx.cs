using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class Admin_category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            panel_categorylist.Visible = true;
            panel_addcategory.Visible = false;
            btn_panelcategorylist.BackColor = ColorTranslator.FromHtml("#343A40");
            btn_paneladdcategory.BackColor = ColorTranslator.FromHtml("#DC3545");
            categorylistmethod();
        }
    }
    ///<summary>This is button<c>btn_panelcategorylist_Click</c> for the enable list of category panel </summary>
    protected void btn_panelcategorylist_Click(object sender, EventArgs e)
    {
        panel_categorylist.Visible = true;
        panel_addcategory.Visible = false;
        btn_panelcategorylist.BackColor = ColorTranslator.FromHtml("#343A40");
        btn_paneladdcategory.BackColor = ColorTranslator.FromHtml("#DC3545");
        categorylistmethod();

    }
    //This is button for enable the adding in category panel
    /// <summary>
    /// This is button for enable the adding in category panel
    /// </summary>
    /// <param name="sender">first paramentr</param>
    /// <param name="e">second parametr</param>
    protected void btn_paneladdcategory_Click(object sender, EventArgs e)
    {
        txt_category.Focus();
        panel_categorylist.Visible = false;
        panel_addcategory.Visible = true;
        btn_panelcategorylist.BackColor = ColorTranslator.FromHtml("#DC3545");
        btn_paneladdcategory.BackColor = ColorTranslator.FromHtml("#343A40");
    }

    //This is for adding the category in databse 
    /// <summary>
    /// This is for adding the category in databse 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_addcategory_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {

            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("insert into category (category_name) values (@category_name)", con);
                cmd.Parameters.AddWithValue("@category_name", txt_category.Text);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        txt_category.Text = string.Empty;
                        Response.Redirect("~/admin/category.aspx");
                        Response.Write("Added Succesfully");
                    }
                    else
                    {
                        txt_category.Focus();
                        panel_addcategory_warning.Visible = true;
                        lbl_categoryaddwarning.Text = "Something went wrong";
                    }
                }
                catch (Exception ex)
                {
                    txt_category.Focus();
                    panel_addcategory_warning.Visible = true;
                    lbl_categoryaddwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
                }

            }
        }
        else
        {
            txt_category.Focus();
            panel_addcategory_warning.Visible = true;
            lbl_categoryaddwarning.Text = "You must fill all the requirements";
        }

    }
    // For row command argument
    /// <summary>
    /// For row command argument
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdview_categorylist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete_category")
        {
            deletecategory(Convert.ToInt32(e.CommandArgument));
            categorylistmethod();
        }
    }
    // from page index changing 
    /// <summary>
    /// From page index changing 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdview_categorylist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdview_categorylist.PageIndex = e.NewPageIndex;
        categorylistmethod();
    }

    string s = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
    //Mehtod for retriving category into list item 
    /// <summary>
    /// Mehtod for retriving category into list item 
    /// </summary>
    public void categorylistmethod()
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("select * from category", con);
            try
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        grdview_categorylist.DataSource = dt;
                        grdview_categorylist.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                panel_categorylist_warning.Visible = true;
                lbl_categorylistwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
            }
        }
    }

    //Method for deleting category
    /// <summary>
    /// Method for deleting category
    /// </summary>
    /// <param name="id">Id is used as parametr</param>
    public void deletecategory(int id)
    {
        using (SqlConnection con = new SqlConnection(s))
        {
            SqlCommand cmd = new SqlCommand("delete category  where category_id = @catgeryid", con);
            cmd.Parameters.AddWithValue("@catgeryid", id);
            try
            {
                con.Open();
                int i = (int)cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Redirect("~/admin/category.aspx");
                    Response.Write("Delete Succesfully");
                }
                else
                {
                    panel_categorylist_warning.Visible = true;
                    lbl_categorylistwarning.Text = "Something went wrong. Can't delete now";
                }
            }
            catch (Exception ex)
            {
                panel_categorylist_warning.Visible = true;
                lbl_categorylistwarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message;
            }

        }
    }



}