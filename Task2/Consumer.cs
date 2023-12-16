using System;
using System.Threading;

namespace Task2
{
	internal class Consumer
	{
		// vars
		public delegate void ConsumerHandler(int productId);
		public event ConsumerHandler ProductUsed;

		public string Name { get; private set; }
		private static Random random = new Random();
		
		// constructor
		public Consumer()
		{
			Name = "Huge Nachos Fan";
            Console.WriteLine($"Consumer \"{Name}\" created");
		}

		// event handler
		public void OnProductCreated(Product product) 
		{
			int timeout = random.Next(1, 4) * 1000;
			Console.WriteLine($"'{Name}' start using {product} || Timeout: {timeout}");
			Thread.Sleep(timeout);
            Console.WriteLine($"'{Name}' used {product}");
			
			ProductUsed?.Invoke(product.Id);
        }
	}
}
