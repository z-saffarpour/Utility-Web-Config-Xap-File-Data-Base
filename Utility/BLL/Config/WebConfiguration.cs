using System.Configuration;
using System.IO;
using System.Web.Configuration;

namespace ZaHra.Utility.BLL.Config
{
    public class WebConfiguration
    {
        protected static Configuration ReadWebConfigFile(string pathWebConfig)
        {
            var configFile = new FileInfo(pathWebConfig);
            var vdm = new VirtualDirectoryMapping(configFile.DirectoryName, true, configFile.Name);
            var wcfm = new WebConfigurationFileMap();
            wcfm.VirtualDirectories.Add("/", vdm);
            return WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/"); ;
        }
    }
}
