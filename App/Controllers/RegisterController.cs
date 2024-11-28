//-----------------------------------------------------------------​
//    <copyright file="LoginRegisterSystem.cs" company="IPCA">​
//     Copyright IPCA-EST. All rights reserved.​
//    </copyright>​
//    <date>24-11-2024</date>​
//    <time>21:00</time>​
//    <version>0.1</version>​
//    <author>Ernesto Casanova</author>​
//-----------------------------------------------------------------

using LoginRegisterSystem.Models.Facades;
using LoginRegisterSystem.Views.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginRegisterSystem.Controller
{
    /// <summary>
    /// Controller responsible for handling the registration logic.
    /// </summary>
    public class RegisterController
    {
        #region Fields and Properties

        private readonly IViewRegister _view;  // Interface for the Register View
        private readonly RegisterFacade _registerFacade;  // Facade Class responsible for user operations

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialize the RegisterController with the specified view.
        /// </summary>
        /// <param name="view">The view that the controller will interact with.</param>
        public RegisterController(IViewRegister view)
        {
            _view = view;  // Assign the view
            _registerFacade = new RegisterFacade();  // Initialize the RegisterFacade
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the user registration process asynchronously.
        /// </summary>
        public async Task HandleRegistrationAsync()
        {
            // Check if any required fields are empty
            if (string.IsNullOrWhiteSpace(_view.Username) ||
                string.IsNullOrWhiteSpace(_view.Password) ||
                string.IsNullOrWhiteSpace(_view.ConfirmPassword))
            {
                _view.DisplayMessage("Username and Password fields cannot be empty.", "Sign Up Failed", MessageBoxIcon.Error);
                return;
            }

            // Check if passwords match
            if (_view.Password != _view.ConfirmPassword)
            {
                _view.DisplayMessage("Passwords do not match. Please re-enter.", "Sign Up Failed", MessageBoxIcon.Error);
                _view.ClearInputs();  // Clear the inputs to prompt user for new data
                return;
            }

            try
            {
                // Attempt to register the user
                bool registrationSuccess = await _registerFacade.RegisterUserAsync(_view.Username, _view.Password);

                if (registrationSuccess)
                {
                    _view.ClearInputs();  // Clear inputs after successful registration
                    _view.DisplayMessage("Your account has been successfully created.", "Registration Success", MessageBoxIcon.Information);
                }
                else
                {
                    // If username already exists, show error
                    _view.DisplayMessage("Username already exists.", "Sign Up Failed", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the registration process
                _view.DisplayMessage($"An error occurred: {ex.Message}", "Error", MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
