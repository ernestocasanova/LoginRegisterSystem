using System.Windows.Forms;

namespace LoginRegisterSystem.Views.Interfaces
{
    /// <summary>
    /// Interface representing the login view in the MVC architecture.
    /// </summary>
    public interface IViewLogin
    {
        #region Properties
        /// <summary>
        /// Gets the username entered by the user.
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Gets the password entered by the user.
        /// </summary>
        string Password { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Displays a message to the user.
        /// </summary>
        /// <param name="message">The message content.</param>
        /// <param name="caption">The message box caption.</param>
        /// <param name="icon">The icon to display in the message box.</param>
        void DisplayMessage(string message, string caption, MessageBoxIcon icon);

        /// <summary>
        /// Clears the input fields for username and password.
        /// </summary>
        void ClearInputs();

        /// <summary>
        /// Toggles the visibility of the password field.
        /// </summary>
        /// <param name="showPassword">True to show the password, false to hide it.</param>
        void TogglePasswordVisibility(bool showPassword);

        /// <summary>
        /// Navigates to the registration form.
        /// </summary>
        void NavigateToRegister();

        /// <summary>
        /// Navigates to the main form after successful login.
        /// </summary>
        /// <param name="username">The username of the logged-in user.</param>
        void NavigateToMainForm(string username);
        #endregion
    }
}
