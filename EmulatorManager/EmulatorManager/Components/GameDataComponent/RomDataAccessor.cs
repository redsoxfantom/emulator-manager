﻿using EmulatorManager.Utilities.RestUtilities;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace EmulatorManager.Components.GameDataComponent
{
    public class RomDataAccessor
    {
        string mUrl;

        private ILog mLogger;

        public RomDataAccessor(string dataUrl)
        {
            mUrl = dataUrl;
            mLogger = LogManager.GetLogger(GetType().Name);

            mLogger.Debug(String.Format("Data Accessor created with url {0}", mUrl));
        }

        public async Task<GameData> RetrieveGameData(string romType, string romId)
        {
            string dataId = romId + romType;
            dataId = Cleanup(dataId);
            string finalUrl = String.Format("{0}/gamedata/GetGameDataByNameSystem/{1}",mUrl,dataId);
            mLogger.Info(String.Format("Attempting to request game data from {0}", finalUrl));
            GameData data = new GameData();

            try
            {
                dynamic serverGameData = await RestServerManager.Get(finalUrl);

                string gameName = serverGameData.userData.Name;
                string gamePublisher = serverGameData.userData.Publisher;
                string gameSystem = serverGameData.userData.System;
                int id = serverGameData.userData.id;
                //byte[] gameImageArry = Convert.FromBase64String(serverGameData.userData.Image);
                //Image gameImage = Bitmap.FromStream(new MemoryStream(gameImageArry));
                data = new GameData(gameName, gamePublisher, gameSystem, null,id,true);
            }
            catch(ResponseStatusCodeException ex)
            {
                mLogger.Error("Server returned failing status code", ex);
            }
            catch(Exception ex)
            {
                mLogger.Error("Game Data request failed", ex);
            }

            return data;
        }

        public async void UpdateOrAddGameData(string romId, GameData data)
        {
            String base64Image = null;
            using (MemoryStream mem = new MemoryStream())
            {
                data.GameImage.Save(mem, data.GameImage.RawFormat);
                byte[] imgBytes = mem.ToArray();
                base64Image = Convert.ToBase64String(imgBytes);
            }

            string dataId = romId + data.GameSystem;
            dataId = Cleanup(dataId);

            string url = String.Format("{0}/gamedata", mUrl);
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("NameSystem",dataId);
            header.Add("Name", data.GameName);
            header.Add("Publisher", data.GamePublisher);
            header.Add("System", data.GameSystem);
            header.Add("Image", base64Image);

            if (data.ExistsOnServer)
            {
                string finalUrl = String.Format("{0}/{1}", url, data.Id);
                try
                {
                    mLogger.Info(String.Format("Attempting to update game data object at {0}", finalUrl));
                    RestServerManager.Put(finalUrl, header);
                }
                catch (Exception ex)
                {
                    mLogger.Error("Error updating game data", ex);
                }
            }
            else
            {
                try
                {
                    mLogger.Info(String.Format("Attempting to create new game data object at {0}", url));
                    RestServerManager.Post(url, header);
                }
                catch (Exception ex)
                {
                    mLogger.Error("Error creating game data", ex);
                }
            }
        }

        private string Cleanup(String str)
        {
            IdnMapping mapping = new IdnMapping();
            str = mapping.GetAscii(str);

            //  Remove all invalid characters.  
            str = Regex.Replace(str, @"[^A-Za-z0-9\s-]", "");

            //  Convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();

            //  Replace spaces by underscores.
            str = Regex.Replace(str, @"\s", "_");

            return str;
        }
    }
}
