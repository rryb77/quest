﻿using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge bestGame = new Challenge(
                @"What's the best game in the world?
    1) Super Mario Bros.
    2) Pacman
    3) Galage
    4) This game!
", 4, 50);

            Challenge bestName = new Challenge(
                @"What's the best name in the world?
    1) Dave
    2) Shawn
    3) Ryan
    4) Carl
", 3, 20);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.Write("What's your name adventurer? ");

            Robe theAdventurerRobe = new Robe()
            {
                Colors = new List<string>()
                {
                 "red", "green", "gold", "blue", "black"
                },
                Length = 50,
            };

            Hat theAdventurerHat = new Hat()
            {
                ShininessLevel = 10,
            };

            Adventurer theAdventurer = new Adventurer(Console.ReadLine(), theAdventurerRobe, theAdventurerHat);
            Prize thePrize = new Prize("The best prize in the world!");

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                bestGame,
                bestName
            };


            bool playing = true;

            while (playing)
            {
                var shuffledList = challenges.OrderBy(a => Guid.NewGuid()).ToList();

                Console.WriteLine(theAdventurer.GetDescription());
                Console.WriteLine($"Current Awesomeness: {theAdventurer.Awesomeness}");

                int count = 0;

                // Loop through all the challenges and subject the Adventurer to them            
                foreach (Challenge challenge in shuffledList)
                {
                    if (count < 5)
                    {
                        challenge.RunChallenge(theAdventurer);
                        count++;
                    }
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                thePrize.ShowPrize(theAdventurer);

                Console.WriteLine("");
                Console.Write("Would you like to play again? [Y/N]: ");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    theAdventurer.Awesomeness = 50 + (theAdventurer.QuestSuccess * 10);
                    Console.Clear();
                }
                else
                {
                    playing = false;
                }
            }
        }
    }
}
