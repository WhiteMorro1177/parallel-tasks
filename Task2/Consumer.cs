using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	internal class Consumer
	{
		public string Name { get; private set; }
		public Consumer(int number)
		{
			Name = $"Consumer {number}";
		}


		// event handler
		public static void ProductSetHandler(object sender, EventArgs e)
		{

		}
	}
}
