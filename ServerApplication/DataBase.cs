using Npgsql;
using Org.BouncyCastle.Security.Certificates;
using System;
using System.Threading.Tasks;
using UserCommon;
using System.ServiceModel;
using System.Collections.Generic;

namespace ServerApplication
{
    class DataBase
    {
        string path;
        public NpgsqlConnection con;

        public DataBase(string databaseConfiguration)
        {
            path = databaseConfiguration;
            con = new NpgsqlConnection(path);
        }

        public async Task<Data> GetUserData(string userid)
        {
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM \"UserDetails\" where \"id\" = '" + userid + "' ";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();                    
                    userDetails = new Data(reader.GetString(0), reader.GetString(1), reader.GetString(2));                    
                }
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
            }
            
            return userDetails;
        }

        public async Task<Data[]> GetAllUsers()
        {
            Data userDetails = null;
            List<Data> list = new List<Data>();
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * FROM \"UserDetails\"";
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        userDetails = new Data(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                        list.Add(userDetails);
                    }                   
                }
               
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
            }
            Data[] details = list.ToArray();
            return details;
        }

        public async Task CreateUser(Data userdetails)
        {
            string id = userdetails.id;
            string Name = userdetails.Name;
            string Age = userdetails.Age;

            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "INSERT INTO \"UserDetails\" VALUES('" + id + "', '" + Name + "', '" + Age + "');";
                cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
                throw;
            }
        }

        public async Task UpdateUser(Data userdetails)
        {
            string id = userdetails.id;
            string Name = userdetails.Name;
            string Age = userdetails.Age;

            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "UPDATE \"UserDetails\" SET \"id\"='" + id + "',\"Name\"='" + Name + "',\"Age\"='" + Age + "' where \"id\"='" + id + "';";
                cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
                throw;
            }
        }

        public async Task DeleteUser(string userid)
        {
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "DELETE from \"UserDetails\" where \"id\" = '" + userid + "';";
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg);
                throw;
            }
        }
    }
}
