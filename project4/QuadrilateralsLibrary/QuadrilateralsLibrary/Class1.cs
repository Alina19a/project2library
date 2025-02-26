using System;

namespace QuadrilateralsLibrary
{
    // Базовый класс
    public abstract class ConvexQuadrilateral
    {
        protected (double x, double y)[] vertices;

        public ConvexQuadrilateral((double x, double y)[] vertices)
        {
            if (vertices.Length != 4)
                throw new ArgumentException("Должно быть 4 вершины для выпуклого четырехугольника.");
            this.vertices = vertices;
        }

        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
        public abstract double[] CalculateSides();
        public abstract double[] CalculateDiagonals();
        public abstract double[] CalculateAngles();
    }

    // Класс Параллелограмм
    public class Parallelogram : ConvexQuadrilateral
    {
        public Parallelogram((double x, double y)[] vertices) : base(vertices) { }

        public override double CalculatePerimeter()
        {
            var sides = CalculateSides();
            return 2 * (sides[0] + sides[1]);
        }

        public override double CalculateArea()
        {
            var sides = CalculateSides();
            double height = Math.Abs(vertices[0].y - vertices[2].y); // Пример высоты
            return sides[0] * height; // Пример площади
        }

        public override double[] CalculateSides()
        {
            double side1 = Math.Sqrt(Math.Pow(vertices[1].x - vertices[0].x, 2) + Math.Pow(vertices[1].y - vertices[0].y, 2));
            double side2 = Math.Sqrt(Math.Pow(vertices[2].x - vertices[1].x, 2) + Math.Pow(vertices[2].y - vertices[1].y, 2));
            return new double[] { side1, side2 };
        }

        public override double[] CalculateDiagonals()
        {
            double diagonal1 = Math.Sqrt(Math.Pow(vertices[2].x - vertices[0].x, 2) + Math.Pow(vertices[2].y - vertices[0].y, 2));
            double diagonal2 = Math.Sqrt(Math.Pow(vertices[3].x - vertices[1].x, 2) + Math.Pow(vertices[3].y - vertices[1].y, 2));
            return new double[] { diagonal1, diagonal2 };
        }

        public override double[] CalculateAngles()
        {
            // Упрощенная версия, возвращающая 90 градусов для параллелограмма
            return new double[] { 90, 90, 90, 90 };
        }
    }

    // Класс Ромб
    public class Rhombus : ConvexQuadrilateral
    {
        public Rhombus((double x, double y)[] vertices) : base(vertices) { }

        public override double CalculatePerimeter()
        {
            var sides = CalculateSides();
            return 4 * sides[0];
        }

        public override double CalculateArea()
        {
            var diagonals = CalculateDiagonals();
            return (diagonals[0] * diagonals[1]) / 2;
        }

        public override double[] CalculateSides()
        {
            double side = Math.Sqrt(Math.Pow(vertices[1].x - vertices[0].x, 2) + Math.Pow(vertices[1].y - vertices[0].y, 2));
            return new double[] { side };
        }

        public override double[] CalculateDiagonals()
        {
            double diagonal1 = Math.Sqrt(Math.Pow(vertices[2].x - vertices[0].x, 2) + Math.Pow(vertices[2].y - vertices[0].y, 2));
            double diagonal2 = Math.Sqrt(Math.Pow(vertices[3].x - vertices[1].x, 2) + Math.Pow(vertices[3].y - vertices[1].y, 2));
            return new double[] { diagonal1, diagonal2 };
        }

        public override double[] CalculateAngles()
        {
            // Упрощенная версия, возвращающая 60 и 120 градусов для ромба
            return new double[] { 60, 120, 60, 120 };
        }
    }

    // Класс Квадрат
    public class Square : ConvexQuadrilateral
    {
        public Square((double x, double y)[] vertices) : base(vertices) { }

        public override double CalculatePerimeter()
        {
            var sides = CalculateSides();
            return 4 * sides[0];
        }

        public override double CalculateArea()
        {
            var sides = CalculateSides();
            return sides[0] * sides[0];
        }

        public override double[] CalculateSides()
        {
            double side = Math.Sqrt(Math.Pow(vertices[1].x - vertices[0].x, 2) + Math.Pow(vertices[1].y - vertices[0].y, 2));
            return new double[] { side };
        }

        public override double[] CalculateDiagonals()
        {
            double diagonal = Math.Sqrt(2) * CalculateSides()[0];
            return new double[] { diagonal, diagonal };
        }

        public override double[] CalculateAngles()
        {
            // Все углы квадрата равны 90 градусов
            return new double[] { 90, 90, 90, 90 };
        }

        public override bool Equals(object obj)
        {
            if (obj is Square square)
            {
                return CalculateArea() == square.CalculateArea();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return CalculateArea().GetHashCode();
        }
    }
}