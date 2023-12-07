using System.Reflection.Metadata.Ecma335;

namespace waterlocator.Models
{
    public class Document
    {
        public Placemark Placemark { get; set; }

        public Style Style { get; set; }
    }

    public class Placemark
    {
        public Point Point { get; set; }
        public string styleUrl { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Point
    {
        public string altitudeMode { get; set; }
        public string coordinates { get; set; }
    }

    public class Style
    {
        public IconStyle IconStyle { get; set; }
    }

    public class IconStyle
    {
        public string color { get; set; }
        public string colorMode { get; set; }
        public decimal scale { get; set; }
        public Icon Icon { get; set; }
    }

    public class Icon
    {
        public string href { get; set; }
    }
}
