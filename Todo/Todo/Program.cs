using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class Program
    {
        class PRogram
        {
            static List<string> toDoList = new List<string>();

            static void Main(string[] args)
            {
                LoadListFromFile();

                while (true)
                {
                    Console.WriteLine("1. Add item");
                    Console.WriteLine("2. Remove item");
                    Console.WriteLine("3. View list");
                    Console.WriteLine("4. Quit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter item: ");
                            string item = Console.ReadLine();
                            toDoList.Add(item);
                            break;
                        case 2:
                            Console.Write("Enter index of item to remove: ");
                            int index = int.Parse(Console.ReadLine());
                            toDoList.RemoveAt(index);
                            break;
                        case 3:
                            for (int i = 0; i < toDoList.Count; i++)
                            {
                                Console.WriteLine($"{i}. {toDoList[i]}");
                            }
                            break;
                        case 4:
                            SaveListToFile();
                            return;
                    }
                }
            }

            static void LoadListFromFile()
            {
                if (File.Exists("to-do-list.txt"))
                {
                    using (StreamReader reader = new StreamReader("to-do-list.txt"))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            toDoList.Add(line);
                        }
                    }
                }
            }

            static void SaveListToFile()
            {
                using (StreamWriter writer = new StreamWriter("to-do-list.txt"))
                {
                    foreach (string item in toDoList)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
        }
    }
}
