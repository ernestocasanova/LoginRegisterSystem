using System;
using System.IO;

namespace LoginRegisterSystem.Models.Data
{
    /// <summary>
    /// Singleton class responsible for managing file paths related to the application's data files.
    /// </summary>
    public sealed class FilePathManager
    {
        #region Singleton Implementation

        // Lazy initialization of the Singleton instance
        private static readonly Lazy<FilePathManager> _instance =
            new Lazy<FilePathManager>(() => new FilePathManager());

        /// <summary>
        /// Gets the singleton instance of the FilePathManager.
        /// </summary>
        public static FilePathManager Instance => _instance.Value;

        #endregion

        #region Public Properties

        /// <summary>
        /// The base path where the application data files will be stored.
        /// </summary>
        public static readonly string BasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData");

        // File names for user data and dashboard data
        public string UsersFileName { get; private set; }
        public string DataFileName { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the full file path for a given file name by combining it with the base path.
        /// </summary>
        /// <param name="fileName">The name of the file to get the full path for.</param>
        /// <returns>The full file path for the given file name.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided file name is null or empty.</exception>
        public string GetFullPath(string fileName)
        {
            // Validate the file name
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty", nameof(fileName));
            }

            // Return the full path by combining the base path and file name
            return Path.Combine(BasePath, fileName);
        }

        #endregion

        #region Public Properties (File Paths)

        /// <summary>
        /// Gets the full path for the users data file.
        /// </summary>
        public string UsersFilePath => GetFullPath(UsersFileName);

        /// <summary>
        /// Gets the full path for the dashboard data file.
        /// </summary>
        public string DataFilePath => GetFullPath(DataFileName);

        #endregion

        #region Private Constructor

        /// <summary>
        /// Private constructor to initialize file paths and ensure the necessary directories exist.
        /// </summary>
        private FilePathManager()
        {
            try
            {
                // Ensure the directory exists or create it
                if (!Directory.Exists(BasePath))
                {
                    Directory.CreateDirectory(BasePath);
                }

                // Set default file names
                UsersFileName = "users.json";
                DataFileName = "dashboard.json";
            }
            catch (Exception ex)
            {
                // Throw an exception if there is an error during initialization
                throw new InvalidOperationException("Error initializing FilePathManager", ex);
            }
        }

        #endregion
    }
}
