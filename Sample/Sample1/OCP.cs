using System.Data;

namespace SOLID.Sample1
{
    //False
    public class FileExporter
    {
        public void ExportToCsv(string filePath, DataTable data)
        {
            // Code to export data to a CSV file.
        }
    }
}
//True
public abstract class FileExporter
{
    public abstract void Export(string filePath, DataTable data);
}
public class CsvFileExporter : FileExporter
{
    public override void Export(string filePath, DataTable data)
    {
        // Code logic to export data to a CSV file.
    }
}
public class ExcelFileExporter : FileExporter
{
    public override void Export(string filePath, DataTable data)
    {
        // Code logic to export data to an Excel file.
    }
}
public class JsonFileExporter : FileExporter
{
    public override void Export(string filePath, DataTable data)
    {
        // Code logic to export data to a JSON file.
    }
}
