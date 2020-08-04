using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private Dictionary<int, object[]> HeroDataBase;
        DataManager data = new DataManager();
        public MainWindow()
        {
            InitializeComponent();
            data.readHeroesList();
            HeroDataBase = data.HeroDatabase;
            string heroList = "";
            int i;
            double k;
            double statSum = 0;
            string[] statNames = { "ID:", "Name:", "Attack:", "Defense:", "Attack Speed:", "Health:", "Range:" };
            foreach (KeyValuePair<int, object[]> hero in HeroDataBase)
            {
                i = 0;
                object[] tempHero = hero.Value;
                heroList += statNames[i] + " " + hero.Key;
                i++;
                foreach (object stat in tempHero)
                {
                    heroList += "\n" + statNames[i] + " " + stat;
                    if (double.TryParse(stat.ToString(), out k))
                        statSum += k;
                    i++;
                }
                heroList += "\n" + "sum of stats: " + statSum;
                heroList += "\n\n";
            }
            MessageBox.Show(heroList);
        }
    }
}
