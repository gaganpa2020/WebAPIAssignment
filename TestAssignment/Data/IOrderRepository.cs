namespace TestAssignment.Data
{
	using System.Collections.Generic;
	using TestAssignment.Models;

	public interface IOrderRepository
	{
		Order GetOrderByOrderNumber(string orderNumber);
		List<Order> GetAllOrders();
	}
}