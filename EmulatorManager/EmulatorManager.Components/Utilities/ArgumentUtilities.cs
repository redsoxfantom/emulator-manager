using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Utilities
{
    /// <summary>
    /// Contains utilities for creating arguments to the emulators
    /// </summary>
    public static class ArgumentUtilities
    {
        /// <summary>
        /// Takes a path to a rom and splits it into "<FULL_PATH>=blah;<ROM_PATH>=blah;<ROM_FILE>=blah" components
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SplitPath(String path)
        {
            StringBuilder retString = new StringBuilder();
            retString.Append(String.Format("<FULL_PATH>={0};",Path.GetFullPath(path))); // Add the full path replacement
            retString.Append(String.Format("<ROM_PATH>={0};",Path.GetDirectoryName(path))); // Add the path only replacement
            retString.Append(String.Format("<ROM_FILE>={0}",Path.GetFileName(path))); // Add the file only replacement

            return retString.ToString();
        }
    }
}
