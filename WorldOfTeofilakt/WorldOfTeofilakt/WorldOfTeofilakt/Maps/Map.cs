using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WorldOfTeofilakt.Items;
using WorldOfTeofilakt.CharacterClasses;

namespace WorldOfTeofilakt.Maps
{
    public class Map
    {

        public Map(string name, IList<HomeWork> homeWorks)
        {
            this.Name = name;
            this.HomeWorks = homeWorks;
        }
        
        public string Name { get; private set; }
        public IList<HomeWork> HomeWorks { get; private set; }

        
    }
}
