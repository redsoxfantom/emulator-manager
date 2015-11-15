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

        public List<String> ResolvePaths(String Folder, String extensionFilter)
        {
            mLogger.Info(String.Format("Searching folder {0} for files. Extension filter = {1}",Folder,extensionFilter));
            try
            {
                // Return a list of all files in a folder
                List<String> pathList = new List<String>(Directory.GetFiles(Folder));

                if (!String.IsNullOrEmpty(extensionFilter))
                {
                    // Filter the list of files by only returning files that match the extension 
                    List<String> filteredPathList = pathList.Where((path) => {
                        String fileExtension = Path.GetExtension(path);
                        if (fileExtension.Equals(extensionFilter, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return true;
                        }
                        return false;
                    })
                    .ToList();

                    pathList = filteredPathList;
                }

                mLogger.Debug(String.Format("Search returned the following files:\n{0}", String.Join("\n", pathList.ToArray())));
                return pathList;
            }
            catch (Exception ex)
            {
                mLogger.Error("Error loading pathlist", ex);
                return new List<string>();
            }
        }
    }
}
