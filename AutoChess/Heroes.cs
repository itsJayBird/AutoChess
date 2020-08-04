using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChess
{
    class Heroes : BattleLogic, Allegience
    {
        private Dictionary<int, object[]> HeroDatabase = new Dictionary<int, object[]>();
        public string name { get; private set; }
        public double attack { get; private set; }
        public double defense { get; private set; }
        public double attackSpeed { get; private set; }
        public double health { get; private set; }
        public double range { get; private set; }
        public int starLevel { get; set; }
        public Heroes(Dictionary<int, object[]> db, int ID)
        {
            this.HeroDatabase = db;
            createHero(ID);
        }
        private void createHero(int ID)
        {
            HeroDatabase.TryGetValue(ID, out object[] value);
            this.name = (string)value[0];
            this.attack = (double)value[1];
            this.defense = (double)value[2];
            this.attackSpeed = (double)value[3];
            this.health = (double)value[4];
            this.range = (double)value[5];
            this.starLevel = 1;
        }
        public void CheckAllegienceBonus()
        {
            
        }

    }
}
