namespace StaticFileParser
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Xml;
	using System.Xml.Serialization;
	using TestAssignment.Models;

	internal class Program
	{
		private static void Main(string[] args)
		{
			List<Order> orders = ParseOrderStaticFiles();
			WriteObjectToXml(orders);
		}

		private static List<Order> ParseOrderStaticFiles()
		{
			List<Order> orders = new List<Order>();			
			//Read & Parse file.
			IEnumerable<string> txtFiles = Directory.EnumerateFiles(@"StaticInputFiles\", "*.txt");
			foreach (string currentFile in txtFiles)
			{
				var order = new Order();
				var lines = File.ReadLines(currentFile).ToList();
			
				foreach (string item in lines.Skip(1))
				{
					string[] orderProp = item.Split('|');
					order.items.Add(new OrderItem()
					{
						OrderNumber = orderProp[1],
						OrderLineNumber = orderProp[2],
						ProductNumber = orderProp[3],
						Quantity = Convert.ToInt32(orderProp[4]),
						Name = orderProp[5],
						Description = orderProp[6],
						Price = Convert.ToDouble(orderProp[7]),
						ProductGroup = orderProp[8],
						OrderDate = Convert.ToDateTime(orderProp[9]),
						CustomerName = orderProp[10],
						CustomerNumber = orderProp[11]
					});
				}

				orders.Add(order);
			}

			return orders;
		}

		private static void WriteObjectToXml(List<Order> orders)
		{
			string generatedFolder = @"GeneratedFiles\";

			//Save Order files as xml. - In real time we will save these files in a common storage may be on S3 or Some blobstorage from where, API will read these xml files..
			foreach (var item in orders)
			{
				XmlWriter xmlWriter = null;
				try
				{
					var orderNumber = item.items.Select(x=>x.OrderNumber).FirstOrDefault();
					string filePath = generatedFolder + orderNumber + ".xml";
					xmlWriter = XmlWriter.Create(filePath);
					XmlSerializer xmlserializer = new XmlSerializer(typeof(Order));
					xmlserializer.Serialize(xmlWriter, item);
				}
				catch (Exception)
				{
					//Some exception logs, per record while saving xml.
				}
				finally
				{
					if (xmlWriter != null)
					{
						xmlWriter.Close();
						xmlWriter.Dispose();
					}
				}
			}

		}
	}
}
