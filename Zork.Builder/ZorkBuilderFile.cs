using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Zork.Builder
{
    public class ZorkBuilderFile
    {
        [JsonIgnore]
        public string FileName { get; set; }

        public List<String> Rooms { get; set; }

        public List<String> Neighbors { get; set; }

        public ZorkBuilderFile()
        {
            Rooms = new List<String>();
            Neighbors = new List<String>();
        }
    }
}
