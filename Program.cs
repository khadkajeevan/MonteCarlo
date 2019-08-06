using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            do
            {
                double averageGrade = 0;

                switch (AcceptValidInt("Choose a functionality:\n\t1 Input a specific number of grades\n\t2 Input any number of grades\n\t0 Quit\n\tChoice: ", 0, 2))
                {
                    case 1:
                        averageGrade = AverageNGrades();
                        break;
                    case 2:
                        averageGrade = PromptForGradesAndAverage();
                        break;
                    default:
                        quit = true;
                        break;
                }

                if (!quit)
                {
                    Console.WriteLine($"The average grade is: {averageGrade:F1}");

                    Console.WriteLine($"The letter grade is: {LetterGrade(averageGrade)}");
                }
            } while (!quit);
        }

        private static double AverageNGrades()
        {
            var numberOfScores = PromptForNumberOfScores();

            return PromptForGradesAndAverage(numberOfScores);
        }

        private static char LetterGrade(double averageGrade)
        {
            char letterGrade;

            if ((averageGrade >= 90) && (averageGrade <= 100))
            {
                letterGrade = 'A';
            }
            else if ((averageGrade >= 80) && (averageGrade < 90))
            {
                letterGrade = 'B';
            }
            else if ((averageGrade >= 70) && (averageGrade < 80))
            {
                letterGrade = 'C';
            }
            else if ((averageGrade >= 60) && (averageGrade < 70))
            {
                letterGrade = 'D';
            }
            else
            {
                letterGrade = 'F';
            }

            return letterGrade;
        }

        private static double PromptForGradesAndAverage(int numberOfGrades)
        {
            double sumOfGrades = 0;

            for (int i = 0; i < numberOfGrades; ++i)
            {
                sumOfGrades += AcceptValidInt($"Input the #{i + 1} grade: ", 0, 100);
            }

            return sumOfGrades / numberOfGrades;
        }

        private static double PromptForGradesAndAverage()
        {
            double sumOfGrades = 0;
            bool quit = false;
            int count = 0;

            do
            {
                int input = AcceptValidInt($"Input the #{count + 1} grade (-1 to quit): ",
                                           -1, 100);

                if (input < 0)
                {
                    quit = true;
                }
                else
                {
                    sumOfGrades += input;
                    count++;
                }
            } while (!quit);

            return sumOfGrades / count;
        }

        private static int PromptForNumberOfScores()
        {
            return AcceptValidInt("Enter the number of scores: ", 1);
        }

        private static int AcceptValidInt(string prompt,
                                          int minValue = int.MinValue,
                                          int maxValue = int.MaxValue)
        {
            var value = 0;
            var validInput = false;

            do
            {
                Console.Write(prompt);

                var input = Console.ReadLine();

                try
                {
                    value = int.Parse(input);

                    if ((value >= minValue) && (value <= maxValue))
                    {
                        validInput = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.\n");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"{input} is not a valid value.");
                    Console.WriteLine($"Valid range is ({minValue}, {maxValue})\n");
                }
            } while (!validInput);

            return value;
        }
    }
}






