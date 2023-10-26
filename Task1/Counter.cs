using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Task1
{
	internal class Counter
	{
		private readonly List<long[]> _vector;
		private readonly long vector_items_amount;
		private readonly int _num_threads;

		private readonly long[] _sum_by_thread;

		private long vector_sum = 0;


		public TimeSpan TimeSpent { get; private set; }
		public long Result
		{
			get { return vector_sum / vector_items_amount; }
		}

		public Counter() { }
		public Counter(long[] vector, int num_threads)
		{
			_num_threads = num_threads;
			_vector = PrepareVector(vector);


			vector_items_amount += _vector.Select(item => item.Length).Sum();

			if (vector_items_amount < vector.LongLength)
			{
				int difference = vector.Length - (int) vector_items_amount;
                Console.WriteLine("difference: {0}", difference);
                var skiped_items = _vector.Last().Skip(_vector.Last().Length).Take(difference);
				skiped_items.ToList().ForEach(item => _vector.Last().Append(item));
			}

			_sum_by_thread = new long[num_threads];
            Console.WriteLine("Working with {0} elements", vector_items_amount);
        }

		public void Run()
		{
			var code_start = DateTime.Now;
			Console.WriteLine("Execute main code...");

			foreach (var item in _vector)
			{
				var args = new object[] { item, _vector.IndexOf(item) };

				new Thread((object _args) =>
				{
					var thread_args = _args as object[];
					long[] vector = thread_args[0] as long[];
					int id = (int) thread_args[1];

					long tmp_sum = 0;

					foreach (long i in vector)
						tmp_sum += i;
					
					_sum_by_thread[id] += tmp_sum;
					Console.WriteLine("Thread {0} complete", id);
				}).Start(args);
			}

			while (_sum_by_thread.Contains(0))
				Thread.Sleep(1);
			
			vector_sum += _sum_by_thread.Sum();
			TimeSpent = DateTime.Now - code_start;
        }

		private List<long[]> PrepareVector(long[] vector)
		{
			int item_amount_in_part = vector.Length / _num_threads;

			var splitted_vector = new List<long[]>();

			for (int i = 0; i < _num_threads; i++)
				splitted_vector.Add(vector.Skip(i * item_amount_in_part).Take(item_amount_in_part).ToArray());
			
			return splitted_vector;
		}
	}	
}
