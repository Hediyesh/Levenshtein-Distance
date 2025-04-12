using System;

namespace LevensteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            do
            {
                Console.Clear();
                Console.WriteLine("please enter first string:");
                string str1 = Console.ReadLine();
                Console.WriteLine("please enter second string:");
                string str2 = Console.ReadLine();
                Console.WriteLine("min dis : " + Dis(str1, str2));
                Console.WriteLine("enter yes if you want to exit or no to continue:");
                s = Console.ReadLine();
            } while (s != "yes");
        }
        public static int Dis(string str1, string str2)
        {
            int len1 = str1.Length + 1;
            int len2 = str2.Length + 1;
            int cost;
            int[,] d = new int[len1, len2];
            for (int i = 0; i < len1; i++)
            {
                d[i, 0] = i;
            }
            for (int i = 0; i < len2; i++)
            {
                d[0, i] = i;
            }
            for (int i = 1; i < len1; i++)
            {
                for (int j = 1; j < len2; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        cost = 0;
                    else
                        cost = 1;
                    int min = Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1);
                    min = Math.Min(min, d[i - 1, j - 1] + cost);
                    d[i, j] = min;
                }
            }
            return d[len1 - 1, len2 - 1];
        }
    }
}
