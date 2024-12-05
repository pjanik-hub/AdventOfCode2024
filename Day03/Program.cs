using System.Text.RegularExpressions;

namespace Day03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// assume file is good
			string[] lines = File.ReadAllLines("input.txt");

			int totalSum = 0;
			// regex matching
			Regex regex = new Regex(@"mul\((\d+),(\d+)\)");

			// iterate over each row...
			foreach (string line in lines)
			{
				MatchCollection collection = regex.Matches(line);

                foreach (Match match in collection)
                {
					int a = int.Parse(match.Groups[1].Value);
					int b = int.Parse(match.Groups[2].Value);

					totalSum += a * b;
				}
            }

			Console.WriteLine($"Answer: {totalSum}");
			Console.ReadKey();
		}
	}
}
