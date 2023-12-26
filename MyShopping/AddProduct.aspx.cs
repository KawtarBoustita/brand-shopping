using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace MyShopping
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["MyShoppingDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //when page first time run then this code will execute
                BindBrand();
                BindCategory();
                BindGender();
                BindColor();
                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;
                

                BindGridview1();

            }
        }
        private void BindGender()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblGender with(nolock)", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlGender.DataSource = dt;
                    ddlGender.DataTextField = "GenderName";
                    ddlGender.DataValueField = "GenderID";
                    ddlGender.DataBind();
                    ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }
        private void BindColor()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblColors ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    cblColor.DataSource = dt;
                    cblColor.DataTextField = "ColorName";
                    cblColor.DataValueField = "ColorID";
                    cblColor.DataBind();
                   

                }
            }
        }
      
        private void BindCategory()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        private void BindBrand()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblBrands", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "Name";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
                cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);
                cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);   
                cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);                         
                cmd.Parameters.AddWithValue("@PGender", ddlGender.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
                cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
                cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
                if (chFD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                }

                if (ch30Ret.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
                }
                if (cbCOD.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@COD", 0.ToString());
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());


                //Insert size quantity
                for (int i = 0; i < cblSize.Items.Count; i++)
                {
                    if (cblSize.Items[i].Selected == true)
                    {
                        Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                        int Quantity = Convert.ToInt32(txtQuantity.Text);

                        // SqlCommand cmd2 = new SqlCommand("insert into tblProductSizeQuantity(PID,SizeID,Quantity) values('" + PID + "','" + SizeID + "','" + Quantity + "')", con);
                        SqlCommand cmd2 = new SqlCommand("insert into tblProductSizeQuantity(PID,SizeID,Quantity) values(@PID,@SizeID,@Quantity)", con);
                        cmd2.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                        cmd2.Parameters.AddWithValue("@SizeID", Convert.ToInt32(SizeID));
                        cmd2.Parameters.AddWithValue("@Quantity", Convert.ToInt32(Quantity));
                        cmd2.ExecuteNonQuery();
                    }
                }
                //Insert Color quantity
                for (int i = 0; i < cblColor.Items.Count; i++)
                {
                    if (cblColor.Items[i].Selected == true)
                    {
                        Int64 ColorID = Convert.ToInt64(cblColor.Items[i].Value);
                        int Quantity = Convert.ToInt32(txtQuantity.Text);

                        // SqlCommand cmd2 = new SqlCommand("insert into tblProductSizeQuantity(PID,SizeID,Quantity) values('" + PID + "','" + SizeID + "','" + Quantity + "')", con);
                        SqlCommand cmdd = new SqlCommand("insert into tblProductColorQuantity(PID,ColorID,Quantity) values(@PID,@ColorID,@Quantity)", con);
                        cmdd.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                        cmdd.Parameters.AddWithValue("@ColorID", Convert.ToInt32(ColorID));
                        cmdd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(Quantity));
                        cmdd.ExecuteNonQuery();
                    }
                }
                //Insert and upload images
                if (fuImg01.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);

                    }
                    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                    fuImg01.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);

                    //SqlCommand cmd3 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString ().Trim () + "01" + "','" + Extention  + "')", con);
                    SqlCommand cmd4 = new SqlCommand("insert into tblProductImages(PID,Name,Extention) values(@PID,@Name,@Extention)", con);
                    cmd4.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd4.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "01");
                    cmd4.Parameters.AddWithValue("@Extention", Extention);
                    cmd4.ExecuteNonQuery();
                }
                //2nd fileupload
                if (fuImg02.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);

                    }
                    string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
                    fuImg02.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);

                    //SqlCommand cmd4 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
                    SqlCommand cmd5 = new SqlCommand("insert into tblProductImages(PID,Name,Extention) values(@PID,@Name,@Extention)", con);
                    cmd5.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd5.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "02");
                    cmd5.Parameters.AddWithValue("@Extention", Extention);
                    cmd5.ExecuteNonQuery();
                }

                //3rd file upload 
                if (fuImg03.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);

                    }
                    string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
                    fuImg03.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);

                    //SqlCommand cmd5 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);
                    SqlCommand cmd6 = new SqlCommand("insert into tblProductImages(PID,Name,Extention) values(@PID,@Name,@Extention)", con);
                    cmd6.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd6.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "03");
                    cmd6.Parameters.AddWithValue("@Extention", Extention);
                    cmd6.ExecuteNonQuery();
                }
                //4th file upload control
                if (fuImg04.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);

                    }
                    string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
                    fuImg04.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);

                    //SqlCommand cmd6 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);
                    SqlCommand cmd7 = new SqlCommand("insert into tblProductImages(PID,Name,Extention) values(@PID,@Name,@Extention)", con);
                    cmd7.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd7.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "04");
                    cmd7.Parameters.AddWithValue("@Extention", Extention);
                    cmd7.ExecuteNonQuery();
                }

                //5th file upload
                if (fuImg05.HasFile)
                {
                    string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);

                    }
                    string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
                    fuImg05.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);

                    //SqlCommand cmd7 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
                    SqlCommand cmd8 = new SqlCommand("insert into tblProductImages(PID,Name,Extention) values(@PID,@Name,@Extention)", con);
                    cmd8.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd8.Parameters.AddWithValue("@Name", txtProductName.Text.ToString().Trim() + "05");
                    cmd8.Parameters.AddWithValue("@Extention", Extention);
                    cmd8.ExecuteNonQuery();

                    BindGridview1();
                    Response.Redirect("AddProduct.aspx");
                }

            }
        }
        private void BindGridview1()
        {
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand(" select distinct t1.PID,t1.PName,t1.PPrice,t1.PSelPrice,t2.Name as Brand,t3.CatName,t4.SubCatName, t5.GenderName as gender,t6.SizeName,t7.ColorName,t8.Quantity from tblProducts as t1  inner join tblBrands as t2 on t2.BrandID=t1.PBrandID  inner join tblCategory as t3 on t3.CatID=t1.PCategoryID  inner join tblSubCategory as t4 on t4.SubCatID=t1.PSubCatID   inner join tblGender as t5 on t5.GenderID =t1.PGender   inner join tblSizes as t6 on t6.SubCategoryID=t1.PSubCatID inner join tblColors as t7 on t7.SubCategoryID =t1.PSubCatID  inner join tblProductSizeQuantity as t8 on t8.PID=t1.PID order by t1.PName", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }


        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID='" + ddlCategory.SelectedItem.Value + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = dt;
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedIndex != 0)
            {
                ddlGender.Enabled = true;
            }
            else
            {
                ddlGender.Enabled = false;
            }
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string qr = "Select * from tblSizes where BrandID=@BrandID AND CategoryID=@CategoryID AND SubCategoryID=@SubCategoryID AND GenderID=@GenderID ";
                // qr = "Select * from tblSizes where BrandID='" + ddlBrand.SelectedValue + "' and CategoryID='" + ddlCategory.SelectedValue + "' and SubCategoryID='" + ddlSubCategory.SelectedValue + "' and GenderID='" + ddlGender.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(qr, con);
                cmd.Parameters.AddWithValue("@BrandID", ddlBrand.SelectedValue);
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@SubCategoryID", ddlSubCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@GenderID", ddlGender.SelectedValue);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                if (dt.Rows.Count != 0)
                {
                    cblSize.DataSource = dt;
                    cblSize.DataTextField = "SizeName";
                    cblSize.DataValueField = "SizeID";
                    cblSize.DataBind();

                }
            }
            
        }      
    }
}