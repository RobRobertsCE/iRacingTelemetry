﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iRacing.Common
{
    public static class TestSessionExtensions
    {
        public static string AddSpacesToSentence(this string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i].ToString().ToLower());
            }
            return newText.ToString();
        }

        public const int DefaultTopNPercent = 75;
        public static IList<Single> LapTimesOnly(this IDictionary<int, Single> list)
        {
            return list.Where(l => l.Value > 0 && l.Key > 0).Select(l => l.Value).ToList();
        }

        /// <summary>
        /// Returns laps where lap number > 0 and lap time > 0 and lap time < average lap * 1.25
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IDictionary<int, Single> ValidLaps(this IDictionary<int, Single> list)
        {
            if (list.Count == 0) return new Dictionary<int, float>();

            var cutoff = (list.Values.Average() * 1.25);

            var listBuffer = list.Where(l => l.Value > 0 && l.Key > 0)
                .Select(l => new { l.Key, l.Value })
                .ToDictionary(l => l.Key, l => l.Value);

            return listBuffer.Where(l => l.Value < cutoff).ToDictionary(l => l.Key, l => l.Value);
        }
        public static double Average(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().Average();
        }
        public static double Median(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().Median();
        }
        public static double BestLap(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().BestLap();
        }
        public static double Range(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().Range();
        }
        public static double StdDev(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().StdDev();
        }
        public static IDictionary<Single, int> FrequencyDistribution(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().FrequencyDistribution();
        }
        public static IList<Single> Dropoff(this IDictionary<int, Single> list)
        {
            return list.Values.ToList().Dropoff();
        }

        public static IList<Single> ValidLaps(this IList<Single> list)
        {
            return list.Where(l => l > 0).ToList();
        }
        public static IList<Single> CoreLaps(this IList<Single> list)
        {
            return CoreLaps(list, DefaultTopNPercent);
        }
        public static IList<Single> CoreLaps(this IList<Single> list, int topNPercent)
        {
            var count = list.Count();
            if (count <= 3)
                return list;

            if (topNPercent > 100)
                topNPercent = 100;

            if (topNPercent < 0)
                topNPercent = 1;

            // throw out the first and last laps
            var buffer1 = list.OrderBy(l => l).Skip(1).Take(count - 2).ToList();
            float newCountBuffer = count * (topNPercent / 100F);
            var skipCount = (int)Math.Floor((count - newCountBuffer) / 2);
            var takeCount = (int)newCountBuffer;
            var result = buffer1.Skip(skipCount).Take(takeCount).ToList();
            return result;
        }
        public static double Median(this IList<Single> list)
        {
            int numberCount = list.Count();
            int halfIndex = list.Count() / 2;
            var sortedNumbers = list.OrderBy(n => n);
            double median;
            if ((numberCount % 2) == 0)
            {
                median = (((sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt((halfIndex - 1)) / 2)));
            }
            else {
                median = sortedNumbers.ElementAt(halfIndex);
            }
            return median;
        }
        public static double BestLap(this IList<Single> list)
        {
            return list.Where(l => l > 0).Min();
        }
        public static double Range(this IList<Single> list)
        {
            if (list.Count < 2)
                return 0;

            var sortedNumbers = list.OrderBy(n => n);
            return (sortedNumbers.LastOrDefault() - sortedNumbers.FirstOrDefault());
        }
        public static double StdDev(this IList<Single> list)
        {
            double average = list.Average();
            double sumOfSquaresOfDifferences = list.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / list.Count);
            return sd;
        }
        public static IDictionary<Single, int> FrequencyDistribution(this IList<Single> list)
        {
            var result = new Dictionary<Single, int>();
            foreach (var item in list)
            {
                var rounded = (Single)Math.Round(item, 1);
                if (result.ContainsKey(rounded))
                {
                    result[rounded]++;
                }
                else
                {
                    result.Add(rounded, 1);
                }
            }
            return result;
        }
        public static IList<Single> Dropoff(this IList<Single> list)
        {
            var result = new List<Single>();
            var sortedNumbers = list.OrderBy(n => n).ToList();
            for (int i = 0; i < sortedNumbers.Count - 1; i++)
            {
                var current = sortedNumbers[i];
                var next = sortedNumbers[i + 1];
                result.Add(current - next);
            }
            return result;
        }
    }
}
