using System;

namespace Quest
{
    public class Prize
    {
        private string _text;


        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = adventurer.Awesomeness; i > 0; i--)
                {
                    Console.WriteLine(_text);
                }
            }
            else if (adventurer.Awesomeness <= 0)
            {
                Console.WriteLine("You are a disgrace to all other adventurers in the world!");
            }
        }
    }
}