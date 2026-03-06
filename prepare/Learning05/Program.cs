using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("purple", 5);
        //Console.WriteLine($"Square Color: {square.GetColor()}");
        //Console.WriteLine($"Square Area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("blue", 10, 7);
        //Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}");
        //Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");

        Circle circle = new Circle("red", 6);
        //Console.WriteLine($"Circle Color: {circle.GetColor()}");
        //Console.WriteLine($"Circle Area: {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} | Area: {shape.GetArea()}");
        }
    }
}