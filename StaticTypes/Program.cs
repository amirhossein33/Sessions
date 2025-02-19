using System.Collections;

public class RefTypeAndValueType
{
    public static void Main()
    {
        int employeeId = 123;
        object boxedEmployeeId = employeeId; 

       
        int unboxedEmployeeId = (int)boxedEmployeeId; 
        Console.WriteLine("Unboxed Employee ID: " + unboxedEmployeeId);

        
        Employee employee = new() { Name = "Farhad", Age = 30 };
        object boxedEmployee = employee; 
        Console.WriteLine("\nBoxed Employee: " + boxedEmployee);

        // UnBoxing custom structure
        Employee unboxedEmployee = (Employee)boxedEmployee;
        Console.WriteLine("Unboxed Employee - Name: " + unboxedEmployee.Name + ", Age: " + unboxedEmployee.Age);

        // Boxing ArrayList
        ArrayList employeeList =
        [
            employeeId, // Boxing: اضافه کردن مقدار value type به ArrayList
        ];

        // Retrieving value from ArrayList (UnBoxing)
        int retrievedEmployeeId = (int)employeeList[0]; // UnBoxing: تبدیل object به value type
        Console.WriteLine("\nRetrieved Employee ID from ArrayList: " + retrievedEmployeeId);

      
    }

    public struct Employee
    {
        public string Name;
        public int Age;

    }
}