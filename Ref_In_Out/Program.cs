using System;
using System.Collections.Generic;

class Program
{
    /*
     ref برای ارسال مقدار و تغییر مستقیم آن درون متد استفاده می‌شود. 
      ref نیاز دارد که متغیر قبل از ارسال مقداردهی اولیه شده باشد.

     out مقداردهی را درون متد اجباری می‌کند.
     out نیازی به مقداردهی اولیه ندارد اما حتماً باید داخل متد مقداردهی شود
     in مقدار را فقط خواندنی می‌کند و تغییر آن درون متد مجاز نیست.
   
    */
    static Dictionary<int, string> users = new()
    {
        { 1, "Ali" },
        { 2, "Reza" },
        { 3, "Amir" }
    };

    static void Main()
    {
        string userName;

        GetUserById(out userName, 1);
        Console.WriteLine($"User before update: {userName}");

        // 2️⃣ Update user name (using ref)
        UpdateUserName(ref userName);
        Console.WriteLine($"User after update: {userName}");

        // 3️⃣ Print user info (using in)
        PrintUserInfo(userName);
    }

    // Using 'out' to get user from DB
    static void GetUserById(out string name, int id)
    {
        if (users.TryGetValue(id, out name))
        {
            Console.WriteLine("User found in database.");
        }
        else
        {
            name = "Unknown";
            Console.WriteLine("User not found.");
        }
    }

    // Using 'ref' 
    static void UpdateUserName(ref string name)
    {
        Console.WriteLine("Enter new name for the user:");
        string newName = Console.ReadLine();
        name = newName;
    }

    // Using 'in' 
    static void PrintUserInfo(in string name)
    {
        Console.WriteLine($"Final user name: {name}");
        // name = "Farhad";  Error
    }
}
