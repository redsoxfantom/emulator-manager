﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorManager.Utilities
{
    public class FileManager
    {
        public static T LoadObject<T>(string Path)
        {
            String serializedObject = File.ReadAllText(Path);
            T deserializedObject = JsonConvert.DeserializeObject<T>(serializedObject);

            return deserializedObject;
        }

        public static void SaveObject(object Obj, string Path)
        {
            String serializedObject = JsonConvert.SerializeObject(Obj);
            File.WriteAllText(Path, serializedObject);
        }

        public static string PickFileToLoad(string pickerTitle = null, string extensionFilter = null)
        {
            string selectedPath = null;

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if(pickerTitle != null)
                {
                    dialog.Title = pickerTitle;
                }
                if(extensionFilter != null)
                {
                    dialog.Filter = extensionFilter;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = dialog.FileName;
                }
            }

            return selectedPath;
        }
    }
}
