using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using ZaHra.Utility.DTO.Config;

namespace ZaHra.Utility.BLL.Config
{
    public class ClientEndpointAddressConfiguration : WebConfiguration
    {
        public static List<Endpoint> ReadClientEndpointAddress(string pathWebConfig)
        {
            var webConfig = ReadWebConfigFile(pathWebConfig);
            var clientSection = webConfig.GetSection("system.serviceModel/client") as ClientSection;
            var list = new List<Endpoint>();
            if (clientSection == null) return list;
            foreach (var item in clientSection.Endpoints)
            {
                var temp = item as ChannelEndpointElement;
                if (temp == null) continue;
                var address = temp.Address;
                var name = temp.Name;
                var serviceName = temp.Contract.Split('.');
                list.Add(new Endpoint
                {
                    Address = address.ToString(),
                    Name = name,
                    AbsolutePath = address.AbsolutePath,
                    Host = address.Host,
                    Port = address.Port,
                    Scheme = address.Scheme,
                    ServiceName = serviceName[0]
                });
            }
            return list;
        }

        public static void ConfigClientEndpointAddress(string pathWebConfig, List<Endpoint> list)
        {
            var webConfig = ReadWebConfigFile(pathWebConfig);
            var clientSection = webConfig.GetSection("system.serviceModel/client") as ClientSection;
            if (clientSection != null)
            {
                foreach (var item in clientSection.Endpoints)
                {
                    var temp = item as ChannelEndpointElement;
                    if (temp == null) continue;
                    var endPoint = list.FirstOrDefault(x => x.Name == temp.Name);
                    if (endPoint == null) continue;
                    var absolutePath = endPoint.AbsolutePath;
                    var scheme = endPoint.Scheme;
                    var host = endPoint.Host;
                    var port = endPoint.Port;
                    temp.Address = new Uri(string.Format("{0}://{1}:{2}{3}", scheme, host, port, absolutePath));
                }
            }
            webConfig.Save();
        }
    }
}
