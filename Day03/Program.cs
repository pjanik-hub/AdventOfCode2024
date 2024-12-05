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
			bool calc = true;
			// regex matching
			Regex instructionRegex = new Regex(@"(mul\((\d+),(\d+)\))|(do\(\))|(don't\(\))");

			// iterate over each row...
			foreach (string line in lines)
			{
				MatchCollection matches = instructionRegex.Matches(line);

				foreach (Match match in matches)
				{
					if (match.Groups[1].Success) // mul() match
					{
						if (calc)
						{
							int a = int.Parse(match.Groups[2].Value);
							int b = int.Parse(match.Groups[3].Value);
							totalSum += a * b;
						}
					}
					else if (match.Groups[4].Success) // do() match
					{
						calc = true;
					}
					else if (match.Groups[5].Success) // don't() match
					{
						calc = false;
					}
				}
			}

			Console.WriteLine($"Answer: {totalSum}");
			Console.ReadKey();
		}
	}
}
