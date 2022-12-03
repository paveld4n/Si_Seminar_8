// Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, 
// на пересечении которых расположен наименьший элемент массива.

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

// int minVolum = FindMinVolume(array);
// Console.WriteLine($"Минимальное значение массива = {minVolum}");
Console.WriteLine();

(int, int) indexes = FindMinVolume(array);
int[,] result  = DeleteRowEndColumn(array, indexes.Item1, indexes.Item2);
Console.WriteLine($"Минимальное число на позиции [{indexes.Item1}, {indexes.Item2}]");
Print2DArray(result);

(int, int) FindMinVolume(int[,] aramin) // с Кортеже
{
    int indexI = 0;
    int indexJ = 0;
    int min = aramin[0, 0];
    for (int i = 0; i < aramin.GetLength(0); i++)
    {
        for (int j = 0; j < aramin.GetLength(1); j++)
        {
            if(aramin[i, j] < min)
            {
                min = aramin[i, j];
                indexI = i;
                indexJ = j;
            }
        }
    }
    return (indexI, indexJ);
}

int[,] DeleteRowEndColumn(int[,] array, int indexRow, int indexColumn)
{
    int[,] result = new int [array.GetLength(0) - 1, array.GetLength(1) - 1];
    int row = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int column = 0;
        if(i != indexRow)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if(j != indexColumn)
                {   
                    result[row, column] = array[i, j];
                    column++;
                }
            }
            row++;
            column = 0;
        }
    }
    return result;
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