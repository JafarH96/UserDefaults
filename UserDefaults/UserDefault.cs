using System;

namespace UserDefaults
{
    public class UserDefault
    {
        private FileManager fileManager;
        public static UserDefault standard = new UserDefault("standard");

        public UserDefault(string name)
        {
            fileManager = new FileManager(name);
        }

        public void Store(string key, object value)
        {
            if (key.Contains("[:=>]") || key.Contains("_|_"))
            {
                throw new Exception("Invalid Characters!");
            }
            fileManager.Store(key, value);
        }

        public void Remove(string key)
        {
            if (key.Contains("[:=>]") || key.Contains("_|_"))
            {
                throw new Exception("Invalid Characters!");
            }
            fileManager.Remove(key);
        }

        public object GetObject(string key)
        {
            return fileManager.GetObject(key);
        }

        public string GetString(string key)
        {
            var val = fileManager.GetObject(key);
            if (val != null)
            {
                return (string)val;
            }

            return null;
        }

        public int GetInteger(string key)
        {
            var val = fileManager.GetObject(key);
            if (val != null)
            {
                return Convert.ToInt32((string)val);
            }

            return 0;
        }

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
