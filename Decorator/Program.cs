using System;

namespace DecoratorPattern
{
    // Base class for reports
    abstract class Report
    {
        public abstract void Generate();  // Method to generate report
    }

    class SimpleReport : Report
    {
        public override void Generate()
        {
            Console.WriteLine("Generating Simple Report...");
        }
    }

    // Abstract decorator for adding features to reports
    abstract class ReportDecorator : Report
    {
        protected Report report;  // Hold reference to the original report

        // Constructor to set the report for the decorator
        public ReportDecorator(Report r)
        {
            report = r;
        }

        public override void Generate()
        {
            if (report != null)
            {
                report.Generate();  // Refer to Generate method from the original report
            }
        }
    }

    // Decorator for adding filter to the report
    class FilterReportDecorator : ReportDecorator
    {
        public FilterReportDecorator(Report r) : base(r) { }

        public override void Generate()
        {
            base.Generate();  // First generate the simple report
            Console.WriteLine("Applying filters to the report...");  // Add filter
        }
    }

    // Decorator for converting report to PDF format
    class PdfReportDecorator : ReportDecorator
    {
        public PdfReportDecorator(Report r) : base(r) { }

        public override void Generate()
        {
            base.Generate();  // First generate the simple report
            Console.WriteLine("Converting the report to PDF...");  // Convert to PDF
        }
    }

    // Main class to run the program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Decorator Pattern Demo for Report Generation***\n");

            // Simple report without any decorators
            SimpleReport simpleReport = new SimpleReport();

            // Use filter decorator
            FilterReportDecorator filterDecorator = new FilterReportDecorator(simpleReport);
            filterDecorator.Generate();  // Generate report with filter

            // Use PDF decorator
            PdfReportDecorator pdfDecorator = new PdfReportDecorator(filterDecorator);  // Add filter decorator to PDF decorator
            pdfDecorator.Generate();  // Generate report with filter and convert to PDF

            Console.ReadKey();
        }
    }
}

/*
Explanation of the principles and improvements:

1\. **Objective of the Decorator Pattern**:
   Decorator is a structural design pattern that allows you to dynamically add behaviors to objects without altering the existing code. Key principles include:
   - An abstract base class or interface (Component) that defines the behavior.
   - A Concrete Component class that implements the base class or interface.
   - One or more decorators that extend the behavior of the Concrete Component dynamically.

2\. **Base Class or Component**:
   The `Report` class serves as the abstract base class, defining the `Generate` method to be implemented by all reports, making it an appropriate starting point for the Decorator pattern.

3\. **Concrete Component**:
   The `SimpleReport` class implements the `Report` class and serves as the core component that generates a simple report.

4\. **Abstract Decorator**:
   The `ReportDecorator` class extends the `Report` class and holds a reference to the `Report` object. The decorator's `Generate` method calls the `Generate` method of the referenced `Report` object. This is a correct implementation of the Decorator pattern.
*/