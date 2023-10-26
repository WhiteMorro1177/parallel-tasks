using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Task1
{
	internal class Counter
	{
		private List<long[]> _vector;
		private long[] _sum_by_thread;

		private long vector_sum = 0;
		private long vector_items_amount = 0;
		private List<Thread> threads = new List<Thread>();

		public int TimeSpent { get; private set; }

		public Counter() { }
		public Counter(long[] vector, int num_threads)
		{
			_vector = PrepareVector(vector, num_threads);
			vector_items_amount += _vector.Select(item => item.Length).Sum();

			_sum_by_thread = new long[num_threads];
            Console.WriteLine("Working with {0} elements", vector_items_amount);
        }

		private static AutoResetEvent waitHandle = new AutoResetEvent(false);

		public void Run()
		{
			var code_start = DateTime.Now;
			Console.WriteLine("Execute main code...");

			foreach (var item in _vector)
			{
				var args = new object[] { item, _vector.IndexOf(item) };

				Thread t = new Thread(SumVector);
				threads.Add(t);
				t.Start(args);
			}

			threads.ForEach(t => t.Join());

			Console.WriteLine(
				"Mean vector sum = {0}, time spent: {1} milliseconds",
				vector_sum / vector_items_amount,
				(DateTime.Now - code_start).TotalMilliseconds
			);
		}

		private List<long[]> PrepareVector(long[] vector, int num_threads)
		{
			int item_amount_in_part = vector.Length / num_threads;

			var splitted_vector = new List<long[]>();

			for (int i = 0; i < num_threads; i++)
				splitted_vector.Add(vector.Skip(i * item_amount_in_part).Take(item_amount_in_part).ToArray());
			

			return splitted_vector;
		}

		private void SumVector(object args)
		{
			var _args = args as object[];
			long[] vector = _args[0] as long[];
			int id = (int) _args[1];
			
			foreach (long item in vector)
			{
				_sum_by_thread[id] += item;
			}

			vector_sum += _sum_by_thread[id];
			Console.WriteLine("Thread {0} complete", id);
        }
	}	
}
