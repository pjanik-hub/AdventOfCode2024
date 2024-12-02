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
        }

        static void Part1(List<List<int>> reactorValues)
        {
            /**
             * The engineers are trying to figure out which reports are safe. 
             * The Red-Nosed reactor safety systems can only tolerate levels that are either gradually increasing or gradually decreasing.
             * So, a report only counts as safe if both of the following are true:
             * - The levels are either all increasing or all decreasing.
             * - Any two adjacent levels differ by at least one and at most three.
             *  7 6 4 2 1
             *  1 2 7 8 9
             *  9 7 6 2 1
             *  1 3 2 4 5
             *  8 6 4 4 1
             *  1 3 6 7 9
             *  
             *  
             */
            int answer = 0;

            List<bool> safetyValues = [];

            foreach (List<int> row in reactorValues)
            {
                // fwd: +1
                // bwd: -1
                bool isSafe = true;
                int direction = row[1] - row [0] > 0 ? 1 : -1;

                for (int i = 0; i < row.Count - 1; i++)
                {
                    int distance = row[i + 1] - row[i];

                    // going in the correct direction?
                    isSafe &= direction == 1 ? int.IsPositive(distance) : int.IsNegative(distance);

                    // within 1 and 3 distance?
                    isSafe &= Math.Abs(distance) > 0 && Math.Abs(distance) <= 3;
                }

                safetyValues.Add(isSafe);
            }

            answer = safetyValues.Where(e => e == true).Count();

            Console.WriteLine($"Part 1 Answer: { answer }");
        }

        static void Part2(List<List<int>> reactorValues)
        {
            const int maxDistance = 3;
            const int errorTolerance = 1;
            int answer = 0;

            List<bool> safetyValues = [];

            foreach (List<int> row in reactorValues)
            {
                // fwd: +1
                // bwd: -1
                bool isSafe = true;
                int errorTotal = 0;

                for (int i = 0; i < row.Count - 1; i++)
                {
                    int direction = row[1] - row[0] > 0 ? 1 : -1;
                    int distance = row[i + 1] - row[i];

                    // going in the correct direction?
                    isSafe &= direction == 1 ? int.IsPositive(distance) : int.IsNegative(distance);

                    // within 1 and 3 distance?
                    isSafe &= Math.Abs(distance) > 0 && Math.Abs(distance) <= maxDistance;

                    if (!isSafe && errorTotal++ < errorTolerance)
                    {
                        int? a = i - 1 >= 0 ? i - 1 : null;
                        int b = i;
                        int? c = i + 1 < row.Count ? i + 1 : null;

                        int indexToRemove = IndexToRemove(a, b, c, direction == 1);
                        row.RemoveAt(i + 1);
                        isSafe = true; // reset
                    }
                }

                safetyValues.Add(isSafe);
            }

            answer = safetyValues.Where(e => e == true).Count();

            Console.WriteLine($"Part 2 Answer: {answer}");
        }

        static int IndexToRemove(int? a, int b, int? c, int direction)
        {
            const int maxDistance = 3;
            int distance = 0;
            int direction = 0;

            if (a is null)
            {
                distance = (int)(c! - b);
            }
            else if (c is null)
            {
                distance = (int)(b - a!);
            }
            else // both are non-null
            {
                int firstDistance = (int)(c! - b);
                int secondDistance = (int)(b! - a);

                int firstDirection = int.IsPositive(firstDistance) ? 1 : -1;
                int secondDirection = int.IsPositive(secondDistance) ? 1 : -1;
            }
        }
    }
}
