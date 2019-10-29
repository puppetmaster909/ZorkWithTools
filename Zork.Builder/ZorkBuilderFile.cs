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

        public Common.Game Game { get; set; }

        public ZorkBuilderFile()
        {
            FileName = "Zork.json";
        }
    }
}
