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
        private Dictionary<int, object[]> HeroDatabase = new Dictionary<int, object[]>();
        public DataManager()
        {
            dir = Environment.CurrentDirectory;
        }
        public void readHeroesList()
        {
            // first pull all the heroes from file
            string[] heroesRAWList = System.IO.File.ReadAllLines(dir + "\\heroes.sav");

            // next we take each string and parse through it to extract hero information
            int j = 0, i;
            foreach (string hero in heroesRAWList)
            {
                i = 0;
                // split stats into new array and create a placeholder
                // for the hero object
                object[] splitString = hero.Split(','), tempHero;
                tempHero = new object[splitString.Length];
                // loop through each stat and check if it's an int, 
                // if so set it as an int and add it to the new array
                // else add it as a string
                foreach (string stat in splitString)
                {
                    if (double.TryParse(stat.Trim(), out double t))
                    {
                        tempHero[i] = t;
                    }
                    else
                    {
                        tempHero[i] = stat;
                    }
                    i++;
                }
                HeroDatabase.Add(j, tempHero);
                j++;
            }
        }
        public Dictionary<int, object[]> getHeroDataBase()
        {
            return HeroDatabase;
        }
    }
}
