namespace TestAssignment.Data
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Xml;
	using System.Xml.Serialization;
	using TestAssignment.Models;

	public class OrderRepository : IOrderRepository
	{
		private List<Order> orders = new List<Order>();
		private T Deserialize<T>(string xml)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			XmlReaderSettings settings = new XmlReaderSettings();
			using (StringReader textReader = new StringReader(xml))
			{
				using (XmlReader xmlReader = XmlReader.Create(textReader, settings))
				{
					return (T)serializer.Deserialize(xmlReader);
				}
			}
		}

		public OrderRepository()
		{
			//In the real world app, we will read these files from blob storage or S3. 
			string path = @"C:\TestAssignment\TestAssignment\bin\GeneratedFiles\";
			//string path = @"C:\Users\gagansharma\source\repos\TestAssignment\TestAssignment\bin\GeneratedFiles\";
			IEnumerable<string> txtFiles = Directory.EnumerateFiles(path, "*.xml");
			foreach (string currentFile in txtFiles)
			{
				string xmlContent = File.ReadAllText(currentFile);
				Order order = Deserialize<Order>(xmlContent);
				orders.Add(order);
			}
		}

		public List<Order> GetAllOrders()
		{
			return orders;
		}

		public Order GetOrderByOrderNumber(string orderNumber)
		{
			return orders.FirstOrDefault(x => x.OrderNumber.Equals(orderNumber));
		}
	}
}