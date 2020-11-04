using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeOefening1Demo
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //DECLARATIONS
            string[] names = { "Franck", "Stylz", "Bulu", "Embo", "Francis", "Jam" };
            DateTime[] birthdates = new DateTime[6];
            TimeSpan[] ageDifference;
            int idx;
            bool stop;
            //INITIALIZATIONS
            //names = new string[10] { "Franck", "Stylz", "Bulu", "Embo", "Jam", "Francis", "Noah", "Nelya", "Naël", "Nelson" };
            //birthdates = new DateTime[10];
            //INPUT
            for (int i = 0; i < birthdates.Length; i++)
            {
                birthdates[i] = GeneratesBirthday();
            }
            ////PROCESSING
            do
            {
                Console.Clear();
                ShowPeople(names);
                Console.WriteLine("Who do you want to compare with de rest of the list? (-1 to quit)");
                idx = int.Parse(Console.ReadLine());
                if (idx != -1)
                {
                    ageDifference = CompareBirthdates(birthdates, idx);
                    ShowAgeDifference(ageDifference, names, idx);
                    Console.ReadLine();
                    stop = true;
                }
                else
                {
                    Console.WriteLine("Applicatie gaat nu sluiten");
                    stop = false;
                }
                
            } while (stop);
            ////OUTPUT
            Console.ReadLine();

        }

        static void ShowAgeDifference(TimeSpan[] ageDifference, string[] names, int idx)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (idx == i)
                {
                    continue;
                }
                else if (ageDifference[i].Days < 0)
                {
                    Console.WriteLine($" {names[idx]} is { Math.Abs(ageDifference[i].Days)} dagen jonger dan {names[i]}");
                }
                else
                {
                    Console.WriteLine($" {names[idx]} is {ageDifference[i].Days} dagen ouder dan {names[i]}");

                }

            }
        }

        static TimeSpan[] CompareBirthdates(DateTime[] birthdates, int idx)
        {
            TimeSpan[] difference = new TimeSpan[birthdates.Length];
            for (int i = 0; i < birthdates.Length; i++)
            {
                difference[i] = birthdates[idx] - birthdates[i];
            }
            return difference;
        }

        static DateTime GeneratesBirthday()
        {
            int year, month, day;
            year = rnd.Next(1980, 2020);
            month = rnd.Next(1, 13);
            day = rnd.Next(1, 32);

            return new DateTime(year, month, day);
        }
        static void ShowPeople(string[] names)
        {
            Console.WriteLine("Kies een persoon: ");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i} \t {names[i]}");
            }
        }
    }
}
