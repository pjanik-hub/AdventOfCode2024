namespace Day04
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region read input
			string[] lines = File.ReadAllLines("input.txt");
			int rows = lines.Length;
			int cols = lines[0].Length;
			char[,] grid = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					grid[i, j] = lines[i][j];
				}
			}
			#endregion

			string substring = "XMAS";
			int count = 0;

			Console.WriteLine($"Answer: {count}");
		}
	}
}
