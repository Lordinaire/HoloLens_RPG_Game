using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class Map
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public List<Case> Cases { get; set; }
    }
}
