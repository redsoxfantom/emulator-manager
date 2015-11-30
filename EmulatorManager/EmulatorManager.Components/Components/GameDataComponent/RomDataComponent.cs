using EmulatorManager.Components.GameDataComponent.RomReaders;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.GameDataComponent
{
    public class RomDataComponent
    {
        public static RomDataComponent Instance
        {
            get
            {
                if(mInstance == null)
                {
                    mInstance = new RomDataComponent();
                }
                return mInstance;
            }
        }
        private static RomDataComponent mInstance = null;

        private List<IRomReader> mReaders;

        private ILog mLogger;

        private IRomDataAccessor mAccessor;

        private RomDataComponent()
        {
            mReaders = new List<IRomReader>();
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public void Initialize(String dataLocation = null)
        {
            mLogger.Info("Initializing RomDataComponent");

            if(dataLocation != null)
            {
                createRomDataAccessor(dataLocation);
            }
            else
            {
                createRomDataAccessor(GetServerUrl());
            }

            // Get list of all types in assembly that implement IRomReader
            Type romReaderType = typeof(IRomReader);
            var implementingTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => romReaderType.IsAssignableFrom(t) && !t.IsInterface);

            foreach(Type t in implementingTypes)
            {
                mLogger.Debug(String.Format("Initializing Rom Reader {0}",t.Name));
                IRomReader reader = (IRomReader)Activator.CreateInstance(t);
                mReaders.Add(reader);
            }

            mLogger.Info("Done Initializing RomDataComponent");
        }

        private void createRomDataAccessor(string dataLocation)
        {
            Uri result;
            bool isValidHttpUrl = Uri.TryCreate(dataLocation, UriKind.Absolute, out result) &&
                                    result.Scheme == Uri.UriSchemeHttp;

            if (isValidHttpUrl)
            {
                mAccessor = new ServerRomDataAccessor(dataLocation);
            }
            else
            {
                mAccessor = new LocalRomDataAccessor(dataLocation);
            }
        }

        public void ClearDataCache()
        {
            mAccessor.ClearCache();
        }

        public bool TryLoadRomData(string romPath, out string romId, out string romSystem)
        {
            romId = null;
            romSystem = null;

            using (FileStream romFile = File.OpenRead(romPath))
            {
                mLogger.Info(String.Format("Attempting to read rom {0}", romFile.Name));

                foreach (var reader in mReaders)
                {
                    if (reader.TryReadRom(romFile, out romId, out romSystem))
                    {
                        mLogger.Info(String.Format("Successfully read data from rom file using {0} reader: romId={1}, romSystem={2}", reader.GetType().Name, romId, romSystem));
                        break;
                    }
                    romFile.Position = 0;
                }
            }

            if (romId != null && romSystem != null)
            {
                return true;
            }
            else
            {
                mLogger.Warn("Could not read rom data using any known reader");
                return false;
            }
        }

        public async Task<GameData> RetrieveGameData(string romId, string romSystem)
        {
            GameData data = await mAccessor.RetrieveGameData(romSystem, romId);
            return data;
        }

        public void UpdateGamePlayTime(string romId, GameData data)
        {
            mLogger.DebugFormat("Attempting to update rom {0} game play time to {1}",romId,data.TimePlayed.TotalSeconds);
            mAccessor.UpdateGamePlayedTime(romId, data);
        }

        public async Task UpdateOrAddGameData(string romId, GameData data)
        {
            mLogger.Debug(String.Format("UpdateOrAddGameData called with rom id {0} and data {1}", romId, data));
            await mAccessor.UpdateOrAddGameData(romId, data);
        }

        private string GetServerUrl()
        {
            String strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String strFilePath = Path.Combine(strAppPath, "Resources");
            String strFullFilename = Path.Combine(strFilePath, "RomDataServerInfo.json");
            String fileData = File.ReadAllText(strFullFilename);

            dynamic serverInfo = JsonConvert.DeserializeObject(fileData);
            return serverInfo.Url;
        }
    }
}
