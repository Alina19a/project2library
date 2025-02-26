using System;
using QuadrilateralsLibrary;

class Program
{
    static void Main()
    {
        // Создаем массив из объектов базового класса
        ConvexQuadrilateral[] quadrilaterals = new ConvexQuadrilateral[]
        {
            new Parallelogram(new (double, double)[] { (0, 0), (4, 0), (5, 3), (1, 3) }),
            new Rhombus(new (double, double)[] { (0, 0), (2, 2), (4, 0), (2, -2) }),
            new Square(new (double, double)[] { (0, 0), (2, 0), (2, 2), (0, 2) })
        };

        // Выводим информацию о каждой фигуре
        foreach (var quad in quadrilaterals)
        {
            Console.WriteLine($"Фигура: {quad.GetType().Name}");
            Console.WriteLine($"Периметр: {quad.CalculatePerimeter()}");
            Console.WriteLine($"Площадь: {quad.CalculateArea()}");
            Console.WriteLine($"Стороны: {string.Join(", ", quad.CalculateSides())}");
            Console.WriteLine($"Диагонали: {string.Join(", ", quad.CalculateDiagonals())}");
            Console.WriteLine($"Углы: {string.Join(", ", quad.CalculateAngles())}");
            Console.WriteLine();
        }

        // Пример сравнения квадратов
        Square square1 = new Square(new (double, double)[] { (0, 0), (2, 0), (2, 2), (0, 2) });
        Square square2 = new Square(new (double, double)[] { (1, 1), (3, 1), (3, 3), (1, 3) });

        Console.WriteLine($"Квадраты равны: {square1.Equals(square2)}");
    }
}