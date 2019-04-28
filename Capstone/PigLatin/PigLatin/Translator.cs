using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatin
{
    class Translator
    {
        private const string vowel = "aeiouAEIOU";
        
        /// <summary>
        /// Returns true if character is a alphabet
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>bool</returns>
        private static bool IsAlphabet(char letter)
        {
            if (char.IsLetter(letter))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if the word begins with a vowel
        /// </summary>
        /// <param name="word"></param>
        /// <returns>bool</returns>
        private static bool BeginsWithVowel(string word)
        {
            if (vowel.Contains(word))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns translation for word beginning with a vowel
        /// </summary>
        /// <param name="word"></param>
        /// <returns>string</returns>
        private static string TranslationForWordBeginWithVowel(string word)
        {                
            return string.Format($"{word}way");
        }

        /// <summary>
        /// Translate word beginning with a consonant
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Return translated word without ending punctuation</returns>
        private static string TranslationForWordBeginConsonant(string word)
        {
            string leadingConsonants = "";
            int counter = 0;//Used to find the index of substring to copy

            //Find all the consonant starting from the beginning of the word 
            //before the first vowel
            foreach (char c in word)
            {                
                if (!BeginsWithVowel(c.ToString()))
                {
                    leadingConsonants += c.ToString();
                }
                else
                {
                    break;//If c is a vowel
                }
                counter++;
            }

            return string.Format("{0}{1}ay", word.Substring(counter), leadingConsonants);
        }

        /// <summary>
        /// Get the punctuation of the last index of the word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>True if there is a punctuation, and output the punctuation</returns>
        private static bool GetPunctuation(string word, out string suffix)
        {
            int sizeOfWord = word.Count() - 1;
            suffix = string.Empty;
                        
            if (char.IsPunctuation(word[sizeOfWord]))
            {
                suffix = word[sizeOfWord].ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets a word, and remove the punctuation at last index of word if it exists
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Return true if word ends with punctuation, and output the punctuation</returns>
        private static string RemoveEndingPunctuation(string word)
        {
            //If there's no punctuation mark, then return the word
            if (!GetPunctuation(word, out string suffix))
            {
                return word;
            }

            string newWord = "";
            int indexOfChar = word.Count() - 2;//ensure that loop ends before the last index

            //Copy all the characters in the word, index by index except the last one
            for (int i = 0; i <= indexOfChar; i++)
            {                
                newWord += word[i].ToString();
            }
            return newWord;
        }

        /// <summary>
        /// Checks user input is a translatable word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>True, if string is a acceptable word, otherwise false</returns>
        private static bool IsWord(string word)
        {
            //Checks word has symbols and numbers. If is NOT is a word
            bool isWord = !new Regex(@".*[\[\]0-9@~`<>|+^%$#&]+.*").IsMatch(word);

            return isWord;
        }        

        /// <summary>
        /// Translate a word to Pig Latin
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Translated word</returns>
        public static string TranslateWordToPigLatin(string word)
        {              
            if (IsWord(word))
            {
                if (GetPunctuation(word, out string suffix))//if there is a punctuation do this
                {
                    word = RemoveEndingPunctuation(word);//Remove the punctuation at the end
                }

                if (BeginsWithVowel(word[0].ToString()))//Do this if word begins with a vowel
                {
                    return TranslationForWordBeginWithVowel(word) + suffix.ToString();//add punctuation back to word
                }
                return TranslationForWordBeginConsonant(word) + suffix.ToString();//add punctuation back to word
            }
            
            return word;//This is not an acceptable word
        }
    }
}
