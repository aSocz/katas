using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RangeExtractor
{
    public static class RangeExtraction
    {
        private const int RangeThreshold = 3;
        public static string Extract(int[] args)
        {
            var result = new StringBuilder(string.Empty);
            var index = 0;
            while (index < args.Length)
            {
                var neighborhood = args.TakeContinuous(index).ToList();
                if (neighborhood.Count < RangeThreshold)
                {
                    result.Append("," + string.Join(",", neighborhood.Select(n => args[n])));
                    index += neighborhood.Count;
                    continue;
                }

                result.Append("," + $"{args[neighborhood.First()]}-{args[neighborhood.Last()]}");
                index += neighborhood.Count;
            }

            return result.ToString().TrimStart(',');
        }

        public static IEnumerable<int> TakeContinuous(this int[] numbers, int startIndex)
        {
            var neighborhood = new List<int> { startIndex };
            var offset = 1;
            while (offset < numbers.Length - startIndex
                && IsNeighbor(numbers[startIndex + offset - 1], numbers[startIndex + offset]))
            {
                neighborhood.Add(startIndex + offset++);
            }

            return neighborhood;
        }

        public static bool IsNeighbor(int left, int right) => Math.Abs(right - left) == 1;
    }
}