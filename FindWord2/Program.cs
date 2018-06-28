using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWord2
{
    class Program
    {
        public static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("There is no word in given text!");
                return count;
            }

            var Punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            var wordArray = text.Split().Select(x => x.Trim(Punctuation));
            foreach (string word in wordArray)
            {
                if (word.Trim() != "")
                {
                    if (!count.ContainsKey(word))
                    {
                        count.Add(word, 1);
                    }
                    else
                    {
                        count[word]++;
                    }
                }
            }
            return count;
        }


        static void Main(string[] args)

        {
            string text = "But there's a side to you \n" +
                "That I never knew, never knew \n" +
                "All the things you'd say \n" +
                "They were never true, never true \n" +
                "And the games you play \n" +
                "You would always win, always win \n";
            Console.WriteLine(text);

            var counter = CountWords(text);

            var sortByWord = counter.OrderBy(x => x.Key);
            var sortbyFreqency = sortByWord.OrderBy(x => x.Value);

            foreach ( KeyValuePair<string, int> key in sortbyFreqency)
            {
                Console.WriteLine($"{key.Key}  {key.Value}  ");

            }



        }
    }
}
