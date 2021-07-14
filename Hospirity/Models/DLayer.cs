using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Hospirity.Models
{
    public class DLayer
    {
        private string con = @"data source=LAPTOP-UCDKD49C\MSSQLSERVER2014;initial catalog=Hospirity;integrated security=true;";


        #region Connection string for Demo
        //private string con = "data source=184.168.47.19;initial catalog=hnsHospirity; user id=Hospirity;password=Heartnsoul@357";
        //private string con = "data source=OpenSource.mssql.somee.com;initial catalog=OpenSource; user id=debsankar620_SQLLogin_1;password=pl4ojao8ep";
        #endregion

        #region Data Access Layer Work
        public string Con
        {
            get
            {

                return con;
            }
        }
        public static byte[] pImage;
        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            int a = 0;

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@img")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                    //cmd.Parameters.Add(parametername[i], SqlDbType.Int).Direction = ParameterDirection.Output;
                }
            }
            con.Open();

            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }
        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {

                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                Property.erroCheck = ex.ToString();

                DataSet ds = null;
                return ds;
            }

        }
        public DataSet MyDs_Process(String Storp)
        {

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }
        public int ExecNonQuery(String Qry)
        {
            int a = 0;

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Qry, con);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            con.Open();
            a = cmd.ExecuteNonQuery();
            con.Dispose();
            return a;
        }

        #endregion

        #region Admin Login
        public int InsertAdmin_Sp(AdminLogin m)
        {
            string[] paname = { "@AdminId", "@FullName", "@Email", "@Password", "@MobileNo" };
            string[] pavalue = { m.AdminId, m.FullName, m.Email, m.Password, m.MobileNo };
            return Int_Process("InsertAdmin_Sp", paname, pavalue);
        }
        public DataSet FetchAdminLogin_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchAdminLogin_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Admin Index
        public DataSet FetchAdminIndex_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchAdminIndex_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Home Page
        public DataSet FetchHomePage_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchHomePage_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Banner Image
        public int InsertBannerImg_Sp(BannerImage m)
        {
            string[] paname = { "@BannerId", "@BannerTitle", "@BannerDes", "@BannerImg" };
            string[] pavalue = { m.BannerId, m.BannerTitle, m.BannerDes, m.BannerImg };
            return Int_Process("InsertBannerImg_Sp", paname, pavalue);
        }
        public DataSet FetchBannerImg_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBannerImg_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Homepage AboutUs
        public int InsertHomeAboutUs_Sp(HomeAbout m)
        {
            string[] paname = { "@AboutId", "@Des", "@Img1", "@Img2", "@Img3" };
            string[] pavalue = { m.AboutId, m.Des, m.Img1, m.Img2, m.Img3 };
            return Int_Process("InsertHomeAboutUs_Sp", paname, pavalue);
        }
        public DataSet FetchHomeAboutUs_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchHomeAboutUs_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Homepage Services
        public int InsertHomeService_Sp(HomeServices m)
        {
            string[] paname = { "@ServicesId", "@Img1", "@Img2", "@Img3", "@Img4", "@Title1", "@Title2", "@Title3", "@Title4" };
            string[] pavalue = { m.ServicesId, m.Img1, m.Img2, m.Img3, m.Img4, m.Title1, m.Title2, m.Title3, m.Title4 };
            return Int_Process("InsertHomeService_Sp", paname, pavalue);
        }
        public DataSet FetchHomeService_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchHomeService_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Contact Us
        public int InsertContactUs_Sp(ContactUs m)
        {
            string[] paname = { "@Name", "@Email", "@MobileNo", "@Message" };
            string[] pavalue = { m.Name, m.Email, m.MobileNo, m.Message };
            return Int_Process("InsertContactUs_Sp", paname, pavalue);
        }
        public int InsertAddress_Sp(Address m)
        {
            string[] paname = { "@Id", "@Location", "@Phone", "@Email" };
            string[] pavalue = { m.Id, m.Location, m.Phone, m.Email };
            return Int_Process("InsertAddress_Sp", paname, pavalue);
        }
        public DataSet FetchContactUs_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchContactUs_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Gallery
        public int InsertGalleryImg_Sp(GalleryPhoto m)
        {
            string[] paname = { "@PhotoId","@Category", "@ImageName", "@SmallImage", "@BigImage" };
            string[] pavalue = { m.PhotoId, m.Category, m.ImageName, m.SmallImage, m.BigImage };
            return Int_Process("InsertGalleryImg_Sp", paname, pavalue);
        }
        public DataSet FetchGalleryImg_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchGalleryImg_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region About Us
        public int InsertAboutus_Sp(AboutUs m)
        {
            string[] paname = { "@AboutId", "@AboutTitle", "@AboutDes", "@AboutImg" };
            string[] pavalue = { m.AboutId, m.AboutTitle, m.AboutDes, m.AboutImg };
            return Int_Process("InsertAboutus_Sp", paname, pavalue);
        }
        public DataSet FetchAboutus_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchAboutus_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int InsertAboutUs1_Sp(AboutUs1 m)
        {
            string[] paname = { "@AboutId", "@Title" };
            string[] pavalue = { m.AboutId, m.Title };
            return Int_Process("InsertAboutUs1_Sp", paname, pavalue);
        }
        public int InsertAboutUs2_Sp(AboutUs2 m)
        {
            string[] paname = { "@AboutId", "@Title", "@Des" };
            string[] pavalue = { m.AboutId, m.Title, m.Des };
            return Int_Process("InsertAboutUs2_Sp", paname, pavalue);
        }
        public int InsertAboutUs3_Sp(AboutUs3 m)
        {
            string[] paname = { "@AboutId", "@Title", "@Des", "@Des1", "@Services1", "@Services2", "@Services3", "@Services4", "@Services5", "@Img" };
            string[] pavalue = { m.AboutId, m.Title, m.Des, m.Des1, m.Services1, m.Services2, m.Services3, m.Services4, m.Services5, m.Img };
            return Int_Process("InsertAboutUs3_Sp", paname, pavalue);
        }
        //public int InsertInsImg_Sp(InsImg m)
        //{
        //    string[] paname = { "@Img" };
        //    string[] pavalue = { m.Img };
        //    return Int_Process("InsertInsImg_Sp", paname, pavalue);
        //}
        //public int InsertTeam_Sp(OurTeam m)
        //{
        //    string[] paname = { "@TeamId", "@Team" };
        //    string[] pavalue = { m.TeamId, m.Team };
        //    return Int_Process("InsertTeam_Sp", paname, pavalue);
        //}
        #endregion

        #region Services
        public int InsertServices_Sp(Services m)
        {
            string[] paname = { "@ServicesId", "@Title", "@SubTitle", "@Img" };
            string[] pavalue = { m.ServicesId, m.Title, m.SubTitle, m.Img };
            return Int_Process("InsertServices_Sp", paname, pavalue);
        }
        public DataSet FetchServices_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchServices_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Company Profile
        public int InsertCompanyProfile_Sp(CompanyProfile m)
        {
            string[] paname = { "@CId", "@Vision", "@CValues", "@Mission" };
            string[] pavalue = { m.CId, m.Vision, m.CValues, m.Mission };
            return Int_Process("InsertCompanyProfile_Sp", paname, pavalue);
        }
        public DataSet FetchCompanyProfile_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchCompanyProfile_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Testimonial
        public int InsertTestimonial_Sp(Testimonial t)
        {
            string[] paname = { "@TestimonialId", "@CName", "@CDesignation", "@Testimonials", "@CImg" };
            string[] pavalue = { t.TestimonialId, t.CName, t.CDesignation, t.Testimonials, t.CImg };
            return Int_Process("InsertTestimonial_Sp", paname, pavalue);
        }
        public DataSet FetchTestimonial_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchTestimonial_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Blog
        public int InsertBlog_Sp(Blog t)
        {
            string[] paname = { "@BlogId", "@BlogTitle", "@SmallDescription", "@BlogDescription", "@BlogImg" };
            string[] pavalue = { t.BlogId, t.BlogTitle, t.SmallDescription, t.BlogDescription, t.BlogImg };
            return Int_Process("InsertBlog_Sp", paname, pavalue);
        }
        public DataSet FetchBlog_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchBlog_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Career
        public int InsertCareer_Sp(Career c)
        {
            string[] paname = { "@CId", "@Title", "@Des" };
            string[] pavalue = { c.CId, c.Title, c.Des };
            return Int_Process("InsertCareer_Sp", paname, pavalue);
        }
        public DataSet FetchCareer_sp(Property p)
        {
            try
            {
                string[] paname = { "@Condition1", "@Condition2", "@Condition3", "@Condition4", "@Condition5", "@Condition6", "@Condition7", "@Condition8", "@Condition9", "@OnTable" };
                string[] pavalue = { p.Condition1, p.Condition2, p.Condition3, p.Condition4, p.Condition5, p.Condition6, p.Condition7, p.Condition8, p.Condition9, p.OnTable };
                return Ds_Process("FetchCareer_sp", paname, pavalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}