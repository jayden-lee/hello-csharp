using System;

namespace Generic
{
    class MainApp
    {
        static void CopyArray<T>(T[] source, T[] target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        static void Main(string[] args)
        {
            int[] source = {1, 2, 3, 4, 5};
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);

            foreach (int element in target)
            {
                Console.WriteLine(element);
            }
        }
    }
}