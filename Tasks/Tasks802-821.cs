using System;
using System.Text; 

namespace Tasks
{
    public class Tasks802_821
    {
        public int Task802(string text)
        {
            int maxCount = 0;
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                    count++;
                else
                {
                    if (count > maxCount)
                        maxCount = count;
                    count = 0;
                }
            }

            if (count > maxCount)
                maxCount = count;

            return maxCount;
        }

        public bool Task803(string text)
        {
            foreach (char c in text)
            {
                if (!(char.IsLetter(c) || c.Equals(' ')))
                    return true;
            }
            return false;
        }

        public string Task804A(string text)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            int indexOfStar = text.IndexOf('*');
            if (indexOfStar == -1)
                return text;

            StringBuilder newText = new StringBuilder();
            for (int i = 0; i < indexOfStar; i++)
            {
                if (alphabet.IndexOf(text[i]) > -1)
                    newText.Append('3');
                else
                    newText.Append(text[i]);
            }
            newText.Append(text.Substring(indexOfStar));

            return newText.ToString();
        }
    }
}
