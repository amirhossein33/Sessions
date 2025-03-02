using System;
using System.Collections.Generic;

// 📌 ۱- اینترفیس محصولاتی که می‌توانند از Visitor استفاده کنند
interface IProduct
{
    void Accept(ITaxVisitor visitor);
    double Price { get; }
}

// 📌 ۲- کلاس‌های مختلف محصولات
class Book : IProduct
{
    public double Price { get; }
    public Book(double price) => Price = price;
    public void Accept(ITaxVisitor visitor) => visitor.Visit(this);
}

class Electronics : IProduct
{
    public double Price { get; }
    public Electronics(double price) => Price = price;
    public void Accept(ITaxVisitor visitor) => visitor.Visit(this);
}

class Clothing : IProduct
{
    public double Price { get; }
    public Clothing(double price) => Price = price;
    public void Accept(ITaxVisitor visitor) => visitor.Visit(this);
}

// 📌 ۳- اینترفیس Visitor برای محاسبه مالیات
interface ITaxVisitor
{
    void Visit(Book book);
    void Visit(Electronics electronics);
    void Visit(Clothing clothing);
}

// 📌 ۴- پیاده‌سازی Visitor برای محاسبه مالیات
class TaxCalculator : ITaxVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"📚 Book: ${book.Price} → Tax: ${book.Price * 0}");
    }

    public void Visit(Electronics electronics)
    {
        Console.WriteLine($"🔌 Electronics: ${electronics.Price} → Tax: ${electronics.Price * 0.15}");
    }

    public void Visit(Clothing clothing)
    {
        Console.WriteLine($"👕 Clothing: ${clothing.Price} → Tax: ${clothing.Price * 0.10}");
    }
}

// 📌 ۵- اجرای برنامه
class Program
{
    static void Main()
    {
        Console.WriteLine("*** Visitor Pattern - Tax Calculation ***\n");

        // لیست محصولات فروشگاه
        List<IProduct> products = new List<IProduct>
        {
            new Book(50),
            new Electronics(500),
            new Clothing(100)
        };

        // محاسبه مالیات با Visitor
        ITaxVisitor taxVisitor = new TaxCalculator();
        foreach (var product in products)
        {
            product.Accept(taxVisitor);
        }

        Console.ReadLine();
    }
}
