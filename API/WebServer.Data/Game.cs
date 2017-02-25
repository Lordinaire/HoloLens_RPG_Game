using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebServer.Data.Helpers;

namespace WebServer.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Map> Maps { get; set; }

        public void CopyFrom(Game updatedGame, string[] excludedProperties = null)
        {
            DataHelper.SetProperties(updatedGame, this, typeof(Game).GetProperties().Select(p => p.Name).Except(excludedProperties).ToList());
        }
    }
}
