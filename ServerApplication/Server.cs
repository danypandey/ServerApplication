using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Npgsql;
using UserCommon;
using System.Threading.Tasks;

namespace ServerApplication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class Server : IUserService
    {

        
        DataBase database = new DataBase("Host = localhost; User Id = postgres; Password = Dany@100; Database = MyHost");

        /*
         * Get single row from database
         */
        public async Task<Data> GetUserData(string userid)
        {
            database.con.Open();
            Data userData = await database.GetUserData(userid);
            database.con.Close();            
            return userData;
        }


        /*
         * Get all rows from database
         */
        public async Task<Data[]> GetAllUsers()
        {
            database.con.Open();
            Data[] userData = await database.GetAllUsers();            
            database.con.Close();
            return userData;
        }


        /*
         * Post single row in database
         */
        public async Task<Result> CreateUser(Data userdetails)
        {
            database.con.Open();
            await database.CreateUser(userdetails);
            database.con.Close();
            return new Result(0, null);
        }


        /*
         * Update single row in database
         */
        public async Task<Result> UpdateUser(Data userdetails)
        {
            database.con.Open();
            await database.UpdateUser(userdetails);
            database.con.Close();
            return new Result(0, null);
        }


        /*
         * Delete single row in database
         */
        public async Task<Result> DeleteUser(string userid)
        {
            database.con.Open();
            await database.DeleteUser(userid);
            database.con.Close();
            return new Result(0, null);
        }
    }
}