﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAssignment;
using TestAssignment.Controllers;

namespace TestAssignment.Tests.Controllers
{
	[TestClass]
	public class ValuesControllerTest
	{
		[TestMethod]
		public void Get()
		{
			// Arrange
			OrdersController controller = new OrdersController();

			//// Act
			//IEnumerable<string> result = controller.Get();

			//// Assert
			//Assert.IsNotNull(result);
			//Assert.AreEqual(2, result.Count());
			//Assert.AreEqual("value1", result.ElementAt(0));
			//Assert.AreEqual("value2", result.ElementAt(1));
		}

		[TestMethod]
		public void GetById()
		{
			// Arrange
			OrdersController controller = new OrdersController();

			//// Act
			//string result = controller.Get(5);

			//// Assert
			//Assert.AreEqual("value", result);
		}
	}
}
