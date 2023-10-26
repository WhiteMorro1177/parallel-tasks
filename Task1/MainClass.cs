using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	internal class MainClass
	{
		static void Main(string[] args)
		{
			// initialize vector
			long N = 100_000_000;
			long[] vector = new long[N];
			var r = new Random();

			Console.WriteLine("Filling vector...");
			for (int i = 0; i < vector.Length; i++)
			{
				vector[i] = i;
			}

			Console.WriteLine($"Vector contain {N} items\n\nPrepare to executing...");


			// sequencial run
			DoSequencially(vector);

			// parallel run
			DoParallel(vector, num_threads: 2);
		}

		private static void DoParallel(long[] vector, int num_threads)
		{
            Console.WriteLine("Start parallel programm\n");

			var counter = new Counter(vector, num_threads);

			counter.Run();
        }

		private static void DoSequencially(long[] vector)
		{
            Console.WriteLine("Start sequencial programm\n");
            var code_start = DateTime.Now;

			long vector_sum = 0;
			for (int i = 0; i < vector.Length; i++)
			{
				vector_sum += vector[i];
			}

			Console.WriteLine(
				"Mean vector sum = {0}, time spent: {1} milliseconds", 
				vector_sum / vector.Length, 
				(DateTime.Now - code_start).TotalMilliseconds
			);
		}
	}
}
