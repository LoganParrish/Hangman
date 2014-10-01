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
            int wins = -0;
            Winnings Win = new Winnings(wins);


            Console.WindowHeight = 40;
            int width = Console.WindowWidth;
            width = width + 20;
            Console.WindowWidth = width;


            while (Win.KeepGoing == true)
            {
                Console.WriteLine("Total games won : " + wins);
                Console.WriteLine("Type 'yes' to begin / keep playing.");
                string playerInput = Console.ReadLine();
                if (playerInput == "yes")
                {
                    Hangman();
                    Win.KeepGoing = false;
                }
                else
                {
                    Win.KeepGoing = false;
                    Console.WriteLine("Cya next time!");
                }
                Console.WriteLine("Did you win? Be honest! yes / no");
                string playerAnswer = Console.ReadLine();
                if (playerAnswer == "yes")
                {
                    wins++;
                    Win.KeepGoing = true;
                }
                else
                {
                    Win.KeepGoing = false;
                }
            }
            AddHighScore(wins);
            DisplayHighScore();
            
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
                   //word guesseddddddddd
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
                   break;
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
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("\n\nAdd your name to the highscores: ");
            string playerName = Console.ReadLine();

            spLoganEntities db = new spLoganEntities();

            HighScore newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now.ToString();
            newHighScore.Name = playerName;
            newHighScore.Game = "Hangman";
            newHighScore.Score = playerScore;

            db.HighScores.Add(newHighScore);

            db.SaveChanges();
        }
        static void DisplayHighScore()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================== HIGH SCORES ====================");
            Console.WriteLine("=====================================================\n\n");
            Console.ResetColor();

            spLoganEntities db = new spLoganEntities();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Hangman").OrderBy(x => x.Score).Take(10).ToList();

            foreach (HighScore highScore in highScoreList)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0}. {1} - {2} Games won - {3}", highScoreList.IndexOf(highScore) + 1, highScore.Name, highScore.Score, highScore.DateCreated);
                Console.ResetColor();
            }
        }

            
        
    }
}
