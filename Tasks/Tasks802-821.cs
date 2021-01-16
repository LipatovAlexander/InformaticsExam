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
    }
}
