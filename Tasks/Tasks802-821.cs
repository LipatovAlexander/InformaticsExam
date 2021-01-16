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

        public string Task805(string text)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int firstLetterIndex = text.IndexOfAny(alphabet);
            if (firstLetterIndex == -1)
                return text;
            int lengthOfFirstLetterGroup = 0;
            for (int i = firstLetterIndex; i < text.Length; i++)
            {
                if (Array.IndexOf(alphabet, text[i]) > -1)
                    lengthOfFirstLetterGroup++;
                else
                    break;
            }
            StringBuilder newText = new StringBuilder();
            newText.Append(text.Substring(0, firstLetterIndex + lengthOfFirstLetterGroup));
            newText.Append(new String('.', text.Length - newText.Length));

            return newText.ToString();
        }

        public string Task809(int n)
        {
            StringBuilder builder = new StringBuilder();
            string str = n.ToString();
            int startCount = str.Length % 3;
            builder.Append(str.Substring(0, startCount));
            int i = startCount;
            while (i < str.Length)
            {
                if (i != 0) // когда все цифры делятся на группы по 3 пробел вначале не нужен
                    builder.Append(' ');
                builder.Append(str.Substring(i, 3));
                i += 3;
            }

            return builder.ToString();
        }
    }
}
