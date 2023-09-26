
using System.Xml.Serialization;

namespace XTC.FMP.MOD.CanvasRenderer.LIB.Unity
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class MyConfig : MyConfigBase
    {
        public class OverlayMode
        {
            [XmlAttribute("pixelPerfect")]
            public bool pixelPerfect { get; set; } = false;
        }

        public class CameraMode
        {
            [XmlAttribute("camera")]
            public string camera { get; set; } = "";
            [XmlAttribute("pixelPerfect")]
            public bool pixelPerfect { get; set; } = false;
        }

        public class Target
        {
            [XmlAttribute("path")]
            public string path { get; set; } = "";
            [XmlAttribute("mode")]
            public string mode { get; set; } = "Overlay";
            [XmlElement("OverlayMode")]
            public OverlayMode overlayMode { get; set; } = new OverlayMode();
            [XmlElement("CameraMode")]
            public CameraMode cameraMode { get; set; } = new CameraMode();
        }

        public class Style
        {
            [XmlAttribute("name")]
            public string name { get; set; } = "";
            [XmlElement("Target")]
            public Target target { get; set; } = new Target();
        }


        [XmlArray("Styles"), XmlArrayItem("Style")]
        public Style[] styles { get; set; } = new Style[0];
    }
}

