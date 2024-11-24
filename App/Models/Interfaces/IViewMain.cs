//-----------------------------------------------------------------​
//    <copyright file="LoginRegisterSystem.cs" company="IPCA">​
//     Copyright IPCA-EST. All rights reserved.​
//    </copyright>​
//    <date>24-11-2024</date>​
//    <time>21:00</time>​
//    <version>0.1</version>​
//    <author>Ernesto Casanova</author>​
//-----------------------------------------------------------------

namespace LoginRegisterSystem.Views.Interfaces
{
    /// <summary>
    /// Interface representing the main view in the MVC architecture.
    /// </summary>
    public interface IViewMain
    {
        #region Properties
        /// <summary>
        /// Gets the username displayed in the main view.
        /// </summary>
        string Username { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Updates the welcome message shown to the user.
        /// </summary>
        /// <param name="message">The welcome message to display.</param>
        void UpdateWelcomeMessage(string message);

        /// <summary>
        /// Navigates the user back to the login form.
        /// </summary>
        void NavigateToLogin();
        #endregion
    }
}
