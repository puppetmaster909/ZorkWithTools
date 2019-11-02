using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;
using Zork.Common;


namespace Zork.Builder
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore]
        public string FileName { get; set; }
        public string WelcomeMessage;
        public string WorldName;
        public Common.Game Game
        {
            get => mGame;
            set
            {
                if (mGame != value)
                {
                    mGame = value;
                    if (mGame != null && mGame.World != null && mGame.World.Rooms != null)
                    {
                        Rooms = new BindingList<Room>(mGame.World.Rooms);
                    }
                    else
                    {
                        Rooms = new BindingList<Room>(Array.Empty<Room>());
                    }
                }
            }
        }

        public GameViewModel()
        {
            Game = new Game();
            Rooms = new BindingList<Room>(Array.Empty<Room>());
        }

        public GameViewModel(Game game = null)
        {
            Game = game;
        }

        public BindingList<Common.Room> Rooms { get; set; }

        public BindingList<Common.Room> Neighbors { get; set; }

        private Game mGame;
    }
}
