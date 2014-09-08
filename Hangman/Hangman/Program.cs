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
            Console.WindowHeight = 40;
            int width = Console.WindowWidth;
            width = width + 20;
            Console.WindowWidth = width;
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

            string[] words = new string[34] {"abyss", "akimbo", "avenue", "awkward", "axolotl", "bacon", "boobs", "buxom", "caliph", "crypt", "cycle", "curacao", "dirndl", "euouae", "fjord", "flyby", "fuchsia", 
                "giaour", "glyph", "gnarly", "gnostic", "gypsum", "iatrogenic", "jinx", "jukebox", "kayak", "pikachu", "kitsch", "klutz", "lymph", "mnemonic", "naphtha", "onyx", "aesthetic"};

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
                       Console.Clear();
                       Console.WriteLine("Good job! Keep guessing.\n");
                       lettersGuessed += guess;
                       Console.WriteLine("You have " + guessesLeft + " guesses left.\n");
                       Console.WriteLine("You've guessed these letters. \n " + lettersGuessed + "\n");
                   }
                   else
                   {
                       Console.Clear();
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
                       Console.Clear();
                       Console.WriteLine(@"__   _______ _   _   _    _ _____ _   _ 
\ \ / /  _  | | | | | |  | |_   _| \ | |
 \ V /| | | | | | | | |  | | | | |  \| |
  \ / | | | | | | | | |/\| | | | | . ` |
  | | \ \_/ / |_| | \  /\  /_| |_| |\  |
  \_/  \___/ \___/   \/  \/ \___/\_| \_/
                                        
                                        " + "\n\n");
                       Console.WriteLine("You had " + guessesLeft + " guess(es) left.\n");
                       Console.WriteLine("The word to guess was: " + randomWord);
                       won = true;
                   }
                   else if (guess != randomWord)
                   {
                       Console.Clear();
                       Console.WriteLine("Incorrect, guess again.\n");
                       guessesLeft--;
                       Console.WriteLine("You have " + guessesLeft + " guesses left.\n");
                       Console.WriteLine("You've guessed these letters. \n " + lettersGuessed + "\n");
                   }
                   
               }
               if (guessesLeft == 0)
               {
                   Console.Clear();
                   won = true;
                   Console.WriteLine(@"__   _______ _   _   _____ _   _ _____  _   __  _____  _____  ___  ____   _ _____  _   _ 
\ \ / /  _  | | | | /  ___| | | /  __ \| | / / /  ___||  _  | |  \/  | | | /  __ \| | | |
 \ V /| | | | | | | \ `--.| | | | /  \/| |/ /  \ `--. | | | | | .  . | | | | /  \/| |_| |
  \ / | | | | | | |  `--. \ | | | |    |    \   `--. \| | | | | |\/| | | | | |    |  _  |
  | | \ \_/ / |_| | /\__/ / |_| | \__/\| |\  \ /\__/ /\ \_/ / | |  | | |_| | \__/\| | | |
  \_/  \___/ \___/  \____/ \___/ \____/\_| \_/ \____/  \___/  \_|  |_/\___/ \____/\_| |_/
                                                                                         
                                                                                         " + "\n\n");
                   Console.WriteLine("The word to guess was: " + randomWord);
               }
               if (guessesLeft == 5)
               {
                   Console.WriteLine(@"
           |/|
           |/|
           |/|
           |/|
           |/|
           |/|");
               }
               else if (guessesLeft == 4)
               {
                   Console.WriteLine(@"  
           |/|
           |/|
           |/|
           |/|
           |/|
           |/|
           |/| /¯)
           |/|/\/
           |/|\/");
               }
               else if (guessesLeft == 3)
               {
                   Console.WriteLine(@"    
           |/|
           |/|
           |/|
           |/|
           |/|
           |/|
           |/| /¯)
           |/|/\/
           |/|\/
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
");
               }
               else if (guessesLeft == 2)
               {
                   Console.WriteLine(@"   
           |/|
           |/|
           |/|
           |/|
           |/|
           |/|
           |/| /¯)
           |/|/\/
           |/|\/
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          /¯¯/\
         / ,^./\
        / /   \/\
       / /     \/\");
               }
               else if (guessesLeft == 1)
               {
                   Console.WriteLine(@"   
           |/|
           |/|
           |/|
           |/|
           |/|
           |/|
           |/| /¯)
           |/|/\/
           |/|\/
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          /¯¯/\
         / ,^./\
        / /   \/\
       / /     \/\
      ( (       )/)
      | |       |/|
      | |       |/|
      | |       |/|");
               }
               else if (guessesLeft == 0)
               {
                   Console.WriteLine(@"    
           |/|
           |/|
           |/|
           |/|
           |/|
           |/|
           |/| /¯)
           |/|/\/
           |/|\/
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          (¯¯¯)
          /¯¯/\
         / ,^./\
        / /   \/\
       / /     \/\
      ( (       )/)
      | |       |/|
      | |       |/|
      | |       |/|
      ( (       )/)
       \ \     / /
        \ `---' /
         `-----' ");
               }
               if (masky == randomWord)
               {
                   Console.Clear();
                       Console.WriteLine(@"__   _______ _   _   _    _ _____ _   _ 
\ \ / /  _  | | | | | |  | |_   _| \ | |
 \ V /| | | | | | | | |  | | | | |  \| |
  \ / | | | | | | | | |/\| | | | | . ` |
  | | \ \_/ / |_| | \  /\  /_| |_| |\  |
  \_/  \___/ \___/   \/  \/ \___/\_| \_/
                                        
                                        " + "\n\n");
                       Console.WriteLine("You had " + guessesLeft + " guess(es) left.\n");
                       Console.WriteLine("The word to guess was: " + randomWord);
                       won = true;
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
                    returnString = returnString + letter;
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
