using System;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XMLMerger {
	internal class Program {

		/// <summary>
		/// Recursively convert xml element to string
		/// </summary>
		/// <param name="element">root element</param>
		/// <param name="depth">initial tab depth</param>
		/// <returns>string of converted xml</returns>
		private static string RecursiveXMLtoString(XElement element, int depth = 0) {
			if (element == null)
				return "";

			string result = "";
			string tab = string.Join("",Enumerable.Repeat("\t", depth));

			result += tab + element.Name;
			foreach (var attribute in element.Attributes()) {
				if (attribute ==  null) continue;
				result += "\t" + attribute.Name + ": " + attribute.Value;
			}
			result += "\n";

			foreach (var childElem in element.Elements()) {
				result += RecursiveXMLtoString(childElem, depth + 1);
			}

			return result;
		}

		private static void Main(string[] args) {
			Console.OutputEncoding = Encoding.UTF8;

			XElement xElement = XElement.Load("Shop-CAB-ac19f39bf318840674fb0eadefa344d4-2192037798729167981.xml");
			if (xElement == null) {
				return;
			}
			//Console.WriteLine(RecursiveXMLtoString(xElement));
		}
	}
}
