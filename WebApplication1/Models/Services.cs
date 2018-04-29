﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Data;

namespace WebApplication1.Models
{
    public class Services
    {
        string connection = @" Data Source = C:\Users\dodu_\Desktop\duha\sqlite_maestro_executable\Services.db; Version = 3; ";

        public string GetData()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Services";

            using (SQLiteConnection con = new SQLiteConnection(connection))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    con.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dt);
                    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
        }
    }
}