using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TVS.Declaration.Settings
{
    public class GroupConfigurationXmlRepository : IConfigurationRepository<GroupConfiguration>
    {
        public void Save(GroupConfiguration config, string pathDirectory)
        {
            if (config == null) throw new ArgumentNullException("config");
            if (string.IsNullOrEmpty(pathDirectory)) throw new ArgumentNullException("path");

            //var filename = config.Database + ".apt";
            //var path = Path.Combine(pathDirectory, filename);
            var s = new XmlSerializer(typeof(GroupConfiguration));
            using (var w = new StreamWriter(pathDirectory, false, Encoding.Unicode))
            {
                s.Serialize(w, config);
                w.Close();
            }
        }

        public GroupConfiguration Load(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");

            if (!File.Exists(path)) return null;

            var serializer = new XmlSerializer(typeof(GroupConfiguration));
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var config = (GroupConfiguration) serializer.Deserialize(fs);
                //var config = serializer.Deserialize(fs) as GroupConfiguration;
                return config;
            }
        }
    }
}