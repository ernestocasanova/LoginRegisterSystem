using LoginRegisterSystem.Controller;
using LoginRegisterSystem.Views.Interfaces;
using System;
using System.Windows.Forms;

namespace LoginRegisterSystem
{
    public partial class frmRegister : Form, IViewRegister
    {
        #region Constructor
        /// <summary>
        /// Initializes the registration form.
        /// </summary>
        public frmRegister()
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

        /// <summary>
        /// Gets the entered confirmation password from the input field.
        /// </summary>
        public string ConfirmPassword => txtComPassword.Text;
        #endregion

        #region Public Methods (IViewRegister Implementation)
        /// <summary>
        /// Displays a message box with the specified message, caption, and icon.
        /// </summary>
        public void DisplayMessage(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Clears the username, password, and confirm password input fields and sets focus to the username field.
        /// </summary>
        public void ClearInputs()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtComPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        /// <summary>
        /// Navigates to the login form.
        /// </summary>
        public void NavigateToLogin()
        {
            new LoginForm().Show();
            this.Hide();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the "Register" button click event to process user registration asynchronously.
        /// </summary>
        private async void registrationButton_Click(object sender, EventArgs e)
        {
            RegisterController controller = new RegisterController(this);
            await controller.HandleRegistrationAsync();
        }

        /// <summary>
        /// Handles the "Clear" button click event to reset the input fields.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        /// <summary>
        /// Handles the "Show Password" checkbox state change to toggle password and confirm password visibility.
        /// </summary>
        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkboxShowPass.Checked ? '\0' : '*';
            txtComPassword.PasswordChar = checkboxShowPass.Checked ? '\0' : '*';
        }

        /// <summary>
        /// Handles the "Go to Login" label click event to navigate to the login form.
        /// </summary>
        private void label6_Click_1(object sender, EventArgs e)
        {
            NavigateToLogin();
        }
        #endregion
    }
}
