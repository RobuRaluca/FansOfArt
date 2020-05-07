using acc.Models.Account;
using acc.Models.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace WebApplication16.Models
{
	public class AccountViewModel
	{
		internal static UserProfile GetUserProfileData(int currentUserId)
    {
        UserProfile userProfile = new UserProfile();

        using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand("usp_UsersGetUserProfileData", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@UserId", currentUserId);

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                userProfile.UserName = reader["UserName"].ToString();
                userProfile.UserEmail = reader["UserEmail"].ToString();
            }
        }

        return userProfile;
    }

    public static void UpdateUserProfile(UserProfile userProfile)
    {
        using (SqlConnection conn = new SqlConnection(AppSetting.ConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand("usp_UsersUpdateUserProfile", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@UserId", WebSecurity.CurrentUserId);
                cmd.Parameters.AddWithValue("@UserName", userProfile.UserName);
                cmd.Parameters.AddWithValue("@UserEmail", userProfile.Email);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
}
