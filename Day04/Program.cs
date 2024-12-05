namespace Day04
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region read input
			// part 1
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

			// part 2
			lines = File.ReadAllLines("input1.txt");
			int rows2 = lines.Length;
			int cols2 = lines[0].Length;
			char[,] grid2 = new char[rows2, cols2];

			for (int i = 0; i < rows2; i++)
			{
				for (int j = 0; j < cols2; j++)
				{
					grid2[i, j] = lines[i][j];
				}
			}
			#endregion

			string substring = "XMAS";
			int count = CountSubstringHVD(grid, substring, rows, cols);

			int xCount = CountXShape(grid2, rows2, cols2);

			Console.WriteLine($"Answer: {count}");
			Console.WriteLine($"Answer2: {xCount}");
			Console.ReadKey();
		}

		static int CountXShape(char[,] grid, int rows, int cols)
		{
			int total = 0;
			string substring = "MAS";
			int sLen = substring.Length;

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					// check X shape forward
					if (i <= rows - sLen && j >= 1 && j <= cols - 2 &&
						grid[i, j] == substring[0] &&
						grid[i + 1, j - 1] == substring[1] &&
						grid[i + 2, j] == substring[2] &&
						grid[i + 1, j + 1] == substring[1])
					{
						total++;
					}

					// check X shape backward
					if (i <= rows - sLen && j >= 1 && j <= cols - 2 &&
						grid[i, j] == substring[2] &&
						grid[i + 1, j - 1] == substring[1] &&
						grid[i + 2, j] == substring[0] &&
						grid[i + 1, j + 1] == substring[1])
					{
						total++;
					}
				}
			}

			return total;
		}

		/// <summary>
		/// H: Horizontal, V: Vertical, D: Diagonal
		/// </summary>
		/// <param name="grid"></param>
		/// <param name="substring"></param>
		/// <param name="rows"></param>
		/// <param name="cols"></param>
		/// <returns>Total occuring substrings</returns>
		static int CountSubstringHVD(char[,] grid, string substring, int rows, int cols)
		{
			int total = 0;
			int sLen = substring.Length;

			// check horizontally, vertically, and diagonally
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					// horizontally forward and backward
					if (j <= cols - sLen && HasSubstring(grid, substring, i, j, 0, 1, 0))
						total++;
					if (j >= sLen - 1 && HasSubstring(grid, substring, i, j, 0, -1, 0))
						total++;

					// vertically forward and backward
					if (i <= rows - sLen && HasSubstring(grid, substring, i, j, 1, 0, 0))
						total++;
					if (i >= sLen - 1 && HasSubstring(grid, substring, i, j, -1, 0, 0))
						total++;

					// diagonally (down-right and up-left)
					if (i <= rows - sLen && j <= cols - sLen && HasSubstring(grid, substring, i, j, 1, 1, 0))
						total++;
					if (i >= sLen - 1 && j >= sLen - 1 && HasSubstring(grid, substring, i, j, -1, -1, 0))
						total++;

					// diagonally (down-left and up-right)
					if (i <= rows - sLen && j >= sLen - 1 && HasSubstring(grid, substring, i, j, 1, -1, 0))
						total++;
					if (i >= sLen - 1 && j <= cols - sLen && HasSubstring(grid, substring, i, j, -1, 1, 0))
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
