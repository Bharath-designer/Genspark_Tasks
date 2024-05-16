namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secret = "1807";
            string guess = "7810";
            string result = Program.Solution(secret, guess);
            Console.WriteLine("Result is: " + result);
        }

        static string Solution(string secret, string guess)
        {
            int[] s = new int[10];
            int[] g = new int[10];

            int bulls = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bulls++;
                }
                else
                {
                    s[secret[i] - '0']++;
                    g[guess[i] - '0']++;
                }
            }

            int cows = 0;
            for (int i = 0; i < s.Length; i++)
            {
                cows += Math.Min(s[i], g[i]);
            }

            return $"{bulls}A{cows}B";

        }
    }
}
