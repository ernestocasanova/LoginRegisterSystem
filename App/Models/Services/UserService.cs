//-----------------------------------------------------------------​
//    <copyright file="LoginRegisterSystem.cs" company="IPCA">​
//     Copyright IPCA-EST. All rights reserved.​
//    </copyright>​
//    <date>24-11-2024</date>​
//    <time>21:00</time>​
//    <version>0.1</version>​
//    <author>Ernesto Casanova</author>​
//-----------------------------------------------------------------

using LoginRegisterSystem.Models.Entity;
using LoginRegisterSystem.Models.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginRegisterSystem.Models.Services
{
    /// <summary>
    /// Service class responsible for managing user-related data operations such as loading, saving, 
    /// validating credentials, and registering users.
    /// </summary>
    public class UserService
    {
        #region Private Fields
        private readonly string _usersFilePath = FilePathManager.Instance.UsersFilePath; // Path to the users data file
        #endregion

        #region Public Methods
        /// <summary>
        /// Asynchronously loads the list of users from the data file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of users.</returns>
        public async Task<List<User>> LoadUsersAsync()
        {
            // Check if the users file exists
            if (!File.Exists(_usersFilePath))
                return new List<User>(); // Return an empty list if no file is found

            // Read the file and deserialize the JSON content into a list of users
            using (StreamReader reader = new StreamReader(_usersFilePath))
            {
                string json = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>(); // Deserialize and return users
            }
        }

        /// <summary>
        /// Validates user credentials by checking the username and password against the list of users.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <param name="users">The list of users to validate against.</param>
        /// <returns>True if the credentials are valid, otherwise false.</returns>
        public bool ValidateCredentials(string username, string password, List<User> users)
        {
            return users.Any(user => user.Username == username && user.Password == password); // Check if any user matches
        }

        /// <summary>
        /// Asynchronously saves the list of users to the data file.
        /// </summary>
        /// <param name="users">The list of users to save.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SaveUsersAsync(List<User> users)
        {
            // Serialize the list of users to JSON
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to the file
            using (StreamWriter writer = new StreamWriter(_usersFilePath))
            {
                await writer.WriteAsync(json);
            }
        }

        /// <summary>
        /// Asynchronously registers a new user by adding their credentials to the users list.
        /// </summary>
        /// <param name="username">The username of the user to register.</param>
        /// <param name="password">The password of the user to register.</param>
        /// <returns>True if registration is successful, false if the username already exists.</returns>
        public async Task<bool> RegisterUserAsync(string username, string password)
        {
            var users = await LoadUsersAsync(); // Load existing users

            // Check if the username already exists
            if (users.Exists(u => u.Username == username))
            {
                return false; // Username already exists, return false
            }

            // Add the new user to the list and save the list back to the file
            users.Add(new User { Username = username, Password = password });
            await SaveUsersAsync(users);
            return true; // Return true to indicate successful registration
        }

        #endregion
    }
}
