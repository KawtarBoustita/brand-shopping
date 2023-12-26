using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyShopping
{
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }
        private void BindBrandRepeater()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShoppingDB"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblBrands", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrBrands.DataSource = dt;
                        rptrBrands.DataBind();
                    }
                }
            }
        }
        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text != null && txtBrand.Text != "" && txtBrand.Text != string.Empty)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShoppingDB"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into tblBrands(Name) Values('" + txtBrand.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    Response.Write("<script> alert('Brand Added Successfully ');  </script>");
                    txtBrand.Text = string.Empty;

                    con.Close();
                    //lblMsg.Text = "Registration Successfully done";
                    //lblMsg.ForeColor = System.Drawing.Color.Green;
                    txtBrand.Focus();


                }
            }
        }

        protected void txtID_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShoppingDB"].ConnectionString);
            //if (con.State == ConnectionState.Closed) { con.Open(); }
            //SqlCommand cmd = new SqlCommand("select Name from tblBrands where BrandID=@ID",con);
            //cmd.Parameters.AddWithValue("@ID",Convert.ToInt32(txtID.Text));
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //da.Fill(ds, "dt");
            //con.Close();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    btnUpdateBrand.Enabled = true;
            //    txtUpdateBrandName.Text = ds.Tables[0].Rows[0]["Name"].ToString();

            //}
            //else
            //{
            //    btnUpdateBrand.Enabled = false;
            //    txtUpdateBrandName.Text = string.Empty;
            //}
            //con.Close();
        }

        protected void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            //txtBrand.Text = "0";
            //txtBrand.Visible = false;
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyShoppingDB"].ConnectionString);
            //if (con.State == ConnectionState.Closed) { con.Open(); }
            //SqlCommand cmd = new SqlCommand("insert into tblBrands (BrandID,Name) values(@ID,@Name)", con);
            //cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            //cmd.Parameters.AddWithValue("@Name", txtUpdateBrandName.Text);
            //cmd.ExecuteNonQuery();
            //Response.Write("<script>alert('Update successfully')</script>");
            //txtID.Text = string.Empty;
            //txtUpdateBrandName.Text = string.Empty;
            //txtBrand.Text = string.Empty;
            //txtBrand.Visible = true;
            //txtBrand.Focus();
        }
    }
}