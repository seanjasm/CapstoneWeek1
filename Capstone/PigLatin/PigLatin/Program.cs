using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool _continue = true;

            UserInput.UserInput.Display(string.Format("\n\n\t\tWelcome to Pig Latin Translator!\n\n"));

            while (_continue)
            {
                string translation = "";
                string _sentence = UserInput.UserInput.GetUserInput(string.Format("\nGive me a sentence! "));

                string[] words = _sentence.Split();

                foreach (string word in words)
                {
                    translation += string.Format(" " + Translator.TranslateWordToPigLatin(word));
                }

                UserInput.UserInput.Display(string.Format($"\nThe translation is: {translation}\n"));
                               
                _continue = UserInput.UserInput.UserConfirmationPrompt(string.Format("\nTranslate another line!<Y/N> "));
            }
        }
    }
}