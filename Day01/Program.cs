using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace Day01
{
	internal class Program
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

		static void Main(string[] args)
		{
			// get input
			string[] lines = File.ReadAllLines("input.txt");

			List<int> left = [];
			List<int> right = [];


		}
	}
}
