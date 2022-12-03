// Задать двумерный массив. Написать программу которая заменит строки на столбцы
// В случае если это невозможно - вывести сообщение для пользователя.

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

int[,] num = ExchangeColumnOnRow(array);
Print2DArray(num);

int[,] ExchangeColumnOnRow(int[,] array)
{
    int[,] numbers = new int[array.GetLength(1), array.GetLength(0)];
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            // int temp = numbers[i, j];
            numbers[i, j] = array[j, i]; 
            // numbers[j, i] = temp;
                        
        }
    }
    return numbers;
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