class Task7
{
    public static void Answer()
    {
        Console.WriteLine("Enter a string with comma-separated words:");
        string input = Console.ReadLine()!;

        string[] words = input.Split(',');

        Dictionary<string, int> wordVowelCounts = new Dictionary<string, int>();
        int minVowelCount = int.MaxValue;

        foreach (string word in words)
        {
            int vowelCount = CountVowels(word.ToLower());
            wordVowelCounts.Add(word, vowelCount);

            minVowelCount = Math.Min(minVowelCount, vowelCount);
        }

        List<string> leastVowelWords = new List<string>();
        foreach (var pair in wordVowelCounts)
        {
            if (pair.Value == minVowelCount)
            {
                leastVowelWords.Add(pair.Key);
            }
        }

        Console.WriteLine($"Words with the least number of repeating vowels ({minVowelCount}):");
        foreach (string word in leastVowelWords)
        {
            Console.WriteLine(word);
        }

    }
    static int CountVowels(string word)
    {
        int count = 0;
        foreach (char c in word)
        {
            if (vowels.Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    static readonly HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u' };

}