namespace TestAssignment.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Web.Http;
	using TestAssignment.BDC;
	using TestAssignment.Models;

	public class OrdersController : ApiController
	{
		IOrderReadService orderService { get; set; }
		public OrdersController()
		{
			orderService = new OrderReadService();
		}

		// GET api/values
		public IEnumerable<Order> Get()
		{
			return orderService.GetAllOrders();
		}

		// GET api/values/5
		public Order Get(string orderNumber)
		{
			if (string.IsNullOrWhiteSpace(orderNumber))
			{
				throw new ArgumentNullException(); 
			}
			else
			{
				return orderService.GetOrderByOrderNumber(orderNumber);
			}
		}
	}
}
