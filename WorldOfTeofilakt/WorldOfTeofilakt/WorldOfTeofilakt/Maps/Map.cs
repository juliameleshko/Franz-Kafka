namespace WorldOfTeofilakt.Maps
{
    using System.Collections.Generic;
    using WorldOfTeofilakt.CharacterClasses;

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
