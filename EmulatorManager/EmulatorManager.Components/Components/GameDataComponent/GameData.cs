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
        public string GameName { get; set; }

        public string GamePublisher { get; set; }

        public string GameSystem { get; set; }

        public Image GameImage { get; set; }

        public int Id { get; private set; }

        public Boolean ExistsOnServer { get; private set; }

        public GameData(
            string gameName = "<No Game Name>", 
            string gamePublisher = "<No Game Publisher>", 
            string gameSystem = "<No Game System>", 
            Image gameImage = null,
            int id = -1,
            Boolean existsOnServer = false)
        {
            GameName = gameName;
            GamePublisher = gamePublisher;
            GameSystem = gameSystem;
            Id = id;
            ExistsOnServer = existsOnServer;

            if(gameImage == null)
            {
                gameImage = Resource.No_Image_Found;
            }
            GameImage = gameImage;
        }

        public override String ToString()
        {
            return String.Format("{0}: Name: {1}, Publisher: {2}, System: {3}",Id,GameName,GamePublisher,GameSystem);
        }
    }
}
