// Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, 
// сколько раз встречается элемент входных данных.

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

int[,] number = CountSimbols(array);
Print2DArray(number);

int [,] CountSimbols(int[,] array)
{
    int[,] result = new int[2, array.Length];
    int index = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int checkFind = Check(result, array[i, j]);
            if(checkFind != -1)
            {
                result[1, checkFind] ++;
            }
            else
            {
                result[0, index] = array[i, j];
                result[1, index] = 1;
                index++;
            }
        }
    }
    
    return Trim(result);
}

int[,] Trim(int[,] araTrim)
{
    int index = araTrim.GetLength(1) - 1;
    for (int i = 0; i < araTrim.GetLength(1); i++)
    {
        if(araTrim[1, i] == 0)
        {
            index = i; // нашли i c которого начинаются нулевые значения. (потом создали новый массив с длинной до i)
            break;
        }
    }
    int[,] result = new int[2, index]; // создали новый массив с длинной до i после которого начинаются нули
    for (int i = 0; i < result.GetLength(1); i++)
    {
        result[0, i] = araTrim[0, i];
        result[1, i] = araTrim[1, i];
    }
    return result;
}
int Check(int[,] array, int num)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        if(array[0, i] == num)
        {
            return i;
        }
    }
    return -1;
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