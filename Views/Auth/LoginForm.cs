using LoginRegisterSystem.Controller;
using LoginRegisterSystem.Views.Interfaces;
using System;
using System.Windows.Forms;

namespace LoginRegisterSystem
{
    public partial class LoginForm : Form, IViewLogin
    {
        #region Constructor
        /// <summary>
        /// Initializes the login form.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the entered username from the input field.
        /// </summary>
        public string Username => txtUsername.Text;

        /// <summary>
        /// Gets the entered password from the input field.
        /// </summary>
        public string Password => txtPassword.Text;
        #endregion

        #region Public Methods (IViewLogin Implementation)
        /// <summary>
        /// Displays a message box with the specified message, caption, and icon.
        /// </summary>
        public void DisplayMessage(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Clears the username and password input fields and sets focus to the username field.
        /// </summary>
        public void ClearInputs()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        /// <summary>
        /// Toggles the visibility of the password field.
        /// </summary>
        public void TogglePasswordVisibility(bool showPassword)
        {
            txtPassword.PasswordChar = showPassword ? '\0' : '*';
        }

        /// <summary>
        /// Navigates to the registration form.
        /// </summary>
        public void NavigateToRegister()
        {
            new frmRegister().Show();
            Hide();
        }

        /// <summary>
        /// Navigates to the main form and updates the username label.
        /// </summary>
        public void NavigateToMainForm(string username)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            MainForm.instance.lbl.Text = username;
            Hide();
        }

        /// <summary>
        /// Handles the login process asynchronously.
        /// </summary>
        public async void HandleLoginAsync() {
            LoginController controller = new LoginController(this);
            await controller.HandleLoginAsync();
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the "Show Password" checkbox state change to toggle password visibility.
        /// </summary>
        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            TogglePasswordVisibility(checkboxShowPass.Checked);
        }

        /// <summary>
        /// Handles the click event for the "Go to Register" label to navigate to the registration form.
        /// </summary>
        private void label6_Click(object sender, EventArgs e)
        {
            NavigateToRegister();
        }

        /// <summary>
        /// Handles the click event for the "Clear" button to clear input fields.
        /// </summary>
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        /// <summary>
        /// Handles the click event for the "Login" button to process user login asynchronously.
        /// </summary>
        private void loginButton_Click(object sender, EventArgs e)
        {
            HandleLoginAsync();
        }

        /// <summary>
        /// Handles the key down event for the password input field to trigger the login process on Enter key press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleLoginAsync(); 
            }
        }
        #endregion
    }
}
