class AdminMenu : IAdminMenu
{

    List<Quiz> quizzes;

    public AdminMenu(List<Quiz> quizzes)
    {
        this.quizzes = quizzes;
    }
    public void CreateQuiz()
    {
        Console.Write("Enter quiz title: ");
        string title = Console.ReadLine();
        Console.Write("Enter quiz description: ");
        string description = Console.ReadLine();
        List<Question> questions = new List<Question>();
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Enter question text (or type 'done' to finish adding questions): ");
            string questionText = Console.ReadLine();
            if (questionText.ToLower() == "done")
            {
                break;
            }
            List<Answer> answers = new List<Answer>();
            while (true)
            {
                Console.WriteLine("Enter answer text (or type 'done' to finish adding answers): ");
                string answerText = Console.ReadLine();
                if (answerText.ToLower() == "done")
                {
                    break;
                }
                answers.Add(new Answer(answerText, false));
            }

            Console.WriteLine("Available answers:");
            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answers[i].Text}");
            }
            int correctAnswerIndex;
            while (true)
            {
                Console.Write("Enter the index of the correct answer: ");
                if (!int.TryParse(Console.ReadLine(), out correctAnswerIndex) || correctAnswerIndex < 1 || correctAnswerIndex > answers.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid index.");
                }
                else
                {
                    break;
                }
            }
            answers[correctAnswerIndex - 1].IsCorrect = true;

            questions.Add(new Question(questionText, answers));
        }
        Quiz quiz = new Quiz(title, description, questions);
        quizzes.Add(quiz);
        Console.WriteLine("Quiz created successfully.");
    }


    public void ManageQuizzes()
    {
        foreach (Quiz quiz in quizzes)
        {
            Console.WriteLine($"{quizzes.IndexOf(quiz) + 1}. {quiz.Title}");
        }
        Console.WriteLine();
        Console.Write("Choose a quiz to manage (enter its number): ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < quizzes.Count)
        {
            Quiz quiz = quizzes[index];
            Console.WriteLine($"Title: {quiz.Title}");
            Console.WriteLine($"Description: {quiz.Description}");
            Console.WriteLine("Questions:");
            foreach (Question question in quiz.Questions)
            {
                Console.WriteLine($"{quiz.Questions.IndexOf(question) + 1}. {question.Text}");
                foreach (Answer answer in question.Answers)
                {
                    Console.WriteLine($"    {answer.Text}{(answer.IsCorrect ? " - [Correct]" : "")}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("1. Modify question text");
            Console.WriteLine("2. Modify answer text");
            Console.WriteLine("3. Modify correct answer");
            Console.WriteLine("4. Back");
            Console.Write("Choose an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ModifyQuestion(quiz);
                    break;
                case 2:
                    ModifyAnswerText(quiz);
                    break;
                case 3:
                    ModifyCorrectAnswer(quiz);
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid quiz number. Please enter a valid quiz number");
        }
    }

    static void ModifyQuestion(Quiz quiz)
    {
        Console.WriteLine("Select a question to modify:");
        for (int i = 0; i < quiz.Questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quiz.Questions[i].Text}");
        }
        Console.Write("Enter the index of the question you want to modify: ");
        int questionIndex = int.Parse(Console.ReadLine()) - 1;
        if (questionIndex >= 0 && questionIndex < quiz.Questions.Count)
        {
            Console.Write("Enter the new question text: ");
            string newQuestionText = Console.ReadLine();
            quiz.Questions[questionIndex].Text = newQuestionText;
            Console.WriteLine("Question modified successfully.");
        }
        else
        {
            Console.WriteLine("Invalid question index. Please enter a valid index.");
        }
    }

    static void ModifyAnswerText(Quiz quiz)
    {
        Console.WriteLine("Select a question to modify the answer text:");
        for (int i = 0; i < quiz.Questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quiz.Questions[i].Text}");
        }
        Console.Write("Enter the index of the question: ");
        int questionIndex = int.Parse(Console.ReadLine()) - 1;
        if (questionIndex >= 0 && questionIndex < quiz.Questions.Count)
        {
            Question question = quiz.Questions[questionIndex];
            Console.WriteLine("Select an answer to modify:");
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
            }
            Console.Write("Enter the index of the answer you want to modify: ");
            int answerIndex = int.Parse(Console.ReadLine()) - 1;
            if (answerIndex >= 0 && answerIndex < question.Answers.Count)
            {
                Console.Write("Enter the new answer text: ");
                string newAnswerText = Console.ReadLine();
                question.Answers[answerIndex].Text = newAnswerText;
                Console.WriteLine("Answer text modified successfully.");
            }
            else
            {
                Console.WriteLine("Invalid answer index. Please enter a valid index.");
            }
        }
        else
        {
            Console.WriteLine("Invalid question index. Please enter a valid index.");
        }
    }

    static void ModifyCorrectAnswer(Quiz quiz)
    {
        Console.WriteLine("Select a question to modify the correct answer:");
        for (int i = 0; i < quiz.Questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quiz.Questions[i].Text}");
        }
        Console.Write("Enter the index of the question: ");
        int questionIndex = int.Parse(Console.ReadLine()) - 1;
        if (questionIndex >= 0 && questionIndex < quiz.Questions.Count)
        {
            Question question = quiz.Questions[questionIndex];
            Console.WriteLine("Select the correct answer:");
            for (int i = 0; i < question.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
            }
            Console.Write("Enter the index of the correct answer: ");
            int correctAnswerIndex = int.Parse(Console.ReadLine()) - 1;
            if (correctAnswerIndex >= 0 && correctAnswerIndex < question.Answers.Count)
            {
                foreach (var answer in question.Answers)
                {
                    answer.IsCorrect = false;
                }
                question.Answers[correctAnswerIndex].IsCorrect = true;
                Console.WriteLine("Correct answer modified successfully.");
            }
            else
            {
                Console.WriteLine("Invalid correct answer index. Please enter a valid index.");
            }
        }
        else
        {
            Console.WriteLine("Invalid question index. Please enter a valid index.");
        }
    }


    public void DeleteQuiz()
    {
        Console.WriteLine("Available quizzes:");
        for (int i = 0; i < quizzes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizzes[i].Title}");
        }

        Console.Write("Enter the index of the quiz you want to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > quizzes.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid index.");
            return;
        }

        Quiz deletedQuiz = quizzes[index - 1];
        quizzes.RemoveAt(index - 1);

        Console.WriteLine($"Quiz '{deletedQuiz.Title}' deleted successfully.");

    }

}