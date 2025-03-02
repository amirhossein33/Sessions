using System;

namespace DecoratorPattern
{
    // کلاس پایه برای گزارش‌ها
    abstract class Report
    {
        public abstract void Generate();  // متدی برای تولید گزارش
    }

    // گزارش ساده (بدون دکوراتور)
    class SimpleReport : Report
    {
        public override void Generate()
        {
            Console.WriteLine("Generating Simple Report...");
        }
    }

    // دکوراتور انتزاعی برای افزودن ویژگی به گزارش
    abstract class ReportDecorator : Report
    {
        protected Report report;  // نگهداری ارجاع به گزارش اصلی

        // ست کردن گزارش برای دکوراتور
        public void SetReport(Report r)
        {
            report = r;
        }

        public override void Generate()
        {
            if (report != null)
            {
                report.Generate();  // ارجاع به متد Generate از گزارش اصلی
            }
        }
    }

    // دکوراتور برای افزودن فیلتر به گزارش
    class FilterReportDecorator : ReportDecorator
    {
        public override void Generate()
        {
            base.Generate();  // ابتدا گزارش ساده را تولید می‌کنیم
            Console.WriteLine("Applying filters to the report...");  // افزودن فیلتر
        }
    }

    // دکوراتور برای چاپ گزارش به فرمت PDF
    class PdfReportDecorator : ReportDecorator
    {
        public override void Generate()
        {
            base.Generate();  // ابتدا گزارش ساده را تولید می‌کنیم
            Console.WriteLine("Converting the report to PDF...");  // تبدیل به PDF
        }
    }

    // کلاس اصلی برای اجرای برنامه
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Decorator Pattern Demo for Report Generation***\n");

            // گزارش ساده بدون هیچ دکوراتوری
            SimpleReport simpleReport = new SimpleReport();

            // استفاده از دکوراتور فیلتر
            FilterReportDecorator filterDecorator = new FilterReportDecorator();
            filterDecorator.SetReport(simpleReport);
            filterDecorator.Generate();  // تولید گزارش با فیلتر

            // استفاده از دکوراتور PDF
            PdfReportDecorator pdfDecorator = new PdfReportDecorator();
            pdfDecorator.SetReport(filterDecorator);  // افزودن دکوراتور فیلتر به دکوراتور PDF
            pdfDecorator.Generate();  // تولید گزارش با فیلتر و تبدیل به PDF

            Console.ReadKey();
        }
    }
}
