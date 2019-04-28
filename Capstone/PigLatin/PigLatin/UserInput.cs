using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    class UserInput
    {
        /// <summary>
        /// Gets and return console input
        /// </summary>
        /// <param name="message"></param>
        /// <returns>string</returns>
        public static string GetUserInput(string message)
        {
            Display(message);
            string input = Console.ReadLine();

            //Requires an input from user
            if(input == string.Empty)
            {
                return GetUserInput(message);
            }
            return input;
        }
       
        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="message"></param>
        public static void Display(string message)
        {
            Console.Write("\n\n" + message);
        }

        /// <summary>
        /// Return true if user input equals trueOption. trueOption set to "Y" by default.  
        /// </summary>
        /// <param name="message"></param>  
        public static bool UserConfirmationPrompt(string message, string trueOption="Y") 
        {
            //true if user input starts with trueOption="Y", with case insensitivity
            if(GetUserInput(message).StartsWith(trueOption, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}
