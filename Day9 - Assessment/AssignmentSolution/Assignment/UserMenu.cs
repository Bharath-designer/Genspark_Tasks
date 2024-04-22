class UserMenu: IUserMenu
{

    List<Quiz> quizzes;

    public UserMenu(List<Quiz> quizzes)
    {
        this.quizzes = quizzes;
    }
    public void TakeQuiz()
    {
        foreach (Quiz quiz in quizzes)
        {
            Console.WriteLine($"{quizzes.IndexOf(quiz) + 1}. {quiz.Title}");
        }
        Console.WriteLine();
        Console.Write("Choose a quiz to take (enter its number): ");
        Console.WriteLine();
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < quizzes.Count)
        {
            Quiz quiz = quizzes[index];
            int score = 0;
            List<bool> results = new List<bool>();

            foreach (Question question in quiz.Questions)
            {
                Console.WriteLine(question.Text);
                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
                }
                Console.Write("Enter your answer: ");
                int answerIndex = int.Parse(Console.ReadLine()) - 1;
                if (answerIndex >= 0 && answerIndex < question.Answers.Count && question.Answers[answerIndex].IsCorrect)
                {
                    score++;
                    results.Add(true);
                }
                else
                {
                    results.Add(false);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Your score: {score}/{quiz.Questions.Count}");

            Console.WriteLine("Question-wise results:");
            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quiz.Questions[i].Text} - {(results[i] ? "Correct" : "Incorrect")}");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid quiz number.");
        }
    }


}