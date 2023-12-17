using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
	internal class Consumer
	{
		// vars
		public string Name { get; private set; }
		private static Random random = new Random();
		
		// constructor
		public Consumer()
		{
			Name = "Huge Nachos Fan";
            Console.WriteLine($"Consumer \"{Name}\" created");
		}

		public void Use(Product product)
		{
			int timeout = random.Next(10, 50) * 100;
			Console.WriteLine($"'{Name}' start using {product} || Timeout: {timeout}");
			Thread.Sleep(timeout);
			Console.WriteLine($"'{Name}' used {product}");
		}
	}
}
