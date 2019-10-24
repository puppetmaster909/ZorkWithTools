﻿using System;
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

        // List of objects to hold room data
        public List<Room> Rooms { get; set; }

        // Default constructor
        public ZorkBuilderFile()
        {
            Rooms = new List<Room>();
        }
    }
}
