using System;

namespace GenericList
{
    public class MyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get => array[index];

            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    Console.WriteLine($"Array Resized: {array.Length}");
                }

                array[index] = value;
            }
        }

        public int Length => array.Length;

        public T GetElement(int index)
        {
            return array[index];
        }
    }

    class MainAp
    {
        static void Main(string[] args)
        {
            MyList<string> str_list = new MyList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";

            for (int i = 0; i < str_list.Length; i++)
            {
                Console.WriteLine(str_list[i]);
            }
        }
    }
}