/*
Дана строка, состоящая из N попарно различных символов. Требуется вывести все перестановки символов данной строки.

Входные данные
Входной файл INPUT.TXT содержит строку, состоящую из N символов (1 ≤ N ≤ 8), символы - буквы английского алфавита и цифры.

Выходные данные
В выходной файл OUTPUT.TXT выведите в каждой строке по одной перестановке. Перестановки можно выводить в любом порядке. 
Повторений и строк, не являющихся перестановками исходной, быть не должно.
*/
HashSet<string> hashSetString = new HashSet<string>();


void Perestanovka(string changeString)
{
    for (int i = 0; i < changeString.Length; i++)
    {
        //Создаем массив символов из переданной строки для возможности изменять в ней определенные позиции
        char[] charArray = changeString.ToCharArray();
        //Если меняем символы не крайние
        if (i < changeString.Length - 1)
        {
            charArray[i] = changeString[i + 1];
            charArray[i + 1] = changeString[i];
        }
        //Если первый с последним
        else
        {
            charArray[i] = changeString[0];
            charArray[0] = changeString[i];
        }
        //Если в Хеш массиве ещё нет такой перестановки, то добавляем ее и отправляем в эту же функцию для поиска дальнейших перестановок,
        // в противном случае ничего не делаем.
        if (!hashSetString.Contains(new string(charArray)))
        {
            hashSetString.Add(new string(charArray));
            Perestanovka(new string(charArray));
        }

    }
}

//Чтение строки из консоли с проверкой на кол-во символов.
string ConsoleReadString()
{
    string ConsoleString  = string.Empty;
    Console.Write("Введите строку, состоящую из N попарно различных символов: ");
    while(true)
    {
        ConsoleString = Console.ReadLine()!;
        if(ConsoleString != null && ConsoleString.Length >= 1 && ConsoleString.Length <= 8) break;
        else
        {
            Console.Write("Необходимое кол-во символов от 1 до 8 включительно, повторите ввод: ");
        }
    }
    
    return ConsoleString;
}


    Perestanovka(ConsoleReadString());
    
    //Выводим массив с возможными перестановками
    Console.WriteLine(string.Join("\n", hashSetString));
    //Выводим кол-во возможных перестановок
    Console.WriteLine($"Количество перестановок: {hashSetString.Count}");

