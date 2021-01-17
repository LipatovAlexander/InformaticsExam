using System;
using System.Collections.Generic;
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

        public bool Task812A(string text)
        {
            char[] word = { 'o', 'n', 'e' };
            int countOfMatch = 0;
            foreach (char c in text)
            {
                if (c == word[countOfMatch])
                    countOfMatch++;
                else
                    countOfMatch = 0;

                if (countOfMatch == 3)
                    return true;
            }

            return false;
        }

        bool IsSign(char c)
        {
            return c == '+' || c == '-' || c == '*';
        }

        public bool Task812B(string text)
        {
            int point = -1;
            int newPoint;
            int[] counts = { 0, 0, 0 };

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    newPoint = 0;
                }
                else if (char.IsDigit(c))
                {
                    newPoint = 1;
                }
                else
                {
                    newPoint = 2;
                }
                if (newPoint != point)
                {
                    counts[newPoint]++;
                    point = newPoint;
                }
            }

            return counts[0] > counts[2];
        }

        public string Task812C(string text)
        {
            bool firstGroup = false;
            bool secondGroup = false;

            int endOfFirstGroup = 0;
            int startOfSecondGroup = 0;

            for (int i = 0; i < text.Length - 1; i++)
            {
                char current = text[i];
                char next = text[i + 1];

                if (!firstGroup && char.IsLetter(current) && !char.IsLetter(next))
                {
                    firstGroup = true;
                    endOfFirstGroup = i;
                }
                else if (firstGroup && !char.IsLetter(current) && char.IsLetter(next))
                {
                    secondGroup = true;
                    startOfSecondGroup = i + 1;
                }
            }

            if (!secondGroup)
                return text;
            
            StringBuilder builder = new StringBuilder(text);
            
            builder.Replace('+', '1', endOfFirstGroup + 1, startOfSecondGroup - endOfFirstGroup - 1);
            builder.Replace('-', '2', endOfFirstGroup + 1, startOfSecondGroup - endOfFirstGroup - 1);
            builder.Replace('*', '3', endOfFirstGroup + 1, startOfSecondGroup - endOfFirstGroup - 1);

            return builder.ToString();
        }

        public int Task812D(string text)
        {
            const char searchLetter = 'f';
            int countOfMatches = 0;
            int countOfLetterGroups = 0;

            for (int i = 0; i < text.Length - 1; i++)
            {
                char current = text[i];
                char next = text[i + 1];
                if (current == searchLetter)
                    countOfMatches++;
                if (char.IsLetter(current) && !char.IsLetter(next))
                    countOfLetterGroups++;
                if (countOfLetterGroups == 3)
                    break;
            }

            if (countOfLetterGroups < 3 && text[text.Length - 1] == searchLetter)
                countOfMatches++;

            return countOfMatches;
        }

        public int Task812E(string text)
        {
            int count = 0;
            char first;
            first = text.Length > 0 ? text[0] : '.';

            for (int i = 0; i < text.Length - 1; i++)
            {
                char current = text[i];
                char next = text[i + 1];
                if (!char.IsLetter(current) && char.IsLetter(next))
                    first = next;
                if (char.IsLetter(current) && !char.IsLetter(next) && current == first)
                    count++;
            }

            char last = text.Length > 0 ? text[text.Length - 1] : ',';
            if (char.IsLetter(last) && last == first)
                count++;

            return count;
        }

        public string[] Task812F(string text)
        {
            List<string> words = new List<string>();
            StringBuilder builder = new StringBuilder();
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsLetter(c))
                {
                    builder.Append(c);
                    if (c == 'a')
                        count++;
                }
                else if (count >= 2)
                {
                    words.Add(builder.ToString());
                    builder.Clear();
                    count = 0;
                }
            }

            if (count >= 2)
                words.Add(builder.ToString());

            return words.ToArray();
        }

        public string Task812G(string text)
        {
            StringBuilder builder = new StringBuilder();
            string result = "";
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    builder.Append(c);
                }
                else
                {
                    if (builder.Length > result.Length)
                    {
                        result = builder.ToString();
                    }
                    builder.Clear();
                }
            }
            if (builder.Length > result.Length)
            {
                result = builder.ToString();
            }

            return result != "" ? result : null;
        }

        bool IsSmallLatinLetter(char c)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            return alphabet.Contains(c);
        }

        public string Task813(string text)
        {
            if (!IsSmallLatinLetter(text[0]))
                return text;

            int startDigits = 1;
            while (startDigits < text.Length && !char.IsDigit(text[startDigits]))
            {
                startDigits++;
            }
            if (startDigits == text.Length || !IsSmallLatinLetter(text[startDigits - 1]))
            {
                return text;
            }

            StringBuilder builder = new StringBuilder(text);
            for (int i = startDigits; i < text.Length && char.IsDigit(text[i]); i++)
            {
                builder[i] = '*';
            }
            return builder.ToString();
        }
    }
}