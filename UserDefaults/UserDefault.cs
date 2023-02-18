using System;

namespace UserDefaults
{
    public class UserDefault
    {
        private FileManager fileManager;
        /// <summary>
        /// The shared instance of the User Default
        /// </summary>
        public static UserDefault standard = new UserDefault("standard");

        public UserDefault(string name)
        {
            fileManager = new FileManager(name);
        }

        /// <summary>
        /// Store a new key-value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Store(string key, object value)
        {
            if (key.Contains("[:=>]") || key.Contains("_|_"))
            {
                throw new Exception("Invalid Characters!");
            }
            fileManager.Store(key, value);
        }

        /// <summary>
        /// Remove the value of a specific key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (key.Contains("[:=>]") || key.Contains("_|_"))
            {
                throw new Exception("Invalid Characters!");
            }
            fileManager.Remove(key);
        }

        /// <summary>
        /// Returns the value of a specific key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>null if the key is not exist</returns>
        public object GetObject(string key)
        {
            return fileManager.GetObject(key);
        }

        /// <summary>
        /// Returns the value as String
        /// </summary>
        /// <param name="key"></param>
        /// <returns>String value</returns>
        public string GetString(string key)
        {
            var val = fileManager.GetObject(key);
            if (val != null)
            {
                return (string)val;
            }

            return null;
        }

        /// <summary>
        /// Returns value as Integer
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Zero if the key is not exist</returns>
        public int GetInteger(string key)
        {
            var val = fileManager.GetObject(key);
            if (val != null)
            {
                return Convert.ToInt32((string)val);
            }

            return 0;
        }

        /// <summary>
        /// Returns value as Boolean
        /// </summary>
        /// <param name="key"></param>
        /// <returns>False if the key is not exist</returns>
        public bool GetBoolean(string key)
        {
            var val = fileManager.GetObject(key);
            if (val != null)
            {
                return Convert.ToInt32((string)val) != 0;
            }

            return false;
        }
    }
}
