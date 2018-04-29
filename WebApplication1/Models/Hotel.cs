using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
namespace WebApplication1.Models
{
    public class Hotel : IService
    {
        public int servicID { get; set; }
        public string serviceName { get; set; }
        public string serviceType { get; set; }
        public string City { get; set; }
        public string country { get; set; }

        string connection = @" Data Source = C:\Users\dodu_\Desktop\duha\sqlite_maestro_executable\Services.db; Version = 3; ";

        public Hotel()
        {
        }

        public Hotel(string serviceName, string city, string country)
        {
            this.serviceName = serviceName;
            this.serviceType = "Hotel";
            City = city;
            this.country = country;
        }

        public int Add(IService service)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                try
                {
                    conn.Open();

                    if(conn.State == System.Data.ConnectionState.Open)
                    {
                        string sql = "INSERT INTO Services (SERVICENAME, SERVICETYPE, CITY, COUNTRY) VALUES('" + service.serviceName + "', 'Hotel" 
                                  + "', '" + service.City + "', '" + service.country + "')";     
                        SQLiteCommand command = new SQLiteCommand(sql, conn);
                        command.ExecuteNonQuery();
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        public int Delete(int serviceID)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                try
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        string sql = "DELETE FROM Services WHERE SERVICEID = " + serviceID;
                        SQLiteCommand command = new SQLiteCommand(sql, conn);
                        command.ExecuteNonQuery();
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }

        public int Edit(int serviceID, IService service)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connection))
            {
                try
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        string sql = "UPDATE Services SET SERVICENAME ='" + service.serviceName + "', SERVICETYPE ='Hotel', CITY ='" 
                            +service.City + "', COUNTRY = '" + service.country + "' WHERE SERVICEID = " + serviceID;
                        SQLiteCommand command = new SQLiteCommand(sql, conn);
                        command.ExecuteNonQuery();
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
        }
    }
}