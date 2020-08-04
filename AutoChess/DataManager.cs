using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace AutoChess
{
    class DataManager
    {
        public Dictionary<int, object[]> HeroDatabase { get; private set; }
        public DataManager()
        {
            HeroDatabase = new Dictionary<int, object[]>();
        }
        private static UnmanagedMemoryStream GetResourceStream(string resName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var strResources = assembly.GetName().Name + ".g.resources";
            var rStream = assembly.GetManifestResourceStream(strResources);
            var resourceReader = new ResourceReader(rStream);
            var items = resourceReader.OfType<DictionaryEntry>();
            var stream = items.First(x => (x.Key as string) == resName.ToLower()).Value;
            return (UnmanagedMemoryStream)stream;
        }
        public void readHeroesList()
        {
            // first pull all the heroes from file
            string resName = "heroes.txt";
            var file = GetResourceStream(resName);
            List<string> heroes = new List<string>();
            var reader = new StreamReader(file);
            {
                string line = "";
                while(line != null)
                {
                    line = reader.ReadLine();
                    if (line == null)
                        break;
                    heroes.Add(line);
                };
            }
            // next we take each string and parse through it to extract hero information
            int j = 0, i;
            foreach (string hero in heroes)
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
    }
}
