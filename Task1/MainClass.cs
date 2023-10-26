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
			var sequncially_time_spent = DoSequencially(vector);

			int num_threads = 4;
			// parallel run
			var in_parallel_time_spent = DoParallel(vector, num_threads);


			// count statistics
			double acceleration = sequncially_time_spent / in_parallel_time_spent;
			double efficiency = acceleration / num_threads;

            Console.WriteLine("Acceleration: {0}\nEfficiency: {1}", acceleration, efficiency);

			// create charts
			List<double> accelerations = new List<double>() { 1 };
			List<double> efficiencies = new List<double>() { 1 };

			for (int i = 2; i <= 3; i++)
			{
				var tmp_in_parallel_time_spent = DoParallel(vector, i);
				var tmp_acceleration = sequncially_time_spent / tmp_in_parallel_time_spent;
				accelerations.Add(tmp_acceleration);
				efficiencies.Add(tmp_acceleration / i);
			}

			accelerations.Add(acceleration);
			efficiencies.Add(efficiency);

			new ChartPreview("Acceleration", accelerations).ShowDialog();
			new ChartPreview("Efficiency", efficiencies).ShowDialog();
		}

		private static double DoParallel(long[] vector, int num_threads)
		{
            Console.WriteLine("\nStart parallel programm\n");

			var counter = new Counter(vector, num_threads);

			counter.Run();

			Console.WriteLine(
				"Mean vector sum = {0}, time spent: {1} milliseconds",
				counter.Result,
				counter.TimeSpent.TotalMilliseconds
			);

			return counter.TimeSpent.TotalMilliseconds;
		}

		private static double DoSequencially(long[] vector)
		{
            Console.WriteLine("\nStart sequencial programm\n");
            var code_start = DateTime.Now;

			long vector_sum = 0;
			for (int i = 0; i < vector.Length; i++)
			{
				vector_sum += vector[i];
			}

			var time_spent = (DateTime.Now - code_start).TotalMilliseconds;

			Console.WriteLine(
				"Mean vector sum = {0}, time spent: {1} milliseconds", 
				vector_sum / vector.Length, 
				time_spent
			);
			return time_spent;
		}
	}
}
