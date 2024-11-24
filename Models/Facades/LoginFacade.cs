using LoginRegisterSystem.Models.Services;
using System.Threading.Tasks;

namespace LoginRegisterSystem.Models.Facades
{
    /// <summary>
    /// Facade class that provides a simplified interface for user authentication.
    /// </summary>
    public class LoginFacade
    {
        #region Private Fields
        private readonly UserService _userService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the LoginFacade with necessary services.
        /// </summary>
        public LoginFacade()
        {
            _userService = new UserService(); // Initialize the UserService dependency
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Authenticates the user asynchronously based on provided username and password.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password of the user attempting to log in.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is a boolean indicating whether the authentication was successful.</returns>
        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            // Load the list of users asynchronously
            var users = await _userService.LoadUsersAsync();

            // Validate the credentials using the UserService
            return _userService.ValidateCredentials(username, password, users);
        }
        #endregion
    }
}
