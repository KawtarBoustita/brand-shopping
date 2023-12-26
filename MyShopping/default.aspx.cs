using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace MyShopping
{
    public partial class _default : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyShoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserLogin"] == "YES")
            {
                Response.Redirect("UserHome.aspx?UserLogin=YES");
            }

            if (Session["Username"] != null)
            {
                //lblSuccess.Text = "Login Success, Welcome <b>" + Session["Username"].ToString() + "</b>";

                if (!this.IsPostBack)
                {
                    BindProductRemove();
                    BindProductRepeater();
                    BindProductRepeater1();
                    BindProductRepeater2();
                    BindProductRepeater3();
                    btnSignUP.Visible = false;
                    btnSignIN.Visible = false;
                    btnlogout.Visible = true;
                }

            }
            else
            {
                BindProductRemove();
                BindProductRepeater();
                BindProductRepeater1();
                BindProductRepeater2();
                BindProductRepeater3();
                btnSignUP.Visible = true;
                btnSignIN.Visible = true;
                btnlogout.Visible = false;
                //Response.Redirect("Default.aspx");
                Response.Write("<script type='text/javascript'>alert('Login plz')</script>");

            }
        }
        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                //pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                //pCount.InnerText = 0.ToString();
            }
        }
        private void BindProductRepeater1()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("procBindAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);


                        rptrProducts2.DataSource = dt;
                        rptrProducts2.DataBind();
                        if (dt.Rows.Count <= 0)
                        {
                            //Label1.Text = "Sorry! Currently no products in this category.";
                            //pCount.InnerHtml = "0";
                        }
                        else
                        {
                            //Label1.Text = "Showing All Products";
                        }
                    }
                }
            }
        }
        private void BindProductRepeater()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {

                    using (SqlCommand cmd = new SqlCommand("procBindAllProducts", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);


                            rptrProducts.DataSource = dt;
                            rptrProducts.DataBind();

                        if (dt.Rows.Count <= 0)
                        {
                            Int32 myQty = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                            if (myQty <= 1)
                            {
                                string removeProductQuery = "DELETE tblProducts " +
                                 "FROM tblProducts " +
                                 "INNER JOIN tblProductSizeQuantity ON tblProducts.PID = tblProductSizeQuantity.PrdSizeQuantID " +
                                 "WHERE tblProductSizeQuantity.Quantity = 0";
                                 SqlCommand comd = new SqlCommand("removeProductQuery", con);
                                Int32 PID = Convert.ToInt32(dt.Rows[0]["PID"].ToString());
                                comd.Parameters.AddWithValue("@PID", PID);
                                con.Open();
                                comd.ExecuteNonQuery();
                                con.Close();

                            }
                            else
                            {
                                //Label1.Text = "Showing All Products";
                            }
                        }
                        
                    }
                    
                }

                
            }
        }
        private void BindProductRepeater2()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("procBindAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))

                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);


                        rptrProducts.DataSource = dt;
                        rptrProducts.DataBind();
                        if (dt.Rows.Count <= 0)
                        {
                            //Label1.Text = "Sorry! Currently no products in this category.";
                            //pCount.InnerHtml = "0";
                        }
                        else
                        {
                            //Label1.Text = "Showing All Products";
                        }
                    }
                }
            }
        }
       
        private void BindProductRemove()
        {

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
             
                string removeProductQuery = "DELETE tblProducts " +
                                 "FROM tblProducts " +
                                 "INNER JOIN tblProductSizeQuantity ON tblProducts.PID = tblProductSizeQuantity.PrdSizeQuantID " +
                                 "WHERE tblProductSizeQuantity.Quantity = 0";
                using (SqlCommand deleteCommand = new SqlCommand(removeProductQuery, con))
                {
                     int rowsAffected = deleteCommand.ExecuteNonQuery();

                     if (rowsAffected > 0)
                     {
                         Console.WriteLine($"{rowsAffected} records deleted successfully.");
                     }
                     else
                     {
                         Console.WriteLine("No records matched the condition or no deletion was needed.");
                     }
                }              
            }

        }
        private void BindProductRepeater3()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {

                using (SqlCommand cmd = new SqlCommand("procBindAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);


                        rptrProducts.DataSource = dt;
                        rptrProducts.DataBind();

                        if (dt.Rows.Count <= 0)
                        {
                            Int32 myQty = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                            if (myQty <= 1)
                            {
                                string removeProductQuery = "DELETE tblProducts " +
                                 "FROM tblProducts " +
                                 "INNER JOIN tblProductSizeQuantity ON tblProducts.PID = tblProductSizeQuantity.PrdSizeQuantID " +
                                 "WHERE tblProductSizeQuantity.Quantity = 0";
                                SqlCommand comd = new SqlCommand("removeProductQuery", con);
                                Int32 PID = Convert.ToInt32(dt.Rows[0]["PID"].ToString());
                                comd.Parameters.AddWithValue("@PID", PID);
                                con.Open();
                                comd.ExecuteNonQuery();
                                con.Close();

                            }
                            else
                            {
                                //Label1.Text = "Showing All Products";
                            }
                        }

                    }

                }


            }
        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("AR-Mr");
            ci.NumberFormat.CurrencySymbol = "DH";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {

            Session["Username"] = null;
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }
    }
}