﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Zork.Common
{
    [JsonConverter(typeof(RoomConverter))]
    public class Room : IEquatable<Room>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Room()
        {

        }

        public Room(string name, string description, Dictionary<Directions, string> neighborNames)
        {
            Name = name;
            Description = description;
            NeighborNames = neighborNames;
        }

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Neighbors", Order = 3)]
        public Dictionary<Directions, string> NeighborNames { get; set; }

        [JsonIgnore]
        public IReadOnlyDictionary<Directions, Room> Neighbors { get; private set; }

        public static bool operator ==(Room lhs, Room rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (lhs is null || rhs is null)
            {
                return false;
            }

            return lhs.Name == rhs.Name;
        }

        public static bool operator !=(Room lhs, Room rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => obj is Room room ? this == room : false;

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();
       
        public void UpdateNeighbors(World world) => Neighbors = (from entry in NeighborNames
                                                                 let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                                                                 where room != null
                                                                 select (Direction: entry.Key, Room: room))
                                                                 .ToDictionary(pair => pair.Direction, pair => pair.Room);

        public void BuildNeighborsFromNames(World world)
        {
            Neighbors = (from entry in NeighborNames
                         let room = world.RoomsByName.GetValueOrDefault(entry.Value)
                         where room != null
                         select (Direction: entry.Key, Room: room))
                         .ToDictionary(pair => pair.Direction, pair => pair.Room);

            NeighborNames.Clear();
        }

        public bool Equals(Room other)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Directions neighborDirections, out Room neighborRoom)
        {
            throw new NotImplementedException();
        }
    }
}
