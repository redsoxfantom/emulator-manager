using Newtonsoft.Json;
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

        public static string UseFilePicker(FilePickerType type, string pickerTitle = null, string extensionFilter = null)
        {
            string selectedPath = null;
            FileDialog dialog = null;

            switch(type)
            {
                case FilePickerType.LOAD:
                    dialog = new OpenFileDialog();
                    break;
                case FilePickerType.SAVE:
                    dialog = new SaveFileDialog();
                    break;
            }

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

            dialog.Dispose();

            return selectedPath;
        }

        public static string PickFolderToLoad()
        {
            string selectedFolder = null;

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolder = dialog.SelectedPath;
                }
            }

            return selectedFolder;
        }

        public enum FilePickerType
        {
            SAVE,
            LOAD
        }
    }
}
