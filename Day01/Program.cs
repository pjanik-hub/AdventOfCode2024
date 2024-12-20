﻿namespace Day01
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// get input
			string[] lines = File.ReadAllLines("input.txt");

			List<int> left = [];
			List<int> right = [];

			foreach (string line in lines)
			{
				// sep by "     "
				string[] split = line.Split();

				// assume file/format is good
				_ = int.TryParse(split.First(), out int leftInt);
				_ = int.TryParse(split.Last(), out int rightInt);

				left.Add(leftInt);
				right.Add(rightInt);
			}

			PartOne(new(left), new(right));
			PartTwo(new(left), new(right));

			Console.Write("Press any key to continue... ");
			Console.ReadKey();
		}

		static void PartOne(List<int> left, List<int> right)
		{
			//	There's just one problem: by holding the two lists up side by side (your puzzle input),
			//	it quickly becomes clear that the lists aren't very similar.
			//	Maybe you can help The Historians reconcile their lists?
			//	For example:
			//  3   4
			//  4   3
			//  2   5
			//  1   3
			//  3   9
			//  3   3
			//  Maybe the lists are only off by a small amount!
			//  To find out, pair up the numbers and measure how far apart they are.
			//  Pair up the smallest number in the left list with the smallest number in the right list,
			//  then the second-smallest left number with the second-smallest right number, and so on.

			//	Within each pair, figure out how far apart the two numbers are; you'll need to add up all of those distances.
			//	For example, if you pair up a 3 from the left list with a 7 from the right list,
			//	the distance apart is 4; if you pair up a 9 with a 3, the distance apart is 6.


			// Lists should be sorted by ascending, min to min, max to max
			left.Sort();
			right.Sort();

			// find the distances between each pair!
			List<int> distances = left.Zip(right, (l, r) => Math.Abs(l - r)).ToList();

			int answer = distances.Sum();

			Console.WriteLine($"Answer: {answer}");
		}

		static void PartTwo(List<int> left, List<int> right)
		{
			// This time, you'll need to figure out exactly how often each number
			// from the left list appears in the right list.
			// Calculate a total similarity score by adding up each number in the left list
			// after multiplying it by the number of times that number appears in the right list.

			// create a frequency map
			Dictionary<int, int> rightValueFreqs = right
				.GroupBy(val => val)
				.ToDictionary(kvp => kvp.Key, kvp => kvp.Count());

			int similarityScore = left.Sum(
				val => val * (rightValueFreqs.TryGetValue(val, out int value) ? value : 0)
			);

			Console.WriteLine($"Similarity: {similarityScore}");
		}
	}
}
