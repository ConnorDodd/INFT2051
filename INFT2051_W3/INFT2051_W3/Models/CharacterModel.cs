using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT2051_W3.Models
{
    public class CharacterModel : ObservableObject
    {
        //NamePage
        //This is how getters and setters are specified in C#
        public string Name { get; set; }
        public string Class { get; set; }
        public int HPTotal { get; set; } = 1;
        public int HPCurrent { get; set; }
        public int Iniative { get; set; }
        public int Speed { get; set; }
        public int Inspiration { get; set; }
        public bool DeathSave1 { get; set; }
        public bool DeathSave2 { get; set; }
        public bool DeathSave3 { get; set; }

        //StatsPage
        public int StatStrength { get; set; }
        public int StatDexterity { get; set; }
        public int StatConstitution { get; set; }
        public int StatIntelligence { get; set; }
        public int StatWisdom { get; set; }
        public int StatCharisma { get; set; }

        //TraitsPage
        public string TraitPersonality { get; set; }
        public string TraitIdeals { get; set; }
        public string TraitBonds { get; set; }
        public string TraitFlaws { get; set; }
    }
}
