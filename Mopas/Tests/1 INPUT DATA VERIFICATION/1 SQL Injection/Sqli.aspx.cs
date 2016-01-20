﻿using System;
using System.Data.SqlClient;

namespace Mopas.Tests
{

    /// <summary>
    /// 1.
    /// SQL Injection
    /// MOPAS
    /// Contains 1 vulnerability
    /// </summary>
    public partial class Sqli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.Params["id"];

            int str1 = 0;

            using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            using (var command = connection.CreateCommand())
            {
                // TODO: AI issue #1, High, SQL Injection, https://github.com/sdldemo/MOPAS/issues/1
                // GET /Tests/1 INPUT DATA VERIFICATION/1 SQL Injection/Sqli.aspx?id=1%27+AND+%271%27%3d%272 HTTP/1.1
                // Host:localhost
                command.CommandText = string.Format("SELECT test FROM news where id={0}", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        str1 += (int)reader["ColumnName"];
                }
            }

            Response.Write("<b>" + str1 + "</b>");
        }
    }
}