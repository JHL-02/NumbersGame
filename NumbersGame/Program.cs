namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ALL VARIABLES GATHERED HERE
            string userInput;

            int userGuess;
            int randomNumber;
            int guessAmount = 0;
            int totalWins = 0;

            bool won = false;

            //ACTUAL GAME LOOP
            while (true)
            {
                won = false;
                
                Console.Write("Välkommen! ");
                randomNumber = Svårighet(); //CALLING OUR METHOD WHICH ALSO CONTAINS MORE OUTPUTS FOR USERS 

                Console.Write("Kan du gissa vilket? Du får 5 försök: ");

                //THE ACTUAL PLAY LOOP BASED ON HOW MANY TIMES THE HAVE GUESSED
                for (guessAmount = 0; guessAmount < 5; guessAmount++)
                {
                    //ONLY TELLS USERS HOW  MANY GUESSES THEY HAVE LEFT AFTER THE FIRST LOOP
                    //BECAUSE IT STARTED WITH SAYING THAT WE HAVE 5 TRIES SO IT'S UNNECESSARY, IN MY OPINION 
                    if (guessAmount > 0)
                    {
                        int guessesLeft = 5 - guessAmount;
                        Console.Write($"\nDu har {guessesLeft} gissningar kvar: ");
                    }

                    //ERROR HANDLING FOR NON INT ANSWERS
                    while (!int.TryParse(Console.ReadLine(), out userGuess))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Snälla svara i heltal... Försök igen: ");
                        Console.ResetColor();
                    }

                    //CHECKS ANSWERS
                    if (userGuess == randomNumber)
                    {
                        Console.WriteLine("\nWoohoo! Du klarade det!");
                        won = true;
                        totalWins++;
                        break; //BREAKS OUT OF THE FOR LOOP            
                    }
                    else if (userGuess > randomNumber)
                    {
                        Console.Write("\nTyvärr, du gissade för högt!");

                        //IF THE GUESS IS UP TO 5 NUMBERS AWAY FROM THE ANSWER THIS WILL RUN
                        if (userGuess - randomNumber <= 5)
                        {
                            Console.WriteLine(" Men det var väldigt nära!");
                        }
                    }
                    else if (userGuess < randomNumber) //I COULD USE AN ELSE INSTEAD BUT I LIKE THIS FOR EXTRA CLARITY!
                    {
                        Console.Write("\nTyvärr, du gissade för lågt!");
                        
                        //SAME AS ABOVE!
                        if (randomNumber - userGuess <= 5)
                        {
                            Console.WriteLine(" Men det var väldigt nära!");
                        }
                    }
                }

                //IF THE USER WON THE VARIABLE BECOMES TRUE AND THIS RUNS
                if (won)
                {         
                        Console.WriteLine($"\nDu klarade spelet på {guessAmount + 1} försök!");
                }
                
                //IF THE VARIABLE NEVER TURNED TO TRUE (BECAUSE THEY DIDN'T WIN) THEN THIS RUNS 
                else
                {
                    Console.WriteLine("\nTyvärr, du lyckades inte gissa talet på 5 försök!");
                }

                Console.WriteLine("\nVill du spela igen?");
                userInput = Console.ReadLine();

                //ALLOWS PLAYERS TO PLAY AGAIN
                if (userInput.ToUpper() == "JA" || userInput.ToUpper() == "YES")
                {
                    Console.Clear(); //CLEARS THE CONSOLE TO AVOID CLUTTER
                    continue; //LOOPS THE LOOP AGAIN
                }
                else
                {
                    break; //STOPS THE LOOP COMPLETELY
                }

            }

            //END DIALOGUE
            Console.WriteLine("\nTack för att du spelade!");

            if (totalWins == 0)
            {
                Console.WriteLine("Synd att du inte klarade spelet...");
            }
            else
            {
                Console.WriteLine($"Du vann {totalWins} gånger!");
            }

        }

        static int Svårighet()
        {
            int userInput;
            Random random = new Random();
            int randomNumber = 0;

            Console.WriteLine("Hur svårt vill du att spelet ska vara? Välj mellan 1-5!");

            //PREVENTS NON INT ANSWERS, NUMBERS OVER 5 OR NUMBERS UNDER 1
            while ((!int.TryParse(Console.ReadLine(), out userInput) || userInput > 5 || userInput < 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Snälla svara i hela siffror från 1-5");
                Console.ResetColor();
            }

            //TO HANDLE THE USERS INPUT, LETTING THEM CHOOSE THE DIFFICULTY 
            switch (userInput)
            {
                case 1:
                    randomNumber = random.Next(1, 21);
                    Console.WriteLine("\nOkej, jag tänker på ett nummer mellan 1 och 20.");
                    break;
                case 2:
                    randomNumber = random.Next(1, 41);
                    Console.WriteLine("\nOkej, jag tänker på ett nummer mellan 1 och 40");
                    break;
                case 3:
                    randomNumber = random.Next(1, 61);
                    Console.WriteLine("\nOkej, jag tänker på ett nummer mellan 1 och 60");
                    break;
                case 4:
                    randomNumber = random.Next(1, 81);
                    Console.WriteLine("\nOkej, jag tänker på ett nummer mellan 1 och 80");
                    break;
                case 5:
                    randomNumber = random.Next(1, 101);
                    Console.WriteLine("\nOkej, jag tänker på ett nummer mellan 1 och 100");
                    break;
                default:
                    //FOR ANYTHING UNEXPECTED
                    break;
            }            
            return randomNumber;
        }

    }
}