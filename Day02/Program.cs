using System.Runtime.CompilerServices;

namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region capture input
            // assume file is good
            string[] lines = File.ReadAllLines("input.txt");
            int totalLines = lines.Length;

            List<List<int>> reactorValues = [];

            // iterate over each row...
            foreach (string line in lines)
            {
                string[] values = line.Split();
                List<int> row = [];

                // append each integer to the row
                for (int i = 0; i < values.Length; i++)
                {
                    if (int.TryParse(values[i], out int val))
                        row.Add(val);
                }

                reactorValues.Add(row);
            }
            #endregion

            Part1(reactorValues);
            Part2(reactorValues);
            Console.ReadKey();
        }

		static void Part1(List<List<int>> reactorValues)
		{
			const int maxDistance = 3;
			int answer = 0;

			List<bool> safetyValues = [];

			foreach (List<int> row in reactorValues)
			{
				bool isSafe = IsRowSafe(row, maxDistance);
				safetyValues.Add(isSafe);
			}

			answer = safetyValues.Where(e => e == true).Count();

			Console.WriteLine($"Part 1 Answer: {answer}");
		}

		static void Part2(List<List<int>> reactorValues)
		{
			const int maxDistance = 3;
			int answer = 0;
			const int maxErrors = 1;
			int errors;

			List<bool> safetyValues = [];

			foreach (List<int> row in reactorValues)
			{
				bool isSafe = IsRowSafe(row, maxDistance);
				errors = 0;

				if (!isSafe && errors++ < maxErrors)
				{
					for (int i = 0; i < row.Count; i++)
					{
						List<int> modifiedRow = new(row);
						modifiedRow.RemoveAt(i);

						if (IsRowSafe(modifiedRow, maxDistance))
						{
							isSafe = true;
							break;
						}
					}
				}

				safetyValues.Add(isSafe);
			}

			answer = safetyValues.Where(e => e == true).Count();

			Console.WriteLine($"Part 2 Answer: {answer}");
		}

		/// <summary>
		/// True if the row contains no errors. I.e. is within tolerable distance (3)
		/// and is strictly in ascending or descending
		/// </summary>
		/// <param name="row">A row of integers</param>
		/// <param name="maxDistance">The max tolerable distance</param>
		/// <returns>True if valid, false otherwise</returns>
		static bool IsRowSafe(List<int> row, int maxDistance)
		{
			if (row.Count < 2) return false;

            // going up or down
			int direction = row[1] - row[0] > 0 ? 1 : -1;

			for (int i = 0; i < row.Count - 1; i++)
			{
				int distance = row[i + 1] - row[i];

				// going in the correct direction?
				if ((direction == 1 && distance <= 0) || (direction == -1 && distance >= 0))
					return false;

				// within 1 and 3 distance?
				if (Math.Abs(distance) < 1 || Math.Abs(distance) > maxDistance)
					return false;
			}

			return true;
		}
	}
}
