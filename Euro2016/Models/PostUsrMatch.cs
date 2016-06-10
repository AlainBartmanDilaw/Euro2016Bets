using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Euro2016.Models
{
    public class PostUsrMatch : System.Web.UI.Page
    {
        [WebMethod]
        public static string Insert_Data(String pMatchsIdt, String pUsrName, String pScoreHome, String pScoreAway)
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.PostBetFull";
                        cmd.Parameters.AddWithValue("@pMatchsIdt"   , Convert.ToInt32(pMatchsIdt));
                        cmd.Parameters.AddWithValue("@pUsrName"     , pUsrName);
                        cmd.Parameters.AddWithValue("@pScoreHome"   , Convert.ToInt32(pScoreHome));
                        cmd.Parameters.AddWithValue("@pScoreAway"   , Convert.ToInt32(pScoreAway));
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return "success";

                    }
                }
                catch (Exception ex)
                {
                    return "error " + ex.Message;
                }
            }
        }
    }
}