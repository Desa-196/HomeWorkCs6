/*
Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3

*/

int read_int_from_console(string message)
{
    int console_int = 0;

    Console.Write($"{message}: ");

    while(true)
    {
        if( int.TryParse(Console.ReadLine(), out console_int ) )
        {
            break;
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }
    }
    return console_int;

}

void fill_array_from_console(int[] array)
{
    for(int i=0; i < array.Length; i++)
    {
        array[i] = read_int_from_console($"Введите {i}-й элемент массива");
    }
}

int count_positive_numbers_in_array(int[] array)
{
    int count = 0;
    foreach(int array_element in array)
    {
        if(array_element > 0) count++;
    }
    return count;
}

int[] array = new int[read_int_from_console("Введите кол-во элементов массива")];
fill_array_from_console(array);
Console.WriteLine($"Количество элементов больше 0 равно: {count_positive_numbers_in_array(array)}");