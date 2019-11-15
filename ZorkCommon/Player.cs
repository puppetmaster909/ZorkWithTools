using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Zork.Common
{
    public class Player : INotifyPropertyChanged
    {
        private int mScore;
        private int moves;
        private Room location;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<int> ScoreChanged;
        public event EventHandler<int> MovesChanged;
        public event EventHandler<string> LocationChanged;

        public World World { get; }

        public int Score
        {
            get => mScore;
            set
            {
                mScore = value;
                ScoreChanged?.Invoke(this, Score);
            }
        }

        public int Moves
        {
            get => moves;
            set
            {
                moves = value;
                MovesChanged?.Invoke(this, Moves);
            }
        }

        [JsonIgnore]
        public Room Location
        {
            get => location; 
            private set
            {
                location = value;
                LocationChanged?.Invoke(this, Location.Name);
            }
        }

        [JsonIgnore]
        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }
        }

        public Player(World world, string startingLocation)
        {
            World = world;
            LocationName = startingLocation;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbors.TryGetValue(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
        }
    }

    public enum Directions
    {
        North,
        South,
        East,
        West
    }
}
