using System;
using System.Collections.Generic;
using System.IO;

namespace UserDefaults
{
    class FileManager
    {
        private string path;

        public FileManager(string name)
        {
            path = $"{name}UserDefault.txt";
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");
            }
        }
        public void Store(string key, object value)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("User default is not exist!");
            }

            if(value is string)
            {
                append(key, (string)value);
            }
            else if(value is int || value is short || value is long)
            {
                append(key, value.ToString());
            }
            else if(value is bool)
            {
                if((bool)value == true)
                {
                    append(key, "1");
                }
                else
                {
                    append(key, "0");
                }
            }
            else
            {
                throw new Exception("Unsupported type!");
            }
        }

        public void Remove(string key)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("User default is not exist!");
            }

            var (val, index) = find(key);
            if (val != null)
            {
                var file = File.ReadAllLines(path);
                List<string> list = new List<string>(file);
                list.RemoveAt(index);
                File.WriteAllLines(path, list);
            }
        }

        public object GetObject(string key)
        {
            var (val, _) = find(key);
            return val;
        }

        private (object, int) find(string key)
        {
            // _|_key_|_[:=>]_|_val_|_
            var file = File.ReadAllLines(path);
            int i = 0;
            foreach(var line in file)
            {
                var splited = line.Split("[:=>]");
                var _key = splited[0].Replace("_|_", "");
                var _value = splited[1].Replace("_|_", "");

                if(_key == key)
                {
                    return (_value, i);
                }
                i++;
            }

            return (null, -1);
        }

        private void append(string key, string value)
        {
            // _|_key_|_[:=>]_|_val_|_
            var (val, index) = find(key);
            if(val != null)
            {
                var file = File.ReadAllLines(path);
                file[index] = $"_|_{key}_|_[:=>]_|_{value}_|_";
                File.WriteAllLines(path, file);
            }
            else
            {
                var line = new string[] { $"_|_{key}_|_[:=>]_|_{value}_|_" };
                File.AppendAllLines(path, line);
            }
        }
    }
}
