using System;
using System.Reflection;
using System.Xml.Linq;
using Animal_;
using System.Linq;

namespace Lab7
{
    public class Class1
    {
        public static void Main()
        {
            var assembly = Assembly.GetAssembly(typeof(Animal));
            var xDocument = new XDocument(new XElement("ClassDiagram"));

            foreach (var type in assembly.GetTypes().Where(t => t.IsClass))
            {
                var xClass = new XElement("Class", new XAttribute("Name", type.Name));
                var customCommentAttr = type.GetCustomAttribute<CustomCommentAttribute>();

                if (customCommentAttr != null)
                {
                    xClass.Add(new XElement("Comment", customCommentAttr.Comment));
                }

                // Add properties
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    var xProperty = new XElement("Property");
                    xProperty.Add(new XAttribute("Name", property.Name));
                    xProperty.Add(new XAttribute("Type", property.PropertyType.Name));
                    xClass.Add(xProperty);
                }

                // Add methods
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                foreach (var method in methods)
                {
                    var xMethod = new XElement("Method");
                    xMethod.Add(new XAttribute("Name", method.Name));
                    xMethod.Add(new XAttribute("ReturnType", method.ReturnType.Name));
                    xClass.Add(xMethod);
                }

                xDocument.Root.Add(xClass);
            }

            xDocument.Save("ClassDiagram.xml");
        }
    }
}
