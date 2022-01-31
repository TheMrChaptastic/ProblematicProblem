using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont = true;
            bool setup = true;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            cont = Console.ReadLine().ToLower() == "yes" ? true : false;

            int userAge = 0;
            bool isAge = false;
            string userName = "";

            while (cont)
            {
                if (setup)
                {
                    Console.WriteLine();

                    Console.Write("We are going to need your information first! What is your name? ");
                    userName = Console.ReadLine();

                    Console.WriteLine();

                    
                    while (!isAge)
                    {
                        Console.Write("What is your age? ");
                        isAge = int.TryParse(Console.ReadLine(), out userAge);
                    }


                    Console.WriteLine();

                    Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                    bool seeList = Console.ReadLine().ToLower() == "sure" ? true : false;

                    if (seeList)
                    {
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                        bool addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                        Console.WriteLine();

                        while (addToList)
                        {
                            Console.Write("What would you like to add? ");
                            string userAddition = Console.ReadLine();

                            activities.Add(userAddition);

                            foreach (string activity in activities)
                            {
                                Console.Write($"{activity} ");
                                Thread.Sleep(250);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Would you like to add more? yes/no: ");
                            addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Skipping Show List");
                    }

                    setup = false;
                }

                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(50);
                }

                Console.WriteLine();
                if(activities.Count == 0)
                {
                    Console.WriteLine("Nothing left in list. Please try again.");
                    System.Environment.Exit(0);
                }
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                activities.Remove(randomActivity);
                cont = Console.ReadLine().ToLower() == "keep" ? false : true;
            }
        }
    }
}
