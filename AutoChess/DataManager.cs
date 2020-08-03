using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChess
{
    class DataManager
    {
        private string dir;
        public DataManager()
        {
            dir = Environment.CurrentDirectory;
        }
        public string[] readHeroesList()
        {
            string[] heroesList = System.IO.File.ReadAllLines(dir + "\\heroes.txt");
            return heroesList;
        }
    }
}
