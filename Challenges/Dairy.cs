using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class dairy
    {
        static void Main()
        {
                var diary = new Dictionary<string, Dictionary<string, List<int>>>
                {
                    ["Azam"] = new Dictionary<string, List<int>>
                    {
                        ["Math"] = new List<int> { 5, 4, 5, 5 },
                        ["English"] = new List<int> { 5, 4, 4, 5 }
                    },
                    ["Ali"] = new Dictionary<string, List<int>>
                    {
                        ["Math"] = new List<int> { 4, 3, 4, 4 },
                        ["English"] = new List<int> { 5, 4, 3, 4 }
                    },
                    ["Husen"] = new Dictionary<string, List<int>>
                    {
                        ["Math"] = new List<int> { 3, 4, 4, 3 },
                        ["English"] = new List<int> { 3, 4, 3, 4 }
                    }
                };

                bool loop = true;


                string? FindKeyIgnoreCase(IEnumerable<string> keys, string input)
                {
                    return keys.FirstOrDefault(k => string.Equals(k, input, StringComparison.OrdinalIgnoreCase));
                }


                bool AskContinue()
                {
                    Console.Write("Do you want to continue? (yes/no): ");
                    string? cont = Console.ReadLine()?.Trim().ToLower();
                    return cont == "yes";
                }

                while (loop)
                {
                    Console.Write("Enter name of student: ");
                    string? nameInput = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(nameInput))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        continue;
                    }

                    string? studentKey = FindKeyIgnoreCase(diary.Keys, nameInput);
                    if (studentKey == null)
                    {
                        Console.WriteLine("Student not found.");
                        if (!AskContinue()) break;
                        continue;
                    }

                    Console.Write("Enter the subject: ");
                    string? subjectInput = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(subjectInput))
                    {
                        Console.WriteLine("Subject cannot be empty.");
                        continue;
                    }

                    var subjects = diary[studentKey];
                    string? subjectKey = FindKeyIgnoreCase(subjects.Keys, subjectInput);
                    if (subjectKey == null)
                    {
                        Console.WriteLine("Subject not found for this student.");
                        if (!AskContinue()) break;
                        continue;
                    }

                    var marks = subjects[subjectKey];
                    Console.WriteLine($"Marks: {string.Join(", ", marks)}");

                    double average = marks.Average();
                    Console.WriteLine($"Average mark: {average:F2}");

                    Console.Write("Do you want to enter a new mark? (yes/no): ");
                    string? answer = Console.ReadLine()?.Trim().ToLower();
                    if (answer == "yes")
                    {
                        Console.Write("Enter new mark (1-5): ");
                        string? markInput = Console.ReadLine()?.Trim();
                        if (int.TryParse(markInput, out int newMark) && newMark >= 1 && newMark <= 5)
                        {
                            marks.Add(newMark);
                            Console.WriteLine("Mark added!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid mark. Must be a number from 1 to 5.");
                        }
                    }

                    if (!AskContinue())
                        loop = false;
                }

                Console.WriteLine("Thank you! Goodbye.");
            }
        }
    }








