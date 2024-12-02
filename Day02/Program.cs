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

            Console.WriteLine($"Answer: { answer }");
        }
    }
}
