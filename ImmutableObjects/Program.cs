using System;

// 1. روش: استفاده از `readonly` فیلدها
public class Car
{
    public readonly string Model;
    public readonly int Year;

    public Car(string model, int year)
    {
        Model = model;
        Year = year;
    }
}

// 2. روش: استفاده از Propertyهای `init` (از C# 9)
public class Book
{
    public string Title { get; init; }
    public string Author { get; init; }
}

// 3. روش: استفاده از رکوردها (Records) (از C# 9)
public record Point(int X, int Y);

// 4. روش: استفاده از کلاس‌های Immutable با Propertyهای فقط خواندنی (get-only)
public class Product
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

// 5. روش: استفاده از Structهای Immutable
public readonly struct Color
{
    public byte Red { get; }
    public byte Green { get; }
    public byte Blue { get; }

    public Color(byte red, byte green, byte blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }
}

// 6. روش: استفاده از کلاس‌های Immutable با Builder Pattern
public class Computer
{
    public string CPU { get; }
    public int RAM { get; }
    public int Storage { get; }

    private Computer(string cpu, int ram, int storage)
    {
        CPU = cpu;
        RAM = ram;
        Storage = storage;
    }

    public class Builder
    {
        private string _cpu;
        private int _ram;
        private int _storage;

        public Builder SetCPU(string cpu)
        {
            _cpu = cpu;
            return this;
        }

        public Builder SetRAM(int ram)
        {
            _ram = ram;
            return this;
        }

        public Builder SetStorage(int storage)
        {
            _storage = storage;
            return this;
        }

        public Computer Build()
        {
            return new Computer(_cpu, _ram, _storage);
        }
    }
}

// 7. روش: استفاده از کلاس‌های Immutable با روش Fluent Interface
public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }

    public Address() { }

    public Address SetStreet(string street)
    {
        return new Address { Street = street, City = this.City, PostalCode = this.PostalCode };
    }

    public Address SetCity(string city)
    {
        return new Address { Street = this.Street, City = city, PostalCode = this.PostalCode };
    }

    public Address SetPostalCode(string postalCode)
    {
        return new Address { Street = this.Street, City = this.City, PostalCode = postalCode };
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 1. استفاده از `readonly` فیلدها
        var car = new Car("Tesla Model S", 2023);
        // car.Model = "Tesla Model X"; // خطا: فیلدهای readonly قابل تغییر نیستند.

        // 2. استفاده از Propertyهای `init`
        var book = new Book { Title = "Clean Code", Author = "Robert C. Martin" };
        // book.Title = "Refactoring"; // خطا: Propertyهای init پس از مقداردهی اولیه قابل تغییر نیستند.

        // 3. استفاده از رکوردها
        var point = new Point(10, 20);
        // point.X = 30; // خطا: رکوردها Immutable هستند.

        // 4. استفاده از Propertyهای فقط خواندنی
        var product = new Product("Laptop", 1200.00m);
        // product.Name = "Desktop"; // خطا: Propertyهای فقط خواندنی قابل تغییر نیستند.

        // 5. استفاده از Structهای Immutable
        var color = new Color(255, 0, 0);
        // color.Red = 128; // خطا: Struct Immutable است.

        // 6. استفاده از Builder Pattern
        var computer = new Computer.Builder()
            .SetCPU("Intel i7")
            .SetRAM(16)
            .SetStorage(512)
            .Build();

        // 7. استفاده از Fluent Interface
        var address = new Address()
            .SetStreet("123 Main St")
            .SetCity("New York")
            .SetPostalCode("10001");
    }
}