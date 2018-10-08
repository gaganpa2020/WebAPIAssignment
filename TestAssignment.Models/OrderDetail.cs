namespace TestAssignment.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	[DataContract]
	public class OrderItem
    {
		[DataMember]
		public string OrderNumber { get; set; }

		[DataMember]
		public string OrderLineNumber { get; set; }

		[DataMember]
		public string ProductNumber { get; set; }

		[DataMember]
		public int Quantity { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public Double Price { get; set; }

		[DataMember]
		public string ProductGroup { get; set; }

		[DataMember]
		public DateTime OrderDate { get; set; }

		[DataMember]
		public string CustomerName { get; set; }

		[DataMember]
		public string CustomerNumber { get; set; }

		public override string ToString()
		{
			return $"OrderNumber: {OrderNumber}, OrderLineNumber: {OrderLineNumber},ProductNumber: {ProductNumber}, Quantity: {Quantity}, Name: {Name}, Price: {Price}, ProductGroup: {ProductGroup}, OrderDate: {OrderDate}, CustomerName: {CustomerName}, CustomerNumber: {CustomerNumber}  ";
		}
	}

	[DataContract]
	public class Order
	{
		public Order()
		{
			items = new List<OrderItem>();
		}

		[DataMember]
		public string OrderNumber
		{
			get
			{
				var _orderNumber = string.Empty;
				if (items != null && items.Count > 0)
				{
					_orderNumber = items.Select(x => x.OrderNumber).FirstOrDefault();
				}

				return _orderNumber;
			}
			set { }
		}

		[DataMember]
		public List<OrderItem> items { get; set; }		
	}
}
