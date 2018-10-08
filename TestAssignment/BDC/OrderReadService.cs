namespace TestAssignment.BDC
{
	using System.Collections.Generic;
	using TestAssignment.Data;
	using TestAssignment.Models;

	/// <summary>
	/// In the real world Order read service will be a part of diff. layer. 
	/// </summary>
	public class OrderReadService : IOrderReadService
	{
		IOrderRepository orderRepo { get; set; }

		public OrderReadService()
		{
			orderRepo = new OrderRepository();
		}

		public List<Order> GetAllOrders()
		{
			return orderRepo.GetAllOrders();
		}

		public Order GetOrderByOrderNumber(string orderNumber)
		{
			return orderRepo.GetOrderByOrderNumber(orderNumber);
		}
	}
}