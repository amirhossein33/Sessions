using System;

namespace FactoryMethodPattern
{
    // 1. Common interface for all geometric shapes
    public interface IShape
    {
        void Draw();
        void Area();
    }

    // 2. Concrete Product classes
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

    // 3. Abstract Factory class with MakeShape() method
    public abstract class ShapeFactory
    {
        public IShape MakeShape()
        {
            Console.WriteLine("\nShapeFactory.MakeShape() - Enforcing factory rules.");
            IShape shape = CreateShape(); // Factory method implemented by subclasses
            shape.Draw();
            shape.Area();
            return shape;
        }

        // Abstract method to be implemented by subclasses
        public abstract IShape CreateShape();
    }

    // 4. Concrete Factory classes
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

            // Create Circle factory
            ShapeFactory circleFactory = new CircleFactory();
            IShape aCircle = circleFactory.MakeShape();

            // Create Rectangle factory
            ShapeFactory rectangleFactory = new RectangleFactory();
            IShape aRectangle = rectangleFactory.MakeShape();

            // Create Triangle factory
            ShapeFactory triangleFactory = new TriangleFactory();
            IShape aTriangle = triangleFactory.MakeShape();

            Console.ReadKey();
        }
    }
}
