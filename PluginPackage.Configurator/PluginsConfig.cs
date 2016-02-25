using System.Xml.Serialization;

namespace PluginPackage.Configurator
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class PluginsConfig
    {
        [XmlElement("Plugin")]
        public PluginsPlugin[] Plugin { get; set; }
    }

    [XmlType(AnonymousType = true)]
    public partial class PluginsPlugin
    {
        [XmlAttribute()]
        public string Name { get; set; }
        [XmlAttribute()]
        public int Index { get; set; }

        [XmlAttribute()]
        public string Path { get; set; }
        [XmlAttribute()]
        public string Tag { get; set; }

    }


}
