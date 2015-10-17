using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
