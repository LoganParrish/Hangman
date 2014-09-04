using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman();
            Console.ReadKey();
        }
        static void Hangman()
        {
            //obligatory comment that will suffice for the entire code.
            Console.WriteLine("Welcome! Please enter your name before we begin.");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome to the game, " + name + "!");
            Console.WriteLine("\n\n You will be playing Hangman today!. If you haven't played, you will be guessing letters of a randomly generated word until you can guess the full word, or all of the letters. \n\n\n\n");

            string[] words = new string[30] {"abyss", "akimbo", "avenue", "awkward", "axolotl", "buxom", "caliph", "crypt", "cycle", "curacao", "dirndl", "euouae", "fjord", "flyby", "fuchsia", 
                "giaour", "glyph", "gnarly", "gnostic", "gypsum", "iatrogenic", "jinx", "jukebox", "kayak", "kitsch", "klutz", "lymph", "mnemonic", "naphtha", "onyx"};

            Random soHung = new Random();

            string randomWord = words[soHung.Next(0, words.Length + 1)];

            bool won = false;

            int guessesLeft = 6;

            string lettersGuessed = string.Empty;

            while (!won)
            {
               
               string masky = MaskWord(randomWord, lettersGuessed);
               Console.WriteLine(masky);
               Console.WriteLine();
               string guess = Console.ReadLine().ToLower();

               if (guess.Length == 1)
               {
                   //letter guess
                   if (randomWord.Contains(guess))
                   {
                       Console.WriteLine("Good job! Keep guessing.\n");
                       lettersGuessed += guess;
                       Console.WriteLine("You have " + guessesLeft + " guesses left.\n");
                       Console.WriteLine("You've guessed these letters. \n " + lettersGuessed + "\n");
                   }
                   else
                   {
                       Console.WriteLine("Terrible. You're so bad. Keep going.\n\n");
                       guessesLeft--;
                       Console.WriteLine("You have " + guessesLeft + " guesses left.\n");
                       lettersGuessed += guess;
                       Console.WriteLine("You've guessed these letters. \n " + lettersGuessed + "\n");

                   }
               }
               else
               {
                   //word guess
                   if (guess == randomWord)
                   {
                       Console.WriteLine("You win!");
                       Console.WriteLine("You had " + guessesLeft + " guesses left.\n");
                       won = true;
                   }
                   else if (guess != randomWord)
                   {
                       Console.WriteLine("Incorrect, guess again.\n");
                       guessesLeft--;
                       Console.WriteLine("You have " + guessesLeft + " guesses left.\n");
                       Console.WriteLine("You've guessed these letters. \n " + lettersGuessed + "\n");
                   }
                   
               }
               
            }

            

        }
        static string MaskWord(string randomWord, string lettersGuessed)
        {
            string returnString = string.Empty;

            int guessesLeft = 6;

            for (int i = 0; i < randomWord.Length; i++)
            {
                char letter = randomWord[i];

                if (lettersGuessed.Contains(letter.ToString()))
                {
                    returnString = returnString + letter + " ";
                }
                else
                {
                    returnString = returnString + "_ ";
                    guessesLeft--;
                }
            }
            return returnString;
            }

            
        
    }
}
