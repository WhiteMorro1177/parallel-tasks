using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	internal class Retailer
	{
		public string Name { get; private set; }

		public Retailer(int number)
		{
			Name = $"Retailer {number}";
		}
	}
}
