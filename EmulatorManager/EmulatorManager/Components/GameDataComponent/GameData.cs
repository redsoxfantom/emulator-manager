﻿using EmulatorManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public class GameData
    {
        public string GameName { get; private set; }

        public string GamePublisher { get; private set; }

        public string GameSystem { get; private set; }

        public Image GameImage { get; private set; }

        public GameData(
            string gameName = "<No Game Name>", 
            string gamePublisher = "<No Game Publisher>", 
            string gameSystem = "<No Game System>", 
            Image gameImage = null)
        {
            GameName = gameName;
            GamePublisher = gamePublisher;
            GameSystem = gameSystem;

            if(gameImage == null)
            {
                gameImage = Resources.No_Image_Found;
            }
            GameImage = gameImage;
        }
    }
}
