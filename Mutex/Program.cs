using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class Program
{
    static readonly Mutex mutex = new(); 

   
    public static HashSet<string> loggedInUsers = new();

    public static void LoginUser(object username)
    {
        Console.WriteLine($" User {username} is trying to log in...");

        if (mutex.WaitOne(TimeSpan.FromSeconds(3))) 
        {
            try
            {
                if (!loggedInUsers.Contains((string)username))
                {
                    Console.WriteLine($" User {username} has successfully logged in.");
                    loggedInUsers.Add((string)username);
                }
                else
                {
                    Console.WriteLine($" User {username} is already logged in.");
                }
            }
            finally
            {
                mutex.ReleaseMutex(); 
            }
        }
        else
        {
            Console.WriteLine($" User {username} could not log in (Timeout).");
        }
    }

    public static void Main()
    {
        Console.WriteLine(" Mutex Synchronization Example\n");
        
        Thread[] users = new Thread[5];

        for (int i = 0; i < 5; i++)
        {
            users[i] = new Thread(LoginUser);
            users[i].Start("Ali"); 
        }

        foreach (var user in users)
        {
            user.Join(); 
        }

        Console.WriteLine("\n Mutex Demo Finished!");
    }
}
