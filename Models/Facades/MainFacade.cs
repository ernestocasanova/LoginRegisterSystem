using LoginRegisterSystem.Models.Services;

namespace LoginRegisterSystem.Models.Facades
{
    /// <summary>
    /// Facade class for handling main operations like user greetings and logout.
    /// </summary>
    public class MainFacade
    {
        #region Private Fields
        private readonly UserService _userService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the MainFacade with necessary services.
        /// </summary>
        public MainFacade()
        {
            _userService = new UserService(); // Initialize the UserService dependency
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Generates a welcome message for the user.
        /// </summary>
        /// <param name="username">The username of the user to be greeted.</param>
        /// <returns>A welcome message string for the given username.</returns>
        public string GetWelcomeMessage(string username)
        {
            return $"Welcome, {username}!"; // Return a welcome message for the user
        }

        /// <summary>
        /// Logs out the user and performs any necessary tasks related to logout.
        /// </summary>
        public void Logout()
        {
            // Perform logout-related tasks here, such as clearing user data, session, etc.
        }
        #endregion
    }
}
