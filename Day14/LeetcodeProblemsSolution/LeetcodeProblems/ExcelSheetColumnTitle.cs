

using System.Text;

namespace LeetcodeProblems
{
    public class ExcelSheetColumnTitle
    {
        string alphabets = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Solution(int columnNumber) 
        {
            StringBuilder result = new StringBuilder();

            while (columnNumber > 0)
            {
                int remainder = (columnNumber - 1) % 26;
                result.Insert(0, alphabets[remainder]);
                columnNumber = (columnNumber - 1) / 26;
            }

            return result.ToString();

        }
    }
}
