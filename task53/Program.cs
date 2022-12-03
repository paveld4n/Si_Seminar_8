// Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

Console.WriteLine("Введите количество строк - m");
bool isParsedM = int.TryParse(Console.ReadLine(), out int m);

Console.WriteLine("Введите количество столбцов - n");
bool isParsedN = int.TryParse(Console.ReadLine(), out int n);

if(!isParsedM || !isParsedN)
{
    Console.WriteLine("Ошибочный ввод! Не цифра! ПереВВедите!");
    return;
}

int[,] array = CreateRandom2DArray(m, n);
Print2DArray(array);
Console.WriteLine(); // визуально разделить
SwapFirstAndLastRow(array);
Print2DArray(array);

void SwapFirstAndLastRow(int[,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        int temp = array[0, i];
        array[0, i] = array[array.GetUpperBound(0), i]; // возвращает послежний индекс
        array[array.GetUpperBound(0), i] = temp;
    }
}

int[,] CreateRandom2DArray(int m, int n)
{
    int[,] array = new int[m, n];

    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(1, 9);
        }
    }
    return array;
}

void Print2DArray (int [,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}