using System;
using System.Xml;

namespace ProcessingXmlDom
{
    public class Startup
    {
        public static void Main()
        {
            var xml = GetXml();
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var root = doc.DocumentElement;

            PrintChilden(root);

        }

        static string GetXml()
        {
            return @"<?xml version=""1.0"" ?>
<books>
    <book id=""1"">
        <title>The name of the Wind</title>
    </book>
    <book id=""2"">
        <title>Harry Potter 1</title>
    </book>
    <book id=""3"">
        <title>Harry Potter 2</title>
    </book>
</books>";
        }


        static void PrintChilden(XmlNode node)
        {
            Console.WriteLine(string.Format($"Node Name: {node.Name} --- Node Value: {node.Value}"));

            var attrs = "";

            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    attrs += attr.Name + " ";
                }
            }
            
            foreach (XmlNode child in node.ChildNodes)
            {
                PrintChilden(child);
            }

            Console.WriteLine(attrs);
        }
    }
}
