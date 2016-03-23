using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_1.Models;

namespace AI_1.Extensions
{
    public static class ExtensionMethods
    {
        private static Random rng = new Random();

        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static bool ContainsSpecimen(this IList<Genotype> population, Genotype specimen)
        {
            bool exists = false;
            for (int i = 0; !exists && i < population.Count; i++)
            {
                exists = population[i].IsClone(specimen);
            }

            return exists;
        }
    }
}
