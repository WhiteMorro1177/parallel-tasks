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

        }
	}


	public class Events
	{
		public EventHandler ProductSet;
		public EventHandler ProductUsed;

		public void OnProductSet()
		{

		}
	}
}
