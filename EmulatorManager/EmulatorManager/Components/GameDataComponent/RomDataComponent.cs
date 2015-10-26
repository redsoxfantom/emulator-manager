﻿using EmulatorManager.Components.GameDataComponent.RomReaders;
using EmulatorManager.Properties;
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

        private RomDataAccessor mAccessor;

        private RomDataComponent()
        {
            mReaders = new List<IRomReader>();
            mLogger = LogManager.GetLogger(GetType().Name);
            mAccessor = new RomDataAccessor(GetServerUrl());
        }

        public void Initialize()
        {
            mLogger.Info("Initializing RomDataComponent");

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

        public async Task<GameData> GetRomData(string romPath)
        {
            string romId = null;
            string romSystem = null;
            GameData data = new GameData();

            using (FileStream romFile = File.OpenRead(romPath))
            {
                foreach (var reader in mReaders)
                {
                    romId = reader.GetRomId(romFile);
                    if (romId != null)
                    {
                        romId = romId.Replace(' ', '_');
                        romSystem = reader.RomType;
                        break;
                    }
                    romFile.Position = 0;
                }

                // only query the accessor if we got a successful read on the file
                if(romId != null && romSystem != null)
                {
                    data = await mAccessor.LoadGameData(romSystem, romId);
                }
            }

            return data;
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
