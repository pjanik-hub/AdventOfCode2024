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
			int count = CountSubstringHVD(grid, substring, rows, cols);

			Console.WriteLine($"Answer: {count}");
			Console.ReadKey();
		}
		
		static int CountSubstringHVD(char[,] grid, string substring, int rows, int cols)
		{
			int total = 0;
			int sLen = substring.Length;

			// check horizontally, vertically, and diagonally
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					// horizontally
					if (j <= cols - sLen && HasSubstring(grid, substring, i, j, 0, 1, 0))
						total++;

					// vertically
					if (i <= rows - sLen && HasSubstring(grid, substring, i, j, 1, 0, 0))
						total++;

					// diagonally (down-right)
					if (i <= rows - sLen && j <= cols - sLen && HasSubstring(grid, substring, i, j, 1, 1, 0))
						total++;

					// diagonally (down-left)
					if (i <= rows - sLen && j >= sLen - 1 && HasSubstring(grid, substring, i, j, 1, -1, 0))
						total++;
				}
			}

			return total;
		}

		static bool HasSubstring(char[,] grid, string substring, int startRow, int startCol, int rowDir, int colDir, int index)
		{
			// base case
			if (index == substring.Length)
				return true;

			// dead end
			if (startRow < 0 || startRow >= grid.GetLength(0) || startCol < 0 || startCol >= grid.GetLength(1))
				return false;

			// dead end
			if (grid[startRow, startCol] != substring[index])
				return false;

			return HasSubstring(grid, substring, startRow + rowDir, startCol + colDir, rowDir, colDir, index + 1);
		}
	}
}
