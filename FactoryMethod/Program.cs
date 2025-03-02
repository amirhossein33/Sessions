using System;

namespace FactoryMethodPattern
{
    // 1. اینترفیس مشترک برای همه اشکال هندسی
    public interface IShape
    {
        void Draw();
        void Area();
    }

    // 2. پیاده‌سازی کلاس‌های محصول (Concrete Products)
    public class Circle : IShape
    {
        public void Draw() => Console.WriteLine("Drawing a Circle.");
        public void Area() => Console.WriteLine("Formula: π × r²\n");
    }

    public class Rectangle : IShape
    {
        public void Draw() => Console.WriteLine("Drawing a Rectangle.");
        public void Area() => Console.WriteLine("Formula: width × height\n");
    }

    public class Triangle : IShape
    {
        public void Draw() => Console.WriteLine("Drawing a Triangle.");
        public void Area() => Console.WriteLine("Formula: 0.5 × base × height\n");
    }

    // 3. کلاس کارخانه انتزاعی (Abstract Factory) با متد MakeShape()
    public abstract class ShapeFactory
    {
        public IShape MakeShape()
        {
            Console.WriteLine("\nShapeFactory.MakeShape() - Enforcing factory rules.");
            IShape shape = CreateShape(); // متد Factory که زیرکلاس آن را پیاده‌سازی می‌کند
            shape.Draw();
            shape.Area();
            return shape;
        }

        // متد انتزاعی که زیرکلاس‌ها باید پیاده‌سازی کنند
        public abstract IShape CreateShape();
    }

    // 4. پیاده‌سازی کارخانه‌های خاص (Concrete Factories)
    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape() => new Circle();
    }

    public class RectangleFactory : ShapeFactory
    {
        public override IShape CreateShape() => new Rectangle();
    }

    public class TriangleFactory : ShapeFactory
    {
        public override IShape CreateShape() => new Triangle();
    }

   
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Factory Method Pattern Demo - Geometric Shapes***\n");

            // ایجاد کارخانه دایره
            ShapeFactory circleFactory = new CircleFactory();
            IShape aCircle = circleFactory.MakeShape(); // استفاده از MakeShape()

            // ایجاد کارخانه مستطیل
            ShapeFactory rectangleFactory = new RectangleFactory();
            IShape aRectangle = rectangleFactory.MakeShape(); // استفاده از MakeShape()

            // ایجاد کارخانه مثلث
            ShapeFactory triangleFactory = new TriangleFactory();
            IShape aTriangle = triangleFactory.MakeShape(); // استفاده از MakeShape()

            Console.ReadKey();
        }
    }
}
