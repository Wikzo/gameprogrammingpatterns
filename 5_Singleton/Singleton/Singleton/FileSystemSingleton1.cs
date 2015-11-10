using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class FileSystemSingleton1
    {
        private static FileSystemSingleton1 _instance;

        public static FileSystemSingleton1 Instance()
        {
            // Lazy initialization (can be dangerous, because we don't know when it will be called!)
            if (_instance == null)
                _instance = new FileSystemSingleton1();

            return _instance;
        }

        // fields
        public int File1;
        public string Name;
    }
}
