using System;

class Program
{
    static void Main(string[] args)
    {
       {
        Random randomNum = new Random();
        int Answer = randomNum.Next(1, 101);

        int guess = -1;

        
        while (guess != Answer)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (Answer > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (Answer < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }                    
    }
    }
}