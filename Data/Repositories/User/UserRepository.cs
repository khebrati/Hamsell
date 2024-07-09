using System;
using System.Collections.Generic;
using Hamsell.Models;
using static Hamsell.Models.User;
using MySql.Data.MySqlClient;

namespace Hamsell.Data.Repositories.User
{
    public class UserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public void GetUser(int id)
        {
            string query = "SELECT * FROM User";
            var cmd = new MySqlCommand(query, _context.Connection);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var acountId = reader.GetInt32(0);
                var cityId = reader.GetInt32(1);
                var userStatusId = reader.GetInt32(2);
                Console.WriteLine(acountId + "," + cityId + "," + userStatusId);
            }

            _context.Close();
        }

        public IEnumerable<Models.User> GetAllUsers()
        {
            // Implement method to fetch all users
            throw new NotImplementedException();
        }

        public void AddUser(Models.User user)
        {
            // Implement method to add a new user
            throw new NotImplementedException();
        }

        public void UpdateUser(Models.User user)
        {
            // Implement method to update an existing user
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            // Implement method to delete a user by id
            throw new NotImplementedException();
        }
    }
}