namespace TestAssignment.BDC
{
	using System.Collections.Generic;
	using TestAssignment.Models;

	public interface IOrderReadService
	{
		List<Order> GetAllOrders();
		Order GetOrderByOrderNumber(string orderNumber);
	}
}