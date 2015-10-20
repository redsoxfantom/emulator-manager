using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorManager.Components.PathComponent
{
    public class PathResolverComponent
    {
        private ILog mLogger;

        public PathResolverComponent()
        {
            mLogger = LogManager.GetLogger(GetType().Name);
        }

        public List<String> ResolvePaths(String Folder)
        {
            mLogger.Info(String.Format("Searching folder {0} for files",Folder));
            // Return a list of all files in a folder
            List<String> pathList = new List<String>(Directory.GetFiles(Folder));

            mLogger.Debug(String.Format("Search returned the following files:\n{0}",String.Join("\n",pathList.ToArray())));

            return pathList;
        }
    }
}
