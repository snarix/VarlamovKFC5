using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Transactions;

static bool RectDouble(in double A)
{
    return (A > 0 && A % 2 == 0);
}

static int[,] RectCulc(int[] arr)
{
    var n = (int)Math.Sqrt(arr.Length);
    var matrix = new int[n, n];

    int m = n / 2 + n % 2,
        len = n,
        count = 0;

    for (int i = 0; i < m; i++)
    {
        // Верх
        for (int j = 0; j < len; j++)
        {
            matrix[i, i + j] = arr[count++];
        }

        // Право
        for (int j = 1; j < len; j++)
        {
            matrix[i + j, n - i - 1] = arr[count++];
        }

        len -= 2;
        // Низ
        for (int j = len; j >= 0; j--)
        {

            matrix[n - i - 1, i + j] = arr[count++];
        }

        // Лево
        for (int j = len; j >= 1; j--)
        {
            matrix[i + j, i] = arr[count++];
        }
    }
    return matrix;
}
static string RectCultString(string inputString)
{
    char[] symbolsArray = inputString.ToCharArray();

    for (int i = 2; i < symbolsArray.Length; i += 3)
    {
        if (Char.IsLetter(symbolsArray[i]))
        {
            symbolsArray[i] = Char.ToUpper(symbolsArray[i]);
        }
    }

    string resultString = new string(symbolsArray);

    return resultString;
}

try
{
    int p;
    do
    {
        Console.WriteLine("Выберите задание от 1 до 3, чтобы выйти введите 0");
        Console.Write("Задание - ");

        p = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        switch (p)
        {
            case 0:
                {
                    Console.WriteLine("Выход осуществлен");
                }
                break;

            case 1:
                {
                    Console.Write("Введите число - ");
                    int x = Convert.ToInt32(Console.ReadLine());

                    if (RectDouble(x))
                        Console.WriteLine("Число " + x + " положительное и четное.");
                    else
                        Console.WriteLine("Число " + x + " не подходит под условия.");

                    Console.WriteLine();
                }
                break;

            case 2:
                {
                    Console.Write("Введите размер массива - ");
                    int X = Convert.ToInt32(Console.ReadLine());

                    int[,] mass = new int[X, X];
                    Random rand = new Random();

                    for (int i = 0; i < X; i++)
                    {
                        for (int j = 0; j < X; j++)
                        {
                            mass[i, j] = rand.Next(10);
                        }
                    }

                    Console.WriteLine("Получилась следующая матрица: ");
                    for (int i = 0; i < X; i++)
                    {
                        for (int j = 0; j < X; j++)
                        {
                            Console.Write(String.Format("{0, 4}", mass[i, j].ToString()));
                        }
                        Console.WriteLine();
                    }

                    // создаем массив
                    int k = 0;
                    int[] ar = new int[mass.Length];

                    for (int i = 0; i < mass.GetLength(0); i++)
                    {
                        for (int j = 0; j < mass.GetLength(1); j++)
                        {
                            ar[k++] = mass[i, j];
                        }
                    }

                    // сортируем массив
                    Array.Sort(ar);
                    Array.Reverse(ar);

                    // преобразуем матрицу
                    mass = RectCulc(ar);

                    Console.WriteLine("Результат: ");
                    for (int i = 0; i < X; i++)
                    {
                        for (int j = 0; j < X; j++)
                        {
                            Console.Write(String.Format("{0, 4}", mass[i, j].ToString()));
                        }
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                }
                break;

            case 3:
                {
                    Console.WriteLine("Введите строку :");
                    string str = Convert.ToString(Console.ReadLine());
                    Console.WriteLine();

                    str = RectCultString(str);
                    Console.WriteLine(str);

                    Console.WriteLine();
                }
                break;

            default:
                Console.WriteLine("Неверный номер задания");
                break;
        }
    }
    while (p != 0);
}
catch
{
    Console.WriteLine("Вводите корректные данные!");
    Console.ReadLine();
}