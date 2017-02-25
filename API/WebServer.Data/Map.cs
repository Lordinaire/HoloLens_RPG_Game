using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebServer.Data.Helpers;

namespace WebServer.Data
{
    public class Map
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        private string _jsonItems;

        [JsonIgnore]
        public string JsonItems
        {
            get
            {
                return _jsonItems;
            }
            set
            {
                _jsonItems = value;
            }
        }

        public virtual MapItem[] Items //{ get; set; }
        {
            get
            {
                return _jsonItems == null ? new List<MapItem>().ToArray() : JsonConvert.DeserializeObject<MapItem[]>(JsonItems);
            }
            set
            {
                _jsonItems = JsonConvert.SerializeObject(value);
            }
        }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public void CopyFrom(Map updatedMap, string[] excludedProperties = null)
        {
            var properties = typeof (Map).GetProperties().Select(p => p.Name);
            if (excludedProperties != null)
                properties = properties.Except(excludedProperties);
            DataHelper.SetProperties(updatedMap, this, properties.ToList());
        }
    }
}