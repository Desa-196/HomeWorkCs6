/*
По целочисленным координатам вершин треугольника (x1,y1), (x2,y2) и (x3,y3) требуется вычислить его площадь.

Входные данные
Входной файл INPUT.TXT содержит 6 целых чисел x1,y1,x2,y2,x3,y3 – координаты вершин треугольника. 
Все числа не превышают 106 по абсолютной величине.

Выходные данные
В выходной файл OUTPUT.TXT выведите точное значение площади заданного треугольника.
*/
using System.Drawing;

int console_read_int(string text, int min, int max)
{
    Console.Write(text);

    int read_int;

    while (true)
    {

        if (int.TryParse(Console.ReadLine(), out read_int))
        {
            if (read_int >= min && read_int <= max)
            {
                return read_int;
            }
            else
            {
                Console.Write($"Число должно находиться в пределах от {min} до {max}, повторите попытку ввода:");
            }
        }
        else
        {
            Console.Write("Введено некорректное число, повторите попытку ввода:");
        }

    }
}
//Читает X и Y координаты из консоли и возвращает структуру Point
Point ReadPointFromConsole(int numberPoint)
{
    Point Point = new Point();
    Point.X = console_read_int($"Введите координату X для точки {numberPoint}: ", -106, 106);
    Point.Y = console_read_int($"Введите координату Y для точки {numberPoint}: ", -106, 106);
    return Point;
}
//Возвращает длинну отрезка заданного двумя точками
double LengthLine(Point Point1, Point Point2)
{
    return Math.Sqrt(Math.Pow((Point1.X - Point2.X), 2) + Math.Pow((Point1.Y - Point2.Y), 2));
}

//Возвращает площадь треугольника
double GetSquare(Point[] PointArray)
{
    double a = LengthLine(PointArray[0], PointArray[1]);
    double b = LengthLine(PointArray[1], PointArray[2]);
    double c = LengthLine(PointArray[2], PointArray[0]);

    double p = (a + b + c) / 2;

    return Math.Sqrt(p * (p - a) * (p - c) * (p - c));

}
//Проверяет, является ли фигура треугольником
bool IsTriangle(Point[] PointArray)
{
    double a = LengthLine(PointArray[0], PointArray[1]);
    double b = LengthLine(PointArray[1], PointArray[2]);
    double c = LengthLine(PointArray[2], PointArray[0]);

    return a + b > c && b + c > a && c + a > b;
}


//Создаем массив точек
Point[] PointArray = new Point[3];

//Заполняем массив точек из консоли
for (int i = 0; i < PointArray.Length; i++)
{
    PointArray[i] = ReadPointFromConsole(i);
}

//Если фигура является треугольником, выводим площадь.
if(IsTriangle(PointArray))
{   
    Console.WriteLine(Math.Round(GetSquare(PointArray), 2));
}
else
{
    Console.WriteLine("Не является треугольником.");
}