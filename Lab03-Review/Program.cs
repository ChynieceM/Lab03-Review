using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab03_Review
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Challenge1();
            Challenge2();
            Challenge3();
            Challenge4();
            Challenge5();
            Challenge6();
            Challenge7();
            Challenge8();
            Challenge9();
        }

        public static int Challenge1()
        {
            Console.Write("Please enter 3 numbers:");
            string? userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(" ");

            if (inputArray.Length > 3)
            {

                return 0;
            }
            int product = 1;
            for (int i = 0; i < 3; i++)
            {

                if (int.TryParse(inputArray[i], out int value))
                {
                    product *= value;

                }
                else
                {
                    product *= 1;
                }
            }
            Console.WriteLine("The product of these 3 numbers is:" + product);
            return product;


        }

        public static void Challenge2()
        {
            Console.Write("Please enter a number between 2-10:");

            int randomNumber = Convert.ToInt32(Console.ReadLine());
            int[] numberArray = new int[randomNumber];
            decimal sumOfNumbers = 0m;

            for (int i = 0; i < numberArray.Length; i++)
            {
                    Console.Write(i + 1 + " of " + randomNumber + " - " + "Enter a number:");
                    int currentNumber = Convert.ToInt32(Console.ReadLine());
                if (currentNumber < 0) 
                {
                    Console.WriteLine("Please enter a number greater than 0");
                    i--; //makes the loop ask for the same index again
                }
                else
                {
                    numberArray[i] = currentNumber;
                    sumOfNumbers += currentNumber;
                }

                
            }
                decimal averageOfNumbers = sumOfNumbers / randomNumber; //casting is a way of telling the program to treat sumofnumbers as a decimal

            Console.WriteLine( "The average of these " + randomNumber + " numbers is:" + averageOfNumbers);
        }
        public static void Challenge3()
        {
            Console.WriteLine("    *");
            Console.WriteLine("   ***");
            Console.WriteLine("  *****");
            Console.WriteLine(" *******");
            Console.WriteLine("*********");
            Console.WriteLine(" *******");
            Console.WriteLine("  *****");
            Console.WriteLine("   ***");
            Console.WriteLine("    *");

        }

        public static void Challenge4()
        {
            Console.Write("Input:");
            string? userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(" ");
            int[] numberArray = Array.ConvertAll(inputArray, int.Parse);

            int maxCount = 0;
            int maxNumber = 0;
            
            for (int i = 0;i < numberArray.Length;i++)
            {
                int count = 0;
                for (int j = 0; j < numberArray.Length - 1;j++)
                {
                    if (numberArray[j] == numberArray[i])
                    {
                        count++;
                    }
                }
                    
                if (count > maxCount)
                {
                    maxCount = count;
                   maxNumber= numberArray[i];
                }
            }
            Console.Write("Output: " + maxNumber);
        }

        public static int Challenge5()
        {
            Console.Write("Input an array of numbers:");
            string? userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(" ");

            int maxNum = int.MinValue; // Starting with the lowest possible integer value

            foreach (string strNum in inputArray)
            {
                if (int.TryParse(strNum, out int value)) // Convert each string to an integer
                {
                    if (value > maxNum) // If the current number is larger than maxNum
                    {
                        maxNum = value; // Update maxNum to the current number
                    }
                }
            }

            Console.WriteLine("The maximum number in the array is: " + maxNum);
            return maxNum;
        }

        public static void Challenge6()
        {
            Console.Write("Please input a word: ");
            string word = Console.ReadLine();

            SaveWordToFile(word);

             static void SaveWordToFile(string word)
            {
                string filePath = "words.txt";

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(word);
                }

                Console.WriteLine("Word saved to file successfully!");
            }
        }

        public static void Challenge7()
        {
            string filePath = "words.txt"; 

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void Challenge8()
        {
            RemoveSpecificWord("wordToRemove");

            static void RemoveSpecificWord(string word)
            {
                string filePath = "words.txt"; 

                string text = File.ReadAllText(filePath);

                
                string modifiedText = Regex.Replace(text, @"\b" + word + @"\b", "");

                
                File.WriteAllText(filePath, modifiedText);
            }
        }
        public static void Challenge9()
        {
            Console.Write("Please input a sentence: ");
            string sentence = Console.ReadLine();

            string[] wordLengthArray = WordLengths(sentence);

            Console.WriteLine("Output: ");
            foreach (string wordLength in wordLengthArray)
            {
                Console.WriteLine(wordLength);
            }


             static string[] WordLengths(string sentence)
            {
                string[] words = sentence.Split(' ');

                string[] wordLengths = new string[words.Length];

                for (int i = 0; i < words.Length; i++)
                {
                    wordLengths[i] = $"{words[i]}: {words[i].Length}";
                }

                return wordLengths;
            }
        }
    }
}