﻿public class Quiz
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Question> Questions { get; set; }

    public Quiz(string title, string description, List<Question> questions)
    {
        Title = title;
        Description = description;
        Questions = questions;
    }

}