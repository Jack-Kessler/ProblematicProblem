using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            while (cont == true)
            {
                Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
                string str = Console.ReadLine().ToLower();
                while (str != "yes" && str != "no")
                {
                    Console.WriteLine("Invalid Entry. Enter \"Yes\" or \"No\".\n");
                    str = Console.ReadLine().ToLower();
                }
                bool cont = str == "yes" ? true : false;
                Console.WriteLine();
                if (cont == false) 
                {
                    break;
                }
                else
                {
                    Console.Write("We are going to need your information first! What is your name? ");
                    string userName = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("What is your age? ");
                    int userAge = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Would you like to see the current list of activities? Sure/No Thanks:\n");
                    str = Console.ReadLine().ToLower();
                    while (str != "sure" && str != "no thanks")
                    {
                        Console.WriteLine("\nInvalid Entry. Enter \"Sure\" or \"No Thanks\".\n");
                        str = Console.ReadLine().ToLower();
                    }
                    bool seeList = str == "sure" ? true : false;
                    if (seeList == false)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity}, ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine("\n");
                        Console.Write("\nWould you like to add any activities before we generate one? yes/no:\n");
                        str = Console.ReadLine().ToLower();
                        while (str != "yes" && str != "no")
                        {
                            Console.WriteLine("\nInvalid Entry. Enter \"yes\" or \"no\".\n");
                            str = Console.ReadLine().ToLower();
                        }
                        bool addToList = str == "yes" ? true : false;
                        Console.WriteLine();
                        while (addToList == true)
                        {
                            Console.Write("\nWhat would you like to add?\n");
                            string userAddition = Console.ReadLine();
                            activities.Add(userAddition);
                            foreach (string activity in activities)
                            {
                                Console.Write($"{activity} ");
                                Thread.Sleep(250);
                            }
                            Console.WriteLine();
                            Console.WriteLine("\nWould you like to add more? yes/no:\n");
                            str = Console.ReadLine().ToLower();
                            while (str != "yes" && str != "no")
                            {
                                Console.WriteLine("\nInvalid Entry. Enter \"yes\" or \"no\".\n");
                                str = Console.ReadLine().ToLower();
                            }
                            addToList = str == "yes" ? true : false;
                        }
                        while (cont == true)
                        {
                            Console.Write("Connecting to the database");
                            for (int i = 0; i < 10; i++)
                            {
                                Console.Write(". ");
                                Thread.Sleep(100);
                            }
                            Console.WriteLine();
                            Console.Write("Choosing your random activity");
                            for (int i = 0; i < 9; i++)
                            {
                                Console.Write(". ");
                                Thread.Sleep(100);
                            }
                            Console.WriteLine();
                            Random rnd = new Random();
                            int randomNumber = rnd.Next(activities.Count);
                            string randomActivity = activities[randomNumber];
                            if (userAge < 21 && randomActivity == "Wine Tasting")
                            {
                                Console.WriteLine($"\nOh no! Looks like you are too young to do {randomActivity}\n");
                                Console.WriteLine("Pick something else!\n");
                                activities.Remove(activities[activities.Count - 1]);
                                randomNumber = rnd.Next(activities.Count);
                                randomActivity = activities[randomNumber];
                            }
                            Console.Write($"\nAh got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo:\n");

                            str = Console.ReadLine().ToLower();
                            while (str != "keep" && str != "redo")
                            {
                                Console.WriteLine("\nInvalid Entry. Enter \"Keep\" or \"Redo\".\n");
                                str = Console.ReadLine().ToLower();
                            }
                            cont = str == "keep" ? false : true;
                            Console.WriteLine();
                        }
                        break;
                    }
                }
            }
        }
    }
}
