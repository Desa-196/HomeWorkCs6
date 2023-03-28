/*
Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
значения b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
*/
const int COEFFICIENT = 0;
const int CONSTANT = 1;

double ReadIntFromConsole(string message)
{
    double console_int = 0;

    Console.Write($"{message}: ");

    while(true)
    {
        if( double.TryParse(Console.ReadLine(), out console_int ) )
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
double[] ReadParameterFunctionFronConsole(int number_line)
{
    double[] parameter_array = new double[2];
    parameter_array[COEFFICIENT] = ReadIntFromConsole($"Введите коэффициент для прямой {number_line}");
    parameter_array[CONSTANT] = ReadIntFromConsole($"Введите константу для прямой {number_line}");
    return parameter_array;
}

string CheckDataLines(double[] parameter_line1, double[] parameter_line2)
{
    if(parameter_line1[COEFFICIENT] == parameter_line2[COEFFICIENT])
    {
        if(parameter_line1[CONSTANT] == parameter_line2[CONSTANT])
        {
            return "Прямые совпадают.";
        }
        else
        {
            return "Прямые параллельны.";
        }
    }
    else
    {
        return null;
    }

}

double[] CoordinateLineIntersection(double[] parameter_line1, double[] parameter_line2)
{
    double[] coordinate = new double[2];
    coordinate[0] = (parameter_line1[CONSTANT] - parameter_line2[CONSTANT])/
    (parameter_line2[COEFFICIENT] - parameter_line1[COEFFICIENT]);
    coordinate[1] = parameter_line1[CONSTANT]*coordinate[0] + parameter_line1[CONSTANT];
    return coordinate;
}

double[] parameter_line1 = ReadParameterFunctionFronConsole(1);
double[] parameter_line2 = ReadParameterFunctionFronConsole(2);


string result_check = CheckDataLines(parameter_line1, parameter_line2);
if( result_check != null)
{
    Console.WriteLine(result_check);
}
else
{
    double[] coordinate_intersection = CoordinateLineIntersection(parameter_line1, parameter_line2);
    Console.WriteLine($"Координаты пересечения прямых: X={coordinate_intersection[0]}, Y={coordinate_intersection[1]}");
}





