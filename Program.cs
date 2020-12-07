using System;
using System.Text;

namespace Lab_9
{
    class dimension
    {
        public static int ndimension()
        {
            int k = 0;
            while (true)
            {
                Console.WriteLine("Введіть кількість стопчиків у масиві: ");
                try
                {
                    string string1 = Console.ReadLine();
                    int n = Convert.ToInt32(string1);
                    k += n;
                    break;
                }

                catch
                {
                    Console.WriteLine("Щось не так у ваших даних. Перевірте, будь ласка.");
                }
            }


            return k;

        }

        public static int mdimension()
        {
            int l = 0;
            while (true)
            {
                Console.WriteLine("Введіть кількість рядків у масиві: ");
                try
                {
                    string string1 = Console.ReadLine();
                    int m = Convert.ToInt32(string1);
                    l += m;
                    break;
                }

                catch
                {
                    Console.WriteLine("Щось не так у ваших даних. Перевірте, будь ласка.");
                }
            }
            return l;
        }

        public static int[,] massive(int x, int y)
        {
            int[,] array = new int[x, y];  //{ ndimension(), mdimension() } ;
            Random rand = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    array[i, j] = rand.Next(1, 41);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Ваш масив згенеровано випадковими числами:");

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(array[i, j] + "   ");
                }
                Console.WriteLine();
            }

            return array;
        }

        public static int key()
        {
            int temp = 0;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введіть значення, яке хочете відшукати у масиві: ");
                try
                {
                    string str = Console.ReadLine();
                    int key = Convert.ToInt32(str);
                    temp += key;
                    break;
                }
                catch
                {
                    Console.WriteLine("Щось не так у ваших даних. Перевірте, будь ласка.");
                }
            }

            return temp;
        }

        public static int Search(int[,] array, int find)
        {
            int h = array.GetLength(0);
            int w = array.GetLength(1);

            int value = 0;
            Console.WriteLine();

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (array[i, j].Equals(find))
                    {
                        Console.WriteLine($"Елемент {find} знайдений на позиції [{i}, {j}].");
                        value += 1;
                    }

                }
            }

            if (value == 0)
            {
                Console.WriteLine($"Елемент {find} не знайдено у масиві((((");
            }

            Console.WriteLine();
            return find;
        }

        public static int[] multiply(int[,] array)
        {
            int w = array.GetLength(1);

            int[] res = new int[w];

            for (int i = 0; i < array.GetLength(1); ++i)
            {

                int tempmax = int.MinValue;
                int tempmin = int.MaxValue;


                for (int j = 0; j < array.GetLength(0); ++j)
                {
                    if (array[j, i] > tempmax)
                    {
                        tempmax = array[j, i];
                    }

                    if (array[j, i] < tempmin)
                    {
                        tempmin = array[j, i];
                    }

                    res[i] = (tempmin * tempmax);

                }

                Console.WriteLine($"Максимальний елемент у стовпчику {i+1} - {tempmax}, а мінімальний {tempmin}.");
            }

            Console.WriteLine();

            Console.WriteLine("Знайдемо їх добутки: ");
            for (int i = 0; i < w; i++)
            {
                Console.WriteLine($"Результат множення максимального та мінімального елементів {i+1}-го стовпчика: {res[i]}.");
            }

            return res;
        }

        public static isEqual delegatee;
        public delegate bool isEqual(int x);

        public static bool ConditionCheck(int x) => x <= 35;

        public static void MyCalculation(int[,] arr, isEqual func)
        {
            for (int j = 0; j < arr.GetUpperBound(1) + 1; j++)
            {
                int tempmax = int.MinValue;
                int tempmin = int.MaxValue;

                int[] res = new int[arr.GetLength(1)];

                for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
                {
                    if (arr[i, j] > tempmax && func(arr[i, j]))
                    {
                        tempmax = arr[i, j];
                    }

                    if (arr[i, j] < tempmin && func(arr[i, j]))
                    {
                        tempmin = arr[i,j];
                    }

                    res[j] = (tempmax * tempmin);
                }

                if (tempmin!=0 && tempmax!=0)
                {
                    Console.WriteLine($"Максимальний елемент в стовпчику {j+1} дорівнює {tempmax}, мінімальний - {tempmin}. Їх добуток {res[j]}.");
                }
                else
                {
                    Console.WriteLine($"В стовпчику {j+1} немає максимального елемента, який би задовольняв умову.");
                }

            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                dimension dimen = new dimension();

                Console.OutputEncoding = System.Text.Encoding.UTF8;

                int[,] arrayx = dimension.massive(dimension.ndimension(), dimension.mdimension());
                dimension.Search(arrayx, dimension.key());
                dimension.multiply(arrayx);
                dimension.delegatee += dimension.ConditionCheck;
                Console.WriteLine("\nМасив після фільтру ConditionCheck: ");
                dimension.MyCalculation(arrayx, dimension.delegatee);
                Console.WriteLine("\nМасив після виконання умови лямбда-виразу: ");
                dimension.MyCalculation(arrayx, x => x % 10 != 0);


                Console.WriteLine();
                Console.WriteLine("Натисність '1', щоб відтворити програму заново, будь-що інше - для виходу.");
                string res = Console.ReadLine();

                if (res == "1")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }

}
