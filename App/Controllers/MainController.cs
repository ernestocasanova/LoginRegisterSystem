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

namespace LoginRegisterSystem.Controller
{
    /// <summary>
    /// Controller responsible for handling the main form logic.
    /// </summary>
    public class MainController
    {
        #region Fields and Properties

        private readonly IViewMain _view;  // Interface for the Main View
        private readonly MainFacade _facade;  // Facade to handle business logic for the main form

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialize the MainController with the specified view.
        /// </summary>
        /// <param name="view">The view that the controller will interact with.</param>
        public MainController(IViewMain view)
        {
            _view = view;  // Assign the view
            _facade = new MainFacade();  // Initialize the MainFacade
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the main form by setting the welcome message.
        /// </summary>
        public void Initialize()
        {
            // Get the username from the view
            string username = _view.Username;

            // Get the welcome message from the facade
            string welcomeMessage = _facade.GetWelcomeMessage(username);

            // Update the view with the welcome message
            _view.UpdateWelcomeMessage(welcomeMessage);
        }

        /// <summary>
        /// Handles the logout process.
        /// </summary>
        public void HandleLogout()
        {
            // Perform logout operations using the facade
            _facade.Logout();

            // Navigate back to the login view
            _view.NavigateToLogin();
        }

        #endregion
    }
}
