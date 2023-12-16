using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 1. Написать параллельную программу "Потребитель - Поставщик" с использованием семафоров.
// 2. Написать параллельную программу "Потребитель - Поставщик" с использованием мониторов.
// 3. Написать параллельную программу "Потребитель - Поставщик" с усложнённым условием (разное кол-во потоков, двусторонняя передача сообщения).

namespace Task2
{
	internal class MainClass
	{
		static void Main(string[] args)
		{
			var provider = new Provider();
			var consumer = new Consumer();

			// bind events
			provider.ProductSet += consumer.OnProductCreated;
			consumer.ProductUsed += provider.OnProductUsed;

			while (true)
			{
                Console.WriteLine("Press 'Enter' to set a product...");
				Console.ReadLine();

				provider.SetProduct();
			}
        }
	}
}
