﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MVCWebApplication4.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }


        public static DataSet GetProviderData()
        {
            
            var connectionString = @"Data Source=DESKTOP-37UDTFK\VIKASSQL;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing";
            SqlConnection conn = new SqlConnection(connectionString);


            conn.Open();
            SqlCommand command = new SqlCommand("select * from Provider", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            return ds;
        }

        internal void InsertProvider(Provider p)
        {
            var connectionString = @"Data Source=DESKTOP-37UDTFK\VIKASSQL;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing";
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"insert into Provider (ProviderName, ProviderType) values ('{p.ProviderName}','{p.ProviderType}'";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }
    }  
}