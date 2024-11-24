//-----------------------------------------------------------------​
//    <copyright file="LoginRegisterSystem.cs" company="IPCA">​
//     Copyright IPCA-EST. All rights reserved.​
//    </copyright>​
//    <date>24-11-2024</date>​
//    <time>21:00</time>​
//    <version>0.1</version>​
//    <author>Ernesto Casanova</author>​
//-----------------------------------------------------------------

using LoginRegisterSystem.Controller;
using LoginRegisterSystem.Views.Interfaces;
using System;
using System.Windows.Forms;

namespace LoginRegisterSystem
{
    public partial class MainForm : Form, IViewMain
    {
        #region Fields
        /// <summary>
        /// Singleton instance of the MainForm.
        /// </summary>
        public static MainForm instance;

        /// <summary>
        /// Label to display the username or welcome message.
        /// </summary>
        public Label lbl;

        /// <summary>
        /// Controller responsible for handling business logic in the MainForm.
        /// </summary>
        private readonly MainController _controller;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the main form and its dependencies.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            instance = this;
            lbl = label1;

            // Instantiate the controller and pass the current view.
            _controller = new MainController(this);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the username displayed in the label.
        /// </summary>
        public string Username => lbl.Text;
        #endregion

        #region Public Methods (IViewMain Implementation)
        /// <summary>
        /// Updates the welcome message displayed on the form.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void UpdateWelcomeMessage(string message)
        {
            label1.Text = message;
        }

        /// <summary>
        /// Navigates back to the login form.
        /// </summary>
        public void NavigateToLogin()
        {
            new LoginForm().Show();
            this.Hide();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the load event of the main form and initializes the controller.
        /// </summary>
        private void Dashboard_Load(object sender, EventArgs e)
        {
            _controller.Initialize();
        }

        /// <summary>
        /// Handles the logout button click event and performs logout actions via the controller.
        /// </summary>
        private void logoutButton_Click(object sender, EventArgs e)
        {
            _controller.HandleLogout();
        }

        /// <summary>
        /// Placeholder for additional button functionality (currently unused).
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // Additional button functionality can be added here.
        }
        #endregion
    }
}
