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
using LoginRegisterSystem.Models.Services;
using LoginRegisterSystem.Views.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegisterSystem.Controller
{
    /// <summary>
    /// Controller responsible for handling the login logic.
    /// </summary>
    public class LoginController
    {
        #region Fields and Properties

        private readonly IViewLogin _view;   // Interface for the Login View
        private readonly UserService _userService;  // Service to handle user-related operations

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialize the LoginController with the specified view.
        /// </summary>
        /// <param name="view">The view that the controller will interact with.</param>
        public LoginController(IViewLogin view)
        {
            _view = view;  // Assign the view
            _userService = new UserService();  // Initialize the UserService
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the login process asynchronously.
        /// </summary>
        public async Task HandleLoginAsync()
        {
            // Load the list of users from the file
            List<User> users = await _userService.LoadUsersAsync();

            // Check if there are no users in the system
            if (users.Count == 0)
            {
                _view.DisplayMessage("No user data file found. Please register first.", "Login Failed", MessageBoxIcon.Error);
                return;
            }

            // Validate the credentials entered by the user
            bool loginSuccess = _userService.ValidateCredentials(_view.Username, _view.Password, users);

            // If login is successful, navigate to the main form
            if (loginSuccess)
            {
                _view.NavigateToMainForm(_view.Username);
            }
            else
            {
                // If login failed, show an error message and clear inputs
                _view.DisplayMessage("Invalid Credentials, please try again.", "Login Failed", MessageBoxIcon.Error);
                _view.ClearInputs();
            }
        }

        #endregion
    }
}