using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema {
    class Program {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;

        static void Main(string[] args) {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            string line = null;
            while ((line = Console.ReadLine()) != "generate") {
                string[] parts = line.Split(" - ");

                people[int.Parse(parts[1]) - 1] = parts[0];
                locked[int.Parse(parts[1]) - 1] = true;

                nonStaticPeople.Remove(parts[0]);
            }

            Permute(0);
        }

        private static void Permute(int index) {
            if (index >= nonStaticPeople.Count) {
                PrintPermutation();               
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < nonStaticPeople.Count; i++) {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintPermutation() {
            var peopleIndex = 0;
            for (int i = 0; i < people.Length; i++) {
                if (i == people.Length - 1) {
                    if (locked[i]) {
                        Console.Write($"{people[i]}");
                    }
                    else {
                        Console.Write($"{nonStaticPeople[peopleIndex++]}");
                    }
                }
                else {
                    if (locked[i]) {
                        Console.Write($"{people[i]} ");
                    }
                    else {
                        Console.Write($"{nonStaticPeople[peopleIndex++]} ");
                    }
                }
            }

            Console.WriteLine();
        }

        private static void Swap(int first, int second) {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}
